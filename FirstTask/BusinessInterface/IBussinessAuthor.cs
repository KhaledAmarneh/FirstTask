using ContosoPizza.Models;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface IBussinessAuthor

    {
        Task<IEnumerable<AuthorResource>> GetAllAsync();
        Task<AuthorResource> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AuthorResource> UpdateAsync(Author author, int id);

        Task<AuthorResource> CreateAsync([FromBody] Author author);

    }
}
