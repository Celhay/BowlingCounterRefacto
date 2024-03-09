namespace BowlingCounter.Model;

public class Player
{
    public int PlayerId { get; set; }
    public int TotalScore { get; set; }
    public int[][] AllThrows { get; set; }

    public Player(int id)
    {
        TotalScore = 0;
        PlayerId = id;
    }
}