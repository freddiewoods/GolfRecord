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

        [Optionally]
        public virtual bool Response { get; set; }

        [Title]
        public virtual Match match { get; set; }

        public void AcceptInvite()
        {
            Response = true;
            this.match.Golfers.Add(this.Reciever);
        }
   }
}
