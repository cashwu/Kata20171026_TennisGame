using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20171026_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void Love_All()
        {
            TennisGame tennisGame = new TennisGame("player1", "player2");
            var result = tennisGame.Score();
            Assert.AreEqual("Love All", result);
        }
    }

    public class TennisGame
    {
        private readonly string _player1;
        private readonly string _player2;

        public TennisGame(string player1, string player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string Score()
        {
            return "Love All";
        }
    }
}