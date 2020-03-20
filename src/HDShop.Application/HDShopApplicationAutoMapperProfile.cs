﻿using AutoMapper;
using HDShop.Goods;
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
        }
    }
}
