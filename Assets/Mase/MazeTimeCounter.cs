using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets
{
    class MazeTimeCounter
    {
        private float overallTime;
        private float startTime;
        private float firstLevelTime;
        private float secondLevelTime;
        private float thirdLevelTime;
        private float fourthLevelTime;
        private float fifthLevelTime;
        private float sixthLevelTime;

        public float StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public float FirstLevelTime
        {
            get { return firstLevelTime; }
            set { firstLevelTime = value; }
        }

        public float SecondLevelTime
        {
            get { return secondLevelTime; }
            set { secondLevelTime = value; }
        }

        public float ThirdLevelTime
        {
            get { return thirdLevelTime; }
            set { thirdLevelTime = value; }
        }

        public float FourthLevelTime
        {
            get { return fourthLevelTime; }
            set { fourthLevelTime = value; }
        }

        public float FifthLevelTime
        {
            get { return fifthLevelTime; }
            set { fifthLevelTime = value; }
        }

        public float SixthLevelTime
        {
            get { return sixthLevelTime; }
            set { sixthLevelTime = value; }
        }

        public float OverallTime
        {
            get { return overallTime; }
            set { overallTime = value; }
        }
    }
}
