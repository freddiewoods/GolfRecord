using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Foursome : Match
    {
        public int TotalScoreA;
        public int TotalScoreB;
        public int TotalScoreC;
        public int TotalScoreD;
        public Golfer AddScoreFoursome(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD, HoleScore hs, IDomainObjectContainer Container)
        {
            ScoreA = TotalScoreA;
            ScoreB = TotalScoreB;
            ScoreC = TotalScoreC;
            ScoreD = TotalScoreD;
            return null;
        }
    }
}
