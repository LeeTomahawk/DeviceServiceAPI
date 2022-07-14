﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class TaskCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; } 
        public DateTime? endDate { get; set; } 
        public float? amount { get; set; }
    }
}
