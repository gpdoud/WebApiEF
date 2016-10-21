using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiEF.Models {
    [Table("Student")]
    public class Student {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Sat { get; set; }
        public int? MajorId { get; set; }
        [ForeignKey("MajorId")]
        public Major Major { get; set; }
    }
}