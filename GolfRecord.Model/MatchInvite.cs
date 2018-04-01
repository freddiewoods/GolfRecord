using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class MatchInvite : Invite
    {
        public IDomainObjectContainer Container;
        [Title]
        public virtual Match match { get; set; }

        public virtual Golfer Reciever { get; set; }

        }
}
