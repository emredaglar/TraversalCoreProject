﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutSub
    {
        [Key]
        public int SubAboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
