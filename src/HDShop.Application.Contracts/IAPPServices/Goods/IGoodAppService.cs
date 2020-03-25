using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HDShop.Goods
{
    public interface IGoodAppService : ICrudAppService< //Defines CRUD methods
            GoodDto, //Used to show books
            Guid, //Primary key of the book entity
            QueryByCate, //Used for paging/sorting on getting a list of books
            GoodCreateUpdateDto, //Used to create a new book
            GoodCreateUpdateDto> //Used to update a book
    {
    }
}
