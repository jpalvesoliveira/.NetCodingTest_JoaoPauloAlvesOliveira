using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Icatu.EmployeeManagerAPI.Core.DTO;
using Icatu.EmployeeManagerAPI.DTO;
using Icatu.EmployeeManagerAPI.Model;
using Icatu.EmployeeManagerAPI.Presenters;
using Icatu.EmployerManagerAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Icatu.EmployeeManagerAPI.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _service;
        private ILogger _logger;
        private IMapper _mapper;

        public EmployeeController(IEmployeeService service, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery(Name ="pageSize")]int pageSize, [FromQuery(Name = "page")] int page)
        {
            var employees = _service.Get();
            if (employees == null)
                return NoContent();
            var pages = (int) Math.Ceiling(employees.Count / Convert.ToDecimal(pageSize));

            var response = new GetAllEmployeesPresenter();
            response.Handle(employees, pageSize, page);
            HttpContext.Response.Headers.Add("X-Pages-TotalPages", response.Pages.ToString());
            return response.Result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _service.Get(id);
            if (model == null)
                return NoContent();

            var response = new GetEmployeePresenter();
            response.Handle(model);
            return response.Result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]NewEmployeeRequest employee)
        {
            if (ModelState.IsValid)
            {
                var model = _service.Create(new EmployeeDTO
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department
                });

                var response = new NewEmployeePresenter();
                response.Handle(model);
                return response.Result;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody]UpdateEmployeeRequest employee)
        {
            if (ModelState.IsValid)
            {
                _service.Update(new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department
                });
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
