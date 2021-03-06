﻿using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class HoleAuthorier : ITypeAuthorizer<Hole>
    {
        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, Hole target, string memberName)
        {
            if (target.Course.ClubManager == GolferServices.Me())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Hole target, string memberName)
        {
            if ((GolferServices.Me().Position == Enums.Title.ClubManager) & (memberName == "AddOrChangeAttachment"))
            {
                return true;
            }
            if (((target.LadiesRedYards == 0) & (memberName == "LadiesRedYards"))
                | ((target.Name == null) & (memberName == "Name"))
                | ((target.RedPar == 0) & (memberName == "RedPar"))
                | ((target.RedStrokeIndex == 0) & (memberName == "RedStrokeIndex"))
                | ((target.WhiteYards == 0) & (memberName == "WhiteYards"))
                | ((target.YellowYards == 0) & (memberName == "YellowYards"))
                | (memberName == "AddOrChangeAttachment"))               
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
