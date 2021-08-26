using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using FirstTask.Resources;
using FirstTask.Interfaces;
using System.Threading.Tasks;


namespace FirstTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly IBussinessAuthor _authorBussiness;
        

        public AuthorController(IBussinessAuthor authorBussiness)
        {
            _authorBussiness = authorBussiness;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAll()
        {
            var authorResources = await _authorBussiness.GetAllAsync();
            return Ok(authorResources);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResource>> Get(int id)
        {
            var authorResource = await _authorBussiness.GetAsync(id);
            return Ok(authorResource);
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
