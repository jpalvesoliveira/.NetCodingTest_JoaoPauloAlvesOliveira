using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Icatu.EmployeeManagerAPI.Core.Contexts;
using Icatu.EmployeeManagerAPI.Core.Entities;
using Icatu.EmployerManagerAPI.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Icatu.EmployeeManagerAPI.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ILogger _logger;
        private EmployeeContext _context { get; set; } 

        public EmployeeRepository(ILogger<EmployeeRepository> logger, EmployeeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Employee Create(Employee obj)
        {
            _context.Set.Add(obj);
            _context.SaveChanges();
            _logger.LogInformation($"{DateTime.Now.ToString()} - Employee created - ID {obj.Id}");
            return obj;
        }

        public void Delete(int id)
        {
            _context.Set.Remove(_context.Set.Find(id));
            _context.SaveChanges();
            _logger.LogInformation($"{DateTime.Now.ToString()} - Employee removed - ID {id}");
        }

        public Employee Get(int id)
        {
            _logger.LogInformation($"{DateTime.Now.ToString()} - Finding Employee - ID {id}");
            return _context.Set.Find(id);
        }

        public IList<Employee> Get()
        {
            _logger.LogInformation($"{DateTime.Now.ToString()} - Finding all employees");
            return _context.Set.OrderBy(e => e.Id).ToList();
        }

        public void Update(Employee obj)
        {
            _context.Set.Update(obj);
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            _logger.LogInformation($"{DateTime.Now.ToString()} - Updated Employee - ID {obj.Id}");
        }
    }
}
