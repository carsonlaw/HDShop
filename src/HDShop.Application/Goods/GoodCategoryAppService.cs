using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HDShop.Goods
{
    public class GoodCategoryAppService : CrudAppService<GoodCategory,
            GoodCategoryDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting on getting a list of books
            GoodCategoryCreateUpdateDto, //Used to create a new book
            GoodCategoryCreateUpdateDto //Used to update a book
        >, IGoodCategoryAppService
    {
        public GoodCategoryAppService(IRepository<GoodCategory,Guid> repository)
            :base(repository)
        { }
    }
}
