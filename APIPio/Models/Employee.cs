using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPio.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public double MaxFte { get; set; }
        public double FreeFte { get; set; }
        public bool IsActive { get; set; }
    }
}