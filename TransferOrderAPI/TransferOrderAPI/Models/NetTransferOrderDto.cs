using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class NetTransferOrderDto
    {
        public Guid Id { get; set; }
        public string sourceCurrency { get; set; }
        public string  destinationCurrency { get; set; }
        public decimal netAmmount { get; set; }
        public decimal grossAmmount { get; set; }
    }
}
