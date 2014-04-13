/* Generated by SharpKit 5 v5.3.6 */

/* Generated by SharpKit 5 v5.3.6 */
if (typeof($CreateException)=='undefined') 
{
    var $CreateException = function(ex, error) 
    {
        if(error==null)
            error = new Error();
        if(ex==null)
            ex = new System.Exception.ctor();       
        error.message = ex.message;
        for (var p in ex)
           error[p] = ex[p];
        return error;
    }
}


if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Templates$Controls$StringTemplate = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.StringTemplate",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.ViewTemplateBase",
    assemblyName: "Neptuo.TemplateEngine.Templates",
    Kind: "Class",
    definition: {
        ctor: function (dependencyProvider, componentManager, viewService){
            this._ViewService = null;
            this._TemplateContent = null;
            Neptuo.TemplateEngine.Templates.Controls.ViewTemplateBase.ctor.call(this, dependencyProvider, componentManager);
            this.set_ViewService(viewService);
        },
        ViewService$$: "Neptuo.Templates.Compilation.IViewService",
        get_ViewService: function (){
            return this._ViewService;
        },
        set_ViewService: function (value){
            this._ViewService = value;
        },
        TemplateContent$$: "System.String",
        get_TemplateContent: function (){
            return this._TemplateContent;
        },
        set_TemplateContent: function (value){
            this._TemplateContent = value;
        },
        CreateView: function (){
            return Cast(this.get_ViewService().ProcessContent(this.get_TemplateContent(), new Neptuo.Templates.Compilation.ViewServiceContext.ctor(this.get_DependencyProvider())), Neptuo.Templates.BaseGeneratedView.ctor);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.IDependencyProvider", "Neptuo.Templates.IComponentManager", "Neptuo.Templates.Compilation.IViewService"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$StringTemplate);
var Neptuo$TemplateEngine$Templates$DataSources$ListDataSourceBase$1 = {
    fullname: "Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceBase$1",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates",
    interfaceNames: ["Neptuo.TemplateEngine.Templates.DataSources.IListDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (T, providerFactory){
            this.T = T;
            this._ProviderFactory = null;
            System.Object.ctor.call(this);
            if (providerFactory == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("providerFactory"), new Error());
            this.set_ProviderFactory(providerFactory);
        },
        ProviderFactory$$: "Neptuo.PresentationModels.TypeModels.IModelValueProviderFactory",
        get_ProviderFactory: function (){
            return this._ProviderFactory;
        },
        set_ProviderFactory: function (value){
            this._ProviderFactory = value;
        },
        GetData$$Nullable$1$Int32$$Nullable$1$Int32: function (pageIndex, pageSize){
            var $yield = [];
            var data = this.GetData();
            data = this.ApplyFilter(data);
            if (pageSize != null)
                data = System.Linq.Queryable.Take$1(this.T, System.Linq.Queryable.Skip$1(this.T, data, (pageIndex != null ? pageIndex : 0) * pageSize.get_Value()), pageSize.get_Value());
            var $it1 = data.GetEnumerator();
            while ($it1.MoveNext()){
                var item = $it1.get_Current();
                $yield.push(this.get_ProviderFactory().Create(item));
            }
            return $yield;
        },
        GetTotalCount: function (){
            var data = this.GetData();
            data = this.ApplyFilter(data);
            return System.Linq.Queryable.Count$1$$IQueryable$1(this.T, data);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.PresentationModels.TypeModels.IModelValueProviderFactory"]
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$DataSources$ListDataSourceBase$1);
var Neptuo$TemplateEngine$Templates$ViewServiceViewActivator = {
    fullname: "Neptuo.TemplateEngine.Templates.ViewServiceViewActivator",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates",
    interfaceNames: ["Neptuo.TemplateEngine.Templates.IViewActivator"],
    Kind: "Class",
    definition: {
        ctor: function (dependencyProvider, viewService){
            this.dependencyProvider = null;
            this.viewService = null;
            System.Object.ctor.call(this);
            this.dependencyProvider = dependencyProvider;
            this.viewService = viewService;
        },
        CreateView: function (path){
            return Cast(this.viewService.Process(path, new Neptuo.Templates.Compilation.ViewServiceContext.ctor(this.dependencyProvider)), Neptuo.Templates.BaseGeneratedView.ctor);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.IDependencyProvider", "Neptuo.Templates.Compilation.IViewService"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$ViewServiceViewActivator);


