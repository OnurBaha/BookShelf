﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Book : Entity<Guid>
    {
        public string Name { get; set; } 
        public string Author { get; set; }
        public string Category { get; set; } 
        public int Rating { get; set; } 
        public bool IsRead { get; set; } 
        public bool IsFavorite { get; set; } 
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
    }
}