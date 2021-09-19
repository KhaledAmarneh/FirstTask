using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.Collections.Generic;
using System.Linq;

public static class AuthorMappingMethods

{
    public static AuthorResource MapAuthorEntityToResource(this Author author)
    {
        return new AuthorResource
        {
            Name = author.Name,
            Id = author.Id,
            Books = author.Books.Select(book => book.MapBookEntityToBookLiteResource()).ToList(),
        };
    }


    public static Author MapAuthorModelToEntity(this AuthorModel author, List<Book> books)
    {
        return new Author
        {
            Name = author.Name,
            Books = books
 
        };
    }


    public static AuthorLiteResource MapAuthorEntityToAuthorLiteResource(this Author author)
    {
        return new AuthorLiteResource
        {
            Name = author.Name,
            Id = author.Id,
        };
    }

   

}
