using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class GroupInvitation:Invitation
    {
        public IDomainObjectContainer Container;
        public virtual Group group { get; set; }

        }
}
