﻿using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface IBussinessBook
    {
        Task<IEnumerable<BookResource>> GetAllAsync();
        Task<BookResource> GetAsync(int id);
        Task<BookEntity> GetAsyncWithoutAuthors(int id);
        Task DeleteAsync(int id);
        Task<BookResource>UpdateAsync(Book book, int id);
        Task<BookResource> CreateAsync(Book book);

    }
}