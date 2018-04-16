using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace GolfRecord.Model
{
    public class Stableford : Match
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
            var hs = Container.NewTransientInstance<StablefordScores>();
            Container.Persist(ref hs);
            hs.GolferARawScore = ScoreA;
            hs.GolferBRawScore = ScoreB;
            hs.GolferCRawScore = ScoreC;
            hs.GolferDRawScore = ScoreD;
            hs.Hole = hole;
            int[] Pars = StrokeIndexandHandicapEffectonPar(hole);
            int[] Scores = { ScoreA, ScoreB, ScoreC, ScoreD };
            TotalScoreCalculated(hole, Scores, hs, Pars);
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {
               FindWinner();
            }
        }
        public string ValidateAddScores(Hole hole, int A, int B, int C, int D)
        {
            if ((A <= 0) | (B <= 0) | (C <= 0) | (D<= 0))
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }
        private int[] StrokeIndexandHandicapEffectonPar(Hole hole)
        {
            int[] ModifiedPar = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if ((Golfers.ElementAt(i).Gender == Enums.Gender.Female) & (hole.RedStrokeIndex != 0))
                {
                    if (Golfers.ElementAt(i).Handicap >= hole.RedStrokeIndex)
                    {
                        if ((Golfers.ElementAt(i).Handicap >= (hole.RedStrokeIndex + 18)) & (Course.Holes.Count == 18))
                        {
                            ModifiedPar[i] = hole.RedPar + 2;
                        }
                        else if ((Golfers.ElementAt(i).Handicap >= (hole.RedStrokeIndex + 9)) & (Course.Holes.Count == 9))
                        {
                            ModifiedPar[i] = hole.RedPar + 2;
                        }

                        else
                        {
                            ModifiedPar[i] = hole.RedPar + 1;
                        }
                    }
                    else
                    {
                        ModifiedPar[i] = hole.RedPar;
                    }
                }
                else 
                {
                    if (Golfers.ElementAt(i).Handicap >= hole.StrokeIndex)
                    {
                        if ((Golfers.ElementAt(i).Handicap >= (hole.StrokeIndex + 18)) & (Course.Holes.Count == 18))
                        {
                            ModifiedPar[i] = hole.Par + 2;
                        }
                        else if ((Golfers.ElementAt(i).Handicap >= (hole.StrokeIndex + 9)) & (Course.Holes.Count == 9))
                        {
                            ModifiedPar[i] = hole.Par + 2;
                        }
                        else
                        {
                            ModifiedPar[i] = hole.Par + 1;
                        }
                    }
                    else
                    {
                        ModifiedPar[i] = hole.Par;
                    }
                }

            }  
            return ModifiedPar;
        } 
        private int FindScore(int Score, int Par)
        {
            int  TotalScore = 0;
            if (Score - Par == 1)
            {
                TotalScore += 1;
            }
            else if (Score - Par == 0)
            {
                TotalScore += 2;
            }
            else if (Score - Par < 0)
            {
                TotalScore += ((Score- Par) - 2)* (-1);
            }
            else
            {
                TotalScore += 0;
            }
            return TotalScore;
        }

        [NakedObjectsIgnore]
        public void TotalScoreCalculated(Hole hole, int[] Scores, StablefordScores hs, int[] handicaps)
        {
            int[] TotalScore = new int[4];
            for (int i = 0; i < 4; i++)
            {
                TotalScore[i] += FindScore(Scores[i], handicaps[i]);
                Scores[i] = TotalScore[i];
            }
            hs.GolferAActualScore = Scores[0];
            hs.GolferBActualScore = Scores[1];
            hs.GolferCActualScore = Scores[2];
            hs.GolferDActualScore = Scores[3];
            TotalScoreA += Scores[0];
            TotalScoreB += Scores[1];
            TotalScoreC += Scores[2];
            TotalScoreD += Scores[3];
            hs.GolferATotalScore = TotalScoreA;
            hs.GolferBTotalScore = TotalScoreB;
            hs.GolferCTotalScore = TotalScoreC;
            hs.GolferDTotalScore = TotalScoreD;
        }

        [NakedObjectsIgnore]
        public void FindWinner()
        {
            int[] TotalScores = { TotalScoreA, TotalScoreB, TotalScoreC, TotalScoreD };
            for (int i = 0; i < 4; i++)
            {
                if (TotalScores.Max() == TotalScores[i])
                {
                    Winner = Golfers.ElementAt(i);
                }
            }
            MatchOver = true;
        }
    }
}
