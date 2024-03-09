using BowlingCounter;
using BowlingCounter.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace TestProject;

public class Tests
{
    private GameService _gameService;
    private Mock<ILogger> _mockLogger;

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
        var game = new GameService(null);
        game.Should().BeOfType<GameService>();
    }

    [Fact]
    public void Should_Stop_Game()
    {
        //Arrange
        var input = new StringReader("exit");
        Console.SetIn(input);

        //Act
        _gameService.Start();
        //Assert
        Assert.True(true);
    }
}