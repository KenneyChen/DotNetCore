using System;
using System.Collections.Generic;
using System.Text;

namespace IocDemo.Attribute
{

    public class ImportAttribute : System.Attribute
    {
        public string ImportName { get; set; }

        public ImportAttribute()
        {

        }

        public ImportAttribute(string name)
        {
            this.ImportName = name;
        }
    }
}
