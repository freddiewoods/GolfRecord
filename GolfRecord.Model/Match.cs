using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;
using NakedObjects.Menu;
using static GolfRecord.Model.Enums;

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

        public virtual MatchType MatchType { get; set; }

 
        public virtual int TotalScoreA { get; set; }
        
        public virtual int TotalScoreB { get; set; }

        public virtual int TotalScoreC { get; set; }


        public virtual int TotalScoreD { get; set; }


        public virtual String Winner { get; set; }

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

            if (MatchType == MatchType.StrokePlay)
            {
                MatchStrokePlay match = new MatchStrokePlay();
                match.AddScoreStrokePlay(hole, ScoreA, ScoreB, ScoreC, ScoreD);
            }
            else if (MatchType == MatchType.MatchPlay)
            {
                MatchPlayL match = new MatchPlayL();
                match.AddScoreMatchPlay(hole, ScoreA, ScoreB, ScoreC, ScoreD);
            }
        }
    }
}