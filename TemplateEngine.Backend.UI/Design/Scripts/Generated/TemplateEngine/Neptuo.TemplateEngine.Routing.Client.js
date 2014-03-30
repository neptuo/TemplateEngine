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
var Neptuo$TemplateEngine$Routing$IRoute = {
    fullname: "Neptuo.TemplateEngine.Routing.IRoute",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Routing$IRoute);
var Neptuo$TemplateEngine$Routing$IRouteHandler = {
    fullname: "Neptuo.TemplateEngine.Routing.IRouteHandler",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Routing$IRouteHandler);
var Neptuo$TemplateEngine$Routing$IRouter = {
    fullname: "Neptuo.TemplateEngine.Routing.IRouter",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Routing$IRouter);
var Neptuo$TemplateEngine$Routing$RouteNotFoundException = {
    fullname: "Neptuo.TemplateEngine.Routing.RouteNotFoundException",
    baseTypeName: "System.Exception",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (requestContext){
            this._RequestContext = null;
            System.Exception.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(requestContext, "requestContext");
            this.set_RequestContext(requestContext);
        },
        RequestContext$$: "Neptuo.TemplateEngine.Routing.RequestContext",
        get_RequestContext: function (){
            return this._RequestContext;
        },
        set_RequestContext: function (value){
            this._RequestContext = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Routing.RequestContext"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RouteNotFoundException);
var Neptuo$TemplateEngine$Routing$RequestContext = {
    fullname: "Neptuo.TemplateEngine.Routing.RequestContext",
    baseTypeName: "System.Object",
    staticDefinition: {
        RemoveQueryString: function (url){
            Neptuo.Guard.NotNullOrEmpty(url, "url");
            var index = url.IndexOf$$Char("?");
            if (index > 0)
                return url.Substring$$Int32$$Int32(0, index);
            return url;
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (url, form, customValues){
            this._Url = null;
            this._QueryString = null;
            this._Form = null;
            this._CustomValues = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNullOrEmpty(url, "url");
            Neptuo.Guard.NotNull$$Object$$String(form, "form");
            this.set_Url(Neptuo.TemplateEngine.Routing.RequestContext.RemoveQueryString(url));
            this.set_Form(form);
            this.set_QueryString(Neptuo.TemplateEngine.Routing.RouteParamDictionary.FromUrl(url));
            this.set_CustomValues((customValues != null ? customValues : new Neptuo.TemplateEngine.Routing.RouteValueDictionary.ctor()));
        },
        Url$$: "System.String",
        get_Url: function (){
            return this._Url;
        },
        set_Url: function (value){
            this._Url = value;
        },
        QueryString$$: "Neptuo.TemplateEngine.Routing.RouteParamDictionary",
        get_QueryString: function (){
            return this._QueryString;
        },
        set_QueryString: function (value){
            this._QueryString = value;
        },
        Form$$: "Neptuo.TemplateEngine.Routing.RouteParamDictionary",
        get_Form: function (){
            return this._Form;
        },
        set_Form: function (value){
            this._Form = value;
        },
        CustomValues$$: "Neptuo.TemplateEngine.Routing.RouteValueDictionary",
        get_CustomValues: function (){
            return this._CustomValues;
        },
        set_CustomValues: function (value){
            this._CustomValues = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "Neptuo.TemplateEngine.Routing.RouteParamDictionary", "Neptuo.TemplateEngine.Routing.RouteValueDictionary"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RequestContext);
var Neptuo$TemplateEngine$Routing$RouteContext = {
    fullname: "Neptuo.TemplateEngine.Routing.RouteContext",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (routeData){
            this._Request = null;
            this._RouteData = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(routeData, "routeData");
            this.set_Request(routeData.get_Request());
            this.set_RouteData(routeData);
        },
        Request$$: "Neptuo.TemplateEngine.Routing.RequestContext",
        get_Request: function (){
            return this._Request;
        },
        set_Request: function (value){
            this._Request = value;
        },
        RouteData$$: "Neptuo.TemplateEngine.Routing.RouteData",
        get_RouteData: function (){
            return this._RouteData;
        },
        set_RouteData: function (value){
            this._RouteData = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Routing.RouteData"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RouteContext);
var Neptuo$TemplateEngine$Routing$RouteData = {
    fullname: "Neptuo.TemplateEngine.Routing.RouteData",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (request, routeHandler, routeValues){
            this._Request = null;
            this._RouteHandler = null;
            this._RouteValues = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(request, "request");
            Neptuo.Guard.NotNull$$Object$$String(routeHandler, "routeHandler");
            Neptuo.Guard.NotNull$$Object$$String(routeValues, "routeValues");
            this.set_Request(request);
            this.set_RouteHandler(routeHandler);
            this.set_RouteValues(routeValues);
        },
        Request$$: "Neptuo.TemplateEngine.Routing.RequestContext",
        get_Request: function (){
            return this._Request;
        },
        set_Request: function (value){
            this._Request = value;
        },
        RouteHandler$$: "Neptuo.TemplateEngine.Routing.IRouteHandler",
        get_RouteHandler: function (){
            return this._RouteHandler;
        },
        set_RouteHandler: function (value){
            this._RouteHandler = value;
        },
        RouteValues$$: "Neptuo.TemplateEngine.Routing.RouteValueDictionary",
        get_RouteValues: function (){
            return this._RouteValues;
        },
        set_RouteValues: function (value){
            this._RouteValues = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Routing.RequestContext", "Neptuo.TemplateEngine.Routing.IRouteHandler", "Neptuo.TemplateEngine.Routing.RouteValueDictionary"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RouteData);
var Neptuo$TemplateEngine$Routing$RouteParamDictionary = {
    fullname: "Neptuo.TemplateEngine.Routing.RouteParamDictionary",
    baseTypeName: "System.Collections.Generic.Dictionary$2",
    staticDefinition: {
        FromUrl: function (url){
            Neptuo.Guard.NotNull$$Object$$String(url, "url");
            var index = url.IndexOf$$Char("?");
            if (index > 0){
                var queryString = url.Substring$$Int32(index);
                return Neptuo.TemplateEngine.Routing.RouteParamDictionary.FromQueryString(queryString);
            }
            return new Neptuo.TemplateEngine.Routing.RouteParamDictionary.ctor();
        },
        FromQueryString: function (queryString){
            var result = new Neptuo.TemplateEngine.Routing.RouteParamDictionary.ctor();
            if (System.String.IsNullOrEmpty(queryString))
                return result;
            if (queryString.StartsWith$$String("?"))
                queryString = queryString.Substring$$Int32(1);
            var keyValues = queryString.Split$$Char$Array("&");
            var $it1 = keyValues.GetEnumerator();
            while ($it1.MoveNext()){
                var keyValue = $it1.get_Current();
                var param = keyValue.Split$$Char$Array("=");
                if (param.get_Length() == 2)
                    result.set_Item$$TKey(param[0], Neptuo.TemplateEngine.Routing.RouteParamDictionary.DecodeValueFromUrl(param[1]));
                else
                    result.set_Item$$TKey(param[0], null);
            }
            return result;
        },
        DecodeValueFromUrl: function (value){
            if (value == null)
                return null;
            return value.Replace$$String$$String("+", " ");
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Collections.Generic.Dictionary$2.ctor.call(this, System.String.ctor, System.String.ctor);
        },
        AddItem: function (key, value){
            this.Add(key, value);
            return this;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RouteParamDictionary);
var Neptuo$TemplateEngine$Routing$Router = {
    fullname: "Neptuo.TemplateEngine.Routing.Router",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Routing.IRouter"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Routes = null;
            System.Object.ctor.call(this);
            this.set_Routes(new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Routing.IRoute.ctor));
        },
        Routes$$: "System.Collections.Generic.List`1[[Neptuo.TemplateEngine.Routing.IRoute]]",
        get_Routes: function (){
            return this._Routes;
        },
        set_Routes: function (value){
            this._Routes = value;
        },
        AddRoute: function (route){
            Neptuo.Guard.NotNull$$Object$$String(route, "route");
            this.get_Routes().Add(route);
        },
        RouteTo: function (context){
            var $it2 = this.get_Routes().GetEnumerator();
            while ($it2.MoveNext()){
                var route = $it2.get_Current();
                var routeData = route.GetRouteData(context);
                if (routeData != null){
                    routeData.get_RouteHandler().ProcessRequest(new Neptuo.TemplateEngine.Routing.RouteContext.ctor(routeData));
                    return;
                }
            }
            this.WhenNoRouteFound(context);
        },
        WhenNoRouteFound: function (context){
            throw $CreateException(new Neptuo.TemplateEngine.Routing.RouteNotFoundException.ctor(context), new Error());
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$Router);
var Neptuo$TemplateEngine$Routing$RouteValueDictionary = {
    fullname: "Neptuo.TemplateEngine.Routing.RouteValueDictionary",
    baseTypeName: "System.Collections.Generic.Dictionary$2",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Collections.Generic.Dictionary$2.ctor.call(this, System.String.ctor, System.Object.ctor);
        },
        AddItem: function (key, value){
            this.Add(key, value);
            return this;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$RouteValueDictionary);
var Neptuo$TemplateEngine$Routing$StaticRoute = {
    fullname: "Neptuo.TemplateEngine.Routing.StaticRoute",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Routing.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Routing.IRoute"],
    Kind: "Class",
    definition: {
        ctor: function (url, routeHandler){
            this._Url = null;
            this._RouteHandler = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(url, "url");
            Neptuo.Guard.NotNull$$Object$$String(routeHandler, "routeHandler");
            this.set_Url(url);
            this.set_RouteHandler(routeHandler);
        },
        Url$$: "System.String",
        get_Url: function (){
            return this._Url;
        },
        set_Url: function (value){
            this._Url = value;
        },
        RouteHandler$$: "Neptuo.TemplateEngine.Routing.IRouteHandler",
        get_RouteHandler: function (){
            return this._RouteHandler;
        },
        set_RouteHandler: function (value){
            this._RouteHandler = value;
        },
        GetRouteData: function (context){
            if (this.get_Url() == context.get_Url())
                return new Neptuo.TemplateEngine.Routing.RouteData.ctor(context, this.get_RouteHandler(), new Neptuo.TemplateEngine.Routing.RouteValueDictionary.ctor());
            return null;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "Neptuo.TemplateEngine.Routing.IRouteHandler"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Routing$StaticRoute);


