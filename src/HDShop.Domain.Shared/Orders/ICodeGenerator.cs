using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HDShop.Orders
{
    public interface ICodeGenerator
    {
        Task<string> Next();
    }
}
