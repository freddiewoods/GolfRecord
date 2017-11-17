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
        public int TotalScoreA;
        public int TotalScoreB;
        public int Difficulty;

        public void AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            int Gwin = 0;
            int Difficulty1 = 0;
            int Difficulty2 = 0;

            if (Golfers.ElementAt(0).Gender == Gender.Female)
            {

                Difficulty1 = 19 - hole.RedStrokeIndex;
            }
            else
            {

                Difficulty1 = 19 - hole.StrokeIndex;
            }
            if (Golfers.ElementAt(1).Gender == Gender.Female)
            {

                Difficulty2 = 19 - hole.RedStrokeIndex;
            }
            else
            {
                Difficulty2 = 19 - hole.StrokeIndex;
            }
            int handiA = Golfers.First().Handicap - Difficulty1;
            int handiB = Golfers.Last().Handicap - Difficulty2;
        
            AddScores(hole, ScoreA, ScoreB, hs, Container, handiA, handiB);
            if (hole.HoleNumber == Course.Holes.Count)
            {
              
                Gwin = MatchP.findWinnerMatchPlay();
                Winner = Golfers.ElementAt(Gwin);
                for (int i = 0; i< 5; i++)
                {
                    Golfers.ElementAt(i).WithinMatch = false;
                }
            }
            Container.Persist(ref hs);
             HoleScores.Add(hs);
        }



        public void AddScores(Hole hole, int ScoreA, int ScoreB, HoleScore hs, IDomainObjectContainer Container,int handiA, int handiB)
        {         
            if (handiA > 1)
            {
                if (handiA >= 18)
                {
                    ScoreA -= 2;
                }
                else
                {
                    ScoreA -= 1;
                }
            }
            if (handiB > 1)
            {
                if (handiB >= 18)
                {
                    ScoreB -= 2;
                }
                else
                {
                    ScoreB -= 1;
                }
            }
            if (ScoreA < ScoreB)
            {
                TotalScoreA += 1;
            }
            else if (ScoreB < ScoreA)
            {
                TotalScoreB += 1;
            }
            else
            {
            }        
            hs.Hole = hole;
            hs.GolferScores[0] = ScoreA;
            hs.GolferScores[1] = ScoreB;
        }
        public int findWinnerMatchPlay()
        {
            int gwin = 0;
            if (TotalScoreA > TotalScoreB)
            {
                gwin = 0;
            }
            else if (TotalScoreB > TotalScoreA)
            {
                gwin = 1;
            }
            else gwin = 0;
            return gwin;
        }
    }
}
