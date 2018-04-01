using NakedObjects;
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

        [Optionally][MemberOrder(3)]
        public virtual string Mobile { get; set; }

        [Optionally]
        public virtual Gender Gender { get; set; }

        public virtual Title Position { get; set; }

        public virtual string Username { get; set; }

        public virtual bool PrivateAccount { get; set; }

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
            var invite = Container.NewTransientInstance<FriendInvite>();
            invite.Sender = GolferConfig.Me();
            invite.Receiver = golfer;
            Container.Persist(ref invite);
            golfer.Invites.Add(invite);

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
            var group = Container.NewTransientInstance<Group>();
            group.GroupOwner = GolferConfig.Me();
            group.Name = (GolferConfig.Me().FullName + "'s group");
            Container.Persist(ref group);
            GolferConfig.Me().Groups.Add(group);
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

        private ICollection<Invite> _Invites = new List<Invite>();

        public virtual ICollection<Invite> Invites
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

        public void DeclineInvite(Invite invite)
        {
            Container.DisposeInstance(this);
        }

        public void AcceptFriendship(FriendInvite invite)
        {
            invite.Sender.Friends.Add(invite.Receiver);
            invite.Receiver.Friends.Add(invite.Sender);
            Container.DisposeInstance(invite);
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
            return AmountOfInvites < 0;
        }

        public void AcceptGroupMember(RequestToJoin invite)
        {
            invite.group.Members.Add(invite.Sender);
            Container.DisposeInstance(invite);
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
            return AmountOfInvites < 0;
        }

        public void AcceptGroup(GroupInvite invite)
        {
           invite.group.Members.Add(invite.Receiver);
           Container.DisposeInstance(invite);
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
            return AmountOfInvites < 0;
        }


        public void AcceptMatch(MatchInvite invite)
        {
            invite.match.Golfers.Add(invite.Receiver);
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
            return AmountOfInvites < 0;
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
            m.Sender = GolferConfig.Me();
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

