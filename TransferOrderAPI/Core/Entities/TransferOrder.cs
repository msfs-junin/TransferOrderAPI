using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class TransferOrder
    {
        [Key]
        public Guid Id { get; set; }

        public string sourceCurrency { get; set; }
        public string destinationCurrency { get; set; }
        public decimal netAmmount { get; set; }
        public decimal grossAmmount { get; set; }



    }
}
