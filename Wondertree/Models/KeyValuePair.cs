using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wondertree.Models
{
    public class KeyValuePair
    {
        //[Display(Name ="Value")]
        public int Info { get; set; }
        //[Display(Name ="Key")]
        public DateTime DateTime { get; set; }
    }
}
