
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstTask.Entities
{
    public class Book

    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public List<BookAuthor> BooksAuthors { get; set; }

    }
}