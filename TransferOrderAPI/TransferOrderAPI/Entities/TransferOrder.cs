using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Entities
{
    public class TransferOrder
    {
        [Key]
        public Guid Id { get; set; }

        public string sourceCurrency { get; set; }
        public string destinationCurrency { get; set; }
        [Column(TypeName = "decimal(24,6)")]
        public decimal netAmmount { get; set; }
        [Column(TypeName = "decimal(24,6)")]
        public decimal grossAmmount { get; set; }



    }
}
