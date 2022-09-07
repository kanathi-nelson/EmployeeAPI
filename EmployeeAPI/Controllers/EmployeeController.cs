using EmployeeAPI.Data;
using EmployeeAPI.ExceptionHandler;
using EmployeeAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //inject the employee service and exception handler
        private readonly ICustomService<Employee> _customService;
        private readonly IQueryExHandler _queryexhandler;
        public EmployeeController(ICustomService<Employee> customService, IQueryExHandler queryExHandler)
        {
            _customService = customService;
            _queryexhandler = queryExHandler;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var allemployees = _customService.GetAll();

                if (allemployees == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(allemployees);
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _queryexhandler.HandleError(ex);
                return BadRequest();
            }
        }

        // GET: api/<EmployeeController>
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _customService.Get(id);

                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _queryexhandler.HandleError(ex);
                return BadRequest();
            }
        }


        //post an employee data
        [Produces("application/json")]
        [HttpPost]
        public ActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return NoContent();
                }
                else
                {
                    _customService.Insert(employee);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _queryexhandler.HandleError(ex);
                return BadRequest();
            }

        }


        //update an employee data
        [Produces("application/json")]
        [HttpPost]
        public ActionResult UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return NoContent();
                }
                else
                {
                    //check if employee to update exists
                    if (_customService.Get(employee.Id) != null)
                    {
                        _customService.Update(employee);
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(403,"Employee to update not found");
                    }
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _queryexhandler.HandleError(ex);
                return BadRequest();
            }

        }


        //delete an employee
        [Produces("application/json")]
        [HttpPost]
        public ActionResult DeleteEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return NoContent();
                }
                else
                {
                    //check if employee to update exists
                    if (_customService.Get(employee.Id) != null)
                    {
                        _customService.Remove(employee);
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(403, "Employee to delete does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _queryexhandler.HandleError(ex);
                return BadRequest();
            }

        }

    }
}
