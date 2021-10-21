using API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface ITransferOrderRepository
    {
        void AddTransferOrder(TransferOrder transferOrder);
        bool Save();
        IEnumerable<TransferOrder> GetTransferOrders();
    }
}
