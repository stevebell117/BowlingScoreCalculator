using BowlingScoreCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    class Program
    {
        static void Main()
        {
            BowlingController mainEntry = new BowlingController();

            Console.WriteLine("Enter in bowling game string to get your score!");
            Console.WriteLine("Example: '10|10|10|10|10|10|10|10|10|10,10,10' (Perfect Game)");
            Console.WriteLine("Press Enter to exit.");

            mainEntry.BowlingGame(null);
        }
    }
}