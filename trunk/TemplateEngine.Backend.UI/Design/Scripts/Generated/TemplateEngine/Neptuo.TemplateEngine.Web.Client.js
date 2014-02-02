/* Generated by SharpKit 5 v5.3.4 */
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
var Neptuo$TemplateEngine$Web$Controls$ControlBase =
{
    fullname: "Neptuo.TemplateEngine.Web.Controls.ControlBase",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.Templates.Controls.IControl"],
    Kind: "Class",
    definition:
    {
        ctor: function (componentManager)
        {
            this.defaultPropertyName = null;
            this._ComponentManager = null;
            System.Object.ctor.call(this);
            this.set_ComponentManager(componentManager);
        },
        ComponentManager$$: "Neptuo.Templates.IComponentManager",
        get_ComponentManager: function ()
        {
            return this._ComponentManager;
        },
        set_ComponentManager: function (value)
        {
            this._ComponentManager = value;
        },
        DefaultPropertyName$$: "System.String",
        get_DefaultPropertyName: function ()
        {
            if (this.defaultPropertyName == null)
            {
                var attr = Neptuo.Reflection.ReflectionHelper.GetAttribute$1(System.ComponentModel.DefaultPropertyAttribute.ctor, this.GetType());
                if (attr != null)
                    this.defaultPropertyName = attr.get_Name();
            }
            return this.defaultPropertyName;
        },
        set_DefaultPropertyName: function (value)
        {
            this.defaultPropertyName = value;
        },
        OnInit: function ()
        {
        },
        Render: function (writer)
        {
        },
        InitComponent: function (component)
        {
            this.get_ComponentManager().Init(component);
        },
        RenderComponent: function (component, writer)
        {
            this.get_ComponentManager().Render(component, writer);
        },
        InitComponents$1: function (T, compoments)
        {
            if (compoments != null)
            {
                var $it1 = compoments.GetEnumerator();
                while ($it1.MoveNext())
                {
                    var component = $it1.get_Current();
                    this.InitComponent(component);
                }
            }
        }
    },
    ctors: [ {name: "ctor", parameters: ["Neptuo.Templates.IComponentManager"]}],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Web$Controls$ControlBase);
var Neptuo$TemplateEngine$Web$Controls$FileTemplate2 =
{
    fullname: "Neptuo.TemplateEngine.Web.Controls.FileTemplate2",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.Controls.ITemplate"],
    Kind: "Class",
    definition:
    {
        ctor: function (dependencyProvider, componentManager)
        {
            this.dependencyProvider = null;
            this.componentManager = null;
            this._Path = null;
            System.Object.ctor.call(this);
            this.dependencyProvider = dependencyProvider;
            this.componentManager = componentManager;
        },
        Path$$: "System.String",
        get_Path: function ()
        {
            return this._Path;
        },
        set_Path: function (value)
        {
            this._Path = value;
        },
        CreateView: function ()
        {
            if (this.get_Path() == "~/Views/Accounts/Login.view")
                return new Neptuo.Templates.View_3D09FEDA526F72327E9894F4A68B10A6DDEF92A5.ctor();
            if (this.get_Path() == "~/Views/Accounts/UserList.view")
                return new Neptuo.Templates.View_4871826135338C3DD897DE2539C817F096C4D1B7.ctor();
            if (this.get_Path() == "~/Views/Accounts/UserEdit.view")
                return new Neptuo.Templates.View_A9765037BA31823A1DE86513A9CB363FC6ED62C6.ctor();
            if (this.get_Path() == "~/Views/Accounts/RoleList.view")
                return new Neptuo.Templates.View_5889BF089264D8E71B12E789260799CEAFAF3495.ctor();
            if (this.get_Path() == "~/Views/Accounts/RoleEdit.view")
                return new Neptuo.Templates.View_76B4615AA7B3E8A93E8536FE35E7F10DCE4F723E.ctor();
            if (this.get_Path() == "~/Views/Accounts/SideNav.view")
                return new Neptuo.Templates.View_7386527D2661E330C28B00144916CF09DD787052.ctor();
            if (this.get_Path() == "~/Views/Shared/AdminLayout.view")
                return new Neptuo.Templates.View_B3FB932CB3BBED93A72876CB64C25B2BDE4D0C0E.ctor();
            if (this.get_Path() == "~/Views/Shared/SubHeader.view")
                return new Neptuo.Templates.View_4DDEE9A62BE4F945CAD406C3AEF5F059B5A01614.ctor();
            if (this.get_Path() == "~/Views/Home.view")
                return new Neptuo.Templates.View_169A146015B9683BA3DA19241AEB502786C332B0.ctor();
            return null;
        },
        CreateInstance: function ()
        {
            var view = this.CreateView();
            view.Setup(new Neptuo.Templates.BaseViewPage.ctor(this.componentManager), this.componentManager, this.dependencyProvider);
            view.CreateControls();
            var templateContent = new Neptuo.TemplateEngine.Web.Controls.ViewTemplateContent.ctor(view);
            this.componentManager.AddComponent$1(Neptuo.TemplateEngine.Web.Controls.ViewTemplateContent.ctor, templateContent, null);
            return templateContent;
        },
        Dispose: function ()
        {
        }
    },
    ctors: [ {name: "ctor", parameters: ["Neptuo.IDependencyProvider", "Neptuo.Templates.IComponentManager"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$Controls$FileTemplate2);
var Neptuo$TemplateEngine$Web$Controls$ITextControl = {fullname: "Neptuo.TemplateEngine.Web.Controls.ITextControl", baseTypeName: "System.Object", assemblyName: "Neptuo.TemplateEngine.Web.Client", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$TemplateEngine$Web$Controls$ITextControl);
var Neptuo$TemplateEngine$Web$Controls$LiteralControl =
{
    fullname: "Neptuo.TemplateEngine.Web.Controls.LiteralControl",
    baseTypeName: "Neptuo.TemplateEngine.Web.Controls.ControlBase",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.Controls.ITextControl"],
    Kind: "Class",
    definition:
    {
        ctor: function (componentManager)
        {
            this._Text = null;
            this._FormatString = null;
            Neptuo.TemplateEngine.Web.Controls.ControlBase.ctor.call(this, componentManager);
        },
        Text$$: "System.String",
        get_Text: function ()
        {
            return this._Text;
        },
        set_Text: function (value)
        {
            this._Text = value;
        },
        FormatString$$: "System.String",
        get_FormatString: function ()
        {
            return this._FormatString;
        },
        set_FormatString: function (value)
        {
            this._FormatString = value;
        },
        Render: function (writer)
        {
            if (!System.String.IsNullOrEmpty(this.get_FormatString()))
                writer.Content$$String(System.String.Format$$String$$Object(this.get_FormatString(), this.get_Text()));
            else
                writer.Content$$String(this.get_Text());
        }
    },
    ctors: [ {name: "ctor", parameters: ["Neptuo.Templates.IComponentManager"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$Controls$LiteralControl);
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource =
{
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserAccountDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.IListDataSource", "Neptuo.TemplateEngine.Web.IDataSource"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this._Key = null;
            this._Username = null;
            System.Object.ctor.call(this);
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function ()
        {
            return this._Key;
        },
        set_Key: function (value)
        {
            this._Key = value;
        },
        Username$$: "System.String",
        get_Username: function ()
        {
            return this._Username;
        },
        set_Username: function (value)
        {
            this._Username = value;
        },
        GetItem: function ()
        {
            return null;
        },
        GetData: function (pageIndex, pageSize)
        {
            return new System.Collections.Generic.List$1.ctor(System.Object.ctor);
        },
        GetTotalCount: function ()
        {
            return 0;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource);
var Neptuo$TemplateEngine$Web$GeneratedViewBase =
{
    fullname: "Neptuo.TemplateEngine.Web.GeneratedViewBase",
    baseTypeName: "Neptuo.Templates.BaseGeneratedView",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this.urlProvider = null;
            Neptuo.Templates.BaseGeneratedView.ctor.call(this);
        },
        ResolveUrl: function (relativeUrl)
        {
            if (this.urlProvider == null)
                this.urlProvider = Neptuo.DependencyProviderExtensions.Resolve$1$$IDependencyProvider(Neptuo.Templates.IVirtualUrlProvider.ctor, this.dependencyProvider);
            return this.urlProvider.ResolveUrl(relativeUrl);
        },
        CastValueTo$1: function (T, value)
        {
            return Cast(value, T);
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Web$GeneratedViewBase);
var Neptuo$TemplateEngine$Web$Client$InitScript =
{
    fullname: "Neptuo.TemplateEngine.Web.Client.InitScript",
    baseTypeName: "System.Object",
    staticDefinition:
    {
        Init: function (container)
        {
            Neptuo.DependencyContainerExtensions.RegisterInstance$1(Neptuo.TemplateEngine.Web.TemplateContentStorageStack.ctor, Neptuo.DependencyContainerExtensions.RegisterType$2$$IDependencyContainer(Neptuo.TemplateEngine.Web.IParameterProvider.ctor, Neptuo.TemplateEngine.Web.Client.ParameterProvider.ctor, Neptuo.DependencyContainerExtensions.RegisterType$2$$IDependencyContainer(Neptuo.TemplateEngine.Web.IParameterProviderFactory.ctor, Neptuo.TemplateEngine.Web.Client.ParameterProviderFactory.ctor, Neptuo.DependencyContainerExtensions.RegisterType$2$$IDependencyContainer(Neptuo.TemplateEngine.Web.ICurrentUrlProvider.ctor, Neptuo.TemplateEngine.Web.Client.UrlProvider.ctor, Neptuo.DependencyContainerExtensions.RegisterType$2$$IDependencyContainer(Neptuo.Templates.IVirtualUrlProvider.ctor, Neptuo.TemplateEngine.Web.Client.UrlProvider.ctor, Neptuo.DependencyContainerExtensions.RegisterType$2$$IDependencyContainer(Neptuo.TemplateEngine.IStackStorage$1.ctor, Neptuo.TemplateEngine.StackStorage$1.ctor, container))))), new Neptuo.TemplateEngine.Web.TemplateContentStorageStack.ctor());
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Web$Client$InitScript);
var Neptuo$TemplateEngine$Web$Client$UrlProvider =
{
    fullname: "Neptuo.TemplateEngine.Web.Client.UrlProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.Templates.IVirtualUrlProvider", "Neptuo.TemplateEngine.Web.ICurrentUrlProvider"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        },
        ResolveUrl: function (path)
        {
            return path.Replace$$String$$String("~/", "/");
        },
        GetCurrentUrl: function ()
        {
            return location.href;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$Client$UrlProvider);
var Neptuo$TemplateEngine$Web$Client$ParameterProviderFactory =
{
    fullname: "Neptuo.TemplateEngine.Web.Client.ParameterProviderFactory",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.IParameterProviderFactory"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        },
        Provider: function (providerType)
        {
            return new Neptuo.TemplateEngine.Web.Client.ParameterProvider.ctor();
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$Client$ParameterProviderFactory);
var Neptuo$TemplateEngine$Web$Client$ParameterProvider =
{
    fullname: "Neptuo.TemplateEngine.Web.Client.ParameterProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.IParameterProvider"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        },
        Keys$$: "System.Collections.Generic.IEnumerable`1[[System.String]]",
        get_Keys: function ()
        {
            return new System.Collections.Generic.List$1.ctor(System.String.ctor);
        },
        TryGet: function (key, value)
        {
            value.Value = null;
            return false;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$Client$ParameterProvider);
