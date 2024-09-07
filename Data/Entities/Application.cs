﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // ---- navigation properties
        public ICollection<Education>? Educations { get; set; }
        public User User { get; set; }
    }
}
