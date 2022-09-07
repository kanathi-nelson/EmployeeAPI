using EmployeeAPI.Data;
using EmployeeAPI.Repo.Interfaces;
using EmployeeAPI.Service.Interfaces;
using EmployeeAPI.Service.ServiceExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Service.Repositories
{
    //Implementation of the Employee service
    public class EmployeeService : ICustomService<Employee>
    {
        private readonly IBaseRepository<Employee> _studentRepository;
        private readonly IServiceQueryExHandler _servicequeryexhandler;
        public EmployeeService(IBaseRepository<Employee> studentRepository, IServiceQueryExHandler serviceQueryEx)
        {
            _studentRepository = studentRepository;
            _servicequeryexhandler = serviceQueryEx;
        }
        public void Delete(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _studentRepository.Delete(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
        public Employee Get(int Id)
        {
            try
            {
                var obj = _studentRepository.GetByCondition(q => q.Id == Id);
                if (obj != null)
                {
                    return obj.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var obj = _studentRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
        public void Insert(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _studentRepository.Insert(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
        public void Remove(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _studentRepository.Remove(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
        public void Update(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _studentRepository.Update(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //handle exception
                _servicequeryexhandler.HandleError(ex);
                throw;
            }
        }
    }
        
    }
