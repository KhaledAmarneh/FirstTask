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

        private readonly IAuthor _authorRepository;
        private readonly IBook _bookRepository;

        public AuthorController(IAuthor authorRepository, IBook bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;

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
            List<int> ListOfBookids = await _authorRepository.GetBookIds(author);
            if (ListOfBookids?.Count == 0)
            {
                throw new Exception("Invalid ids");
            }
            else if (author.BookIds.Count != ListOfBookids?.Count)
            {

                throw new Exception("There is an invalid id");
            }
            else
            {
                authorEntity.Books = ListOfBookids.Select(async bookId => await _bookRepository.GetAsyncWithoutAuthors(bookId)).Select(x => x.Result).Where(y => y != null).ToList();
                var authorResource = _authorRepository.CreateAsync(authorEntity);
                return Ok((await authorResource).AuthorEntityToResource());
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorResource>> Update(Author author, int id)
        {
            

            var authorEntity = author.AuthorModelToEntity();
            authorEntity.Id = id;
            List<int> ListOfBookids = await _authorRepository.GetBookIds(author);//[1,2]


            if (ListOfBookids?.Count == 0)
            {
                throw new Exception("Invalid ids");
            }
            else if (author.BookIds.Count != ListOfBookids?.Count)
            {
                throw new Exception("There is an invalid id");
            }
            else
            {
                authorEntity.Books = ListOfBookids.Select(async bookId => await _bookRepository.GetAsyncWithoutAuthors(bookId)).Select(x => x.Result).Where(y => y != null).ToList();
                await _authorRepository.UpdateAsync(authorEntity);
                return Ok(authorEntity.AuthorEntityToResource());
            }
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