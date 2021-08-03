//using ContosoPizza.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace ContosoPizza.Services
//{
//    public static class BookService
//    {
//        static List<Book> Books { get; }
//        static int nextId = 3;
//        static BookService()
//        {
//            Books = new List<Book>
//            {
//                new Book { Id = 1, Name = "Book1", Title = "T1" },
//                new Book { Id = 2, Name = "Book2", Title = "T2" }
//            };
//        }

//        public static List<Book> GetAll() => Books;

//        public static Book Get(int id) => Books.FirstOrDefault(p => p.Id == id);

//        public static void Add(Book book)
//        {
//            book.Id = nextId++;
//            Books.Add(book);
//        }

//        public static void Delete(int id)
//        {
//            var book = Get(id);
//            if(book is null)
//                return;

//            Books.Remove(book);
//        }

//        public static void Update(Book book)
//        {
//            var index = Books.FindIndex(p => p.Id == book.Id);
//            if(index == -1)
//                return;

//            Books[index] = book;
//        }
//    }
//}