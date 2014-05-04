/* Generated by SharpKit 5 v5.3.6 */

/* Generated by SharpKit 5 v5.3.6 */

if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Publishing$Bootstrap$PublishingBootstrapTask = {
    fullname: "Neptuo.TemplateEngine.Publishing.Bootstrap.PublishingBootstrapTask",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Publishing.Client",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapTask"],
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        },
        Initialize: function (){
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Publishing$Bootstrap$PublishingBootstrapTask);
var Neptuo$TemplateEngine$Publishing$Templates$DataSources$ArticleDataSource = {
    fullname: "Neptuo.TemplateEngine.Publishing.Templates.DataSources.ArticleDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1",
    staticDefinition: {
        GetFilterProperties: function (){
            return (function (){
                var $v1 = new System.Collections.Generic.List$1.ctor(System.String.ctor);
                $v1.Add("Key");
                $v1.Add("LineKey");
                $v1.Add("TagKey");
                $v1.Add("IsIncludeHidden");
                $v1.Add("Title");
                $v1.Add("UrlPart");
                return $v1;
            })();
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Publishing.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Publishing.Templates.DataSources.IArticleDataSourceFilter"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this._Key = null;
            this._LineKey = null;
            this._TagKey = null;
            this._IsIncludeHidden = false;
            this._Title = null;
            this._UrlPart = null;
            Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.ModelValueGetterListResult.ctor, urlProvider, Neptuo.TemplateEngine.Publishing.Templates.DataSources.ArticleDataSource.GetFilterProperties());
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        LineKey$$: "System.Nullable`1[[System.Int32]]",
        get_LineKey: function (){
            return this._LineKey;
        },
        set_LineKey: function (value){
            this._LineKey = value;
        },
        TagKey$$: "System.Nullable`1[[System.Int32]]",
        get_TagKey: function (){
            return this._TagKey;
        },
        set_TagKey: function (value){
            this._TagKey = value;
        },
        IsIncludeHidden$$: "System.Boolean",
        get_IsIncludeHidden: function (){
            return this._IsIncludeHidden;
        },
        set_IsIncludeHidden: function (value){
            this._IsIncludeHidden = value;
        },
        Title$$: "System.String",
        get_Title: function (){
            return this._Title;
        },
        set_Title: function (value){
            this._Title = value;
        },
        UrlPart$$: "System.String",
        get_UrlPart: function (){
            return this._UrlPart;
        },
        set_UrlPart: function (value){
            this._UrlPart = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Publishing$Templates$DataSources$ArticleDataSource);


