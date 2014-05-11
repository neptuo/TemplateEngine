using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// JSON response result.
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// JSON content.
        /// </summary>
        public string Response { get; private set; }

        /// <summary>
        /// Content type.
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Length of content.
        /// </summary>
        public int ReponseLength { get { return Response.Length; } }

        public JsonResponse(string response)
        {
            Response = response;
            ContentType = "application/json";
        }
    }
}
