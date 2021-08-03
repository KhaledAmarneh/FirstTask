using ContosoPizza.Models;
using FirstTask.Entities;
using FirstTask.Resources;
using System.ComponentModel.DataAnnotations;


public static class AuthorMappingMethods

{
    public static AuthorResource AuthorEntityToResource(this AuthorEntity author)
    {
        return new AuthorResource
        {
            Name = author.Name,
            Id = author.Id
        };
    }


    public static AuthorEntity AuthorModelToEntity(this Author author)
    {
        return new AuthorEntity
        {
            Name = author.Name,
        };
    }





}
