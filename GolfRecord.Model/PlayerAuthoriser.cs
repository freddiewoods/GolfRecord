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
        public bool IsEditable(IPrincipal principal, Player player, string memberName)
        {
            if (player.Username == principal.Identity.Name)
            {
                if ((memberName == "Position" ) | (memberName == "Username"))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Player player, string memberName)
        {
            if (player.Username == principal.Identity.Name)
            {
                return true;
            }
            else if ((memberName == "AddFavouriteCourses") | (memberName == "AddRegisteredGolfers") | (memberName == "AddMatchHistory") | (memberName == "AddFriend"))
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
