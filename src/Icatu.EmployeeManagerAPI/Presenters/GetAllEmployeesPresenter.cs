using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Icatu.EmployeeManagerAPI.Core.DTO;
using Icatu.EmployeeManagerAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace Icatu.EmployeeManagerAPI.Presenters
{
    public class GetAllEmployeesPresenter
    {
        public int Pages { get; set; }
        public IActionResult Result { get; private set; }

        public void Handle(IList<EmployeeDTO> output, int pageSize, int page)
        {
            if (output == null)
            {
                Result = new NoContentResult();
            }
            else
            {
                var employees = new List<EmployeeResponse>(
                            from a in output
                            select new EmployeeResponse
                            {
                                Id = a.Id,
                                Name = a.Name,
                                Email = a.Email,
                                Department = a.Department
                            });
                Pages = (int)Math.Ceiling(employees.Count / Convert.ToDecimal(pageSize));
                var status = new ObjectResult(employees.Skip(pageSize * (page - 1)).Take(pageSize));
                status.StatusCode = (int)HttpStatusCode.OK;
                Result = status;
            }
        }
    }
}
