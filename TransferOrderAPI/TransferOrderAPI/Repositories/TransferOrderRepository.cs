using API.Entities;
using API.Interfaces;
using API.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Repositories
{
    public class TransferOrderRepository : ITransferOrderRepository, IDisposable
    {
        private readonly TransferOrderContext _context;

        public TransferOrderRepository(TransferOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTransferOrder(TransferOrder transferOrder)
        {
            if (transferOrder == null)
            {
                throw new ArgumentNullException(nameof(transferOrder));
            }
            _context.TransferOrders.Add(transferOrder);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public IEnumerable<TransferOrder> GetTransferOrders()
        {
            return _context.TransferOrders.ToList<TransferOrder>();
        }

        public TransferOrder GetTransferOrder(Guid transferOrderId)
        {
            if (transferOrderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(transferOrderId));
            }

            return _context.TransferOrders.FirstOrDefault(a => a.Id == transferOrderId);
        }
    }
}
