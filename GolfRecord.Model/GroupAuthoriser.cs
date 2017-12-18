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
        public bool IsEditable(IPrincipal principal, Group target, string memberName)
        {
            if (target.GroupOwner.Username == principal.Identity.Name)
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
            if ((memberName == "AddMember") & (target.GroupOwner.Username == principal.Identity.Name))
            {
                return true;
            }
            else if ((memberName == "AddMember") & !(target.GroupOwner.Username == principal.Identity.Name))
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
