using BowlingCounter;
using BowlingCounter.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace TestProject;

public class Tests
{
    private GameService _gameService;

    public Tests()
    {
        _gameService = new GameService(new LoggerFactory());
    }
    [Fact]
    public void Constructor_Test()
    {
        var game = new GameService(new LoggerFactory());
        game.Should().BeOfType<GameService>();
    }
    
    [Fact]
    public void Constructor_Failed_Test()
    {
        Assert.Throws<ArgumentNullException>( () => new GameService(null));
    }

    [Fact]
    public void Should_Stop_Game()
    {
        //Arrange
        var input = new StringReader("exit");
        Console.SetIn(input);
        Console.SetIn(new StringReader("exit"));
        //Act
        //Assert
        Assert.Throws<FormatException>( () =>_gameService.Start());
    }
    [Fact]
    public void Should_Hello_Game()
    {
        //Arrange
        var input = new StringReader("2");
        Console.SetIn(input);
        //Act
        _gameService.Start();
        //Assert
        Assert.True(true);
    }
    
    [Fact]
    public void Should_Start_Game()
    {
        //Arrange
        var input = new StringReader("1");
        Console.SetIn(input);

        //Act
        _gameService.Start();
        //Assert
        Assert.True(true);
    }
}