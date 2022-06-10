namespace Tenis
{
    internal class TennisGameSolution2
    {

        public IGameState Score { get; private set; } = new Normal(0, 0);

        public void AddScore(Player player)
        {
            if(player == Player.P1)
            {
                Score = Score switch
                {
                    Normal(30, 40) => new Deuce(),
                    Deuce => new P1Advantage(),
                    P1Advantage => new P1Win(),
                    P2Advantage => new Deuce(),
                    Normal(40, _) => new P1Win(),
                    Normal n => new Normal(Next(n.P1), n.P2),
                    IGameState x => x,
                };
            }

            if (player == Player.P2)
            {
                Score = Score switch
                {
                    Normal(40, 30) => new Deuce(),
                    Deuce => new P2Advantage(),
                    P2Advantage => new P2Win(),
                    P1Advantage => new Deuce(),
                    Normal(_, 40) => new P2Win(),
                    Normal n => new Normal(n.P1, Next(n.P2)),
                    IGameState x => x,
                };
            }
        }

        private int Next(int score)
        {
            return score switch
            {
                0 => 15,
                15 => 30,
                30 => 40,
                _ => throw new Exception("Cannot happen")
            };
        }
    }

    public interface IGameState
    {
    }

    public record Normal(int P1, int P2) : IGameState;
    public record Deuce : IGameState;
    public record P1Advantage : IGameState;
    public record P2Advantage : IGameState;
    public record P1Win : IGameState;
    public record P2Win : IGameState;
}
