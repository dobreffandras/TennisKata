using Xunit;

namespace Tenis
{
    public class TennisGameSolution1Tests
    {
        [Fact]
        public void GameStartsAtZeroZero()
        {
            var t = new TennisGameSolution1();
            Assert.Equal((S.S0, S.S0), t.Score);
        }

        [Fact]
        public void Player1ScoresAfterZero()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P1);
            Assert.Equal((S.S15, S.S0), t.Score);
        }

        [Fact]
        public void Player2ScoresAfterZero()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            Assert.Equal((S.S0, S.S15), t.Score);
        }

        [Fact]
        public void Player2ScoresTwice()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            Assert.Equal((S.S0, S.S30), t.Score);
        }

        [Fact]
        public void Player1ScoresTwiceAndPlayer2Once()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P2);
            Assert.Equal((S.S30, S.S15), t.Score);
        }

        [Fact]
        public void Player1ScoresThreeTimes()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            Assert.Equal((S.S40, S.S0), t.Score);
        }


        [Fact]
        public void Player1ScoresFourTimes()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            Assert.Equal((S.Win, S.Loose), t.Score);
        }

        [Fact]
        public void Player2ScoresFourTimes()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            Assert.Equal((S.Loose, S.Win), t.Score);
        }

        [Fact]
        public void Player1GetsAdvantageAfterDeuce()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            // Now we have Deuce
            t.AddScore(Player.P1);
            Assert.Equal((S.Advantage, S.S40), t.Score);
        }

        [Fact]
        public void GoBackToDeuceAfterPlayer1ScoresOnPlayer2sAdvantage()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            // Now we have Deuce
            t.AddScore(Player.P2);
            // Player2 Advantage
            t.AddScore(Player.P1);
            Assert.Equal((S.S40, S.S40), t.Score);
        }

        [Fact]
        public void WinAfterPlayer1ScoresOnAdvantage()
        {
            var t = new TennisGameSolution1();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            // Now we have Deuce
            t.AddScore(Player.P1);
            // Player1 Advantage
            t.AddScore(Player.P1);
            Assert.Equal((S.Win, S.Loose), t.Score);
        }
    }
}
