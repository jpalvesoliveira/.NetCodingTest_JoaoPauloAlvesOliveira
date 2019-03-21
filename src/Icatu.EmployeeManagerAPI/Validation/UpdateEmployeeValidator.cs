using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Icatu.EmployeeManagerAPI.Model;

namespace Icatu.EmployeeManagerAPI.Validation
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Name).Length(2, 60);
            RuleFor(x => x.Email).Length(2, 40);
            RuleFor(x => x.Department).Length(2, 60);
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
