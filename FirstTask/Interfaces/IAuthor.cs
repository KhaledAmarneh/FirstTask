using ContosoPizza.Models;
using FirstTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface IAuthor 
    {
        Task<IEnumerable<AuthorEntity>> GetAllAsync();
        Task<AuthorEntity> GetAsync(int id);

        Task DeleteAsync(AuthorEntity author);

        Task UpdateAsync(AuthorEntity author );

        Task<AuthorEntity> CreateAsync(AuthorEntity author);

         Task<List<int>> GetBookIds(Author author);

    }
}
