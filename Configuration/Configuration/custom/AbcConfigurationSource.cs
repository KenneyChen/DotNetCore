using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.custom
{
    public class AbcConfigurationSource : FileConfigurationSource
    {
        private string path;
        public AbcConfigurationSource(string path)
        {
            this.path = path;
        }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AbcConfigurationProvider(path);
        }
    }
}
