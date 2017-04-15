using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatalinkProject;

namespace TestCases
{
    [TestClass]
    public class UnitTest1
    {
        //Tested against the following website: https://www.easycalculation.com/sports/bowling-score-calculator.php

        [TestMethod]
        public void PerfectGameTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "10|10|10|10|10|10|10|10|10|10,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 300;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void LastFrameMissedStrikeTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "10|10|10|10|10|10|10|10|10|0,0";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 240;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void MiddleFrameMissedStrikeTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "10|10|10|10|10|0,0|10|10|10|10,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 240;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void FirstFrameMissedStrikeTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|10|10|10|10|10|10|10|10|10,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 270;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void FirstFrameMissedSpareTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "8,2|10|10|10|10|10|10|10|10|10,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 290;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void FirstAndThirdFrameMissedSpareTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "8,2|10|7,3|10|10|10|10|10|10|10,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 270;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void SpareInLastFrameTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "8,2|10|7,3|10|10|10|10|10|10|7,3,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 247;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void RandomsTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "8,1|5,3|7,2|10|8,2|2,4|10|8,1|10|7,3,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 132;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void BadBowlerTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0,0";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void UnluckyBowlerTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,10,0";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 10;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void SeriouslyUnluckyBowlerTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|0,0|8,2,0";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 10;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void RandomStrikeTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|10|10|10|10|10|10|10|10|0,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 240;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void AnotherRandomStrikeTest()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|10|10|10|10|10|10|10|8,2|0,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 228;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void RandomTestOnFinalFrame()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|10|10|10|10|10|10|10|8,1|0,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 226;

            Assert.AreEqual(expectedValue, valueReturned);
        }

        [TestMethod]
        public void GreaterThan10Test()
        {
            BowlingController gameTest = new BowlingController();

            string gameValue = "0,0|100|10|10|10|10|10|10|8,1|0,10,10";

            int valueReturned = gameTest.BowlingGame(gameValue);
            int expectedValue = 0; //This test is done in the Console for now, but will return 0.

            Assert.AreEqual(expectedValue, valueReturned);
        }
    }
}
