﻿using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
   public  class HoleScoreMP
    {
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [NakedObjectsIgnore]
        public virtual int HoleId { get; set; }

        public virtual Hole Hole { get; set; }

        public virtual int GolferA { get; set; }

        public virtual int GolferB { get; set; }
    }
}
