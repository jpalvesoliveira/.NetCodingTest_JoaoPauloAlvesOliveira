using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Icatu.EmployeeManagerAPI.Core.DTO;
using Icatu.EmployeeManagerAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Icatu.EmployeeManagerAPI.Presenters
{
    public class NewEmployeePresenter
    {
        public IActionResult Result { get; private set; }

        public void Handle(EmployeeDTO output)
        {
            if (output == null)
            {
                Result = new NoContentResult();
            }
            else
            {
               var status = new ObjectResult(new EmployeeResponse()
                {
                    Id = output.Id,
                    Name = output.Name,
                    Email = output.Email,
                    Department = output.Department
                });
                status.StatusCode = (int) HttpStatusCode.Created;
                Result = status;
            }
        }
    }
}
