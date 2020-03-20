using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HDShop.Goods
{
    public class GoodAppService : CrudAppService<Good,
            GoodDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting on getting a list of books
            GoodCreateUpdateDto, //Used to create a new book
            GoodCreateUpdateDto //Used to update a book
        >, IGoodAppService
    {
        public GoodAppService(IRepository<Good, Guid> repository)
            : base(repository)
        { }

        public async Task<PagedResultDto<GoodDto>> GetGoodsByCate(QueryByCate input)
        {
            var query = Repository.WithDetails(f => f.GoodSkus);
            return new PagedResultDto<GoodDto>()
            {
                TotalCount = query.Count(),
                Items = query.Select(MapToGetListOutputDto).ToList()
            };
               
            //return await GetListAsync(input);
        }
    }
}
