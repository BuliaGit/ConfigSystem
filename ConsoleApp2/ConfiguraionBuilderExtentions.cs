using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    static class ConfiguraionBuilderExtentions
    {
        public static IConfigurationBuilder AddFxConfig(this IConfigurationBuilder builder,string file)
        {
            builder.Add(new FxConfigSource(){ Path = file });
            return builder;
        }
    }
}
