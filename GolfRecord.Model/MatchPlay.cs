using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Matchplay : Match //normally have 2 people playing unless its four ball better ball teams of 2.
    {

        [NakedObjectsIgnore]
        public virtual int TotalScoreA { get; set; }

        [NakedObjectsIgnore]

        public virtual int TotalScoreB { get; set; }


        public int[] Handicaps = new int[2];
        public int[] DifficultyPerGolfer = new int[2];

        public void AddScores(Hole hole, int ScoreA, int ScoreB)
        {
            var hs = Container.NewTransientInstance<MatchPlayHoleScore>();
            int[] Scores = { ScoreA, ScoreB };
            hs.GolferARawScore = ScoreA;
            hs.GolferBRawScore = ScoreB;
            int[] ModifiedScore = StrokeIndexandHandicapEffectOnScore(hole, Scores);
            ScoreCalculation(hole, ModifiedScore, hs );
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {
                findWinnerMatchPlay();                            
            }

        }

        private int[] StrokeIndexandHandicapEffectOnScore(Hole hole, int[] Scores)
        {
            int[] ModifiedScore = new int[4];
            for (int i = 0; i< 2; i++)
            {
                if ((Golfers.ElementAt(i).Gender == Gender.Female) & (hole.RedStrokeIndex != 0))
                {
                    if (Golfers.ElementAt(i).Handicap >= hole.RedStrokeIndex)
                    {
                        if ((Golfers.ElementAt(i).Handicap >= (hole.RedStrokeIndex + 18)) & (Course.Holes.Count == 18))
                        {
                            ModifiedScore[i] = Scores[i] - 2;
                        }
                        else if ((Golfers.ElementAt(i).Handicap >= (hole.RedStrokeIndex + 9)) & (Course.Holes.Count == 9))
                        {
                            ModifiedScore[i] = Scores[i] - 2;
                        }

                        else
                        {
                            ModifiedScore[i] = Scores[i] - 1;
                        }
                    }
                    else
                    {
                        ModifiedScore[i] = Scores[i];
                    }
                }
                else 
                {
                    if (Golfers.ElementAt(i).Handicap >= hole.StrokeIndex)
                    {
                        if ((Golfers.ElementAt(i).Handicap >= (hole.StrokeIndex + 18)) & (Course.Holes.Count == 18))
                        {
                            ModifiedScore[i] = Scores[i] - 2;
                        }
                        else if ((Golfers.ElementAt(i).Handicap >= (hole.StrokeIndex + 9)) & (Course.Holes.Count == 9))
                        {
                            ModifiedScore[i] = Scores[i] - 2;
                        }
                        else
                        {
                            ModifiedScore[i] = Scores[i] - 1;
                        }
                    }
                    else
                    {
                        ModifiedScore[i] = Scores[i];
                    }
                }

            }  
            return ModifiedScore;
        } 
    
        [NakedObjectsIgnore]
        public void ScoreCalculation(Hole hole, int[] Scores, MatchPlayHoleScore hs)
        {

            
            if (Scores[0] < Scores[1])
            {
                hs.HoleWinner = Golfers.ElementAt(0);
                TotalScoreA += 1;
            }
            else if (Scores[1] < Scores[0])
            {
                hs.HoleWinner = Golfers.ElementAt(1);
                TotalScoreB += 1;
                
            }
            else // if there is a draw dont add a score.
            {
            }        
            hs.Hole = hole;
            hs.GolferATotalScore = TotalScoreA;
            hs.GolferBTotalScore = TotalScoreB;
            hs.GolferAActualScore = Scores[0];
            hs.GolferBActualScore = Scores[1];
        }

        [NakedObjectsIgnore]
        public void findWinnerMatchPlay()
        {
            if (TotalScoreA > TotalScoreB)
            {
                Winner = Golfers.ElementAt(0);
            }
            else if (TotalScoreB > TotalScoreA)
            {
                Winner = Golfers.ElementAt(1);
            }
            MatchOver = true;

        }
    }
}
