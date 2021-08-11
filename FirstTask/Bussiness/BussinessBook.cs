using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Bussiness
{
    public class BussinessBook : IBussinessBook
    {

        private readonly IBook _bookRepository;

        public BussinessBook(IBook bookRepository)
        {
            
            _bookRepository = bookRepository;

        }
        public async Task<BookResource> CreateAsync(Book book)
        {
            var BookEntity = book.BookModelToEntity();
            var BookResource = await _bookRepository.CreateAsync(BookEntity);
            return BookResource.BookEntityToResource();

        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book != null)
            {
                await _bookRepository.DeleteAsync(book);
            }
            else
            {
                throw new Exception("Book Doesn't Exist!!");
            }

        }

        public async Task<IEnumerable<BookResource>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null)

            {
                throw new Exception("No Books Yet!!");
            }
            return books.Select(book => book.BookEntityToResource()).ToList();
        }

        public async Task<BookResource> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book == null)

            {
                throw new Exception("Book Doesn't Exist!!");
            }
            return book.BookEntityToResource();
        }

        public Task<BookEntity> GetAsyncWithoutAuthors(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookResource> UpdateAsync(Book book, int id)
        {

            var oldBook = await _bookRepository.GetAsync(id); // this entity is tracked.

            if (oldBook == null)
            {
                throw new Exception("Book Doesn't Exist!!");
            }
            oldBook.Name = book.Name;
            oldBook.Title = book.Title;
            await _bookRepository.UpdateAsync(oldBook);
            return oldBook.BookEntityToResource();

        }
    }
}
