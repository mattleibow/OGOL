using SkiaSharp.Views.Maui;
using SkiaSharp;
using OgolEngine;
using OgolEngine.Commands;

namespace OgolApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DrawingSurface _drawingSurface; // Encapsulated drawing logic
        private readonly CommandParser _commandParser; // Command parser

        public MainPage()
        {
            InitializeComponent();

            _drawingSurface = new DrawingSurface(); // Initialize the DrawingSurface instance
            _commandParser = new CommandParser(); // Initialize the CommandParser instance
        }

        private void OnDrawSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var width = e.Info.Width;
            var height = e.Info.Height;

            // Delegate drawing to the DrawingSurface class
            _drawingSurface.Draw(canvas, width, height);
        }

        private void OnEditorCompleted(object sender, EventArgs e)
        {
            // Directly access the editor field
            ProcessCommands(editor.Text);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Directly access the editor field
            ProcessCommands(editor.Text);
        }

        private void ProcessCommands(string commands)
        {
            var parsedCommands = _commandParser.Parse(commands);
            _drawingSurface.Commands = parsedCommands;
            canvasView.InvalidateSurface(); // Redraw the canvas
        }
    }
}
