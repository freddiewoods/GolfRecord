using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Result
    {
        [NakedObjectsIgnore]
        public virtual int id { get; set; }


        public virtual Course Course { get; set; }

        public virtual Match Match { get; set; }

        public virtual Golfer Golfer { get; set; }




    }
}
