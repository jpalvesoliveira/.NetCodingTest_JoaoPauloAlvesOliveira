namespace Icatu.EmployeeManagerAPI.Model
{
    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
    }
}
