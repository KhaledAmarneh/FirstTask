using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public static class AuthorMappingMethods

{
    public static AuthorResource AuthorEntityToResource(this AuthorEntity author)
    {
        return new AuthorResource
        {
            Name = author.Name,
            Id = author.Id,
            Books = author.Books.Select(book => book.BookEntityToBookLiteResource()).ToList(),
        };
    }


    public static AuthorEntity AuthorModelToEntity(this Author author)
    {
        return new AuthorEntity
        {
            Name = author.Name,
        };
    }


    public static AuthorLiteResource AuthorEntityToAuthorLiteResource(this AuthorEntity author)
    {
        return new AuthorLiteResource
        {
            Name = author.Name,
            Id = author.Id,
        };
    }

    public static Author AuthorEntityToModel(this AuthorEntity author)
    {
        return new Author
        {
            Name = author.Name,
            BookIds = author.Books.Select(x => x.Id).ToList(),
        };
    }

}
