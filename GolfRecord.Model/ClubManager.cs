using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
   public class ClubManager:Golfer
    {
        [Optionally]
        public virtual Course course { get; set; }
    }
}
