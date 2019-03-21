using System;
using System.Collections.Generic;
using System.Text;

namespace Icatu.EmployerManagerAPI.Core.Interfaces
{
    public interface IRequestHandler<T>
    {
        void Handle(T message);
    }
}