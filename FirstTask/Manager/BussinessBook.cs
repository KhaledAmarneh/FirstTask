using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IBussinessBook
{
    Task<IEnumerable<BookResource>> GetAllAsync();
    Task<BookResource> GetAsync(int id);
    Task<Book> GetAsyncWithoutAuthors(int id);
    Task DeleteAsync(int id);
    Task<BookResource> UpdateAsync(BookModel book, int id);
    Task<BookResource> CreateAsync(BookModel book);

}

namespace FirstTask.Bussiness
{



    public class BussinessBook : IBussinessBook
    {

        private readonly IBookRepository _bookRepository;

        public BussinessBook(IBookRepository bookRepository)
        {
            
            _bookRepository = bookRepository;

        }
        public async Task<BookResource> CreateAsync(BookModel book)
        {
            var BookEntity = book.MapBookModelToEntity();
            var BookResource = await _bookRepository.CreateAsync(BookEntity);
            return BookResource.MapBookEntityToResource();

        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book == null)
            {
                throw new Exception("Book Doesn't Exist!!");
               
            }
            await _bookRepository.DeleteAsync(book);

        }

        public async Task<IEnumerable<BookResource>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null)

            {
                throw new Exception("No Books Yet!!");
            }
            return books.Select(book => book.MapBookEntityToResource()).ToList();
        }

        public async Task<BookResource> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book == null)
            {
                throw new Exception("Book Doesn't Exist!!");
            }
            return book.MapBookEntityToResource();
        }

        public Task<Book> GetAsyncWithoutAuthors(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookResource> UpdateAsync(BookModel book, int id)
        {
            // This entity is tracked.
            var bookEntity = await _bookRepository.GetAsync(id); 

            if (bookEntity == null)
            {
                throw new Exception("Book Doesn't Exist!!");
            }
            bookEntity.Name = book.Name;
            bookEntity.Title = book.Title;
            await _bookRepository.UpdateAsync(bookEntity);
            return bookEntity.MapBookEntityToResource();

        }
    }
}

