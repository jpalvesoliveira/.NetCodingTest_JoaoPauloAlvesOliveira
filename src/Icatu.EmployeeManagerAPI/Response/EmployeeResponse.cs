using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icatu.EmployeeManagerAPI.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
    }
}
