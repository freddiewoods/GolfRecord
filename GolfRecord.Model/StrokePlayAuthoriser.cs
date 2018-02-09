using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class StrokePlayAuthoriser : ITypeAuthorizer<MatchStrokePlay>
    {
        public GolferConfig GolferConfig { set; protected get; }

        public bool IsEditable(IPrincipal principal, MatchStrokePlay match, string memberName)
        {
          //  if (match.Golfers.Contains(GolferConfig.Me()) == false)
          //  {
          //      return false;
          //  }
          //  else
 if ((memberName == "Winner") | (memberName == "MatchType"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsVisible(IPrincipal principal, MatchStrokePlay match, string memberName)
        {
               if ((match.Golfers.Contains(GolferConfig.Me()) == false) & (memberName == "AddScores"))
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
