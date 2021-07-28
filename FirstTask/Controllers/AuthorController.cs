using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace FirstTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        public AuthorController()
        {
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll() =>
            AuthorService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            var author = AuthorService.Get(id);

            if(author == null)
                return NotFound();

            return author;
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {            
        AuthorService.Add(author);
        return CreatedAtAction(nameof(Create), new { id = author.Id }, author);       
         }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Author author)
{
    if (id != author.Id)
        return BadRequest();

    var existingAuthor = AuthorService.Get(id);
    if(existingAuthor is null)
        return NotFound();

    AuthorService.Update(author);           

    return NoContent();
}
        [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var author = AuthorService.Get(id);

    if (author is null)
        return NotFound();

    AuthorService.Delete(id);

    return NoContent();
}
    }
}