using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HDShop.Goods
{
    public interface IGoodCategoryAppService : ICrudAppService< 
            GoodCategoryDto, 
            Guid, 
            PagedAndSortedResultRequestDto, 
            GoodCategoryCreateUpdateDto, 
            GoodCategoryCreateUpdateDto>
    {
    }
}
