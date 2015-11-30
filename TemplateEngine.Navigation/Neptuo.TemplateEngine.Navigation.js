/* Generated by SharpKit 5 v5.4.4 */
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
var Neptuo$TemplateEngine$Navigation$DefaultFormUriRepository = {
    fullname: "Neptuo.TemplateEngine.Navigation.DefaultFormUriRepository",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    interfaceNames: ["Neptuo.TemplateEngine.Navigation.IFormUriRepository", "Neptuo.TemplateEngine.Navigation.Bootstrap.IFormUriRegistry"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Storage = null;
            System.Object.ctor.call(this);
            this.set_Storage(new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, Neptuo.TemplateEngine.Navigation.FormUri.ctor));
        },
        Storage$$: "System.Collections.Generic.Dictionary`2[[System.String],[Neptuo.TemplateEngine.Navigation.FormUri]]",
        get_Storage: function (){
            return this._Storage;
        },
        set_Storage: function (value){
            this._Storage = value;
        },
        Register: function (identifier, url){
            if (identifier == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("identifier"), new Error());
            if (url == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("url"), new Error());
            var formUri = new Neptuo.TemplateEngine.Navigation.FormUri.ctor(identifier, url);
            this.get_Storage().set_Item$$TKey(identifier, formUri);
            return this;
        },
        TryGet: function (identifier, formUri){
            return this.get_Storage().TryGetValue(identifier, formUri);
        },
        EnumerateForms: function (){
            return this.get_Storage().get_Values();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$DefaultFormUriRepository);
var Neptuo$TemplateEngine$Navigation$FormUri = {
    fullname: "Neptuo.TemplateEngine.Navigation.FormUri",
    baseTypeName: "System.Object",
    staticDefinition: {
        op_Explicit: function (uri){
            var formUri;
            if ((function (){
                var $1 = {
                    Value: formUri
                };
                var $res = Neptuo.TemplateEngine.Navigation.FormUriTable.get_Repository().TryGet(uri, $1);
                formUri = $1.Value;
                return $res;
            })())
                return formUri;
            throw $CreateException(new System.ArgumentOutOfRangeException.ctor$$String$$String("uri", System.String.Format$$String$$Object("This \'{0}\' isn\'t registered form uri.", uri)), new Error());
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Class",
    definition: {
        ctor: function (identifier, url){
            this.identifier = null;
            this.url = null;
            System.Object.ctor.call(this);
            if (identifier == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("identifier"), new Error());
            if (url == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("url"), new Error());
            this.identifier = identifier;
            this.url = url;
        },
        Identifier: function (){
            return this.identifier;
        },
        Url: function (){
            return this.url;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$FormUri);
var Neptuo$TemplateEngine$Navigation$FormUriTable = {
    fullname: "Neptuo.TemplateEngine.Navigation.FormUriTable",
    baseTypeName: "System.Object",
    staticDefinition: {
        cctor: function (){
            Neptuo.TemplateEngine.Navigation.FormUriTable.instance = null;
        },
        Repository$$: "Neptuo.TemplateEngine.Navigation.IFormUriRepository",
        get_Repository: function (){
            if (Neptuo.TemplateEngine.Navigation.FormUriTable.instance == null)
                Neptuo.TemplateEngine.Navigation.FormUriTable.instance = new Neptuo.TemplateEngine.Navigation.DefaultFormUriRepository.ctor();
            return Neptuo.TemplateEngine.Navigation.FormUriTable.instance;
        },
        Registry$$: "Neptuo.TemplateEngine.Navigation.Bootstrap.IFormUriRegistry",
        get_Registry: function (){
            if (Neptuo.TemplateEngine.Navigation.FormUriTable.instance == null)
                Neptuo.TemplateEngine.Navigation.FormUriTable.instance = new Neptuo.TemplateEngine.Navigation.DefaultFormUriRepository.ctor();
            return Neptuo.TemplateEngine.Navigation.FormUriTable.instance;
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$FormUriTable);
var Neptuo$TemplateEngine$Navigation$Bootstrap$IFormUriRegistry = {
    fullname: "Neptuo.TemplateEngine.Navigation.Bootstrap.IFormUriRegistry",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$Bootstrap$IFormUriRegistry);
var Neptuo$TemplateEngine$Navigation$IFormUriRepository = {
    fullname: "Neptuo.TemplateEngine.Navigation.IFormUriRepository",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$IFormUriRepository);
var Neptuo$TemplateEngine$Navigation$INavigateTo = {
    fullname: "Neptuo.TemplateEngine.Navigation.INavigateTo",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$INavigateTo);
var Neptuo$TemplateEngine$Navigation$INavigator = {
    fullname: "Neptuo.TemplateEngine.Navigation.INavigator",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Navigation",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Navigation$INavigator);

