using OgolEngine;
using OgolEngine.Commands;
using Xunit;

namespace OgolApp.Tests;

public class CommandParserTests
{
    private readonly CommandParser _parser = new();

    [Fact]
    public void Parse_ShouldReturnEmpty_WhenInputIsEmpty()
    {
        var result = _parser.Parse(string.Empty);
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_ShouldParseSingleCommand()
    {
        var result = _parser.Parse("df 100").ToList();

        Assert.Single(result);
        var command = Assert.IsType<DrawForwardCommand>(result[0]);
        Assert.Equal(100, command.Distance);
    }

    [Fact]
    public void Parse_ShouldParseMultipleCommands()
    {
        var result = _parser.Parse("df 100 tr 90").ToList();

        Assert.Equal(2, result.Count);
        var drawCommand = Assert.IsType<DrawForwardCommand>(result[0]);
        Assert.Equal(100, drawCommand.Distance);

        var turnCommand = Assert.IsType<TurnRightCommand>(result[1]);
        Assert.Equal(90, turnCommand.Angle);
    }

    [Fact]
    public void Parse_ShouldHandleAliases()
    {
        var result = _parser.Parse("kb 50").ToList();

        Assert.Single(result);
        var command = Assert.IsType<MoveBackwardCommand>(result[0]);
        Assert.Equal(50, command.Distance);
    }

    [Fact]
    public void Parse_ShouldHandleNestedCommandBlocks()
    {
        var result = _parser.Parse("taeper 2 [ df 50 tr 90 ]").ToList();

        Assert.Single(result);
        var repeatCommand = Assert.IsType<RepeatCommand>(result[0]);
        Assert.Equal(2, repeatCommand.Count);
        Assert.Equal(2, repeatCommand.Commands.Count);

        var drawCommand = Assert.IsType<DrawForwardCommand>(repeatCommand.Commands[0]);
        Assert.Equal(50, drawCommand.Distance);

        var turnCommand = Assert.IsType<TurnRightCommand>(repeatCommand.Commands[1]);
        Assert.Equal(90, turnCommand.Angle);
    }

    [Fact]
    public void Parse_ShouldThrowException_ForUnknownCommand()
    {
        Assert.Throws<InvalidOperationException>(() => _parser.Parse("unknown 123"));
    }

    [Fact]
    public void Parse_ShouldThrowException_ForUnmatchedBrackets()
    {
        Assert.Throws<InvalidOperationException>(() => _parser.Parse("taeper 2 [ df 50"));
    }
}
