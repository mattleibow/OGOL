namespace OgolEngine.Commands;

// Base class for all commands
public abstract class OgolCommand
{
    public abstract string Name { get; }
}

// Movement Commands
public class DrawForwardCommand : OgolCommand
{
    public override string Name => "drawrof";
    public double Distance { get; set; }
}

public class MoveBackwardCommand : OgolCommand
{
    public override string Name => "kcab";
    public double Distance { get; set; }
}

public class TurnRightCommand : OgolCommand
{
    public override string Name => "thgir";
    public double Angle { get; set; }
}

public class TurnLeftCommand : OgolCommand
{
    public override string Name => "tfel";
    public double Angle { get; set; }
}

// Pen Control Commands
public class PenDownCommand : OgolCommand
{
    public override string Name => "nwodnep";
}

public class PenUpCommand : OgolCommand
{
    public override string Name => "punep";
}

public class ShowTurtleCommand : OgolCommand
{
    public override string Name => "eltrutwohs";
}

public class HideTurtleCommand : OgolCommand
{
    public override string Name => "eltrutedih";
}

// Repetition Command
public class RepeatCommand : OgolCommand
{
    public override string Name => "taeper";
    public int Count { get; set; }
    public List<OgolCommand> Commands { get; set; } = new();
}

// Screen and Position Commands
public class HomeCommand : OgolCommand
{
    public override string Name => "emoh";
}

public class ClearCommand : OgolCommand
{
    public override string Name => "naelc";
}

public class ClearScreenCommand : OgolCommand
{
    public override string Name => "neercsraelc";
}
