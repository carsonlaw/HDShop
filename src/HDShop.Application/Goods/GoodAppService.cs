using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HDShop.Goods
{
    public class GoodAppService : CrudAppService<Good,
            GoodDto, //Used to show books
            Guid, //Primary key of the book entity
            QueryByCate, //Used for paging/sorting on getting a list of books
            GoodCreateUpdateDto, //Used to create a new book
            GoodCreateUpdateDto //Used to update a book
        >, IGoodAppService
    {
        public GoodAppService(IRepository<Good, Guid> repository)
            : base(repository)
        { }

        //public async Task<PagedResultDto<GoodDto>> GetGoodsByCate(QueryByCate input)
        //{
        //    var query = Repository.ToEfCoreRepository().WithDetails(f => f.GoodPropertieMaps, 
        //        f => f.GoodSkus);
            
        //    int totalCount = await AsyncQueryableExecuter.CountAsync(query).ConfigureAwait(continueOnCapturedContext: false);
        //    query = ApplySorting(query, input);
        //    query = ApplyPaging(query, input);
        //    return new PagedResultDto<GoodDto>(totalCount, (await AsyncQueryableExecuter.ToListAsync(query).ConfigureAwait(continueOnCapturedContext: false)).Select(MapToGetListOutputDto).ToList());
               
        //    //return await GetListAsync(input);
        //}
        protected override IQueryable<Good> CreateFilteredQuery(QueryByCate input)
        {
            var ret = base.CreateFilteredQuery(input)
                .AsNoTracking()
                .Include(f=>f.GoodSkus)
                .Include(f=>f.GoodProperties)
                .ThenInclude(f=>f.ChildGoodProperties)
                .AsQueryable();

            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.CateCode),
                f => f.GoodCategorys.Any(m => m.Code == input.CateCode));
            return ret;
        }

    }
}
