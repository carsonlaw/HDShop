namespace HDShop
{
    public static class HDShopDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */
        /// <summary>
        /// 商品已没有库存
        /// </summary>
        public const string GoodNoStock = "100001";
        /// <summary>
        /// 价格已经变动
        /// </summary>
        public const string PriceChanged = "100002";
        /// <summary>
        /// 没有找到对应的商品明细
        /// </summary>
        public const string NoGoodSku = "100003";
        public const string OrderCantConfirm = "100004";
    }
}
