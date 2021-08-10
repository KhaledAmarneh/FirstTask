using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class BookRepository : IBook
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<BookEntity> CreateAsync(BookEntity book)
        {


            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var Book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (Book != null)
            {
                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            var Books = await _context.Books.Include(x => x.Authors).ToListAsync(); 
            return Books;
        }

        public async Task<BookEntity> GetAsync(int id)
        {
            var Book = await _context.Books.Include(x => x.Authors).SingleOrDefaultAsync(x => x.Id == id);
            return Book;
        }

        public async Task<BookEntity> GetAsyncWithoutAuthors(int id)
        {
            var Book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return Book;
        }

        public async Task UpdateAsync(BookEntity book, int id)
        {
            book.Id = id;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
