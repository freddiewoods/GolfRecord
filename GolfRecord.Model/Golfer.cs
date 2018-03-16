﻿using NakedObjects;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static GolfRecord.Model.Enums;
using System.Security;
using NakedObjects.Value;

namespace GolfRecord.Model
{
    public class Golfer
    {
        //All persisted properties on a domain object must be 'virtual'
        public IDomainObjectContainer Container { set; protected get; }

        public GolferServices GolferConfig { set; protected get; }

        public CourseServices CourseConfig { set; protected get; }

        public MatchServices MatchConfig { set; protected get; }
       
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [MemberOrder(2)] //this property is not neccessary
        public virtual int Handicap { get; set; }

        [Optionally][MemberOrder(4)]
        public virtual string Mobile { get; set; }

        [Optionally]
        public virtual Gender Gender { get; set; }

        public virtual Title Position { get; set; }

        public virtual string Username { get; set; }

        #region Friends (collection)
        private ICollection<Golfer> _Friends = new List<Golfer>();

          public virtual ICollection<Golfer> Friends
          {
              get
              {
                  return _Friends;
             }
              set
             {
                  _Friends = value;
              }
          }

          public void AddFriend(Golfer golfer)
          {
              Friends.Add(golfer);
        
          }
          [PageSize(3)]
          public IQueryable<Golfer> AutoComplete0AddFriend([MinLength(2)] string matching)
          {
              return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(matching));
          }
          #endregion

        #region MatchHistory (collection)
        private  ICollection<Match> _MatchHistory = new List<Match>();

        public virtual ICollection<Match> MatchHistory
        {
            get
            {
                return _MatchHistory;
            }
            set
            {
                _MatchHistory = value;
            }
        }
        public void AddMatchHistory(Match match)
        {
            MatchHistory.Add(match);
        }
        public IQueryable<Match> AutoComplete0AddMatchHistory([MinLength(2)] string matching)
        {
            return MatchConfig.ShowMatches().Where(m => m.MatchName.Contains(matching));
        }
        #endregion

        #region Groups

        public Group CreateNewGroup()
        {
            var group = Container.NewTransientInstance<Group>(); //Need to automatically add the leader
            group.GroupOwner = GolferConfig.Me();
            return group;
        }
      
        private ICollection<Group> _Groups = new List<Group>();

        public virtual ICollection<Group> Groups
        {
            get
            {
                return _Groups;
            }
            set
            {
                _Groups = value;
            }
        }
        #endregion

        // #region Invitations
        //    private ICollection<Invite> _Invitations = new List<Invite>();

        //    public virtual ICollection<Invite> Invitations
        //    {
        //       get
        //        {
        //            return _Invitations;
        //        }
        //        set
        //        {
        //            _Invitations = value;
        //        }
        //    }

        //       public void Sendmessage(Golfer golfer)
        //        {
        //            var invite =  GolferConfig.SendInvite(golfer);
        //            GolferConfig.Me().Invite = invite;
        //        }

        //  [PageSize(3)]
        //  public IQueryable<Golfer> AutoComplete0Sendmessage([MinLength(2)] string name)
        //  {
        //    return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(name));
        //  }
        // #endregion
    }
}

