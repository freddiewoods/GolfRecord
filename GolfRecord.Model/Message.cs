using NakedObjects;
using NakedObjects.Value;
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

        [Optionally]
        public virtual FileAttachment Attachment
        {
            get
            {
                if (AttContent == null) return null;
                return new FileAttachment(AttContent, AttName, AttMime);
            }
        }

        [NakedObjectsIgnore]
        public virtual byte[] AttContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttName { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttMime { get; set; }

        public void AddOrChangeAttachment(FileAttachment newAttachment)
        {
            AttContent = newAttachment.GetResourceAsByteArray();
            AttName = newAttachment.Name;
            AttMime = newAttachment.MimeType;
        }



    }
}
