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
        public int[] TotalScores;
        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<FourPlayerHoleScore>();
            Container.Persist(ref hs);
            hs.ScoreGolferA = ScoreA;
            hs.ScoreGolferB = ScoreB;
            hs.ScoreGolferC = ScoreC;
            hs.ScoreGolferD = ScoreD;
            hs.Hole = hole;
            HoleScores.Add(hs);
            int[] StrokeIndexs = StrokeIndexEffect(hole);
            int[] GenderEffectOfGolfer = GenderEffect(hole);
            int[] Scores = { ScoreA, ScoreB, ScoreC, ScoreD };
            TotalScoreCalculated(hole, Scores, hs, StrokeIndexs, GenderEffectOfGolfer);
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {
                Winner = Golfers.ElementAt(FindWinner());
            }
        }

        private int[] GenderEffect(Hole hole)
        {
            int[] ParsForEachG = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (Golfers.ElementAt(i).Gender == Enums.Gender.Female)
                {
                    ParsForEachG[i] = 1;
                }
                else
                {
                    ParsForEachG[i] = 2;
                }
            }
            return ParsForEachG;
        }

        private int[] StrokeIndexEffect(Hole hole)
        {
            int[] Difficulties = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (Golfers.ElementAt(i).Gender == Enums.Gender.Female)
                {
                    Difficulties[i] = 19 - hole.RedStrokeIndex;
                }
                else
                {
                    Difficulties[i] = 19 - hole.StrokeIndex;
                }
            }
            int[] Handicaps = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Handicaps[i] = Golfers.ElementAt(i).Handicap - Difficulties[i];
            }  
            return Handicaps;
        }

        private int ModifiedPar(FourPlayerHoleScore hs, int handi, int intitialPar)
        {
            int FinalPar = 0;
            if (handi >= 1)
            {
                if (handi >= 18 & intitialPar == 2)
                {
                    FinalPar = hs.Hole.Par + 2;
                }
                else if (handi >= 1 & handi < 18 & intitialPar == 2)
                {
                    FinalPar = hs.Hole.Par + 1;
                }
                else if (handi >= 18 & intitialPar == 1)
                {
                    FinalPar = hs.Hole.RedPar + 2;
                }
                else if (handi >= 1 & handi < 18 & intitialPar == 1)
                {
                    FinalPar = hs.Hole.RedPar + 1;
                }
            }
            return FinalPar;
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
        public void TotalScoreCalculated(Hole hole, int[] Scores, FourPlayerHoleScore hs, int[] handicaps, int[] ParsForEachG)
        {

            int[] FinalPar = new int[4];
            int[] TotalScores = new int[4];
            for (int i = 0; i < 4; i++)
            {
                FinalPar[i] = ModifiedPar(hs, handicaps[i], ParsForEachG[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                TotalScores[i] += FindScore(Scores[i], FinalPar[i]);
            }
        }
        [NakedObjectsIgnore]
        public int FindWinner()
        {
            int Gwin = 0;
            for (int i = 0; i < 4; i++)
            {
                if (TotalScores.Min() == TotalScores[i])
                {
                    Gwin = i;
                }
            }
            for (int i = 0; i < Golfers.Count; i++)
            {
                Golfers.ElementAt(i).MyMatches.Remove(this);
            }
            return Gwin;
        }

        #region HideAddScores()
        public bool HideAddScores()
        {
            return (Golfers.Count != 4);
        }
        #endregion  
    }
}
