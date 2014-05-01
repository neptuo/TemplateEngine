using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    public class JsonResponse
    {
        public string Response { get; private set; }
        public string ContentType { get; private set; }
        public int ReponseLength { get { return Response.Length; } }

        public JsonResponse(string response)
        {
            Response = response;
            ContentType = "application/json";
        }
    }
}
