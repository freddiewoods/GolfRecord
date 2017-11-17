﻿using NakedObjects;
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
        public int[] InitialScorePerHole = new int[4];
        public int[] TotalScores = new int[4];
        public int Gwin;

        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            hs.Hole = hole;
            int[] scores = { ScoreA, ScoreB, ScoreC, ScoreD };
            for (int i = 0; i < 4; i++)
            {
                hs.GolferScores[i] = scores[i];
            }
            HoleScores.Add(hs);
            for (int i = 0; i < 4; i++)
            {
                TotalScores[i] = InitialScorePerHole[i];
            }
            if (hole.HoleNumber == Course.Holes.Count)
            {
                for (int i = 0; i < 4; i++)
                {
                    TotalScores[i] -= Golfers.ElementAt(i).Handicap;
                }
                int Gwin = FindWinnerStrokePlay();
                Winner = Golfers.ElementAt(Gwin);
                for (int i = 0; i < 4; i++)
                {
                    Golfers.ElementAt(i).WithinMatch = false;
                }
            }
        }
        [NakedObjectsIgnore]
        public int FindWinnerStrokePlay()
        {
            List<int> Scores = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                Scores.Add(TotalScores[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                if (Scores.Min() == TotalScores[i])
                {
                    Gwin = i;
                }
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
