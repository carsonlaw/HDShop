using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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
        public OrderAppService(IRepository<Order, Guid> repository)
            : base(repository)
        { }
    }
}
