using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface IFeeRepository
    {
        decimal getFeeForOperation(string sourceCurrency, string destinationCurrency);
    }
}
