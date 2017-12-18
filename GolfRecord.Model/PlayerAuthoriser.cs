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
            if (memberName == "AddMatchHistory")
            {
                return false;
            }
            else if (((player.FavouriteCourses.Count == 0) & (memberName == "FavouriteCourses"))
                    | ((player.Friends.Count == 0) & (memberName == "Friends"))
                    | ((player.Groups.Count == 0) &(memberName == "Groups")))
            {
                return false;
            }
            else if (player.Username == principal.Identity.Name)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
