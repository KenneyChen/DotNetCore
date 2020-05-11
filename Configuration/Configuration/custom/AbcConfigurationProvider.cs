using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.custom
{
    public class AbcConfigurationProvider : ConfigurationProvider
    {
        private string path;
        public AbcConfigurationProvider(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// 解析文件 加载到data对象
        /// </summary>
        public override void Load()
        {
            var text = System.IO.File.ReadAllLines(this.path);
            foreach (var r in text)
            {
                var arr = r.Split('|');
                this.Data.Add(arr[0], arr[1]);
            }
        }
    }
}
