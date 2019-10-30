using ASPNetFramework_Angular7_EF.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Data.EF6
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public UnitOfWork(IContext context)
        {
            this._context = context;
        }
        public void Complete()
        {
            try
            {
                _context.SaveChanges();
            }

            catch (DbUpdateConcurrencyException ex)
            {
                var entityName = ex.Entries
                    .Single()
                    .Entity
                    .ToString()
                    .Split('.')
                    .Last();

                var exception = new Exception($"The { entityName } that you attempted to edit has already been modified by another user.");
                throw exception;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
