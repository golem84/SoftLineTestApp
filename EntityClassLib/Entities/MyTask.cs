﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}