using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author> GetAsync(int id);

    Task DeleteAsync(Author author);

    Task UpdateAsync(Author author);

    Task<Author> CreateAsync(Author author);

    //Task<List<int>> GetBookIds(AuthorModel author);

}




namespace FirstTask.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;




        public AuthorRepository(DataContext context)
        {


            _context = context;

        }


        public async Task<Author> CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }



        public async Task DeleteAsync(Author author)
        {
  
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(x => x.Books).ToListAsync();
        }

        public async Task<Author> GetAsync(int id)
        {
            var Author = await _context.Authors.Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == id);
            return Author;
        }

        //public async Task<List<int>> GetBookIds(AuthorModel author)
        //{
            

        //    List<int> AllBooksIds = await _context.Books.Select(book => book.Id).ToListAsync();

        //    return AllBooksIds.Where(id => author.BookIds.Contains(id)).ToList();
        //}
    }
}
 