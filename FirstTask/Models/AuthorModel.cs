using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class AuthorModel

    {   
        public string Name { get; set; }
        public List<int> BookIds { get; set; }
        

    }
}