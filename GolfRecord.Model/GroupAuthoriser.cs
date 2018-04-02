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

        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, Group target, string memberName)
        {
            if (target.GroupOwner == GolferServices.Me())
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
            if (((target.GroupOwner == GolferServices.Me()) | (target.Members.Contains(GolferServices.Me()))) & (memberName == "RequestToJoin"))
            {
                return false;
            }
            else if (target.Members.Contains(GolferServices.Me()) == true)
            {
                return true;
            }
            else if ((target.Members.Contains(GolferServices.Me()) == false) & (memberName == "Messages"))
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
