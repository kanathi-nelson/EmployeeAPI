using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Service.ServiceExceptionHandler
{
    public class ServiceQueryExHandler : IServiceQueryExHandler
    {
        public void HandleError(Exception ex)
        {
            try
            {
                //handle the exception ex passed via the parameter
                return;
            }
            catch { }
        }
    }
}
