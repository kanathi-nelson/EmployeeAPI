using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Service.ServiceExceptionHandler
{
    public interface IServiceQueryExHandler
    {
        void HandleError(Exception ex);
    }
}
