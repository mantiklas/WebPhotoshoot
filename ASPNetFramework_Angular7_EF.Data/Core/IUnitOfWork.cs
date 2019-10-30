using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Data.Core
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}
