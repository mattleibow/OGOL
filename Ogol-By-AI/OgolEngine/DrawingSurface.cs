using SkiaSharp;
using OgolEngine.Commands;

namespace OgolEngine;

public class DrawingSurface
{
    private readonly SKPath _trianglePath; // Directly initialized triangle path
    private readonly SKPaint _paint; // Cached paint
    private bool _isPenDown = true; // Tracks pen state
    private bool _isTurtleVisible = true; // Tracks turtle visibility

    public DrawingSurface()
    {
        // Initialize the triangle path
        _trianglePath = new SKPath();
        _trianglePath.MoveTo(0, -50); // Top point (relative to center)
        _trianglePath.LineTo(-50, 50); // Bottom-left point (relative to center)
        _trianglePath.LineTo(50, 50); // Bottom-right point (relative to center)
        _trianglePath.Close();

        // Initialize the paint
        _paint = new SKPaint
        {
            Color = SKColors.Black,
            Style = SKPaintStyle.Fill
        };
    }

    public IEnumerable<OgolCommand>? Commands { get; set; }

    public void Draw(SKCanvas canvas, int width, int height)
    {
        // Clear the canvas
        canvas.Clear(SKColors.White);

        // Translate canvas to center
        canvas.Translate(width / 2, height / 2);

        // Execute commands on the canvas
        ExecuteCommands(canvas, Commands);

        // Draw the triangle
        canvas.DrawPath(_trianglePath, _paint);
    }

    private void ExecuteCommands(SKCanvas canvas, IEnumerable<OgolCommand> commands)
    {
        if (commands is null)
            return;

        foreach (var command in commands)
        {
            switch (command)
            {
                case DrawForwardCommand drawForward:
                    var forwardDistance = -(float)drawForward.Distance;
                    if (_isPenDown)
                    {
                        canvas.DrawLine(0, 0, 0, forwardDistance, _paint);
                    }
                    canvas.Translate(0, forwardDistance);
                    break;

                case MoveBackwardCommand moveBackward:
                    var backwardDistance = (float)moveBackward.Distance;
                    if (_isPenDown)
                    {
                        canvas.DrawLine(0, 0, 0, backwardDistance, _paint);
                    }
                    canvas.Translate(0, backwardDistance);
                    break;

                case TurnRightCommand turnRight:
                    canvas.RotateDegrees((float)turnRight.Angle);
                    break;

                case TurnLeftCommand turnLeft:
                    canvas.RotateDegrees(-(float)turnLeft.Angle);
                    break;

                case PenDownCommand:
                    _isPenDown = true;
                    break;

                case PenUpCommand:
                    _isPenDown = false;
                    break;

                case ShowTurtleCommand:
                    _isTurtleVisible = true;
                    break;

                case HideTurtleCommand:
                    _isTurtleVisible = false;
                    break;

                case RepeatCommand repeat:
                    for (int i = 0; i < repeat.Count; i++)
                    {
                        ExecuteCommands(canvas, repeat.Commands);
                    }
                    break;

                case HomeCommand:
                    canvas.ResetMatrix(); // Resets canvas to the home position
                    break;

                case ClearCommand:
                    canvas.Clear(SKColors.White);
                    break;

                case ClearScreenCommand:
                    canvas.Clear(SKColors.White);
                    canvas.ResetMatrix(); // Resets canvas to the home position
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported command: {command.Name}");
            }
        }
    }
}
