﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class GiftCard:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
