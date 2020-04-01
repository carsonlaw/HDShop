using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace HDShop.Orders
{
    [Authorize]
    public class DeliverAddressAppService : CrudAppService<DeliverAddress,
            DeliverAddressDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting on getting a list of books
            DeliverAddressDto, //Used to create a new book
            DeliverAddressDto //Used to update a book
        >, IDeliverAddressAppService
    {
        public DeliverAddressAppService(IRepository<DeliverAddress, Guid> repository)
            : base(repository)
        { }

        
    }
}
