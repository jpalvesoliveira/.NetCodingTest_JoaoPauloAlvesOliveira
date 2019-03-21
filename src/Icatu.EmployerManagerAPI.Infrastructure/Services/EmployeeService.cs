using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Icatu.EmployeeManagerAPI.Core.DTO;
using Icatu.EmployeeManagerAPI.Core.Entities;
using Icatu.EmployerManagerAPI.Core.Interfaces;

namespace Icatu.EmployerManagerAPI.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repo;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public EmployeeDTO Create(EmployeeDTO obj)
        {
            var result = _repo.Create(_mapper.Map<Employee>(obj));
            return _mapper.Map<EmployeeDTO>(result);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public EmployeeDTO Get(int id)
        {
            return _mapper.Map<EmployeeDTO>(_repo.Get(id));
        }

        public IList<EmployeeDTO> Get()
        {
            return _mapper.Map<IList<EmployeeDTO>>(_repo.Get());
        }

        public void Update(EmployeeDTO obj)
        {
            _repo.Update(_mapper.Map<Employee>(obj));
        }
    }
}
