using FirstTask.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstTask.Resources

{
    public class AuthorResource 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<BookLiteResource> Books { get; set; }

    }
}