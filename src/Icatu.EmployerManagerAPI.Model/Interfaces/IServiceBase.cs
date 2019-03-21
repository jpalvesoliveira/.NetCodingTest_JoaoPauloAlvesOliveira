using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Icatu.EmployerManagerAPI.Core.Interfaces
{
    public interface IServiceBase<T>
    {
        T Get(int id);
        IList<T> Get();
        void Delete(int id);
        void Update(T obj);
        T Create(T obj);
    }
}
