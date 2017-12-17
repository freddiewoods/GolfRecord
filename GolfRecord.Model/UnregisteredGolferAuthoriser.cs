using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class UnregisteredGolferAuthoriser : ITypeAuthorizer<UnregisteredPlayer>
    {
        public bool IsEditable(IPrincipal principal, UnregisteredPlayer player, string memberName)
        {
            return true;
        }

        public bool IsVisible(IPrincipal principal, UnregisteredPlayer player, string memberName)
        {
            if ((memberName == "FullName") | (memberName == "Handicap"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
