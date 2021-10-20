using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Fee
    {
        public int Id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public decimal rate { get; set; }
        public int timestamp { get; set; }
    }
}
