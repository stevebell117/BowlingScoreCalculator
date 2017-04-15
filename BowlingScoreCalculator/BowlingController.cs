using BowlingScoreCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class BowlingController
    {
        public int BowlingGame(string enteredGameValue)
        {
            int finalScore = 0;

            if (enteredGameValue == null) //Used for Console Play
            {
                string entryLine = "";

                while (string.IsNullOrEmpty((entryLine = Console.ReadLine()).Trim()) == false)
                {
                    GameModel game = new GameModel(entryLine);

                    game.PlayGame();

                    Console.WriteLine("Press Enter to exit.");
                }
            }
            else //Used for Unit Testing, will return an expected value to Assert.
            {
                GameModel game = new GameModel(enteredGameValue);

                finalScore = game.PlayGame();
            }

            return finalScore;
        }
    }
}
