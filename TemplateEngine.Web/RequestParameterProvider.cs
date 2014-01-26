﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web
{
    public class RequestParameterProvider : IParameterProvider
    {
        public HttpRequestBase HttpRequest { get; private set; }

        public RequestParameterProvider(HttpRequestBase httpRequest)
        {
            if (httpRequest == null)
                throw new ArgumentNullException("httpRequest");

            HttpRequest = httpRequest;
        }

        public bool TryGet(string key, out object value)
        {
            if(key == null)
                throw new ArgumentNullException("key");

            if (!HttpRequest.Params.AllKeys.Contains(key))
            {
                value = null;
                return false;
            }

            value = HttpRequest.Params[key];
            return true;
        }
    }
}