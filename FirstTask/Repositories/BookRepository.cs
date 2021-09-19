using ContosoPizza.Models;
using FirstTask.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;




public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetAsync(int id);
    Task<Book> GetAsyncWithoutAuthors(int id);
    Task DeleteAsync(Book book);
    Task UpdateAsync(Book book);
    Task<Book> CreateAsync(Book book);

    Task<List<int>> GetInvalidBookIds(AuthorModel author);

}
namespace FirstTask.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var Books = await _context.Books.Include(x => x.Authors).ToListAsync();
            return Books;
        }

        public async Task<Book> GetAsync(int id)
        {
            var Book = await _context.Books.Include(x => x.Authors).SingleOrDefaultAsync(x => x.Id == id);
            return Book;
        }

        public async Task<Book> GetAsyncWithoutAuthors(int id)
        {
            var Book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return Book;
        }

        public async Task<List<int>> GetInvalidBookIds(AuthorModel author) 
        {
            List<int> inputIds = author.BookIds;
            List<int> invalidBooksList = new();
            for (int x = 0; x < inputIds.Count; x++)
            {
                var myBook = await _context.Books.SingleOrDefaultAsync(i => i.Id == inputIds[x]);

                if (myBook == null)
                {
                    invalidBooksList.Add(inputIds[x]);
                }
            }
            return invalidBooksList;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }
    }
}
