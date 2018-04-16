using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfRecord.Model;

namespace GolfRecord.Model
{
    public class Strokeplay : Match 
    {

        [NakedObjectsIgnore]
        public virtual int TotalScoreA { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreB { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreC { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreD { get; set; }

        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            int[] TotalScores = { TotalScoreA + ScoreA, TotalScoreB +ScoreB, TotalScoreC+ScoreC,TotalScoreD+ScoreD };
            var hs = Container.NewTransientInstance<StrokeplayScores>();
            hs.Hole = hole;         
            hs.GolferARawScore = ScoreA;
            hs.GolferBRawScore = ScoreB;
            hs.GolferCRawScore = ScoreC;
            hs.GolferDRawScore = ScoreD;
            hs.GolferAActualScore = TotalScores[0];
            hs.GolferBActualScore = TotalScores[1];
            hs.GolferCActualScore = TotalScores[2];
            hs.GolferDActualScore = TotalScores[3];
            TotalScoreA = TotalScores[0];
            TotalScoreB = TotalScores[1];
            TotalScoreC = TotalScores[2];
            TotalScoreD = TotalScores[3];
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {
                for (int i = 0; i < 4; i++)
                {
                    TotalScores[i] -= Golfers.ElementAt(i).Handicap;
                }
                FindWinnerStrokePlay();
            }
        }
        [NakedObjectsIgnore]
        public void FindWinnerStrokePlay()
        {
            List<int> Scores = new List<int>();
            int[] TotalScores = { TotalScoreA, TotalScoreB, TotalScoreC, TotalScoreD };
            for (int i = 0; i < 4; i++)
            {
                Scores.Add(TotalScores[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                if (Scores.Min() == TotalScores[i])
                {
                    Winner = Golfers.ElementAt(i);
                }
            }
            MatchOver = true;
                      
        }

        public string ValidateAddScores(Hole hole, int A, int B, int C,int D)
        {
            if ((A <= 0) | (B <= 0) | (C<= 0) | (D<=0))
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }
    }
}
