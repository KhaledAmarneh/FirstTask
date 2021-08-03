using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class BookRepository : InterfaceRepositories<BookEntity>
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {


            _context = context;




        }

        public async Task<BookEntity> CreateAsync(BookEntity book)
        {


            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var Book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (Book != null)
            {
                _context.Books.Remove(Book);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {

            return _context.Books;
        }

        public async Task<BookEntity> GetAsync(int id)

        //return _DataContext.Books.SingleOrDefault(x => x.Id == id)
        {
            return _context.Books.SingleOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(BookEntity t, int id)
        {
            t.Id = id;
            _context.Books.Update(t);
            _context.SaveChanges();

        }


    }
}
