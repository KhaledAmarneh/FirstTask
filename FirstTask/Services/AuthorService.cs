//using ContosoPizza.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace ContosoPizza.Services
//{
//    public static class AuthorService
//    {
//        static List<Author> Authors { get; }
//        static int nextId = 3;
//        static AuthorService()
//        {
//            Authors = new List<Author>
//            {
//                new Author { Id = 1, Name = "Ali",},
//                new Author { Id = 2, Name = "Ahmad" }
//            };
//        }

//        public static List<Author> GetAll() => Authors;

//        public static Author Get(int id) => Authors.FirstOrDefault(p => p.Id == id);

//        public static void Add(Author author)
//        {
//            author.Id = nextId++;
//            Authors.Add(author);
//        }

//        public static void Delete(int id)
//        {
//            var author = Get(id);
//            if(author is null)
//                return;

//            Authors.Remove(author);
//        }

//        public static void Update(Author author)
//        {
//            var index = Authors.FindIndex(p => p.Id == author.Id);
//            if(index == -1)
//                return;

//            Authors[index] = author;
//        }
//    }
//}