using System;
using System.Collections.Generic;
using System.Linq;
using NakedObjects;
using static GolfRecord.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace GolfRecord.Model
{
    public class Match
    {
        #region InjectedServices

        public IDomainObjectContainer Container { set; protected get; }

        public CourseServices CourseServices { set; protected get; }

        public GolferServices GolferServices { set; protected get; }

        public MatchServices MatchServices { set; protected get; }

        #endregion
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual string MatchName { get; set; }

        public virtual DateTime DateOfMatch { get; set; }

        [NakedObjectsIgnore]
        public virtual int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Golfer MatchCreator { get; set; }

        [PageSize(3)]
        public IQueryable<Course> AutoCompleteCourse([MinLength(2)] string matching)
        {
            return CourseServices.BrowseCourses().Where(c => c.CourseName.Contains(matching));
        }

        [Title]
        public virtual MatchType MatchType { get; set; }

        [Optionally]
        [Hidden(WhenTo.UntilPersisted)]
        public virtual Golfer Winner { get; set; }

        [NakedObjectsIgnore]
        public virtual bool Completed { get; set; }

        #region Add Golfers
        public void sendInvite(Golfer golfer)
        {
            if (Golfers.Contains(MatchCreator)== false)
            {
                Golfers.Add(MatchCreator);
                MatchCreator.MyMatches.Add(this);
            }
            var invite = Container.NewTransientInstance<MatchInvitation>();
            invite.match = this;
            invite.Sender = GolferServices.Me();
            invite.Receiver = golfer;
            invite.inviteType = InviteType.MatchInvite;
            Container.Persist(ref invite);
            golfer.Invites.Add(invite);
        }

        public bool HideSendInvite()
        {
            if (MatchType == MatchType.Matchplay)
            {
                return Golfers.Count > 1;
            }
            else
            {
                return Golfers.Count > 3;
            }
        }

        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0SendInvite([MinLength(2)] string name)
        {
            return GolferServices.AllGolfers().Where(g => g.FullName.Contains(name));
        }
        #endregion
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

        #region HoleScores
        private ICollection<HoleScoreAbstract> _HoleScores = new List<HoleScoreAbstract>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<HoleScoreAbstract> HoleScores
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
        public IList<Hole> Choices0AddScores()
        {
            if (HoleScores.Count == 0)
            {
                return Course.Holes.ToList();
            }
            else
            {
                // return Course.Holes.ToList();
                return (from h in Course.Holes
                        from s in HoleScores                     
                where h.Id != s.HoleId //a querry across two sources.
                 select h).ToList();
            }
        }
        public Hole Default0AddScores()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }



        #endregion
    }
}