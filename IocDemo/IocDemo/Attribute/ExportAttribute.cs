using System;
using System.Collections.Generic;
using System.Text;

namespace IocDemo.Attribute
{
    public class ExportAttribute : System.Attribute
    {
        public string ImportName { get; set; }

        public ExportAttribute()
        {

        }

        public ExportAttribute(string name)
        {
            this.ImportName = name;
        }
    }
}
