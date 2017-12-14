using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class PlayerAuthoriser : ITypeAuthorizer<Player>
    {
        public bool IsEditable(IPrincipal principal, Player target, string memberName)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(IPrincipal principal, Player target, string memberName)
        {
            throw new NotImplementedException();
        }
    }
}
