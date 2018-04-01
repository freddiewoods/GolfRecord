using NakedObjects;
using System.Collections.Generic;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Invite
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        public virtual Golfer Sender { get; set; }

    }
}
