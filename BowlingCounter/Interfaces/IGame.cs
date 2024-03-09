namespace BowlingCounter.Interfaces;

public interface IGame
{
    void Start();
    void InitGame(int numPlayers);
    void GoodByeGame();
    void Play();
}