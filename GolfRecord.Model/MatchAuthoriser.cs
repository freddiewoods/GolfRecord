using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class MatchAuthoriser : ITypeAuthorizer<Match>
    {

        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, Match match, string memberName)
        {
            if ((match.Golfers.Contains(GolferServices.Me())) | (match.MatchCreator == GolferServices.Me()))
            {
                return true;
            }
           else
            {
                return false;
            }
        }

       public bool IsVisible(IPrincipal principal, Match match, string memberName)
        {
            if ((memberName == "CreateNewMatch") & !(principal.Identity.Name == GolferServices.Me().Username))
                {
                    return false;
                }
                else if (match.Golfers.Contains(GolferServices.Me()))
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
