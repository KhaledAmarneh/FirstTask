using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public static class BookMappingMethods


{
    public static BookResource BookEntityToResource(this BookEntity book)
    {
        return new BookResource
        {
            Name = book.Name,
            Title = book.Title,
            Id = book.Id,
            Authors = book.Authors.Select(author => author.AuthorEntityToAuthorLiteResource()).ToList()

        };
    }


    public static BookEntity BookModelToEntity(this Book book)
    {
        return new BookEntity
        {
            Name = book.Name,
            Title = book.Title,
        };
    }

    public static BookLiteResource BookEntityToBookLiteResource(this BookEntity book)
    {
        return new BookLiteResource
        {
            Name = book.Name,
            Id = book.Id,
            Title = book.Title
        };
    }





}
