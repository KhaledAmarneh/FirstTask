using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class Author
    {   
        public string Name { get; set; }
        public List<int> BookIds { get; set; }
        //public ICollection<Book> Books { get; set; }

    }
}