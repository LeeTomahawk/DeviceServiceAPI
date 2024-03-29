﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Activities { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public float? amount { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public ClientDto Client { get; set; }
    }
}
