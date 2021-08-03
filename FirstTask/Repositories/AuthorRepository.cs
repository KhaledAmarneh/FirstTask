using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Interfaces;
using FirstTask.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Repositories
{
    public class AuthorRepository : InterfaceRepositories<AuthorEntity>
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {


            _context = context;
        }


        public async Task<AuthorEntity> CreateAsync(AuthorEntity author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public async Task DeleteAsync(int id)
        {
            var Author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (Author != null)
            {
                _context.Authors.Remove(Author);
                _context.SaveChanges();
            }
        }

        public async Task UpdateAsync(AuthorEntity author, int id)
        {
            author.Id = id;
            _context.Authors.Update(author);
            _context.SaveChanges();



        }

        async Task<IEnumerable<AuthorEntity>> InterfaceRepositories<AuthorEntity>.GetAllAsync()
        {
            return _context.Authors;
        }

        async Task<AuthorEntity> InterfaceRepositories<AuthorEntity>.GetAsync(int id)
        {
            return _context.Authors.SingleOrDefault(x => x.Id == id);
        }
    }
}
