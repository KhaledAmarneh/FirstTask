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
        Task DeleteAsync(BookEntity book);
        Task UpdateAsync(BookEntity book);
        Task <BookEntity> CreateAsync(BookEntity book);

    }
}
