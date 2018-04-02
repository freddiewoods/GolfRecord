using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Group
    {
        public IDomainObjectContainer Container { set; protected get; }

        public GolferServices GolferServices { set; protected get; }

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]
        public virtual string Name { get; set; }

        public virtual Golfer GroupOwner { get; set; }

        #region GroupMembers (collection)
        private ICollection<Golfer> _Members = new List<Golfer>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Golfer> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }
        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0AddNewMember([MinLength(2)] string name)
        {
            return GolferServices.AllGolfers().Where(g => g.FullName.Contains(name));
        }

        public void AddNewMember(Golfer golfer)
        {
            var invite = Container.NewTransientInstance<GroupInvite>();
            invite.group = this;
            invite.Sender = GolferServices.Me();
            invite.Receiver = golfer;
            Container.Persist(ref invite);
            golfer.Invites.Add(invite);
        }


        public void RequestToJoin()
        {
            var invite = Container.NewTransientInstance<RequestToJoin>();
            invite.group = this;
            invite.Sender = GolferServices.Me();
            invite.Receiver = GroupOwner;
            Container.Persist(ref invite);
            GroupOwner.Invites.Add(invite);
        }
        #endregion

        #region GroupMessages
        private ICollection<GroupMessage> _Messages = new List<GroupMessage>();

        public virtual ICollection<GroupMessage> Messages
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


        public GroupMessage SendGroupMessage()
        {
            GroupMessage m = Container.NewTransientInstance<GroupMessage>();
            m.Sender = GolferServices.Me();
            m.SendersName = GolferServices.Me().FullName;
            m.Content = ("Please press edit to enter your response.");
            Container.Persist(ref m);
            Messages.Add(m);
            return m;
        }


            #endregion
        }
}


