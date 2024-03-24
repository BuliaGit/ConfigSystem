using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<TestController>();
            services.AddScoped<WebTestController>();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            //configurationBuilder.AddJsonFile("config.json", optional:false, reloadOnChange:true);
            //------命令行添加配置信息 name=xxx address:load=111
            //configurationBuilder.AddCommandLine(args);

            //----------自定义配置
            configurationBuilder.AddFxConfig("web.config");
            //configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).Add(new FxConfigSource() { Path = "web.config" });
            IConfigurationRoot configRoot = configurationBuilder.Build();


            //----------添加选项到容器中
            //--------config.json
            //services.AddOptions().Configure<Address>(e => configRoot.GetSection("address").Bind(e));
            //--------web.config
            services.AddOptions().Configure<WebConfig>(e => configRoot.Bind(e));


            //-----------测试实现DI类
            //using (ServiceProvider sp = services.BuildServiceProvider())
            //{
            //    TestController test = sp.GetRequiredService<TestController>();
            //    test.Test();
            //}
            //----------
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                var test = sp.GetRequiredService<WebTestController>();
                test.Test();
            }


            //-----------直接API读取配置
            //Console.WriteLine(configRoot["name"]);
            //Console.WriteLine(configRoot["pwd"]);
            //Console.WriteLine(configRoot.GetSection("address:sub").Value);
            //-----------Get映射类读取
            //Address address = configRoot.GetSection("address").Get<Address>();
            //Console.WriteLine(address.Load);
            //Console.WriteLine(address.Id);
        }
    }
    
    class Address
    {
        public string Load { get; set; }
        public int Id { get; set; }
    }
}
