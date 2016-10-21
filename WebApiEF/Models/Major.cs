using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiEF.Models {
    [Table("Major")]
    public class Major {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int MinSat { get; set; }
        [JsonIgnore]
        [InverseProperty("Major")]
        public virtual List<Student> Students { get; set; }
        public Major() {
            this.Students = new List<Student>();
        }
    }
}