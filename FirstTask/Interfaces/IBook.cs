using FirstTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface IBook
    {
        Task<IEnumerable<BookEntity>> GetAllAsync();
        Task<BookEntity> GetAsync(int id);
        Task<BookEntity> GetAsyncWithoutAuthors(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(BookEntity book, int id);
        Task<BookEntity> CreateAsync(BookEntity book);

    }
}
