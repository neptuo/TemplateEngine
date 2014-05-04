using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public class XmlViewBundleLoader
    {
        protected IVirtualPathProvider PathProvider { get; private set; }

        public XmlViewBundleLoader(IVirtualPathProvider pathProvider)
        {
            Guard.NotNull(pathProvider, "pathProvider");
            PathProvider = pathProvider;
        }

        public void LoadXml(string filePath, IViewBundleCollection viewBundles)
        {
            Guard.NotNullOrEmpty(filePath, "filePath");
            Guard.NotNull(viewBundles, "viewBundles");

            XmlDocument document = new XmlDocument();
            document.Load(PathProvider.MapPath(filePath));

            if (document.DocumentElement.Name != "ViewBundles")
                return;

            foreach (XmlElement bundleElement in document.GetElementsByTagName("ViewBundle"))
            {
                string bundlePath = bundleElement.GetAttribute("Path");

                List<string> viewPaths = new List<string>();
                foreach (XmlElement viewElement in bundleElement.GetElementsByTagName("View"))
                    viewPaths.Add(viewElement.GetAttribute("Path"));

                List<string> scriptPaths = new List<string>();
                foreach (XmlElement scriptElement in bundleElement.GetElementsByTagName("Script"))
                    scriptPaths.Add(scriptElement.GetAttribute("Path"));

                List<IViewBundle> bundles = new List<IViewBundle>();
                if (String.IsNullOrEmpty(bundlePath))
                {
                    foreach (string viewPath in viewPaths)
                        bundles.Add(new ViewBundle(viewPath));
                }
                else
                {
                    bundles.Add(new ViewBundle(bundlePath));
                }

                foreach (IViewBundle bundle in bundles)
                {
                    viewPaths.ForEach(bundle.AddView);
                    scriptPaths.ForEach(bundle.AddScript);
                }

                bundles.ForEach(viewBundles.Add);
            }
        }

        public void LoadDirectory(string directoryPath, IViewBundleCollection viewBundles)
        {
            directoryPath = PathProvider.MapPath(directoryPath);

            foreach (string file in Directory.GetFiles(directoryPath, "*.xml", SearchOption.AllDirectories))
                LoadXml(file, viewBundles);
        }
    }
}
