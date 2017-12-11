using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using NakedObjects.Util;

namespace GolfRecord.Model
{
    public class GolferAuthoriser : ITypeAuthorizer<Golfer>
    {
        public bool IsEditable(IPrincipal principal, Golfer target, string memberName)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(IPrincipal principal, Golfer target, string memberName)
        {
            if (target.Title == Enums.Title.ClubManager)
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
