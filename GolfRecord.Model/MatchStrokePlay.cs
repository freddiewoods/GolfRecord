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
        [NakedObjectsIgnore]
        public virtual int TotalScoreA { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreB { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreC { get; set; }

        public virtual int TotalScoreD { get; set; }
        public  Golfer AddScoreStrokePlay(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD, HoleScore hs, IDomainObjectContainer Container)
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
            if (hole.Id == 4)
            {
                HandicapEffect();
                return FindWinnerStrokePlay();
            }
            return null;
        }
        [NakedObjectsIgnore]
        public Golfer FindWinnerStrokePlay()
        {
            List<int> Scores = new List<int>();
            Scores.Add(TotalScoreA);
            Scores.Add(TotalScoreB);
            Scores.Add(TotalScoreC);
            Scores.Add(TotalScoreD);
            if (Scores.Min() == TotalScoreA)
            {
                return Golfers.ElementAt(1);
            }
            else if (Scores.Min() == TotalScoreB)
            {
                return Golfers.ElementAt(2);
            }
            else if (Scores.Min() == TotalScoreC)
            {
                return Golfers.ElementAt(3);
            }
            else if (Scores.Min() == TotalScoreD)
            {
                return Golfers.ElementAt(4);
            }
            return null;
        }
        [NakedObjectsIgnore]
        public void HandicapEffect()
        {
            TotalScoreA -= Golfers.First().Handicap;
            TotalScoreB -= Golfers.ElementAt(1).Handicap;
            TotalScoreC -= Golfers.ElementAt(2).Handicap;
            TotalScoreD -= Golfers.Last().Handicap;
        }
    }
}
