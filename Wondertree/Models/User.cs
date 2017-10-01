﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wondertree.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
