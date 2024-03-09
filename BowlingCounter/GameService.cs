using System.Net.Mime;
using BowlingCounter.Interfaces;
using BowlingCounter.Model;

namespace BowlingCounter;
using Microsoft.Extensions.Logging;

public class GameService :IGame
{
    private int[][] _firstThrows;
    private int[][] _secondThrows;
    private int _numPlayers;
    private List<Player> _joueurs;

    private readonly ILogger _logger;

    public GameService(ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(loggerFactory);
        _logger = loggerFactory.CreateLogger("GameService");
        _logger.LogInformation("Start Logging ...");
    }

    public void InitGame(int numPlayers)
    {
        _joueurs = new List<Player>();
        _numPlayers = numPlayers;
        _firstThrows = new int[numPlayers][];
        _secondThrows = new int[numPlayers][];
        for (int i = 0; i < numPlayers; i++)
        {
            _firstThrows[i] = new int[10];
            _secondThrows[i] = new int[10];
            _joueurs.Add(new Player(i+1));
        }
    }

    public void Start()
    {
        Console.WriteLine("**************************************");
        Console.WriteLine("*** Welcome to the Bowling Counter ***");
        Console.WriteLine("**************************************");
        Console.WriteLine("\r\n");

        Console.WriteLine("MENU : ");
        Console.WriteLine("1- Start a new game");
        Console.WriteLine("2- Exit");

        try
        {
            var choice = GetIntInput();
            if(choice == 1)
            {
                Console.Write("Enter number of players: ");
                int numPlayers = GetIntInput();
                InitGame(numPlayers);
                Play();
            }else
            {
                GoodByeGame();
            }
            
        }
        catch (Exception e)
        {
            GoodByeGame();
            // _logger.LogWarning(e.Message);
            throw e;
        }
    }

    private int GetIntInput()
    {
        string? inputString = Console.ReadLine();
        int inputInt;
        while (!int.TryParse(inputString, out inputInt))
        {
            Console.WriteLine("Please enter a correct type of numbers !");
            inputString = Console.ReadLine();
        }
        return inputInt;

    }
    private int GetValidThrow()
    {
        string? inputString = Console.ReadLine();
        int inputInt;
        while (!int.TryParse(inputString, out inputInt) && inputInt > 10)
        {
            Console.WriteLine("Please enter a correct type of skittles !");
            inputString = Console.ReadLine();
        }
        return inputInt;

    }
    public void GoodByeGame()
    {
        Console.WriteLine("Thanks for playing.\n GoodBye");
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
        
    }
    public void Play()
    {
        for (int lancer = 0; lancer < 10; lancer++)
        {
            for (int player = 0; player < _numPlayers; player++)
            {
                Console.WriteLine("Player " + (player + 1));
                Console.Write("Enter first throw: ");
                _firstThrows[player][lancer] = GetValidThrow();
                Console.Write("Enter second throw: ");
                _secondThrows[player][lancer] = GetValidThrow();

                
                for (int j = 0; j <= lancer; j++)
                {
                    _joueurs[player].TotalScore += _firstThrows[player][j] + _secondThrows[player][j];
                    if (_firstThrows[player][j] == 10) // strike
                    {
                        _joueurs[player].TotalScore += _firstThrows[player][j + 1] + _secondThrows[player][j + 1];
                    }
                    else if (_firstThrows[player][j] + _secondThrows[player][j] == 10) // spare
                    {
                        _joueurs[player].TotalScore += _firstThrows[player][j + 1];
                    }
                }

                Console.WriteLine("Total score: " + _joueurs[player].TotalScore);
                
                Console.WriteLine("Throws:");
                for (int j = 0; j <= lancer; j++)
                {
                    Console.Write("| " + _firstThrows[player][j] + " " + _secondThrows[player][j] + " ");
                }

                Console.WriteLine("|");
            }
        }
        Console.WriteLine("Fin de la partie");
        var gagnant = _joueurs.MaxBy(x => x.TotalScore);
        Console.WriteLine($"The winner is Player {gagnant.PlayerId} avec un score de {gagnant.TotalScore}");

    }
}