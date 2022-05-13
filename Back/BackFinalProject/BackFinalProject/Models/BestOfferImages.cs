﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class BestOfferImages : BaseEntity
    {
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public int BestOfferId { get; set; }
        public BestOffer BestOffer { get; set; }
    }
}