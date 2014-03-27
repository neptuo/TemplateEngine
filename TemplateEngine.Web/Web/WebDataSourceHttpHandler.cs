using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.TemplateEngine.Web.DataSources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web
{
    public class WebDataSourceHttpHandler : IHttpHandler
    {
        private IDependencyProvider dependencyProvider;

        public bool IsReusable
        {
            get { return true; }
        }

        public WebDataSourceHttpHandler(IDependencyProvider dependencyProvider)
        {
            Guard.NotNull(dependencyProvider, "dependencyProvider");
            this.dependencyProvider = dependencyProvider;
        }

        public void ProcessRequest(HttpContext context)
        {
            object data = null;
            string dataSourceName = context.Request.Params["DataSource"];
            Type dataSourceType = MapDataSource(dataSourceName);
            if (dataSourceType != null)
            {
                IModelBinder modelBinder = dependencyProvider.Resolve<IModelBinder>();
                object dataSourceObject = modelBinder.Bind(dataSourceType);

                IListDataSource listDataSource = dataSourceObject as IListDataSource;
                if (listDataSource != null)
                {
                    data = listDataSource.GetData(null, null); //TODO: Add paging
                }
                else
                {
                    IDataSource dataSource = dataSourceObject as IDataSource;
                    if (dataSource != null)
                        data = dataSource.GetItem();
                }
            }

            if(data != null)
            {
                string response = JsonConvert.SerializeObject(data);
                context.Response.ContentType = "application/json";
                context.Response.Write(response);
            }
        }

        protected virtual Type MapDataSource(string dataSourceName)
        {
            IWebDataSourceRegistry registry = dependencyProvider.Resolve<IWebDataSourceRegistry>();
            Type dataSourceType;
            if (registry.TryGet(dataSourceName, out dataSourceType))
                return dataSourceType;

            return null;
        }
    }
}
