using AutoMapper;
using HDShop.Goods;
using HDShop.Orders;
using System.Linq;

namespace HDShop
{
    public class HDShopApplicationAutoMapperProfile : Profile
    {
        public HDShopApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            #region GoodCategory
            CreateMap<GoodCategory, GoodCategoryDto>();
            CreateMap<GoodCategoryCreateUpdateDto, GoodCategory>();
            #endregion

            #region Good

            CreateMap<Good, GoodDto>()
                .ForMember(d=>d.GoodPropertieMaps,opt=>opt.MapFrom(s=>s.GoodPropertieMaps.Select(map=>map.GoodProperty)));
            CreateMap<GoodCreateUpdateDto, Good>();
            CreateMap<GoodSku, GoodSkuDto>();
            CreateMap<GoodSkuDto, GoodSku>();
            CreateMap<GoodProperty, GoodPropertyDto>();
            CreateMap<GoodPropertyDto, GoodProperty>();
            CreateMap<SaleStates, SaleStatesDto>();
            CreateMap<SaleStatesDto, SaleStates>();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>();
            CreateMap<OrderCreateUpdateDto, Order>()
                .ForMember(d => d.DeliverAddressMaps, opt => opt.MapFrom(s => s.DeliverAddress.Select(map=> new OrderDeliverAddressMap() { DeliverAddressId = map.Id })));
            CreateMap<OrderLine, OrderLineDto>();
            CreateMap<OrderLineDto, OrderLine>();
            
            CreateMap<PayOrder, PayOrderDto>();
            CreateMap<PayOrderDto, PayOrder>();

            CreateMap<DeliverOrder, DeliverOrderDto>();
            CreateMap<DeliverOrderDto, DeliverOrder>();


            #endregion
        }
    }
}
