using ContosoPizza.Models;
using FirstTask.Interfaces;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Bussiness
{
    public class BussinessAuthor : IBussinessAuthor
    {

        private readonly IAuthor _authorRepository;
        private readonly IBook _bookRepository;

        public BussinessAuthor(IAuthor authorRepository, IBook bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;

        }


        public async Task<AuthorResource> CreateAsync([FromBody] Author author)
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
                var authorResource = await _authorRepository.CreateAsync(authorEntity);
                return authorResource.AuthorEntityToResource();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author != null)
            {
               await _authorRepository.DeleteAsync(author);
               
            }
            else
            {
                throw new Exception("Author Doesn't Exist!!");
            }

    }

        public async Task<IEnumerable<AuthorResource>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            if(authors is null)

            {
                throw new Exception("No Authors Yet!!");
            }
            else
            return authors.Select(author => author.AuthorEntityToResource()).ToList();
        }

        public async Task<AuthorResource> GetAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);
            if (author == null)
            {
             throw new Exception("Author Doesn't Exist!!");
            }
            return author.AuthorEntityToResource();

        }

        
        public async Task<AuthorResource> UpdateAsync(Author author, int id)
        {
            var authorEntity = author.AuthorModelToEntity();
            authorEntity.Id = id;
            var getAuthor = await _authorRepository.GetAsync(id);
            if (getAuthor == null)
            {
                throw new Exception("Author Doesn't Exist!!");
            }

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
                await _authorRepository.UpdateAsync(authorEntity);
                return authorEntity.AuthorEntityToResource();
            }
        }
    }
}
