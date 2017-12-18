using NakedObjects;
using System.Collections.Generic;

namespace GolfRecord.Model
{
    public class Invite
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        public virtual Golfer Reciever { get; set; }

        public virtual Golfer Sender { get; set; }

        [MemberOrder(1)][Optionally]
        public virtual bool Response { get; set; }

   }
}
