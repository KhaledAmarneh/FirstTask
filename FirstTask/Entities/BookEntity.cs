
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstTask.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public List<AuthorEntity> Authors { get; set; }

    }
}