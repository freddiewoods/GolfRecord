using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchPlay : Match //normally have 2 people playing unless its four ball better ball teams of 2.
    {
        public int TotalScoreA;
        public int TotalScoreB;
        

        public Golfer AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB, HoleScore hs, IDomainObjectContainer Container)
        {
            
          int difficulty =  19 - hole.DifficultyRating;
          int handiA = Golfers.First().Handicap - difficulty;
            int handiB = Golfers.Last().Handicap- difficulty;
            if (handiA > 1)
            {
                if (handiA > 18)
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
            hs.GolferA = ScoreA;
            hs.GolferB = ScoreB;

            if (hole.Id == 4) //To do change  to 18 just for practice
            {
                if (TotalScoreA > TotalScoreB)
                {
                    return Golfers.ElementAt(1);

                }
                else if (TotalScoreB > TotalScoreA)
                {
                    return Golfers.ElementAt(2);
                }

             }
            return null;
        }
       
     }
}
