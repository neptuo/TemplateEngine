using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Neptuo.TemplateEngine.Hosting.DataSources;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Hosting
{
    public class WebDataSourceHttpHandler : IHttpHandler
    {
        private IModelBinder modelBinder;
        private IWebDataSourceRegistry registry;

        public bool IsReusable
        {
            get { return true; }
        }

        public WebDataSourceHttpHandler(IModelBinder modelBinder, IWebDataSourceRegistry registry)
        {
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(registry, "registry");
            this.modelBinder = modelBinder;
            this.registry = registry;
        }

        public void ProcessRequest(HttpContext context)
        {
            WebDataSourceModel model = modelBinder.Bind<WebDataSourceModel>();

            object data = null;
            Type dataSourceType = MapDataSource(model.DataSource);
            if (dataSourceType != null)
            {
                object dataSourceObject = modelBinder.Bind(dataSourceType);

                IListDataSource listDataSource = dataSourceObject as IListDataSource;
                if (listDataSource != null)
                {
                    data = new ListResult(listDataSource.GetData(model.PageIndex, model.PageSize), listDataSource.GetTotalCount());
                }
                else
                {
                    IDataSource dataSource = dataSourceObject as IDataSource;
                    if (dataSource != null)
                        data = dataSource.GetItem();
                }
            }

            JsonResponse jsonResponse;
            if(data != null && Converts.Try(data, out jsonResponse))
            {
                context.Response.ContentType = jsonResponse.ContentType;
                context.Response.Write(jsonResponse.Response);
            }
        }

        protected virtual Type MapDataSource(string dataSourceName)
        {
            Type dataSourceType;
            if (registry.TryGet(dataSourceName, out dataSourceType))
                return dataSourceType;

            return null;
        }
    }
}
