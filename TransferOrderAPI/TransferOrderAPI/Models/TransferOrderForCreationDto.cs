using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TransferOrderForCreationDto
    {
        public string sourceCurrency;
        public string destinationCurrency;
        public decimal netAmmount;
        public decimal grossAmmount;
    }
}
