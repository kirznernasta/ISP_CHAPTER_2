﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.Domain.Entities
{
    public class JobDuty : Entity
    {
        public string Description { get; set; }
        public int Experience { get; set; }
        public int DutyImportance { get; set; }
    }
}
