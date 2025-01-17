﻿using EasyHttpClient.ActionFilters;
using EasyHttpClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyHttpClient
{
    public class MethodDescription
    {
        internal MethodDescription(MethodInfo methodInfo)
        {
            this.MethodInfo = methodInfo;
            this.ReturnTypeDescription = new ReturnTypeDescription();
            this.Parameters = new ParameterDescription[0];
            this.ActionFilters = new IActionFilter[0];
        }

        internal MethodDescription()
        {
            this.ReturnTypeDescription = new ReturnTypeDescription();
            this.Parameters = new ParameterDescription[0];
            this.ActionFilters = new IActionFilter[0];
        }
        public MethodInfo MethodInfo { get; private set; }
        public string Route { get; internal set; }
        public bool AuthorizeRequired { get; internal set; }
        public int MaxRetry { get; internal set; }
        public HttpMethod HttpMethod { get; internal set; }
        public ParameterDescription[] Parameters { get; internal set; }
        public ReturnTypeDescription ReturnTypeDescription { get; internal set; }
        internal MultiPartAttribute MultiPartAttribute { get; set; }
        internal IActionFilter[] ActionFilters { get; set; }
        internal Func<Task<HttpResponseMessage>, ActionContext, Task<IHttpResult>> HttpResultConverter { get; set; }
        internal Func<Func<Task<IHttpResult>>, object> MethodResultConveter { get; set; }
    }
}
