
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstTask.Resources
{
    public class BookResource 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        public ICollection<AuthorLiteResource> Authors { get; set; }
    }
}