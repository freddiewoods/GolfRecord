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
        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, ClubManager manager, string memberName)
        {
            if ((manager.Username == principal.Identity.Name) & (memberName == "Course")
                | (memberName == "Username")
                | (memberName == "Position"))
            {
                return false;
            }
            else if (manager.Username == principal.Identity.Name)
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
            if ((manager != GolferServices.Me()) & ((memberName == "PrivateAccount")
                                                     | (memberName == "CreateNewGroup")
                                                     | (memberName == "CreateNewMatch")))
            {
                return false;
            }
            else if ((manager.PrivateAccount == true) & (memberName == "Mobile")
                                                  | (memberName == "Username"))
            {
                return false;
            }
            else if (memberName == "AddMatchHistory")
            {
                return false;
            }
            else if (((manager.Friends.Count == 0) & (memberName == "Friends"))
                    | ((manager.Groups.Count == 0) & (memberName == "Groups"))
                    | ((manager.Invites.Count == 0) & (memberName == "Invites"))
                    | ((manager.Messages.Count == 0) & (memberName == "Messages"))
                    | ((manager.MatchHistory.Count == 0) & (memberName == "MatchHistory")))

            {
                return false;
            }
            else if ((manager.Username == principal.Identity.Name) & (memberName == "SendMessage"))
            {
                return false;
            }
            else if ((manager.Username == principal.Identity.Name) &
                    ((manager.Invites.Count == 0) & ((memberName == "AcceptFriendship")
                                                      | (memberName == "AcceptGroup")
                                                      | (memberName == "AcceptMatch")
                                                      | (memberName == "DeclineInvite")
                                                      | (memberName == "AcceptGroupMember"))
                    | ((manager.Messages.Count == 0) & (memberName == "DeleteMessage")))
                    | ((manager.MatchHistory.Count == 0) & (memberName == "MatchHistory")))
            {
                return false;
            }
            else if ((manager.Username != principal.Identity.Name) & ((memberName == "AcceptFriendship")
                                                                   | (memberName == "AcceptGroup")
                                                                   | (memberName == "AcceptGroupMember")
                                                                   | (memberName == "AcceptMatch")
                                                                   | (memberName == "DeclineInvite")
                                                                   | (memberName == "DeleteMessage")
                                                                   | (memberName == "AcceptGroupMember")))
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
