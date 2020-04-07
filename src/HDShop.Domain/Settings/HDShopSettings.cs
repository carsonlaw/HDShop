namespace HDShop.Settings
{
    public static class HDShopSettings
    {
        private const string Prefix = "HDShop";

        //Add your own setting names here. Example:
        /// <summary>
        /// 当前机器码（小于订单机器码位数值）
        /// </summary>
        public const string OrderCodeMachine = Prefix + ".OrderCodeMachine";
        /// <summary>
        /// 订单机器码位数
        /// </summary>
        public const string OrderCodeMachineBit = Prefix + ".OrderCodeMachineBit";
        /// <summary>
        /// 订单序号位数
        /// </summary>
        public const string OrderCodeSequenceBit = Prefix + ".OrderCodeSequenceBit";
    }
}