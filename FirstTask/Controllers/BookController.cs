using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Repositories;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {


        private readonly IBook _bookRepository;
        public BookController(IBook bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null)
                return NotFound("No Books Yet!");
            return Ok(books.Select(book => book.BookEntityToResource()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResource>> Get(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book == null)
                return NotFound($"Book with Id: {id} does not exist.");
            return Ok(book.BookEntityToResource());
        }

        [HttpPost]
        public async Task<ActionResult<BookResource>> Create([FromBody] Book book)
        {
            var BookEntity = book.BookModelToEntity();
            var BookResource = _bookRepository.CreateAsync(BookEntity);

            return Ok((await BookResource).BookEntityToResource());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookResource>> Update(Book book, int id)
        {
            var x = book.BookModelToEntity(); 
            x.Id = id;
            await _bookRepository.UpdateAsync(x, id); 
            return Ok(x.BookEntityToResource());
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

    }
}