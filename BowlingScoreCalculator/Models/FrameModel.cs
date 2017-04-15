using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator.Models
{
    internal class FrameModel
    {
        public FrameModel FirstNextFrame;
        public FrameModel SecondNextFrame;

        private int FirstThrow = 0;
        private int SecondThrow = 0;
        private int ThirdThrow = 0;
        private int FrameNumber = 0;

        internal bool isStrike = false;
        internal bool isSpare = false;
        internal bool hasBadFrame = false;

        internal FrameModel(int firstThrow, int frameNumber, int secondThrow = 0, int thirdThrow = 0)
        {
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
            ThirdThrow = thirdThrow;
            FrameNumber = frameNumber;
            
            if (firstThrow == 10)
            {
                isStrike = true;
            }
            else if ((firstThrow + secondThrow) == 10)
            {
                isSpare = true;
            }

            if (   FirstThrow > 10 
                || SecondThrow > 10 
                || ThirdThrow > 10 
                || (!isSpare && !isStrike) && (FirstThrow + SecondThrow > 10) 
                || (isStrike && (SecondThrow != 10) && (SecondThrow + ThirdThrow > 10)) 
                || FrameNumber != 10 && ThirdThrow > 0
               ) //Edge Cases galore
            {
                hasBadFrame = true;
            }
        }

        internal int GetTotalFrameValue()
        {
            int returnValue = 0;

            if (isStrike)
            {
                int firstFrameToAdd = 0, secondFrameToAdd = 0;

                if (FirstNextFrame.isStrike)
                {
                    firstFrameToAdd = 10;
                    secondFrameToAdd = SecondNextFrame.GetFirstThrowValue();
                }
                else
                {
                    firstFrameToAdd = FirstNextFrame.GetFirstAndSecondResultValue();
                }

                returnValue += 10 + firstFrameToAdd + secondFrameToAdd;
            }
            else if (isSpare)
            {
                if (FrameNumber != 10)
                {
                    returnValue += 10 + FirstNextFrame.GetFirstThrowValue();
                }
                else
                {
                    returnValue += 10 + GetThirdThrowValue();
                }
            }
            else
            {
                returnValue += FirstThrow + SecondThrow;
            }

            return returnValue;
        }

        internal int GetFirstThrowValue()
        {
            return FirstThrow;
        }

        internal int GetSecondThrowValue()
        {
            return SecondThrow;
        }

        internal int GetThirdThrowValue()
        {
            return ThirdThrow;
        }

        internal int GetFirstAndSecondResultValue()
        {
            return FirstThrow + SecondThrow;
        }
    }
}
