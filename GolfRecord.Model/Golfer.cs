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

        public GolferServices GolferServices { set; protected get; }

        public CourseServices CourseServices { set; protected get; }

        public MatchServices MatchServices { set; protected get; }

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]
        [MemberOrder(1)]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [MemberOrder(2)] //this property is not neccessary
        public virtual int Handicap { get; set; }

        [MemberOrder(3)][Optionally]
        public virtual string Mobile { get; set; }
        public string ValidateMobile(string Mobile)
        {
            if ((Mobile.ElementAt(0) == '+') & (Mobile.Length == 13))
            {
                return null;
            }
            else if ((Mobile.ElementAt(0) == '0') & (Mobile.Length == 11))
            {
                return null;
            }
            else
            {
            return ("Incorrect length of mobile number please check");
        }
    
        }

        [Optionally]
        public virtual Gender Gender { get; set; }

        public virtual Title Position { get; set; }

        public virtual string Username { get; set; }

        public virtual bool PrivateAccount { get; set; }

        public Match CreateNewMatch(MatchType matchtype)
        {
            var m = MatchServices.CreateNewMatch(matchtype);
            return m;
        }

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
            var invite = Container.NewTransientInstance<FriendInvitation>();
            invite.Sender = GolferServices.Me();
            invite.Receiver = golfer;
            invite.inviteType = InviteType.FriendInvite;
            Container.Persist(ref invite);
            golfer.Invites.Add(invite);

        }
          [PageSize(3)]
          public IQueryable<Golfer> AutoComplete0AddFriend([MinLength(2)] string matching)
          {
            return GolferServices.AllGolfers().Where(g => (g.FullName.Contains(matching)));
            //& (g.Friends.Contains(GolferServices.Me())))));
          }
          #endregion

        #region MyMatches (collection)
        private  ICollection<Match> _MyMatches = new List<Match>();

        public virtual ICollection<Match> MyMatches
        {
            get
            {
                return _MyMatches;
            }
            set
            {
                _MyMatches = value;
            }
        }
        public void AddMatch(Match match)
        {
            MyMatches.Add(match);
        }
        #endregion

        #region Groups
        public Group CreateNewGroup()
        {
            var group = Container.NewTransientInstance<Group>();
            group.GroupOwner = GolferServices.Me();
            group.Name = (GolferServices.Me().FullName + "'s group");
            Container.Persist(ref group);
            GolferServices.Me().Groups.Add(group);
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

        #region Invites

        private ICollection<Invitation> _Invites = new List<Invitation>();

        public virtual ICollection<Invitation> Invites
        {
            get
            {
                return _Invites;
            }
            set
            {
                _Invites = value;
            }
        }

        public void DeclineInvite(Invitation invite)
        {
            Container.DisposeInstance(invite);
        }

        public void AcceptFriendship(FriendInvitation invite)
        {
            if (invite.Sender.Friends.Contains(invite.Receiver))
            {
                Container.DisposeInstance(invite);
            }
            else
            {
                invite.Sender.Friends.Add(invite.Receiver);
                invite.Receiver.Friends.Add(invite.Sender);
                Container.DisposeInstance(invite);
            }
        }

        public string ValidateAcceptFriendship(Invitation invite)
        {
            if (invite.inviteType == InviteType.FriendInvite)
            {
                if (invite.Receiver.Friends.Contains(invite.Sender))
                {
                    return ("You are already friends with this person please delete the invite");
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return ("This is not an Friend Invitation");
            }
        }

        public bool HideAcceptFriendship()
        {
            int AmountOfInvites = 0;
            for (int i = 0; i < Invites.Count; i++)
            {
                if (Invites.ElementAt(i).inviteType == InviteType.FriendInvite)
                {
                    AmountOfInvites += 1;
                }
            }
            return AmountOfInvites == 0;
        }

        public void AcceptGroupMember(RequestToJoin invite)
        {
            if (invite.group.Members.Contains(invite.Sender))
            {
                Container.DisposeInstance(invite);
            }
            else
            {
                invite.group.Members.Add(invite.Sender);
                Container.DisposeInstance(invite);
            }
        }
        public bool HideAcceptGroupMember()
        {
            int AmountOfInvites = 0;
            for (int i = 0; i < Invites.Count; i++)
            {
                if (Invites.ElementAt(i).inviteType == InviteType.RequestToJoin)
                {
                    AmountOfInvites += 1;
                }
            }
            return AmountOfInvites == 0;
        }

        public void AcceptGroup(GroupInvitation invite)
        {
            if (invite.group.Members.Contains(invite.Receiver))
            {
                Container.DisposeInstance(invite);
            }
            else
            {
                invite.group.Members.Add(invite.Receiver);
                Container.DisposeInstance(invite);
            }
        }
        public bool HideAcceptGroup()
        {
            int AmountOfInvites = 0;
            for (int i = 0; i < Invites.Count; i++)
            {
                if (Invites.ElementAt(i).inviteType == InviteType.GroupInvite)
                {
                    AmountOfInvites += 1;
                }
            }
            return AmountOfInvites == 0;
        }


        public void AcceptMatch(MatchInvitation invite)
        {
            if ((invite.match.MatchType == MatchType.Matchplay) & (invite.match.Golfers.Count == 2))
            {
                PlayerMessage msg = Container.NewTransientInstance<PlayerMessage>();
                msg.Content = "This match is already full";
                Container.Persist(ref msg);
                Messages.Add(msg);

            }
            else if (invite.match.Golfers.Count == 4)
            {
                var msg = Container.NewTransientInstance<PlayerMessage>();
                msg.Content = "This match is already full";
                Container.Persist(ref msg);
                Messages.Add(msg);
            }

            else if (invite.match.Golfers.Contains(invite.Receiver))
            {
                var msg = Container.NewTransientInstance<PlayerMessage>();
                msg.Content = "You are already appart of this match";
                Container.Persist(ref msg);
                Messages.Add(msg);
            }
            {
                invite.match.Golfers.Add(invite.Receiver);
            }
            

            Container.DisposeInstance(invite);
        }
        public bool HideAcceptMatch()
        {

            int AmountOfInvites = 0;
            for (int i = 0; i < Invites.Count; i++)
            {
                if (Invites.ElementAt(i).inviteType == InviteType.MatchInvite)
                {
                    AmountOfInvites += 1;
                }
            }
            return AmountOfInvites == 0;
        }
        #endregion

        #region Messages
        private ICollection<PlayerMessage> _Messages = new List<PlayerMessage>();

        public virtual ICollection<PlayerMessage> Messages
        {
            get
            {
                return _Messages;
            }
            set
            {
                _Messages = value;
            }
        }

        public PlayerMessage SendMessage()
        {
            PlayerMessage m = null;
            m = Container.NewTransientInstance<PlayerMessage>();
            m.Reciever = this;
            m.Sender = GolferServices.Me();
            m.SendersName = m.Sender.FullName;
            m.Content = ("Please Press Edit To Change");            
            Container.Persist(ref m);
            m.Reciever.Messages.Add(m);
            return m;
        }

        public void DeleteMessage(PlayerMessage m)
        {
            Container.DisposeInstance(m);
        }
        #endregion
    }
}

