namespace Tenis
{
    internal class TennisGameSolution1
    {

        public (S p1, S p2) Score { get; private set; } = (S.S0, S.S0);

        public void AddScore(Player player)
        {
            if(player == Player.P1)
            {
                Score = Score switch
                {
                    (S.S40, S.S40) => (S.Advantage, S.S40),
                    (S.Advantage, S.S40) => (S.Win, S.Loose),
                    (S.S40, S.Advantage) => (S.S40, S.S40),
                    (S.S40, _) => (S.Win, S.Loose),
                    var x => (x.p1 + 1, x.p2)
                };
            }

            if (player == Player.P2)
            {
                Score = Score switch
                {
                    (S.S40, S.S40) => (S.S40, S.Advantage),
                    (S.S40, S.Advantage) => (S.Loose, S.Win),
                    (S.Advantage, S.S40) => (S.S40, S.S40),
                    (_, S.S40) => (S.Loose, S.Win),
                    var x => (x.p1, x.p2 + 1)
                };
            }
        }
    }

    enum Player
    {
        P1, P2
    }

    enum S
    {
        S0,
        S15,
        S30,
        S40,
        Advantage,
        Win,
        Loose
    }
}
