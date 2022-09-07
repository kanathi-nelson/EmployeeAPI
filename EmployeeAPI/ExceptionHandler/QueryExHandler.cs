using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.ExceptionHandler
{
    public class QueryExHandler :IQueryExHandler
    {
        public void HandleError(Exception ex)
        {
            try
            {

               //save exception to file or do something with ex 
                return;
            }
            catch { }
        }
    }
}
