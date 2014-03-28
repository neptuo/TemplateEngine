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
            this.converterRepository.Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor), new Neptuo.TemplateEngine.Accounts.UserAccountEditModelConverter.ctor());
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
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.ComponentModel.Converters.IConverter$2"],
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        },
        TryConvert: function (sourceValue, targetValue){
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
            targetValue.Value.set_Username(sourceValue["Username"]);
            targetValue.Value.set_Password(sourceValue["Password"]);
            targetValue.Value.set_PasswordAgain(sourceValue["PasswordAgain"]);
            targetValue.Value.set_IsEnabled(sourceValue["IsEnabled"]);
            targetValue.Value.set_RoleKeys(sourceValue["RoleKeys"]);
            return true;
        },
        TryConvertGeneral: function (sourceType, targetType, sourceValue, targetValue){
            var model;
            if ((function (){
                var $1 = {
                    Value: model
                };
                var $res = this.TryConvert(sourceValue instanceof Object || sourceValue == null ? sourceValue : (function (){
                    throw new Error("InvalidCastException");
                }
                ()), $1);
                model = $1.Value;
                return $res;
            }).call(this)){
                targetValue.Value = model;
                return true;
            }
            targetValue.Value = null;
            return false;
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
        ctor: function (userAccounts){
            this.userAccounts = null;
            this._Key = null;
            this._Username = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(userAccounts, "userAccounts");
            this.userAccounts = userAccounts;
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
        GetData: function (pageIndex, pageSize, callback){
            if (pageSize != null)
                setTimeout($CreateAnonymousDelegate(this, function (){
                    callback(new Neptuo.TemplateEngine.Web.DataSources.ListResult.ctor(this.userAccounts.GetPage((pageIndex != null ? pageIndex : 0), pageSize.get_Value()), this.userAccounts.GetCount()));
                }), 200);
            else
                setTimeout($CreateAnonymousDelegate(this, function (){
                    callback(new Neptuo.TemplateEngine.Web.DataSources.ListResult.ctor(this.userAccounts.GetAll(), this.userAccounts.GetCount()));
                }), 1000);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Accounts.Data.UserRepository"]
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
            return System.String.Format$$String$$Object$$Object("~/DataSource.ashx?DataSource={0}&Key={1}", "UserAccountEditDataSource", this.get_Key());
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

