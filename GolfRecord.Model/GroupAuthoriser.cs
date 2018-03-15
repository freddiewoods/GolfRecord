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
           
        return true;
   
        }

        public bool IsVisible(IPrincipal principal, Group target, string memberName)
        {
                return true;
            
        }
    }
}
