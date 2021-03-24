using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Managers
{
    public abstract class BaseManager
    {
        protected readonly ServiceWrapper ServiceWrapper;
        public BaseManager(ServiceWrapper serviceWrapper)
        {
            ServiceWrapper = serviceWrapper;
        }
    }
}
