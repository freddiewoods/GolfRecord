using NakedObjects;
using System.Collections.Generic;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Invitation
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        public virtual Golfer Sender { get; set; }

        public virtual Golfer Receiver { get; set; }

        public virtual InviteType inviteType { get; set; }
    }
}
