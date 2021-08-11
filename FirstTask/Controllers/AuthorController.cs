using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using FirstTask.Resources;
using System;
using FirstTask.Interfaces;
using FirstTask.Entities;
using System.Threading.Tasks;
using ContosoPizza.Controllers;

namespace FirstTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly IBussinessAuthor _authorBussiness;
        private readonly IBussinessBook _bookBussiness;

        public AuthorController(IBussinessAuthor authorBussiness, IBussinessBook bookBussiness)
        {
            _authorBussiness = authorBussiness;
            _bookBussiness = bookBussiness;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAll()
        {
            var authors = await _authorBussiness.GetAllAsync();
            return Ok(authors);


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResource>> Get(int id)
        {

            var author = await _authorBussiness.GetAsync(id);
            return author;
        }


        [HttpPost]
        public async Task<ActionResult<AuthorResource>> Create([FromBody] Author author)
        {

            var authorResource = await _authorBussiness.CreateAsync(author);
            return Ok(authorResource);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorResource>> Update(Author author, int id)
        {
            var authorResource = await _authorBussiness.UpdateAsync(author, id);

            return Ok(authorResource);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorBussiness.DeleteAsync(id);
            return Ok();

        }
    }
}
