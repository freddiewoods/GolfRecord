using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfRecord.Model;

namespace GolfRecord.Model
{
    public class MatchStrokePlay : Match 
    {

        public virtual int TotalScoreA { get; set; }

        public virtual int TotalScoreB { get; set; }

        public virtual int TotalScoreC { get; set; }

        public virtual int TotalScoreD { get; set; }

        public void AddScoreStrokePlay(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD, HoleScore hs)
        {
            hs.Hole = hole;
            hs.GolferA = ScoreA;
            hs.GolferB = ScoreB;
            hs.GolferC = ScoreC;
            hs.GolferD = ScoreD;
            HoleScores.Add(hs);
            TotalScoreA += ScoreA;
            TotalScoreB += ScoreB;
            TotalScoreC += ScoreC;
            TotalScoreD += ScoreD;
        }
        [NakedObjectsIgnore]
        public int FindWinnerStrokePlay()
        {
            List<int> Scores = new List<int>();
            Scores.Add(TotalScoreA);
            Scores.Add(TotalScoreB);
            Scores.Add(TotalScoreC);
            Scores.Add(TotalScoreD);
            if (Scores.Min() == TotalScoreA)
            {
                return 0;
            }
            else if (Scores.Min() == TotalScoreB)
            {
                return 1;
            }
            else if (Scores.Min() == TotalScoreC)
            {
                return 2;
            }
            else if (Scores.Min() == TotalScoreD)
            {
                return 3;
            }
            return 1;
        }

    }
}
