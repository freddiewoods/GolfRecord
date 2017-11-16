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
            var hs = Container.NewTransientInstance<HoleScoreMP>();
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
            MatchP.AddScoreMatchPlay(hole, ScoreA, ScoreB, hs, Container, handiA, handiB);
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
            HoleScoreMatchPlay.Add(hs);
        }



        public void AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB, HoleScoreMP hs, IDomainObjectContainer Container,int handiA, int handiB)
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

        #region HoleScoresMatchPlay
        private ICollection<HoleScoreMP> _HoleScoreMatchPlay = new List<HoleScoreMP>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<HoleScoreMP> HoleScoreMatchPlay
        {
            get
            {
                return _HoleScoreMatchPlay;
            }
            set
            {
                _HoleScoreMatchPlay = value;
            }
        }
        public IList<Hole> Choices0AddScoreMatchPlay()
        {
            return Course.Holes.ToList();
        }
        public Hole Default0AddScoreMatchPlay()
        {
            int nextHole = 1;
            if (HoleScoreMatchPlay.Count > 0)
            {
                nextHole = HoleScoreMatchPlay.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }

        public bool HideHoleScoreMatchPlay()
        {
            return (MatchType != MatchType.MatchPlay) | (Golfers.Count != 2);
        }

        #endregion
        public bool HideAddScoreMatchPlay()
        {
            return MatchType != MatchType.MatchPlay;
        }

    }
}
