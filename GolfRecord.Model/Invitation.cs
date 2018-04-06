using NakedObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Invitation
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        public virtual Golfer Sender { get; set; }

        public virtual Golfer Receiver { get; set; }

        [Title]
        public virtual InviteType inviteType { get; set; }
    }
}
