using Core.Entities;
using Core.Interfaces;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
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
            // always set the AuthorId to the passed-in authorId
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
    }
}
