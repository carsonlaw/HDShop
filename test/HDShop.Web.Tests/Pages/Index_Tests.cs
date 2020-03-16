using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HDShop.Pages
{
    public class Index_Tests : HDShopWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
