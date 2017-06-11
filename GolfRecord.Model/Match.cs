using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;
using NakedObjects.Menu;

namespace GolfRecord.Model
{
    public class Match
    {
        #region InjectedServices

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual string MatchName { get; set; }

        public virtual DateTime DateOfMatch { get; set; }

        [NakedObjectsIgnore]
        public virtual int CourseID { get; set; }

        public virtual Course Course { get; set; }

       // public virtual MatchType matchType { get; set; }

        public void AddGolfers(Golfer Golfer)
        {
            Golfers.Add(Golfer);
        }

        #region Golfers (collection)
        private ICollection<Golfer> _Golfers = new List<Golfer>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Golfer> Golfers
        {
            get
            {
                return _Golfers;
            }
            set
            {
                _Golfers = value;
            }
        }
        #endregion

        // public enum MatchType { StrokePlay = 1, MatchPlay = 2, Foursome = 3, StableFord = 4 }
        private ICollection<HoleScore> _HoleScores = new List<HoleScore>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<HoleScore> HoleScores
        {
            get
            {
                return _HoleScores;
            }
            set
            {
                _HoleScores = value;
            }
        }
        public void AddScore(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            hs.Hole = hole;
            hs.GolferA= ScoreA;
            hs.GolferB = ScoreB;
            hs.GolferC = ScoreC;
            hs.GolferD = ScoreD;    
            Container.Persist(ref hs);
            HoleScores.Add(hs);
    }

        public IList<Hole> Choices0AddScore()
        {
            return Course.Holes.ToList();
        }


        public Hole Default0AddScore()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
                return Course.Holes.First(h => h.HoleNumber == nextHole);
            
        }

    }
}
