using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPio.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int EmployeeId { get; set; }
        public int TaskDataId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}