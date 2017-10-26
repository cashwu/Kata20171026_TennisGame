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
            FirstPlayerScoreTime(2);
            ScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            FirstPlayerScoreTime(3);
            ScoreShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            _tennisGame.SecondPlayerScore();
            ScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            SecondPlayerScoreTime(2);
            ScoreShouldBe("Love Thirty");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            FirstPlayerScoreTime(1);
            SecondPlayerScoreTime(1);
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Deuce()
        {
            FirstPlayerScoreTime(3);
            SecondPlayerScoreTime(3);
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Deuce_when_4()
        {
            FirstPlayerScoreTime(4);
            SecondPlayerScoreTime(4);
            ScoreShouldBe("Deuce");
        }

        private void SecondPlayerScoreTime(int times)
        {
            for (int j = 0; j < times; j++)
            {
                _tennisGame.SecondPlayerScore();
            }
        }

        private void FirstPlayerScoreTime(int times)
        {
            for (int j = 0; j < times; j++)
            {
                _tennisGame.FirstPlayerScore();
            }
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
        private int _secondPlayerScore;

        public TennisGame(string player1, string player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        private readonly Dictionary<int, string> _lookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public string Score()
        {
            if (_firstPlayerScore != _secondPlayerScore)
            {
                return _lookup[_firstPlayerScore] + " " + _lookup[_secondPlayerScore];
            }
            if (_firstPlayerScore >= 3)
            {
                return "Deuce";
            }
            return _lookup[_firstPlayerScore] + " All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScore++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScore++;
        }
    }
}