using System;
using System.Collections.Generic;
using System.Text;

namespace PipelineDemo
{
    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);

        RequestDelegate Build();
    }
}
