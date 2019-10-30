using ASPNetFramework_Angular7_EF.Data.Core;
using ASPNetFramework_Angular7_EF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Data.EF6.Repositories
{
   public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(Context context) : base(context)
        {

        }
    }
}
