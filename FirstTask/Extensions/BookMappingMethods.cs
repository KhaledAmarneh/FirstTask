using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.ComponentModel.DataAnnotations;


public static class BookMappingMethods


{
    public static BookResource BookEntityToResource(this BookEntity book)
    {
        return new BookResource
        {
            Name = book.Name,
            Title = book.Title,
            Id = book.Id
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





}
