﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class RequestToJoin: Invite
    {

        public virtual Group group { get; set; }

    }
}
