﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace GolfRecord.Model
{
    public class MatchStableFord : Match
    {
        public int[] TotalScores;
        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<FourPlayerHoleScore>();
            int[] handicaps = CalculateHandicapForEachGolfer(hole);
            int[] ParsForEach = CalculateParForEachGolfer(hole);
            int[] Scores = { ScoreA, ScoreB, ScoreC, ScoreD };
            ScoresAddedToHs(hole, Scores, hs, handicaps, ParsForEach);
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {
                Golfers.First().MatchHistory.Add(this);
                for (int i = 0; i < 5; i++)
                {
                    Golfers.ElementAt(i).WithinMatch = false;
                }
            }
        }

        private int[] CalculateParForEachGolfer(Hole hole)
        {
            int[] ParsForEachG = new int[4];
            for (int i = 0; i < 5; i++)
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

        private int[] CalculateHandicapForEachGolfer(Hole hole)
        {
            int[] Difficulties = new int[4];
            for (int i = 0; i < 5; i++)
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
            for (int i = 0; i < 5; i++)
            {
                Handicaps[i] = Golfers.ElementAt(i).Handicap - Difficulties[i];
            }  
            return Handicaps;
        }

        [NakedObjectsIgnore]
        public void ScoresAddedToHs(Hole hole, int[] Scores, FourPlayerHoleScore hs, int[] handicaps ,int[] ParsForEachG)
        {
            int[] ScoreGolfer = { hs.ScoreGolferA, hs.ScoreGolferB, hs.ScoreGolferC, hs.ScoreGolferD };
            hs.Hole = hole;
            for (int i = 0; i < 4; i++)
            {
                ScoreGolfer[i] = Scores[i];
            }
            HoleScores.Add(hs);
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
                TotalScore += 3;
            }
            else
            {
                TotalScore += 0;
            }
            return TotalScore;
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

        [NakedObjectsIgnore]
        public int FindWinner()
        {
            int Gwin = 0;
            List<int> Scores = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Scores.Add(TotalScores[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (Scores.Min() == TotalScores[i])
                    Gwin = i;
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
