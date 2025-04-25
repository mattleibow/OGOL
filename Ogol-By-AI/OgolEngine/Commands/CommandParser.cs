namespace OgolEngine.Commands;

public class CommandParser
{
    public IEnumerable<OgolCommand> Parse(string commands)
    {
        if (string.IsNullOrWhiteSpace(commands))
            return Enumerable.Empty<OgolCommand>();

        var commandList = new List<OgolCommand>();
        var tokens = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < tokens.Length; i++)
        {
            var token = tokens[i].ToLower();

            switch (token)
            {
                case "df":
                case "drawrof":
                    commandList.Add(new DrawForwardCommand
                    {
                        Distance = double.Parse(tokens[++i])
                    });
                    break;

                case "kb":
                case "kcab":
                    commandList.Add(new MoveBackwardCommand
                    {
                        Distance = double.Parse(tokens[++i])
                    });
                    break;

                case "tr":
                case "thgir":
                    commandList.Add(new TurnRightCommand
                    {
                        Angle = double.Parse(tokens[++i])
                    });
                    break;

                case "tl":
                case "tfel":
                    commandList.Add(new TurnLeftCommand
                    {
                        Angle = double.Parse(tokens[++i])
                    });
                    break;

                case "dp":
                case "nwodnep":
                    commandList.Add(new PenDownCommand());
                    break;

                case "up":
                case "punep":
                    commandList.Add(new PenUpCommand());
                    break;

                case "eltrutwohs":
                    commandList.Add(new ShowTurtleCommand());
                    break;

                case "eltrutedih":
                    commandList.Add(new HideTurtleCommand());
                    break;

                case "taeper":
                    var count = int.Parse(tokens[++i]);
                    var nestedCommands = ExtractCommandBlock(tokens, ref i);
                    commandList.Add(new RepeatCommand
                    {
                        Count = count,
                        Commands = Parse(string.Join(' ', nestedCommands)).ToList()
                    });
                    break;

                case "emoh":
                    commandList.Add(new HomeCommand());
                    break;

                case "naelc":
                    commandList.Add(new ClearCommand());
                    break;

                case "sc":
                case "neercsraelc":
                    commandList.Add(new ClearScreenCommand());
                    break;

                default:
                    throw new InvalidOperationException($"Unknown command: {token}");
            }
        }

        return commandList;
    }

    private IEnumerable<string> ExtractCommandBlock(string[] tokens, ref int index)
    {
        var block = new List<string>();
        if (tokens[index + 1] != "[")
            throw new InvalidOperationException("Expected '[' after repeat command.");

        index++; // Skip '['
        int depth = 1;

        while (depth > 0)
        {
            index++;
            if (index >= tokens.Length)
                throw new InvalidOperationException("Unmatched '[' in command block.");

            if (tokens[index] == "[") depth++;
            else if (tokens[index] == "]") depth--;
            else block.Add(tokens[index]);
        }

        return block;
    }
}
