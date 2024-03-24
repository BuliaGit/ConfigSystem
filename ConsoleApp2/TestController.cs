using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class TestController
    {
        private readonly IOptionsSnapshot<Address> optAddress;
        public TestController(IOptionsSnapshot<Address> optAddress)
        {
            this.optAddress = optAddress;
        }
        public void Test()
        {
            
            Console.WriteLine(optAddress.Value.Load);
            Console.WriteLine(optAddress.Value.Id);
        }
    }
}
