using AutoMapper;
using Icatu.EmployeeManagerAPI.Core.DTO;
using Icatu.EmployeeManagerAPI.Core.Entities;

namespace Icatu.EmployeeManagerAPI.DTO
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
