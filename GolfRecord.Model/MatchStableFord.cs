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
        [NakedObjectsIgnore]
        public virtual int TotalScoreA { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreB { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreC { get; set; }

        //[NakedObjectsIgnore]
        public virtual int TotalScoreD { get; set; }

        [NakedObjectsIgnore]
        public virtual int ParA { get; set; }

        [NakedObjectsIgnore]
        public virtual int ParB { get; set; }

        [NakedObjectsIgnore]
        public virtual int ParC { get; set; }

        [NakedObjectsIgnore]
        public virtual int ParD { get; set; }

        public void AddScoreStableford(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD, HoleScore hs, IDomainObjectContainer Container, int handiA, int handiB, int handiC, int handiD, int ParForM1, int ParForM2, int ParForM3, int ParForM4)
        {
            hs.Hole = hole;
            hs.GolferA = ScoreA;
            hs.GolferB = ScoreB;
            hs.GolferC = ScoreC;
            hs.GolferD = ScoreD;
            HoleScores.Add(hs);
            if (handiA >= 1)
            {
                if (handiA >= 18 & ParForM1 == 2)
                {
                    ParA = hs.Hole.Par + 2;
                }
                else if (handiA >= 1 & handiA < 18 & ParForM1 == 2)
                {
                    ParA = hs.Hole.Par + 1;
                }
                else if (handiA >= 18 & ParForM1 == 1)
                {
                    ParA = hs.Hole.RedPar + 2;
                }
                else if (handiA >= 1 & handiA < 18 & ParForM1 == 1)
                {
                    ParA = hs.Hole.RedPar + 1;
                }
            }
            if (handiB >= 1)
            {
                if (handiB >= 18 & ParForM2 == 2)
                {
                    ParB = hs.Hole.Par + 2;
                }
                else if (handiB >= 1 & handiB < 18 & ParForM2 == 2)
                {
                    ParB = hs.Hole.Par + 1;
                }
                else if (handiB >= 18 & ParForM2 == 1)
                {
                    ParB = hs.Hole.RedPar + 2;
                }
                else if (handiB >= 1 & handiB < 18 & ParForM2 == 1)
                {
                    ParB = hs.Hole.RedPar + 1;
                }
            }
            if (handiC >= 1)
            {
                if (handiC >= 18 & ParForM3 == 2)
                {
                    ParC = hs.Hole.Par + 2;
                }
                else if (handiC >= 1 & handiC < 18 & ParForM3 == 2)
                {
                    ParC = hs.Hole.Par + 1;
                }
                else if (handiC >= 18 & ParForM3 == 1)
                {
                    ParC = hs.Hole.RedPar + 2;
                }
                else if (handiC >= 1 & handiC < 18 & ParForM3 == 1)
                {
                    ParC = hs.Hole.RedPar + 1;
                }
            }
            if (handiD >= 1)
            {
                if (handiD >= 18 & ParForM4 == 2)
                {
                    ParD = hs.Hole.Par + 2;
                }
                else if (handiD >= 1 & handiD < 18 & ParForM4 == 2)
                {
                    ParD = hs.Hole.Par + 1;
                }
                else if (handiD >= 18 & ParForM4 == 1)
                {
                    ParD = hs.Hole.RedPar + 2;
                }
                else if (handiD >= 1 & handiD < 18 & ParForM4 == 1)
                {
                    ParD = hs.Hole.RedPar + 1;
                }
            }
            if (ScoreA - ParA == 1)
            {
                TotalScoreA += 1;
            }
            else if (ScoreA - ParA == 0)
            {
                TotalScoreA += 2;
            }
            else if (ScoreA - ParA < 0)
            {
                TotalScoreA += 3;
            }
            else
            {
                TotalScoreA += 0;
            }
            // works out how many points won by golfer A

            if (ScoreB - ParB == 1)
            {
                TotalScoreB += 1;
            }
            else if (ScoreB - ParB == 0)
            {
                TotalScoreB += 2;
            }
            else if (ScoreB - ParB < 0)
            {
                TotalScoreB += 3;
            }
            else
            {
                TotalScoreB += 0;
            }

            if (ScoreC - ParC == 1)
            {
                TotalScoreC += 1;
            }
            else if (ScoreC - ParC == 0)
            {
                TotalScoreC += 2;
            }
            else if (ScoreC - ParC < 0)
            {
                TotalScoreC += 3;
            }
            else
            {
                TotalScoreC += 0;
            }

            if (ScoreD - ParD == 1)
            {
                TotalScoreD += 1;
            }
            else if (ScoreD - ParD == 0)
            {
                TotalScoreD += 2;
            }
            else if (ScoreD - ParD < 0)
            {
                TotalScoreD += 3;
            }
            else
            {
                TotalScoreD += 0;
            }
        }
        [NakedObjectsIgnore]
        public int FindWinnerStableFord()
        {
            List<int> Scores = new List<int>();
            Scores.Add(TotalScoreA);
            Scores.Add(TotalScoreB);
            Scores.Add(TotalScoreC);
            Scores.Add(TotalScoreD);
            int gwin = 0;
            if (Scores.Min() == TotalScoreA)
            {
                gwin = 0;
                
            }
            else if (Scores.Min() == TotalScoreB)
            {
                gwin = 1;
             
            }
            else if (Scores.Min() == TotalScoreC)
            {
                gwin = 2;
                
            }
            else if (Scores.Min() == TotalScoreD)
            {
                gwin = 3;
            }
            return gwin;
        }
    }

}

