using Xunit;

namespace Tenis
{
    public class TennisGameSolution2Tests
    {
        [Fact]
        public void GameStartsAtZeroZero()
        {
            var t = new TennisGameSolution2();
            Assert.Equal(new Normal(0,0), t.Score);
        }

        [Fact]
        public void Player1ScoresAfterZero()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P1);
            Assert.Equal(new Normal(15, 0), t.Score);
        }

        [Fact]
        public void Player2ScoresAfterZero()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P2);
            Assert.Equal(new Normal(0, 15), t.Score);
        }

        [Fact]
        public void Player2ScoresTwice()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            Assert.Equal(new Normal(0, 30), t.Score);
        }

        [Fact]
        public void Player1ScoresTwiceAndPlayer2Once()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P2);
            Assert.Equal(new Normal(30, 15), t.Score);
        }

        [Fact]
        public void Player1ScoresThreeTimes()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            Assert.Equal(new Normal(40, 0), t.Score);
        }


        [Fact]
        public void Player1ScoresFourTimes()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            Assert.Equal(new P1Win(), t.Score);
        }

        [Fact]
        public void Player2ScoresFourTimes()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            Assert.Equal(new P2Win(), t.Score);
        }

        [Fact]
        public void Player1GetsAdvantageAfterDeuce()
        {
            var t = new TennisGameSolution2();
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P2);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            t.AddScore(Player.P1);
            // Now we have Deuce
            t.AddScore(Player.P1);
            Assert.Equal(new P1Advantage(), t.Score);
        }

        [Fact]
        public void GoBackToDeuceAfterPlayer1ScoresOnPlayer2sAdvantage()
        {
            var t = new TennisGameSolution2();
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
            Assert.Equal(new Deuce(), t.Score);
        }

        [Fact]
        public void WinAfterPlayer1ScoresOnAdvantage()
        {
            var t = new TennisGameSolution2();
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
            Assert.Equal(new P1Win(), t.Score);
        }
    }
}
