using MediatR;

namespace Icatu.EmployeeManagerAPI.Model
{
    public class NewEmployeeRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
    }
}
