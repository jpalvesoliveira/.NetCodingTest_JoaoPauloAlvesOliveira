using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icatu.EmployerManagerAPI.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IList<T> Get();
        void Delete(int id);
        void Update(T obj);
        T Create(T obj);
    }
}
