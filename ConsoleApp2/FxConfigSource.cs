using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //主要提供参数使用
    class FxConfigSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            //默认路径处理
            EnsureDefaults(builder);
            return new FxConfigProvider(this);
        }
    }
}
