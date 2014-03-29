/* Generated by SharpKit 5 v5.3.6 */

/* Generated by SharpKit 5 v5.3.6 */
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
var Neptuo$TemplateEngine$Accounts$Bootstrap$AccountBootstrapTask = {
    fullname: "Neptuo.TemplateEngine.Accounts.Bootstrap.AccountBootstrapTask",
    baseTypeName: "Neptuo.TemplateEngine.Accounts.Bootstrap.AccountBootstrapTaskBase",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapTask"],
    Kind: "Class",
    definition: {
        ctor: function (dependencyContainer, formRegistry, controllerRegistry, globalNavigations){
            this.dependencyContainer = null;
            this.formRegistry = null;
            this.controllerRegistry = null;
            this.globalNavigations = null;
            this.converterRepository = null;
            Neptuo.TemplateEngine.Accounts.Bootstrap.AccountBootstrapTaskBase.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(dependencyContainer, "dependencyContainer");
            Neptuo.Guard.NotNull$$Object$$String(formRegistry, "formRegistry");
            Neptuo.Guard.NotNull$$Object$$String(controllerRegistry, "controllerRegistry");
            Neptuo.Guard.NotNull$$Object$$String(globalNavigations, "globalNavigations");
            this.dependencyContainer = dependencyContainer;
            this.formRegistry = formRegistry;
            this.controllerRegistry = controllerRegistry;
            this.globalNavigations = globalNavigations;
            this.converterRepository = Neptuo.Converts.get_Repository();
        },
        Initialize: function (){
            Neptuo.DependencyContainerExtensions.RegisterInstance$1(Neptuo.TemplateEngine.Accounts.Data.UserRepository.ctor, this.dependencyContainer, new Neptuo.TemplateEngine.Accounts.Data.UserRepository.ctor());
            this.converterRepository.Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor), new Neptuo.TemplateEngine.Accounts.UserAccountEditModelConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor), new Neptuo.TemplateEngine.Accounts.UserAccountListResultConverter.ctor());
            this.RegisterForms(this.formRegistry);
            this.RegisterGlobalNavigations(this.globalNavigations);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.IDependencyContainer", "Neptuo.TemplateEngine.Navigation.Bootstrap.IFormUriRegistry", "Neptuo.TemplateEngine.Web.Controllers.IControllerRegistry", "Neptuo.TemplateEngine.Web.GlobalNavigationCollection"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Bootstrap$AccountBootstrapTask);
var Neptuo$TemplateEngine$Accounts$Data$UserRepository = {
    fullname: "Neptuo.TemplateEngine.Accounts.Data.UserRepository",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            this.data = null;
            System.Object.ctor.call(this);
            this.data = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor);
            for (var i = 0; i < 34; i++){
                this.data.Add((function (){
                    var $v1 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                    $v1.set_Key(i + 1);
                    $v1.set_Username("User " + i);
                    $v1.set_IsEnabled((i % 3) == 1);
                    return $v1;
                }).call(this));
            }
        },
        GetPage: function (pageIndex, pageSize){
            return System.Linq.Enumerable.ToList$1(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, System.Linq.Enumerable.Take$1(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, System.Linq.Enumerable.Skip$1(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, this.data, pageIndex * pageSize), pageSize));
        },
        GetAll: function (){
            return this.data;
        },
        Add: function (userAccount){
            this.data.Add(userAccount);
        },
        GetCount: function (){
            return this.data.get_Count();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Data$UserRepository);
var Neptuo$TemplateEngine$Accounts$UserAccountEditModelConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountEditModelConverter",
    baseTypeName: "Neptuo.ComponentModel.Converters.ConverterBase$2",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.ComponentModel.Converters.ConverterBase$2.ctor.call(this, Object, Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor);
        },
        TryConvert: function (sourceValue, targetValue){
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
            targetValue.Value.set_Key(sourceValue["Key"]);
            targetValue.Value.set_Username(sourceValue["Username"]);
            targetValue.Value.set_Password(sourceValue["Password"]);
            targetValue.Value.set_PasswordAgain(sourceValue["PasswordAgain"]);
            targetValue.Value.set_IsEnabled(sourceValue["IsEnabled"]);
            targetValue.Value.set_RoleKeys(new System.Collections.Generic.List$1.ctor$$IEnumerable$1(System.Int32.ctor, sourceValue["RoleKeys"]));
            return true;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountEditModelConverter);
var Neptuo$TemplateEngine$Accounts$UserAccountListResult = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountListResult",
    baseTypeName: "Neptuo.TemplateEngine.Web.DataSources.ListResult",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (data, totalCount){
            Neptuo.TemplateEngine.Web.DataSources.ListResult.ctor.call(this, data, totalCount);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Collections.IEnumerable", "System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountListResult);
var Neptuo$TemplateEngine$Accounts$UserAccountListResultConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountListResultConverter",
    baseTypeName: "Neptuo.ComponentModel.Converters.ConverterBase$2",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.ComponentModel.Converters.ConverterBase$2.ctor.call(this, Object, Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor);
        },
        TryConvert: function (sourceValue, targetValue){
            var totalCount = sourceValue["TotalCount"];
            var data = sourceValue["Data"];
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor(this.GetAccounts(data), totalCount);
            return true;
        },
        GetAccounts: function (sourceValue){
            var data = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.UserAccountViewModel.ctor);
            var array = sourceValue;
            for (var i = 0; i < array.length; i++){
                var item = array[i];
                data.Add(new Neptuo.TemplateEngine.Accounts.UserAccountViewModel.ctor(item["Key"], item["Username"], item["IsEnabled"], this.GetRoles(item)));
            }
            return data;
        },
        GetRoles: function (item){
            var roles = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.UserRoleRowViewModel.ctor);
            var rolesArray = item["Roles"];
            for (var i = 0; i < rolesArray.length; i++){
                var roleItem = rolesArray[i];
                roles.Add(new Neptuo.TemplateEngine.Accounts.UserRoleRowViewModel.ctor(roleItem["Key"], roleItem["Name"]));
            }
            return roles;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountListResultConverter);
var Neptuo$TemplateEngine$Accounts$Web$Controllers$UserAccountController = {
    fullname: "Neptuo.TemplateEngine.Accounts.Web.Controllers.UserAccountController",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.Controllers.IController"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Context = null;
            System.Object.ctor.call(this);
        },
        Context$$: "Neptuo.TemplateEngine.Web.Controllers.IControllerContext",
        get_Context: function (){
            return this._Context;
        },
        set_Context: function (value){
            this._Context = value;
        },
        Create: function (){
            var model = Neptuo.TemplateEngine.Web.Controllers.Binders.ModelBinderExtensions.Bind$1$$IModelBinder$$T(Neptuo.TemplateEngine.Accounts.Commands.UserAccountCreateCommand.ctor, this.get_Context().get_ModelBinder(), new Neptuo.TemplateEngine.Accounts.Commands.UserAccountCreateCommand.ctor());
            console.log(model);
        },
        Execute: function (context){
            this.set_Context(context);
            this.Create();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$Controllers$UserAccountController);
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserAccountDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.DataSources.IListDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this.urlProvider = null;
            this._Key = null;
            this._Username = null;
            this._RoleKey = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(urlProvider, "urlProvider");
            this.urlProvider = urlProvider;
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        Username$$: "System.String",
        get_Username: function (){
            return this._Username;
        },
        set_Username: function (value){
            this._Username = value;
        },
        RoleKey$$: "System.Nullable`1[[System.Int32]]",
        get_RoleKey: function (){
            return this._RoleKey;
        },
        set_RoleKey: function (value){
            this._RoleKey = value;
        },
        GetData: function (pageIndex, pageSize, callback){
            $.ajax({
                url: this.urlProvider.ResolveUrl(this.FormatUrl()),
                type: "GET",
                data: Neptuo.TemplateEngine.JsObjectBuilder.New("DataSource", "UserAccountDataSource").Set("Key", this.get_Key()).Set("Username", this.get_Username()).Set("RoleKey", this.get_RoleKey()).Set("PageIndex", pageIndex).Set("PageSize", pageSize).ToJsObject(),
                cache: false,
                success: $CreateAnonymousDelegate(this, function (response, status, sender){
                    var model;
                    if ((function (){
                        var $1 = {
                            Value: model
                        };
                        var $res = Neptuo.Converts.Try$2$$TSource$$TTarget(Object, Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor, response, $1);
                        model = $1.Value;
                        return $res;
                    }).call(this))
                        callback(model);
                    else
                        throw $CreateException(new System.NotSupportedException.ctor(), new Error());
                })
            });
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
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource);
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountEditDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserAccountEditDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.DataSources.IDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (modelBinder, urlProvider){
            this.key = 0;
            this.modelBinder = null;
            this.urlProvider = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(modelBinder, "modelBinder");
            Neptuo.Guard.NotNull$$Object$$String(urlProvider, "urlProvider");
            this.modelBinder = modelBinder;
            this.urlProvider = urlProvider;
        },
        Key$$: "System.Int32",
        get_Key: function (){
            return this.key;
        },
        set_Key: function (value){
            if (value != null)
                this.key = value;
        },
        GetItem: function (callback){
            if (this.get_Key() == 0){
                var model = (function (){
                    var $v2 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                    $v2.set_Key(0);
                    $v2.set_IsEnabled(true);
                    return $v2;
                }).call(this);
                model = Neptuo.TemplateEngine.Web.Controllers.Binders.ModelBinderExtensions.Bind$1$$IModelBinder$$T(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, this.modelBinder, model);
                callback(model);
                return;
            }
            $.ajax({
                url: this.urlProvider.ResolveUrl(this.FormatUrl()),
                type: "GET",
                data: Neptuo.TemplateEngine.JsObjectBuilder.New("DataSource", "UserAccountEditDataSource").Set("Key", this.get_Key()).ToJsObject(),
                cache: false,
                success: $CreateAnonymousDelegate(this, function (response, status, sender){
                    var model;
                    if ((function (){
                        var $1 = {
                            Value: model
                        };
                        var $res = Neptuo.Converts.Try$2$$TSource$$TTarget(Object, Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, response, $1);
                        model = $1.Value;
                        return $res;
                    }).call(this)){
                        model = Neptuo.TemplateEngine.Web.Controllers.Binders.ModelBinderExtensions.Bind$1$$IModelBinder$$T(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, this.modelBinder, model);
                        callback(model);
                        return;
                    }
                })
            });
        },
        FormatUrl: function (){
            return "~/DataSource.ashx";
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Web.Controllers.Binders.IModelBinder", "Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountEditDataSource);
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserRoleDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserRoleDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.DataSources.IListDataSource"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Key = null;
            this._Name = null;
            System.Object.ctor.call(this);
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        Name$$: "System.String",
        get_Name: function (){
            return this._Name;
        },
        set_Name: function (value){
            this._Name = value;
        },
        GetTotalCount: function (){
            return 0;
        },
        GetData: function (pageIndex, pageSize, callback){
            setTimeout($CreateAnonymousDelegate(this, function (){
                callback(new Neptuo.TemplateEngine.Web.DataSources.ListResult.ctor((function (){
                    var $v3 = new System.Collections.Generic.List$1.ctor(System.Object.ctor);
                    $v3.Add((function (){
                        var $v4 = new Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor();
                        $v4.set_Key(1);
                        $v4.set_Name("Administrators");
                        $v4.set_Description("System admins");
                        return $v4;
                    }).call(this));
                    $v3.Add((function (){
                        var $v5 = new Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor();
                        $v5.set_Key(2);
                        $v5.set_Name("Everyone");
                        $v5.set_Description("Public (un-authenticated) users");
                        return $v5;
                    }).call(this));
                    $v3.Add((function (){
                        var $v6 = new Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor();
                        $v6.set_Key(3);
                        $v6.set_Name("WebAdmins");
                        $v6.set_Description("Admins of web presentation");
                        return $v6;
                    }).call(this));
                    $v3.Add((function (){
                        var $v7 = new Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor();
                        $v7.set_Key(4);
                        $v7.set_Name("Articles");
                        $v7.set_Description("Article writers");
                        return $v7;
                    }).call(this));
                    return $v3;
                }).call(this), 4));
            }), 500);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserRoleDataSource);


