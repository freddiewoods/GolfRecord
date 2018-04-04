using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class CourseAuthoriser : ITypeAuthorizer<Course>
    {
        public GolferServices GolferServices { get; protected set; }
        public bool IsEditable(IPrincipal principal, Course target, string memberName)
        {
            if (GolferServices.Me() == target.ClubManager)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Course target, string memberName)
        {
            if ((GolferServices.Me() == target.ClubManager) & (memberName == "AddFacility"))
            {
                return true;
            }
            else if (memberName == "AddFacility")
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
