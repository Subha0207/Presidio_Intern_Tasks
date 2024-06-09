using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppDLLibrary
{
    public interface IRepository<K, T> where T : class
    {
       Task< IList<T>> GetAll();
        Task<T> Get(K key);
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(K key);

    }
}
