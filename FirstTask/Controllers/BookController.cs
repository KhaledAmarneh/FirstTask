using ContosoPizza.Models;
using FirstTask.Interfaces;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBussinessBook _bookBussiness;
        public BookController(IBussinessBook bookBussiness)
        {
            _bookBussiness = bookBussiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAll()
        {
            var bookResources = await _bookBussiness.GetAllAsync();
            return Ok(bookResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResource>> Get(int id)
        {
            var bookResource = await _bookBussiness.GetAsync(id);
            return Ok(bookResource);
        }

        [HttpPost]
        public async Task<ActionResult<BookResource>> Create([FromBody] Book book)
        {

            var bookResource = await _bookBussiness.CreateAsync(book);
            return Ok(bookResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookResource>> Update(Book book, int id)
        {
            var bookResource = await _bookBussiness.UpdateAsync(book, id);
            return Ok(bookResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookBussiness.DeleteAsync(id);
            return Ok();
        }

    }
}