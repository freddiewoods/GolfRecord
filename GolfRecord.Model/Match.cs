﻿using System;
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

        public CourseServices CourseConfig { set; protected get; }

        public GolferServices GolferConfig { set; protected get; }

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
            return CourseConfig.BrowseCourses().Where(c => c.CourseName.Contains(matching));
        }

        [Title]
        public virtual MatchType MatchType { get; set; }


        [Optionally]
        [Hidden(WhenTo.UntilPersisted)]
        public virtual Golfer Winner { get; set; }

        [NakedObjectsIgnore]
        public virtual bool Completed { get; set; }

        #region Add Golfers
        public void AddRegisteredGolfers(Golfer Golfer)
        {
            if (MatchType == MatchType.MatchPlay & Golfers.Count < 2)
            {
                if (Golfers.Contains(GolferConfig.Me()) == false)
                {
                    Golfers.Add(GolferConfig.Me());
                }
                Golfers.Add(Golfer);
            }
            else if (MatchType == MatchType.StrokePlay & Golfers.Count < 4)
            {
                Golfers.Add(Golfer);
            }
            else if (MatchType == MatchType.StableFord & Golfers.Count < 4)
            {
                Golfers.Add(Golfer);
            }
            else
            {
                Container.InformUser("Too many players in this match or golfer is already in a match");
            }
        }


        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0AddRegisteredGolfers([MinLength(2)] string name)
        {
            return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(name));
        }

        public bool HideAddRegisteredGolfers()
        {
            if (MatchType == MatchType.MatchPlay)
            {
                return Golfers.Count > 1;
            }
            else 
            {
                return Golfers.Count > 3;
            }
        }

        public void sendInvite(Golfer golfer)
        {

            var invite = Container.NewTransientInstance<MatchInvite>();
            invite.match = this;
            invite.Sender = GolferConfig.Me();
            invite.Reciever = golfer;
            Container.Persist(ref invite);
            golfer.Invites.Add(invite);
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