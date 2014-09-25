namespace BullsAndCows.GameLogics
{
    public class GameResultValidator : IGameResultValidator
    {
        public GameResult GetResult()
        {
            return GameResult.NotFinished;
        }
    }
}
