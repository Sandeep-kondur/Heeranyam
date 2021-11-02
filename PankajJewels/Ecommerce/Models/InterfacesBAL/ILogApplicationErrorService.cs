using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface ILogApplicationErrorService
    {
        public void LogError(Exception ex);
    }
}
