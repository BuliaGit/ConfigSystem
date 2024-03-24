using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    /// <summary>
    ///自定义配置读取器
    /// </summary>
    class FxConfigProvider : FileConfigurationProvider
    {
        //调用父类构造函数传参处理
        public FxConfigProvider(FxConfigSource src) : base(src) { }

        /// <summary>
        /// 对目标配置文件数据扁平化处理到Dictionary<string, string>字典中
        /// </summary>
        /// <param name="stream">文件流</param>
        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            var csNodes = xmlDoc.SelectNodes("/configuration/connectionStrings/add");
            foreach (var xmlNode in csNodes.Cast<XmlNode>())
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;

                data[$"{name}:connectionString"] = connectionString;
                var attProviderName = xmlNode.Attributes["providerName"];
                if (attProviderName != null)
                {
                    data[$"{name}:providerName"] = attProviderName.Value;
                }
            }
            var asNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
            foreach (var xmlNode in asNodes.Cast<XmlNode>())
            {
                string key = xmlNode.Attributes["key"].Value;
                key = key.Replace('.', ':');
                string value = xmlNode.Attributes["value"].Value;
                data[key] = value;
            }
            this.Data = data;
        }
    }
}
