﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ITransferOrderRepository
    {
        void AddTransferOrder(TransferOrder transferOrder);
        bool Save();
    }
}
