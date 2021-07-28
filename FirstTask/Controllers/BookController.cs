using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController()
        {
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll() =>
            BookService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookService.Get(id);

            if(book == null)
                return NotFound();

            return book;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {            
        BookService.Add(book);
        return CreatedAtAction(nameof(Create), new { id = book.Id }, book);       
         }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
{
    if (id != book.Id)
        return BadRequest();

    var existingBook = BookService.Get(id);
    if(existingBook is null)
        return NotFound();

    BookService.Update(book);           

    return NoContent();
}
        [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var book = BookService.Get(id);

    if (book is null)
        return NotFound();

    BookService.Delete(id);

    return NoContent();
}
    }
}