using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using FirstTask.Resources;
using System;
using FirstTask.Interfaces;
using FirstTask.Entities;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly InterfaceRepositories<AuthorEntity> _authorRepository;
        public AuthorController(InterfaceRepositories<AuthorEntity> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();
            if (authors == null)
                return NotFound("No Authors Yet!");
            return Ok(authors.Select(author => author.AuthorEntityToResource()).ToList());


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResource>> Get(int id)
        {

            var author = await _authorRepository.GetAsync(id);
            if (author == null)
                return NotFound($"Author with Id: {id} does not exist.");

            return author.AuthorEntityToResource();
        }


        [HttpPost]
        public async Task<ActionResult<AuthorResource>> Create([FromBody] Author author)
        {
            var authorEntity = author.AuthorModelToEntity();
            var authorResource = _authorRepository.CreateAsync(authorEntity);

            return Ok((await authorResource).AuthorEntityToResource());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorResource>> Update(Author author, int id)
        {

            var x = author.AuthorModelToEntity();
            x.Id = id;
            await _authorRepository.UpdateAsync(x, id);
            return Ok(x.AuthorEntityToResource());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //    var author = _DataContext.Authors.FirstOrDefault(x => x.Id == id);

            //    if (author != null)
            //    {
            //        _DataContext.Authors.Remove(author);
            //        _DataContext.SaveChanges();
            //    }
            //    else
            //        return NotFound($"author with Id: {id} does not exist.");
            //    return NoContent();
            //}


            await _authorRepository.DeleteAsync(id);
            return Ok();

        }
    }
}