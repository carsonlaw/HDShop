using HDShop.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HDShop.Orders
{
    public class OrderAppService : CrudAppService<Order,
            OrderDto, //Used to show books
            Guid, //Primary key of the book entity
            OrderQueryRequestDto, //Used for paging/sorting on getting a list of books
            OrderCreateUpdateDto, //Used to create a new book
            OrderCreateUpdateDto //Used to update a book
        >, IOrderAppService
    {
        IRepository<Good, Guid> _repGood;
        OrderService _orderService;
        public OrderAppService(IRepository<Order, Guid> repository
            , IRepository<Good, Guid> repGood
            , OrderService orderService)
            : base(repository)
        {
            _repGood = repGood;
            _orderService = orderService;
        }

        public override async Task<OrderDto> CreateAsync(OrderCreateUpdateDto input)
        {
            await CheckCreatePolicyAsync().ConfigureAwait(continueOnCapturedContext: false);
            var entity = MapToEntity(input);
            
            await _orderService.SetCodeIfNull(entity);
            await _orderService.CalcOrderPrice(entity);
            //下单即确认
            await _orderService.SetOrderConfirmed(entity);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true).ConfigureAwait(continueOnCapturedContext: false);
            return MapToGetOutputDto(entity);
        }

        protected override IQueryable<Order> CreateFilteredQuery(OrderQueryRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .AsNoTracking()
                .Include(f=>f.OrderLines)
                .Where(f=>f.CreatorId == CurrentUser.Id);
        }
    }
}
