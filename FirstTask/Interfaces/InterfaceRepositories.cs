using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface InterfaceRepositories<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(T t, int id);

        Task<T> CreateAsync(T t);

    }
}
