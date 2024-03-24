using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class WebTestController
    {
        private readonly IOptionsSnapshot<WebConfig> optWeb;

        public WebTestController(IOptionsSnapshot<WebConfig> optWeb)
        {
            this.optWeb = optWeb;
        }

        public void Test()
        {
            Console.WriteLine(optWeb.Value.Conn1.ConnectionString);
            Console.WriteLine(optWeb.Value.Conn1.ProviderName);
            Console.WriteLine(optWeb.Value.ConnTest.ConnectionString);
            Console.WriteLine(optWeb.Value.ConnTest.ProviderName);
            Console.WriteLine(optWeb.Value.Config.Name);
            Console.WriteLine(optWeb.Value.Config.Age);
            Console.WriteLine(optWeb.Value.Config.Proxy.Address);
            Console.WriteLine(optWeb.Value.Config.Proxy.Port);
            Console.WriteLine(string.Join('-',optWeb.Value.Config.Proxy.Ids));

        }
    }
}
