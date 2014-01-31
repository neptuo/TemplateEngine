/* Generated by SharpKit 5 v5.3.4 */
if (typeof($CreateDelegate)=='undefined'){
    if(typeof($iKey)=='undefined') var $iKey = 0;
    if(typeof($pKey)=='undefined') var $pKey = String.fromCharCode(1);
    var $CreateDelegate = function(target, func){
        if (target == null || func == null) 
            return func;
        if(func.target==target && func.func==func)
            return func;
        if (target.$delegateCache == null)
            target.$delegateCache = {};
        if (func.$key == null)
            func.$key = $pKey + String(++$iKey);
        var delegate;
        if(target.$delegateCache!=null)
            delegate = target.$delegateCache[func.$key];
        if (delegate == null){
            delegate = function(){
                return func.apply(target, arguments);
            };
            delegate.func = func;
            delegate.target = target;
            delegate.isDelegate = true;
            if(target.$delegateCache!=null)
                target.$delegateCache[func.$key] = delegate;
        }
        return delegate;
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
var Neptuo$Templates$View_3D09FEDA526F72327E9894F4A68B10A6DDEF92A5 =
{
    fullname: "Neptuo.Templates.View_3D09FEDA526F72327E9894F4A68B10A6DDEF92A5",
    baseTypeName: "Neptuo.TemplateEngine.Web.GeneratedViewBase",
    assemblyName: "Neptuo.TemplateEngine.Web.Client",
    interfaceNames: ["System.IDisposable"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            Neptuo.TemplateEngine.Web.GeneratedViewBase.ctor.call(this);
        },
        CreateViewPageControls: function (viewPage)
        {
            this.get_Content().Add("<strong>\r\n    ");
            this.get_Content().Add(this.field97_Create());
            this.get_Content().Add("\r\n");
            this.get_Content().Add("</strong>\r\n");
        },
        field97_Create: function ()
        {
            var field97 = new Neptuo.TemplateEngine.Web.Controls.LiteralControl.ctor(this.componentManager);
            this.componentManager.AddComponent$1(Neptuo.TemplateEngine.Web.Controls.LiteralControl.ctor, field97, $CreateDelegate(this, this.field97_Bind));
            return field97;
        },
        field97_Bind: function (field97)
        {
            field97.set_Text("Hello [from login]!!");
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Templates$View_3D09FEDA526F72327E9894F4A68B10A6DDEF92A5);
