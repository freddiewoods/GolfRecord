using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Message
    {
        public IDomainObjectContainer Container { set; protected get; }

        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title][MemberOrder(1)]
        public virtual string SendersName { get; set; }

        public virtual Golfer Sender { get; set; }

        public virtual string Content { get; set; }

    }
}
