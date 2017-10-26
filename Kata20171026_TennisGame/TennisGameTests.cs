using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Kata20171026_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        private readonly TennisGame _tennisGame = new TennisGame("player1", "player2");

        [TestMethod]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            _tennisGame.FirstPlayerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            _tennisGame.FirstPlayerScore();
            _tennisGame.FirstPlayerScore();
            ScoreShouldBe("Thirty Love");
        }

        private void ScoreShouldBe(string expected)
        {
            var result = _tennisGame.Score();
            Assert.AreEqual(expected, result);
        }
    }

    public class TennisGame
    {
        private readonly string _player1;
        private readonly string _player2;

        private int _firstPlayerScore;

        public TennisGame(string player1, string player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string Score()
        {
            var lookup = new Dictionary<int, string>
            {
                {1, "Fifteen"},
                {2, "Thirty"}
            };
            if (_firstPlayerScore > 0)
            {
                return lookup[_firstPlayerScore] + " Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScore++;
        }
    }
}