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
        public int Difficulty;
        public void AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB, HoleScore hs, IDomainObjectContainer Container,int handiA, int handiB)
        {
            Difficulty =  19 - hole.StrokeIndex;           
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
            hs.GolferA = ScoreA;
            hs.GolferB = ScoreB;
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
