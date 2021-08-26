using System.Collections.Generic;

namespace FirstTask.Entities
{
    public class AuthorEntity
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookEntity> Books { get; set;}
        
    }
}