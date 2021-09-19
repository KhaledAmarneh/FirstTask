using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public interface IBussinessAuthor

{
    Task<IEnumerable<AuthorResource>> GetAllAsync();
    Task<AuthorResource> GetAsync(int id);

    Task DeleteAsync(int id);

    Task<AuthorResource> UpdateAsync(AuthorModel author, int id);

    Task<AuthorResource> CreateAsync([FromBody] AuthorModel author);

}



namespace FirstTask.Bussiness
{

    public class BussinessAuthor : IBussinessAuthor
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BussinessAuthor(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;

        }


        public async Task<AuthorResource> CreateAsync([FromBody] AuthorModel author)
        {
            var books = new List<Book>();
            var listInvalidBooks = new List<int>();
            foreach (var id in author.BookIds)
            {
                var item = await _bookRepository.GetAsyncWithoutAuthors(id);
                if (item == null)
                    listInvalidBooks.Add(id);
                else books.Add(item);
            }
            if (listInvalidBooks.Any()) // if its not empty
                throw new Exception("Invalid Ids " + String.Join(",", listInvalidBooks.ToList()));

            var authorEntity = author.MapAuthorModelToEntity(books);
            var authorResource = await _authorRepository.CreateAsync(authorEntity);
            return authorResource.MapAuthorEntityToResource();
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
            if (authors is null)

            {
                throw new Exception("No Authors Yet!!");
            }
            else
                return authors.Select(author => author.MapAuthorEntityToResource()).ToList();
        }

        public async Task<AuthorResource> GetAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);
            if (author == null)
            {
                throw new Exception("Author Doesn't Exist!!");
            }
            return author.MapAuthorEntityToResource();

        }


        public async Task<AuthorResource> UpdateAsync(AuthorModel author, int id)
        {

            var books = new List<Book>();
            var listInvalidBooks = new List<int>();
            foreach (var Id in author.BookIds)
            {
                var item = await _bookRepository.GetAsyncWithoutAuthors(Id);
                if (item == null)
                    listInvalidBooks.Add(Id);
                else books.Add(item);
            }
            if (listInvalidBooks.Any()) // if its not empty
                throw new Exception("Invalid Ids " + String.Join(",", listInvalidBooks.ToList()));

            var authorEntity = await _authorRepository.GetAsync(id);

            if (authorEntity == null) {

                throw new Exception("Author Doesnt exsit with this id : " + id);


            }
                authorEntity.Books = books;
                authorEntity.Name = author.Name;

                await _authorRepository.UpdateAsync(authorEntity);
                return authorEntity.MapAuthorEntityToResource();
            }
        }
    }



