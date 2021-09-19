using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public static class BookMappingMethods


{
    public static BookResource MapBookEntityToResource(this Book book)
    {
        return new BookResource
        {
            Name = book.Name,
            Title = book.Title,
            Id = book.Id,
            Authors = book.Authors?.Select(author => author.MapAuthorEntityToAuthorLiteResource()).ToList()

        };
    }


    public static Book MapBookModelToEntity(this BookModel book)
    {
        return new Book
        {
            Name = book.Name,
            Title = book.Title,
        };
    }

    public static BookLiteResource MapBookEntityToBookLiteResource(this Book book)
    {
        return new BookLiteResource
        {
            Name = book.Name,
            Id = book.Id,
            Title = book.Title
        };
    }





}
