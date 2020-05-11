using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.custom
{
    public static class AbcConfigurationExtensions
    {
        public static IConfigurationBuilder AddAbcFile(this IConfigurationBuilder builder, string path)
        {
            return builder.Add(new AbcConfigurationSource(path));
        }
    }
}
