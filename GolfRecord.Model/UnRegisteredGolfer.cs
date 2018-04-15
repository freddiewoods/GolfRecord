using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
   public class UnRegisteredGolfer:Golfer
    {

        public virtual Golfer GolferCreator { get; set; }

    }
}
