using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Fee
    {

        [Key]
        public Guid Id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        [Column(TypeName = "decimal(24,6)")]
        public decimal rate { get; set; }
        public int timestamp { get; set; }
    }
}
