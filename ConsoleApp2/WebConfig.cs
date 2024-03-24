using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class WebConfig
    {
        public ConnectStr Conn1 { get; set; }
        public ConnectStr ConnTest { get; set;  }
        public Config Config { get; set; }
    }
    
    class ConnectStr
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }

    class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Proxy Proxy { get; set; }
    }
    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public int[] Ids { get; set; }
    }
}
