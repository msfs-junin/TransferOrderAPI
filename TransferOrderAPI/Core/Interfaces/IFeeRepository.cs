using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IFeeRepository
    {
        decimal getFeeForOperation(string sourceCurrency, string destinationCurrency);
    }
}
