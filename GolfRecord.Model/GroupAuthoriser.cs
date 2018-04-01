using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class GroupAuthoriser : ITypeAuthorizer<Group>
    {

        public GolferServices GolferConfig { set; protected get; }

        public bool IsEditable(IPrincipal principal, Group target, string memberName)
        {
            if (target.GroupOwner == GolferConfig.Me())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Group target, string memberName)
        {
            if (target.Members.Contains(GolferConfig.Me()) == true)
            {
                return true;
            }
            else if ((target.Members.Contains(GolferConfig.Me()) == false) & (memberName == "Messages"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
