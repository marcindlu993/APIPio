﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPio.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}