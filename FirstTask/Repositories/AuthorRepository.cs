using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class AuthorRepository : IAuthor
    {
        private readonly DataContext _context;




        public AuthorRepository(DataContext context)
        {


            _context = context;

        }


        public async Task<AuthorEntity> CreateAsync(AuthorEntity author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }



        public async Task DeleteAsync(AuthorEntity author)
        {
  
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuthorEntity author)
        {
            var Author = await GetAsync(author.Id); //Tracked from Database
            Author.Books.Clear(); //Delete old books from the database
            Author.Books = author.Books; //Here author.books not tracked from database it cointains the required books so we put the books in x.Books(in database)
            Author.Name = author.Name;
            _context.Authors.Update(Author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorEntity>> GetAllAsync()
        {
            List<AuthorEntity> Authors = await _context.Authors.Include(x => x.Books).ToListAsync();
            return Authors;
        }

        public async Task<AuthorEntity> GetAsync(int id)
        {
            var Author = await _context.Authors.Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == id);
            return Author;
        }

        public async Task<List<int>> GetBookIds(Author author)
        {
            List<int> AllBooksIds = await _context.Books.Select(book => book.Id).ToListAsync();

            return AllBooksIds.Where(id => author.BookIds.Contains(id)).ToList();
        }
    }
}
