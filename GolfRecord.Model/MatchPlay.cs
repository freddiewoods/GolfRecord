using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class MatchPlay : Match //normally have 2 people playing unless its four ball better ball teams of 2.
    {
        public int[] TotalScore = new int[2];
        public int[] Handicaps = new int[2];
        public int[] DifficultyPerGolfer = new int[2];
        

        public void AddScores(Hole hole, int ScoreA, int ScoreB)
        {
            var hs = Container.NewTransientInstance<TwoPlayerHoleScore>();
            int[] Scores = { ScoreA, ScoreB };
            CalculateStrokeIndexEffect(hole);
            CalculateHandicapEffect();
            ScoreCalculation(hole, Scores, hs);
            if (hole.HoleNumber == Course.Holes.Count)
            {

                int Gwin = findWinnerMatchPlay();
                Winner = Golfers.ElementAt(Gwin);
                for (int i = 0; i < 2; i++)
                {
                    Golfers.ElementAt(i).WithinMatch = false;
                }
            }
            Container.Persist(ref hs);
            HoleScores.Add(hs);
        }

        [NakedObjectsIgnore]
        public void ScoreCalculation(Hole hole, int[] Scores, TwoPlayerHoleScore hs)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Handicaps[i] > 1)
                {
                    if (Handicaps[i] >= 18)
                    {
                        Scores[i] -= 2;
                    }
                    else
                    {
                        Scores[i] -= 1;
                    }
                }
            }
            
            if (Scores[0] < Scores[1])
            {
                TotalScore[0] += 1;
            }
            else if (Scores[0] < Scores[1])
            {
                TotalScore[1] += 1;
            }
            else // if there is a draw dont add a score.
            {
            }        
            hs.Hole = hole;
            hs.ScoreGolferA = Scores[0];
            hs.ScoreGolferB = Scores[1];
        }
        [NakedObjectsIgnore]
        public void CalculateStrokeIndexEffect(Hole hole)
        {
            for (int i = 0; i < 2; i++)
            {


                if (Golfers.ElementAt(i).Gender == Gender.Female)
                {

                    DifficultyPerGolfer[i] = 19 - hole.RedStrokeIndex;
                }
                else
                {

                    DifficultyPerGolfer[i] = 19 - hole.StrokeIndex;
                }
            }
        }
        [NakedObjectsIgnore]
        private void CalculateHandicapEffect()
        {
            for (int i = 0; i < 2; i++)
            {
                Handicaps[i] = Golfers.ElementAt(i).Handicap - DifficultyPerGolfer[i];
            }
        }
        [NakedObjectsIgnore]
        public int findWinnerMatchPlay()
        {
            int gwin = 0;
            if (TotalScore[0] > TotalScore[1])
            {
                gwin = 0;
            }
            else if (TotalScore[1] > TotalScore[0])
            {
                gwin = 1;
            }
            else gwin = 0;
            return gwin;
        }
    }
}
