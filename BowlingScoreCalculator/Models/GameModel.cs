using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator.Models
{
    internal class GameModel
    {
        private string GameString;
        private List<FrameModel> FrameList = new List<FrameModel>();
        public bool hasError = false;

        internal GameModel(string inputString)
        {
            GameString = inputString;
        }

        /// <summary>
        /// <para>Play a game of bowling! </para>
        /// <para>Expected format:</para>
        /// <para>For user input, frames are '|' delimited and throws are ',' delimited.</para>
        /// <para>A perfect game: "10|10|10|10|10|10|10|10|10|10,10,10"</para>
        /// <para>This would return 300.</para>
        /// </summary>
        /// <returns>Total Score</returns>
        internal int PlayGame()
        {
            string[] frames = GameString.Split('|');

            if (frames.Length != 10)
            {
                Console.WriteLine("The Game must have 10 frames, please re-enter.");
                hasError = true;
                return -1;
            }

            PopulateFrameList(frames);

            int finalScore = CalculateFinalValueUsingFrames();

            Console.WriteLine("Final Score for this game: " + finalScore);

            return finalScore;
        }

        /// <summary>
        /// Populate the Frames from the user input
        /// </summary>
        /// <param name="frames">user input</param>
        private void PopulateFrameList(string[] frames)
        {
            int frameNbr = 1;

            foreach (string frame in frames)
            {
                string[] throws = frame.Split(',');
                int firstThrow = 0, secondThrow = 0, thirdThrow = 0;

                if (int.TryParse(throws[0], out firstThrow))
                {
                    if (throws.Length > 1)
                    {
                        if (int.TryParse(throws[1], out secondThrow) == false)
                        {
                            Console.WriteLine("Frame " + (FrameList.Count + 1) + " has a value which isn't a number. Entered: " + throws[1]);
                            FrameList.Clear();
                            return;
                        }

                        if (throws.Length > 2)
                        {
                            if (int.TryParse(throws[2], out thirdThrow) == false)
                            {
                                Console.WriteLine("Frame " + (FrameList.Count + 1) + " has a value which isn't a number. Entered: " + throws[2]);
                                FrameList.Clear();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Frame " + (FrameList.Count + 1) + " has a value which isn't a number. Entered: " + throws[0]);
                    FrameList.Clear();
                    return;
                }

                FrameModel frameModel = new FrameModel(firstThrow, frameNbr++, secondThrow, thirdThrow);

                if (frameModel.hasBadFrame)
                {
                    Console.WriteLine("Frame " + (FrameList.Count + 1) + " has a bad setup. Verify it adheres to Bowling rules.");
                    FrameList.Clear();
                    return;
                }

                FrameList.Add(frameModel);
            }

            for (int i = 0; i < FrameList.Count; i++)
            {
                if (i < FrameList.Count - 2)
                {
                    FrameList[i].FirstNextFrame = FrameList[i + 1];
                    FrameList[i].SecondNextFrame = FrameList[i + 2];
                }
                else if (i < FrameList.Count - 1)
                {
                    FrameList[i].FirstNextFrame = FrameList[i + 1];
                    FrameList[i].SecondNextFrame = FrameList[i + 1];
                }
                else
                {
                    FrameList[i].FirstNextFrame = FrameList[i];
                    FrameList[i].SecondNextFrame = FrameList[i];
                }
            }
        }

        /// <summary>
        /// Calculate the Game's score using the Frames within this Object
        /// </summary>
        /// <returns>Final Score</returns>
        private int CalculateFinalValueUsingFrames()
        {
            int finalScore = 0;

            for (int i = 0; i < FrameList.Count; i++)
            {
                FrameModel frame = FrameList[i];

                finalScore += frame.GetTotalFrameValue();
            }

            return finalScore;
        }
    }
}
