using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Entities
{
    public class CurrencyQuotation
    {
        public int Id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public decimal rate { get; set; }
        public int timestamp { get; set; }
    }
}
