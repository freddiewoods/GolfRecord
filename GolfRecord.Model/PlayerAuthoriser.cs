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
        public GolferServices GolferServices { set; protected get; }

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
            if ((GolferServices.Me().FullName == null) & ((memberName == "SendMessage") | (memberName == "AddMatch")))
            {
                return false;
            }
            else
               if ((player != GolferServices.Me()) & ((memberName == "PrivateAccount")
                                                        | (memberName == "CreateNewGroup")
                                                        | (memberName == "CreateNewMatch")))
            {
                return false;
            }
            else if ((player.Username == GolferServices.Me().Username ) & ((player.PrivateAccount == true) & (memberName == "Mobile")
                                                 | (memberName == "Username")))
            {
                return true;
            }
            else if ((player.PrivateAccount == true) & ((memberName == "Mobile")
                                                 | (memberName == "Username")))
            {
                return false;
            }
            else if (memberName == "AddMatchHistory")
            {
                return false;
            }
            else if (((player.Friends.Count == 0) & (memberName == "Friends"))
                    | ((player.Groups.Count == 0) & (memberName == "Groups"))
                    | ((player.Invites.Count == 0) & (memberName == "Invites"))
                    | ((player.Messages.Count == 0) & (memberName == "Messages"))
                    | ((player.MyMatches.Count == 0) & (memberName == "MyMatches")))

            {
                return false;
            }
            else if ((player.Username == principal.Identity.Name) & (memberName == "SendMessage"))
            {
                return false;
            }
            else if ((player.Username == principal.Identity.Name) &
                    ((player.Invites.Count == 0) & ((memberName == "AcceptFriendship")
                                                      | (memberName == "AcceptGroup")
                                                      | (memberName == "AcceptGroupMember")
                                                      | (memberName == "AcceptMatch")
                                                      | (memberName == "DeclineInvite"))
                    | ((player.Messages.Count == 0) & (memberName == "DeleteMessage")))
                    | ((player.MyMatches.Count == 0) & (memberName == "MyMatches"))
                    | ((player.FavouriteCourses.Count == 0) & (memberName == "FavouriteCourses")))
            {
                return false;
            }
            else if ((player.Friends.Contains(GolferServices.Me())) & (memberName == "AddFriend"))
            {
                return false;
            }
            else if ((player.Username != principal.Identity.Name) & ((memberName == "AcceptFriendship")
                                                                   | (memberName == "AcceptGroup")
                                                                   | (memberName == "AcceptGroupMember")
                                                                   | (memberName == "AcceptMatch")
                                                                   | (memberName == "DeclineInvite")
                                                                   | (memberName == "DeleteMessage")))
            {
                return false;
            }
            else if (player.Username == principal.Identity.Name)
            {
                return true;
            }
            else
            {
                if ((memberName == "AddFriend") | (memberName == "AddCourseToFavourites"))
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
