using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Icatu.EmployeeManagerAPI.Core.DTO
{
    public class EmployeeDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }
    }
}
