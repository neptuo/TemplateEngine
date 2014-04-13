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

if (typeof ($CreateAnonymousDelegate) == 'undefined') {
    var $CreateAnonymousDelegate = function (target, func) {
        if (target == null || func == null)
            return func;
        var delegate = function () {
            return func.apply(target, arguments);
        };
        delegate.func = func;
        delegate.target = target;
        delegate.isDelegate = true;
        return delegate;
    }
}


if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Templates$Controls$PartialStartUpControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.PartialStartUpControl",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    interfaceNames: ["Neptuo.Templates.Controls.IControl"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._DefaultUpdate = null;
            System.Object.ctor.call(this);
        },
        DefaultUpdate$$: "System.String",
        get_DefaultUpdate: function (){
            return this._DefaultUpdate;
        },
        set_DefaultUpdate: function (value){
            this._DefaultUpdate = value;
        },
        OnInit: function (){
            Neptuo.Guard.NotNull$$Object$$String(this.get_DefaultUpdate(), "DefaultUpdate");
        },
        Render: function (writer){
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$PartialStartUpControl);
var Neptuo$TemplateEngine$Templates$Controls$PartialViewControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.PartialViewControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.HtmlContentControlBase",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Class",
    definition: {
        ctor: function (componentManager, updateWriter){
            this._UpdateWriter = null;
            this._Partial = null;
            Neptuo.TemplateEngine.Templates.Controls.HtmlContentControlBase.ctor.call(this, componentManager, "div", false);
            this.set_UpdateWriter(updateWriter);
        },
        UpdateWriter$$: "Neptuo.TemplateEngine.Templates.IPartialUpdateWriter",
        get_UpdateWriter: function (){
            return this._UpdateWriter;
        },
        set_UpdateWriter: function (value){
            this._UpdateWriter = value;
        },
        Partial$$: "System.String",
        get_Partial: function (){
            return this._Partial;
        },
        set_Partial: function (value){
            this._Partial = value;
        },
        OnInit: function (){
            Neptuo.Guard.NotNull$$Object$$String(this.get_Partial(), "Partial");
            Neptuo.TemplateEngine.Templates.Controls.HtmlContentControlBase.commonPrototype.OnInit.call(this);
            this.get_UpdateWriter().Update(this.get_Partial(), this);
            this.get_Attributes().Add("data-update", this.get_Partial());
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IComponentManager", "Neptuo.TemplateEngine.Templates.IPartialUpdateWriter"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$PartialViewControl);
var Neptuo$TemplateEngine$Templates$Controls$BundleControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.BundleControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.BundleControlBase",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            Neptuo.TemplateEngine.Templates.Controls.BundleControlBase.ctor.call(this, urlProvider);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$BundleControl);
var Neptuo$TemplateEngine$Templates$Controls$DetailViewControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.DetailViewControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.TemplateControl",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Class",
    definition: {
        ctor: function (componentManager, storage, dataContext, updateHelper, notifyService){
            this._Source = null;
            this._DataContext = null;
            this._UpdateHelper = null;
            this._NotifyService = null;
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.ctor.call(this, componentManager, storage);
            this.set_DataContext(dataContext);
            this.set_UpdateHelper(updateHelper);
            this.set_NotifyService(notifyService);
        },
        Source$$: "Neptuo.TemplateEngine.Templates.DataSources.IDataSource",
        get_Source: function (){
            return this._Source;
        },
        set_Source: function (value){
            this._Source = value;
        },
        DataContext$$: "Neptuo.TemplateEngine.Templates.DataContextStorage",
        get_DataContext: function (){
            return this._DataContext;
        },
        set_DataContext: function (value){
            this._DataContext = value;
        },
        UpdateHelper$$: "Neptuo.TemplateEngine.Web.PartialUpdateHelper",
        get_UpdateHelper: function (){
            return this._UpdateHelper;
        },
        set_UpdateHelper: function (value){
            this._UpdateHelper = value;
        },
        NotifyService$$: "Neptuo.TemplateEngine.Web.AsyncNotifyService",
        get_NotifyService: function (){
            return this._NotifyService;
        },
        set_NotifyService: function (value){
            this._NotifyService = value;
        },
        OnInit: function (){
            this.InitComponent(this.get_Source());
            if (this.get_Source() == null)
                throw $CreateException(new System.InvalidOperationException.ctor$$String("Missing data source."), new Error());
            this.get_UpdateHelper().add_RenderContent($CreateDelegate(this, this.OnRenderContent));
            this.get_UpdateHelper().OnInit();
            this.get_NotifyService().Register(this);
            this.get_Source().GetItem($CreateDelegate(this, this.OnLoadData), $CreateDelegate(this, this.OnError));
        },
        OnRenderContent: function (writer){
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.commonPrototype.Render.call(this, writer);
        },
        Render: function (writer){
            this.get_UpdateHelper().Render(writer);
        },
        OnLoadData: function (data){
            this.get_DataContext().Push(data, null);
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.commonPrototype.OnInit.call(this);
            this.get_DataContext().Pop(null);
            this.get_UpdateHelper().OnDataLoaded();
            this.get_NotifyService().NotifyDone(this);
        },
        OnError: function (model){
            this.get_UpdateHelper().OnError(model);
            this.get_NotifyService().NotifyDone(this);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IComponentManager", "Neptuo.TemplateEngine.Templates.TemplateContentStorageStack", "Neptuo.TemplateEngine.Templates.DataContextStorage", "Neptuo.TemplateEngine.Web.PartialUpdateHelper", "Neptuo.TemplateEngine.Web.AsyncNotifyService"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$DetailViewControl);
var Neptuo$TemplateEngine$Templates$Controls$DropDownListControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.DropDownListControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.SelectControl",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Class",
    definition: {
        ctor: function (partialHelper, context){
            this._ID = null;
            this._CssStyle = null;
            this._CssClass = null;
            Neptuo.TemplateEngine.Templates.Controls.SelectControl.ctor.call(this, partialHelper, context);
        },
        ID$$: "System.String",
        get_ID: function (){
            return this._ID;
        },
        set_ID: function (value){
            this._ID = value;
        },
        CssStyle$$: "System.String",
        get_CssStyle: function (){
            return this._CssStyle;
        },
        set_CssStyle: function (value){
            this._CssStyle = value;
        },
        CssClass$$: "System.String",
        get_CssClass: function (){
            return this._CssClass;
        },
        set_CssClass: function (value){
            this._CssClass = value;
        },
        OnInit: function (){
            if (this.get_ID() == null)
                this.set_ID(this.get_Name());
            Neptuo.TemplateEngine.Templates.Controls.SelectControl.commonPrototype.OnInit.call(this);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Web.PartialUpdateHelper", "Neptuo.TemplateEngine.Templates.Controls.SelectControlContext"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$DropDownListControl);
var Neptuo$TemplateEngine$Templates$Controls$ListViewControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.ListViewControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.TemplateControl",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Class",
    definition: {
        ctor: function (requestContext, storage, dataContext, updateHelper){
            this._Source = null;
            this._ItemTemplate = null;
            this._EmptyTemplate = null;
            this._Pagination = null;
            this._PageSize = null;
            this._PageIndex = null;
            this._TotalCount = 0;
            this._RequestContext = null;
            this._DataContext = null;
            this._UpdateHelper = null;
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.ctor.call(this, requestContext.get_ComponentManager(), storage);
            this.set_RequestContext(requestContext);
            this.set_DataContext(dataContext);
            this.set_UpdateHelper(updateHelper);
        },
        Source$$: "Neptuo.TemplateEngine.Templates.DataSources.IListDataSource",
        get_Source: function (){
            return this._Source;
        },
        set_Source: function (value){
            this._Source = value;
        },
        ItemTemplate$$: "Neptuo.TemplateEngine.Templates.Controls.ITemplate",
        get_ItemTemplate: function (){
            return this._ItemTemplate;
        },
        set_ItemTemplate: function (value){
            this._ItemTemplate = value;
        },
        EmptyTemplate$$: "Neptuo.TemplateEngine.Templates.Controls.ITemplate",
        get_EmptyTemplate: function (){
            return this._EmptyTemplate;
        },
        set_EmptyTemplate: function (value){
            this._EmptyTemplate = value;
        },
        Pagination$$: "Neptuo.TemplateEngine.Templates.Controls.IPaginationControl",
        get_Pagination: function (){
            return this._Pagination;
        },
        set_Pagination: function (value){
            this._Pagination = value;
        },
        PageSize$$: "System.Nullable`1[[System.Int32]]",
        get_PageSize: function (){
            return this._PageSize;
        },
        set_PageSize: function (value){
            this._PageSize = value;
        },
        PageIndex$$: "System.Nullable`1[[System.Int32]]",
        get_PageIndex: function (){
            return this._PageIndex;
        },
        set_PageIndex: function (value){
            this._PageIndex = value;
        },
        TotalCount$$: "System.Int32",
        get_TotalCount: function (){
            return this._TotalCount;
        },
        set_TotalCount: function (value){
            this._TotalCount = value;
        },
        RequestContext$$: "Neptuo.TemplateEngine.Providers.IRequestContext",
        get_RequestContext: function (){
            return this._RequestContext;
        },
        set_RequestContext: function (value){
            this._RequestContext = value;
        },
        DataContext$$: "Neptuo.TemplateEngine.Templates.DataContextStorage",
        get_DataContext: function (){
            return this._DataContext;
        },
        set_DataContext: function (value){
            this._DataContext = value;
        },
        UpdateHelper$$: "Neptuo.TemplateEngine.Web.PartialUpdateHelper",
        get_UpdateHelper: function (){
            return this._UpdateHelper;
        },
        set_UpdateHelper: function (value){
            this._UpdateHelper = value;
        },
        OnInit: function (){
            this.InitComponent(this.get_ItemTemplate());
            if (this.get_ItemTemplate() == null)
                throw $CreateException(new System.ArgumentException.ctor$$String$$String("Missing item template.", "ItemTemplate"), new Error());
            this.InitComponent(this.get_Source());
            if (this.get_Source() == null)
                throw $CreateException(new System.ArgumentException.ctor$$String$$String("Missing data source.", "Source"), new Error());
            this.get_UpdateHelper().add_RenderContent($CreateDelegate(this, this.OnRenderContent));
            this.get_UpdateHelper().OnInit();
            this.GetModelPage(this.get_PageIndex(), this.get_PageSize(), $CreateDelegate(this, this.OnLoadData), $CreateDelegate(this, this.OnError));
        },
        GetModelPage: function (pageIndex, pageSize, callback, errorCallback){
            this.get_Source().GetData(pageIndex, pageSize, callback, errorCallback);
        },
        ProcessModelItem: function (itemTemplates, model){
            this.get_DataContext().Push(model, null);
            itemTemplates.Add(this.InitTemplate(this.get_ItemTemplate()));
            this.get_DataContext().Pop(null);
        },
        OnRenderContent: function (writer){
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.commonPrototype.Render.call(this, writer);
            this.RenderComponent(this.get_Pagination(), writer);
        },
        GetBaseUrl: function (){
            var currentUrl = this.get_RequestContext().GetCurrentUrl();
            var indexOfQueryString = currentUrl.indexOf("?");
            if (indexOfQueryString > 0)
                currentUrl = currentUrl.substr(0, indexOfQueryString);
            return currentUrl;
        },
        Render: function (writer){
            this.get_UpdateHelper().Render(writer);
        },
        OnLoadData: function (result){
            var isEmpty = true;
            var itemTemplates = new System.Collections.Generic.List$1.ctor(System.Object.ctor);
            this.get_DataContext().Push(this, "Template");
            this.set_TotalCount(result.get_TotalCount());
            var $it1 = result.get_Data().GetEnumerator();
            while ($it1.MoveNext()){
                var model = $it1.get_Current();
                isEmpty = false;
                this.ProcessModelItem(itemTemplates, model);
            }
            if (isEmpty && this.get_EmptyTemplate() != null){
                this.set_Template(this.get_EmptyTemplate());
            }
            else {
                var templateContent = (function (){
                    var $v1 = new Neptuo.TemplateEngine.Templates.Controls.TemplateContentControl.ctor(this.get_ComponentManager());
                    $v1.set_Name("Content");
                    $v1.set_Content(itemTemplates);
                    return $v1;
                }).call(this);
                this.get_ComponentManager().AddComponent$1(Neptuo.TemplateEngine.Templates.Controls.TemplateContentControl.ctor, templateContent, null);
                this.InitComponent(templateContent);
                this.get_Content().Add(templateContent);
            }
            Neptuo.TemplateEngine.Templates.Controls.TemplateControl.commonPrototype.OnInit.call(this);
            if (this.get_PageSize() != null)
                this.set_Pagination(new Neptuo.TemplateEngine.Templates.Controls.PaginationControl.ctor(this.get_ComponentManager(), this.get_RequestContext(), this.get_TemplateStorageStack()));
            if (this.get_Pagination() != null){
                this.get_Pagination().set_PageIndex((this.get_PageIndex() != null ? this.get_PageIndex() : 0));
                this.get_Pagination().set_PageSize(this.get_PageSize().get_Value());
                this.get_Pagination().set_TotalCount(this.get_TotalCount());
                this.InitComponent(this.get_Pagination());
            }
            this.get_DataContext().Pop("Template");
            this.get_UpdateHelper().OnDataLoaded();
        },
        OnError: function (model){
            this.get_UpdateHelper().OnError(model);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.IRequestContext", "Neptuo.TemplateEngine.Templates.TemplateContentStorageStack", "Neptuo.TemplateEngine.Templates.DataContextStorage", "Neptuo.TemplateEngine.Web.PartialUpdateHelper"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$ListViewControl);
var Neptuo$TemplateEngine$Templates$Controls$SelectControl = {
    fullname: "Neptuo.TemplateEngine.Templates.Controls.SelectControl",
    baseTypeName: "Neptuo.TemplateEngine.Templates.Controls.ListViewControl",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Templates.Controls.IHtmlAttributeCollection", "Neptuo.Templates.IAttributeCollection"],
    Kind: "Class",
    definition: {
        ctor: function (updateHelper, context){
            this._Name = null;
            this._Value = null;
            this._IsAddEmpty = false;
            this._Attributes = null;
            this._SelectedValuePath = null;
            this._BindingManager = null;
            Neptuo.TemplateEngine.Templates.Controls.ListViewControl.ctor.call(this, context.get_RequestContext(), context.get_Storage(), context.get_DataContext(), updateHelper);
            this.set_Attributes(new Neptuo.Templates.HtmlAttributeCollection.ctor());
            this.set_BindingManager(context.get_BindingManager());
        },
        Name$$: "System.String",
        get_Name: function (){
            return this._Name;
        },
        set_Name: function (value){
            this._Name = value;
        },
        Value$$: "System.Object",
        get_Value: function (){
            return this._Value;
        },
        set_Value: function (value){
            this._Value = value;
        },
        IsAddEmpty$$: "System.Boolean",
        get_IsAddEmpty: function (){
            return this._IsAddEmpty;
        },
        set_IsAddEmpty: function (value){
            this._IsAddEmpty = value;
        },
        Attributes$$: "Neptuo.Templates.HtmlAttributeCollection",
        get_Attributes: function (){
            return this._Attributes;
        },
        set_Attributes: function (value){
            this._Attributes = value;
        },
        SelectedValuePath$$: "System.String",
        get_SelectedValuePath: function (){
            return this._SelectedValuePath;
        },
        set_SelectedValuePath: function (value){
            this._SelectedValuePath = value;
        },
        BindingManager$$: "Neptuo.TemplateEngine.Templates.IBindingManager",
        get_BindingManager: function (){
            return this._BindingManager;
        },
        set_BindingManager: function (value){
            this._BindingManager = value;
        },
        SetAttribute: function (name, value){
            this.get_Attributes().set_Item$$TKey(name, value);
        },
        OnInit: function (){
            Neptuo.Guard.NotNullOrEmpty(this.get_SelectedValuePath(), "SelectedValuePath");
            Neptuo.TemplateEngine.Templates.Controls.ListViewControl.commonPrototype.OnInit.call(this);
        },
        ProcessModelItem: function (itemTemplates, model){
            var item = new Neptuo.TemplateEngine.Templates.Controls.SelectItem.ctor(model);
            var targetSelectedValue;
            if ((function (){
                var $1 = {
                    Value: targetSelectedValue
                };
                var $res = this.get_BindingManager().TryGetValue(this.get_SelectedValuePath(), model, $1);
                targetSelectedValue = $1.Value;
                return $res;
            }).call(this))
                item.set_IsSelected(this.IsSelectedValue(targetSelectedValue));
            Neptuo.TemplateEngine.Templates.Controls.ListViewControl.commonPrototype.ProcessModelItem.call(this, itemTemplates, item);
        },
        IsSelectedValue: function (targetSelectedValue){
            var collection = As(this.get_Value(), System.Collections.IEnumerable.ctor);
            if (collection != null){
                var $it2 = collection.GetEnumerator();
                while ($it2.MoveNext()){
                    var item = $it2.get_Current();
                    if (System.Object.Equals$$Object$$Object(item, targetSelectedValue))
                        return true;
                }
            }
            return targetSelectedValue == this.get_Value();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Web.PartialUpdateHelper", "Neptuo.TemplateEngine.Templates.Controls.SelectControlContext"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Templates$Controls$SelectControl);
var Neptuo$TemplateEngine$Templates$DataSources$DataSourceProxy$1 = {
    fullname: "Neptuo.TemplateEngine.Templates.DataSources.DataSourceProxy$1",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Templates.DataSources.IDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (TResultModel, modelBinder, urlProvider){
            this.TResultModel = TResultModel;
            this._ModelBinder = null;
            this._UrlProvider = null;
            this._IsBindModel = false;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(modelBinder, "modelBinder");
            Neptuo.Guard.NotNull$$Object$$String(urlProvider, "urlProvider");
            this.set_ModelBinder(modelBinder);
            this.set_UrlProvider(urlProvider);
            this.set_IsBindModel(true);
        },
        ModelBinder$$: "Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder",
        get_ModelBinder: function (){
            return this._ModelBinder;
        },
        set_ModelBinder: function (value){
            this._ModelBinder = value;
        },
        UrlProvider$$: "Neptuo.Templates.IVirtualUrlProvider",
        get_UrlProvider: function (){
            return this._UrlProvider;
        },
        set_UrlProvider: function (value){
            this._UrlProvider = value;
        },
        IsBindModel$$: "System.Boolean",
        get_IsBindModel: function (){
            return this._IsBindModel;
        },
        set_IsBindModel: function (value){
            this._IsBindModel = value;
        },
        GetItem: function (callback, errorCallback){
            if (!this.OnGetItem(callback)){
                $.ajax({
                    url: this.get_UrlProvider().ResolveUrl(this.FormatUrl()),
                    type: "GET",
                    data: this.SetParametersInternal(),
                    cache: false,
                    success: $CreateAnonymousDelegate(this, function (response, status, sender){
                        var model;
                        if ((function (){
                            var $1 = {
                                Value: model
                            };
                            var $res = Neptuo.Converts.Try$2$$TSource$$TTarget(Object, this.TResultModel, response, $1);
                            model = $1.Value;
                            return $res;
                        }).call(this)){
                            if (this.get_IsBindModel())
                                model = Neptuo.TemplateEngine.Providers.ModelBinders.ModelBinderExtensions.Bind$1$$IModelBinder$$T(this.TResultModel, this.get_ModelBinder(), model);
                            callback(model);
                            return;
                        }
                    }),
                    error: $CreateAnonymousDelegate(this, function (response, status, error){
                        errorCallback(new Neptuo.TemplateEngine.Web.ErrorModel.ctor(response.status, response.statusText, response.responseText));
                    })
                });
            }
        },
        SetParametersInternal: function (){
            var parameterBuilder = Neptuo.TemplateEngine.JsObjectBuilder.New("DataSource", this.GetDataSourceName());
            this.SetParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        },
        GetDataSourceName: function (){
            return this.GetType().get_Name();
        },
        FormatUrl: function (){
            return "~/DataSource.ashx";
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder", "Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$DataSources$DataSourceProxy$1);
var Neptuo$TemplateEngine$Templates$DataSources$IDataSource = {
    fullname: "Neptuo.TemplateEngine.Templates.DataSources.IDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$DataSources$IDataSource);
var Neptuo$TemplateEngine$Templates$DataSources$IListDataSource = {
    fullname: "Neptuo.TemplateEngine.Templates.DataSources.IListDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$DataSources$IListDataSource);
var Neptuo$TemplateEngine$Templates$DataSources$ListDataSourceProxy$1 = {
    fullname: "Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceProxy$1",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Templates.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Templates.DataSources.IListDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (TResultModel, urlProvider){
            this.TResultModel = TResultModel;
            this._UrlProvider = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(urlProvider, "urlProvider");
            this.set_UrlProvider(urlProvider);
        },
        UrlProvider$$: "Neptuo.Templates.IVirtualUrlProvider",
        get_UrlProvider: function (){
            return this._UrlProvider;
        },
        set_UrlProvider: function (value){
            this._UrlProvider = value;
        },
        GetData: function (pageIndex, pageSize, callback, errorCallback){
            $.ajax({
                url: this.get_UrlProvider().ResolveUrl(this.FormatUrl()),
                type: "GET",
                data: this.SetParametersInternal(pageIndex, pageSize),
                cache: false,
                success: $CreateAnonymousDelegate(this, function (response, status, sender){
                    var model;
                    if ((function (){
                        var $1 = {
                            Value: model
                        };
                        var $res = Neptuo.Converts.Try$2$$TSource$$TTarget(Object, this.TResultModel, response, $1);
                        model = $1.Value;
                        return $res;
                    }).call(this))
                        callback(model);
                    else
                        throw $CreateException(new System.NotSupportedException.ctor(), new Error());
                }),
                error: $CreateAnonymousDelegate(this, function (response, status, error){
                    errorCallback(new Neptuo.TemplateEngine.Web.ErrorModel.ctor(response.status, response.statusText, response.responseText));
                })
            });
        },
        SetParametersInternal: function (pageIndex, pageSize){
            var parameterBuilder = Neptuo.TemplateEngine.JsObjectBuilder.New("DataSource", this.GetDataSourceName()).Set("PageIndex", pageIndex).Set("PageSize", pageSize);
            this.SetParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        },
        GetDataSourceName: function (){
            return this.GetType().get_Name();
        },
        FormatUrl: function (){
            return "~/DataSource.ashx";
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Templates$DataSources$ListDataSourceProxy$1);

