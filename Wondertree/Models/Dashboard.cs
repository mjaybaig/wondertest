using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wondertree.Models
{
    public class Dashboard
    {
        public ICollection<KeyValuePair> DataPoints { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
