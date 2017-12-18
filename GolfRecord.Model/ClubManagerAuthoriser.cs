using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class ClubManagerAuthoriser : ITypeAuthorizer<ClubManager>
    {
        public bool IsEditable(IPrincipal principal, ClubManager manager, string memberName)
        {
            if (manager.Username == principal.Identity.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, ClubManager manager, string memberName)
        {
            if (memberName == "AddMatchHistory")
            {
                return false;
            }
            else if (((manager.Friends.Count == 0) & (memberName == "Friends"))
                    | ((manager.Groups.Count == 0) & (memberName == "Groups")))
            {
                return false;
            }
            else if (manager.Username == principal.Identity.Name)
            {
                return true;
            }
            else
            {
                if ((memberName == "Mobile") | (memberName == "AddFriend") | (memberName == "AddCourseToFavourites"))
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
}
