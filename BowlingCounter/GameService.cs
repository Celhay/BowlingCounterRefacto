using BowlingCounter.Interfaces;

namespace BowlingCounter;
using Microsoft.Extensions.Logging;

public class GameService :IGame
{
    private int[][] firstThrows;
    private int[][] secondThrows;

    private readonly ILogger _logger;

    public GameService(ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(loggerFactory);
        _logger = loggerFactory.CreateLogger("GameService");
        _logger.LogInformation("Start Logging ...");
    }

    public void InitGame(int numPlayers)
    {
        firstThrows = new int[numPlayers][];
        secondThrows = new int[numPlayers][];
    }

    public void Start()
    {
        Console.WriteLine("**************************************");
        Console.WriteLine("*** Welcome to the Bowling Counter ***");
        Console.WriteLine("**************************************");
        Console.WriteLine("\r\n");

        Console.WriteLine("MENU : ");
        Console.WriteLine("1- Start a new game");
        Console.WriteLine("2- Say \"Hello\"");
        Console.WriteLine("2- Exit");

        try
        {
            var choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter number of players: ");
                    int numPlayers = int.Parse(Console.ReadLine());
                    InitGame(numPlayers);
                    Play();
                    break;
                case 2:
                    Console.Write("Hello");
                    break;
                default:
                    GoodByeGame();
                    break;
            }
        }
        catch (Exception e)
        {
            GoodByeGame();
            _logger.LogWarning(e.Message);
        }
    }

    public void GoodByeGame()
    {
        Console.WriteLine("Thanks for playing.\n GoodBye");
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }
    public void Play()
    {
        Console.Write("Enter number of players: ");
        int numPlayers = int.Parse(Console.ReadLine());

        int[][] firstThrows = new int[numPlayers][];
        int[][] secondThrows = new int[numPlayers][];

        for (int i = 0; i < numPlayers; i++)
        {
            firstThrows[i] = new int[10];
            secondThrows[i] = new int[10];
        }

        for (int i = 0; i < 10; i++)
        {
            for (int player = 0; player < numPlayers; player++)
            {
                Console.WriteLine("Player " + (player + 1));
                Console.Write("Enter first throw: ");
                firstThrows[player][i] = int.Parse(Console.ReadLine());
                Console.Write("Enter second throw: ");
                secondThrows[player][i] = int.Parse(Console.ReadLine());

                int totalScore = 0;
                for (int j = 0; j <= i; j++)
                {
                    totalScore += firstThrows[player][j] + secondThrows[player][j];
                    if (j < i && firstThrows[player][j] == 10) // strike
                    {
                        totalScore += firstThrows[player][j + 1] + secondThrows[player][j + 1];
                    }
                    else if (firstThrows[player][j] + secondThrows[player][j] == 10) // spare
                    {
                        totalScore += firstThrows[player][j + 1];
                    }
                }

                Console.WriteLine("Total score: " + totalScore);

                // Print the throws in a table
                Console.WriteLine("Throws:");
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("| " + firstThrows[player][j] + " " + secondThrows[player][j] + " ");
                }

                Console.WriteLine("|");
            }
        }
    }
}