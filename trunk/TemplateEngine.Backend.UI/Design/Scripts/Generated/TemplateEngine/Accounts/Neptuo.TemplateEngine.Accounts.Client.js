/* Generated by SharpKit 5 v5.3.6 */

/* Generated by SharpKit 5 v5.3.6 */

if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Accounts$Hosting$Bootstrap$AccountBootstrapTask = {
    fullname: "Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap.AccountBootstrapTask",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapTask"],
    Kind: "Class",
    definition: {
        ctor: function (dependencyContainer, controllerRegistry){
            this.dependencyContainer = null;
            this.controllerRegistry = null;
            this.converterRepository = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(dependencyContainer, "dependencyContainer");
            Neptuo.Guard.NotNull$$Object$$String(controllerRegistry, "controllerRegistry");
            this.dependencyContainer = dependencyContainer;
            this.controllerRegistry = controllerRegistry;
            this.converterRepository = Neptuo.Converts.get_Repository();
        },
        Initialize: function (){
            this.converterRepository.Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor), new Neptuo.TemplateEngine.Accounts.UserAccountEditModelConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor), new Neptuo.TemplateEngine.Accounts.UserAccountListResultConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor), new Neptuo.TemplateEngine.Accounts.UserRoleEditModelConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserRoleListResult.ctor), new Neptuo.TemplateEngine.Accounts.UserRoleListResultConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.UserLogListResult.ctor), new Neptuo.TemplateEngine.Accounts.UserLogListResultConverter.ctor()).Add(Typeof(Object), Typeof(Neptuo.TemplateEngine.Accounts.ResourcePermissionListResult.ctor), new Neptuo.TemplateEngine.Accounts.ResourcePermissionListResultConverter.ctor());
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.IDependencyContainer", "Neptuo.TemplateEngine.Controllers.IAsyncControllerRegistry"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Hosting$Bootstrap$AccountBootstrapTask);
var Neptuo$TemplateEngine$Accounts$ResourcePermissionListResult = {
    fullname: "Neptuo.TemplateEngine.Accounts.ResourcePermissionListResult",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListResult",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (data, totalCount){
            Neptuo.TemplateEngine.Templates.DataSources.ListResult.ctor.call(this, data, totalCount);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Collections.IEnumerable", "System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$ResourcePermissionListResult);
var Neptuo$TemplateEngine$Accounts$ResourcePermissionListResultConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.ResourcePermissionListResultConverter",
    baseTypeName: "Neptuo.ComponentModel.Converters.ConverterBase$2",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.ComponentModel.Converters.ConverterBase$2.ctor.call(this, Object, Neptuo.TemplateEngine.Accounts.ResourcePermissionListResult.ctor);
        },
        TryConvert: function (sourceValue, targetValue){
            var totalCount = sourceValue["TotalCount"];
            var data = sourceValue["Data"];
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.ResourcePermissionListResult.ctor(this.GetResourcePermissions(data), totalCount);
            return true;
        },
        GetResourcePermissions: function (sourceValue){
            var data = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.ViewModels.ResourcePermissionEditViewModel.ctor);
            var array = sourceValue;
            for (var i = 0; i < array.length; i++){
                var item = array[i];
                data.Add(new Neptuo.TemplateEngine.Accounts.ViewModels.ResourcePermissionEditViewModel.ctor(item["ResourceName"], item["ResourceHint"], item["PermissionName"], item["IsEnabled"]));
            }
            return data;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$ResourcePermissionListResultConverter);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$ResourcePermissionDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.ResourcePermissionDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1",
    staticDefinition: {
        GetFilterProperties: function (){
            return (function (){
                var $v1 = new System.Collections.Generic.List$1.ctor(System.String.ctor);
                $v1.Add("RoleKey");
                $v1.Add("ResourceName");
                return $v1;
            })();
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Accounts.Templates.DataSources.IResourcePermissionDataSourceFilter"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this._RoleKey = null;
            this._ResourceName = null;
            Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.ResourcePermissionListResult.ctor, urlProvider, Neptuo.TemplateEngine.Accounts.Templates.DataSources.ResourcePermissionDataSource.GetFilterProperties());
        },
        RoleKey$$: "System.Nullable`1[[System.Int32]]",
        get_RoleKey: function (){
            return this._RoleKey;
        },
        set_RoleKey: function (value){
            this._RoleKey = value;
        },
        ResourceName$$: "System.String",
        get_ResourceName: function (){
            return this._ResourceName;
        },
        set_ResourceName: function (value){
            this._ResourceName = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$ResourcePermissionDataSource);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserLogDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserLogDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceProxy$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Accounts.Templates.DataSources.IUserLogDataSourceFilter"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this._UserKey = null;
            Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserLogListResult.ctor, urlProvider);
        },
        UserKey$$: "System.Nullable`1[[System.Int32]]",
        get_UserKey: function (){
            return this._UserKey;
        },
        set_UserKey: function (value){
            this._UserKey = value;
        },
        SetParameters: function (parameterBuilder){
            parameterBuilder.Set("UserKey", this.get_UserKey());
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserLogDataSource);
var Neptuo$TemplateEngine$Accounts$UserAccountEditModelConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountEditModelConverter",
    baseTypeName: "Neptuo.TemplateEngine.ReflectionConverterBase$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.TemplateEngine.ReflectionConverterBase$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor);
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
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListResult",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (data, totalCount){
            Neptuo.TemplateEngine.Templates.DataSources.ListResult.ctor.call(this, data, totalCount);
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
var Neptuo$TemplateEngine$Accounts$UserLogListResult = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserLogListResult",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListResult",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (data, totalCount){
            Neptuo.TemplateEngine.Templates.DataSources.ListResult.ctor.call(this, data, totalCount);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Collections.IEnumerable", "System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserLogListResult);
var Neptuo$TemplateEngine$Accounts$UserLogListResultConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserLogListResultConverter",
    baseTypeName: "Neptuo.ComponentModel.Converters.ConverterBase$2",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.ComponentModel.Converters.ConverterBase$2.ctor.call(this, Object, Neptuo.TemplateEngine.Accounts.UserLogListResult.ctor);
        },
        TryConvert: function (sourceValue, targetValue){
            var totalCount = sourceValue["TotalCount"];
            var data = sourceValue["Data"];
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.UserLogListResult.ctor(this.GetLogs(data), totalCount);
            return true;
        },
        GetLogs: function (sourceValue){
            var result = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.UserLogViewModel.ctor);
            var array = sourceValue;
            for (var i = 0; i < array.length; i++){
                var item = array[i];
                result.Add(this.GetLog(item));
            }
            return result;
        },
        GetLog: function (sourceValue){
            return new Neptuo.TemplateEngine.Accounts.UserLogViewModel.ctor(sourceValue["Key"], this.GetAccount(sourceValue["User"]), sourceValue["SignedIn"], sourceValue["SignedOut"], sourceValue["LastActivity"], sourceValue["IsCurrent"]);
        },
        GetAccount: function (sourceValue){
            return new Neptuo.TemplateEngine.Accounts.UserAccountRowViewModel.ctor(sourceValue["Key"], sourceValue["Username"]);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserLogListResultConverter);
var Neptuo$TemplateEngine$Accounts$UserRoleEditModelConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleEditModelConverter",
    baseTypeName: "Neptuo.TemplateEngine.ReflectionConverterBase$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.TemplateEngine.ReflectionConverterBase$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleEditModelConverter);
var Neptuo$TemplateEngine$Accounts$UserRoleListResult = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleListResult",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListResult",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (data, totalCount){
            Neptuo.TemplateEngine.Templates.DataSources.ListResult.ctor.call(this, data, totalCount);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Collections.IEnumerable", "System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleListResult);
var Neptuo$TemplateEngine$Accounts$UserRoleListResultConverter = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleListResultConverter",
    baseTypeName: "Neptuo.ComponentModel.Converters.ConverterBase$2",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.ComponentModel.Converters.ConverterBase$2.ctor.call(this, Object, Neptuo.TemplateEngine.Accounts.UserRoleListResult.ctor);
        },
        TryConvert: function (sourceValue, targetValue){
            var totalCount = sourceValue["TotalCount"];
            var data = sourceValue["Data"];
            targetValue.Value = new Neptuo.TemplateEngine.Accounts.UserRoleListResult.ctor(this.GetRoles(data), totalCount);
            return true;
        },
        GetRoles: function (sourceValue){
            var data = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Accounts.UserRoleViewModel.ctor);
            var array = sourceValue;
            for (var i = 0; i < array.length; i++){
                var item = array[i];
                data.Add(new Neptuo.TemplateEngine.Accounts.UserRoleViewModel.ctor(item["Key"], item["Name"], item["Description"]));
            }
            return data;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleListResultConverter);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserAccountDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserAccountDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1",
    staticDefinition: {
        GetFilterProperties: function (){
            return (function (){
                var $v2 = new System.Collections.Generic.List$1.ctor(System.String.ctor);
                $v2.Add("Key");
                $v2.Add("Username");
                $v2.Add("RoleKey");
                return $v2;
            })();
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Accounts.Templates.DataSources.IUserAccountDataSourceFilter"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this._Key = null;
            this._Username = null;
            this._RoleKey = null;
            Neptuo.TemplateEngine.Templates.DataSources.DynamicListDataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserAccountListResult.ctor, urlProvider, Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserAccountDataSource.GetFilterProperties());
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserAccountDataSource);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserAccountEditDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserAccountEditDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.DataSourceProxy$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (modelBinder, urlProvider){
            this._Key = null;
            Neptuo.TemplateEngine.Templates.DataSources.DataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor, modelBinder, urlProvider);
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        SetParameters: function (parameterBuilder){
            parameterBuilder.Set("Key", this.get_Key());
        },
        OnGetItem: function (callback){
            if (this.get_Key() == 0){
                var model = this.BindModelIfRequired(new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor());
                callback(model);
                return true;
            }
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder", "Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserAccountEditDataSource);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserRoleDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserRoleDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceProxy$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Accounts.Templates.DataSources.IUserRoleDataSourceFilter"],
    Kind: "Class",
    definition: {
        ctor: function (urlProvider){
            this._Key = null;
            this._Name = null;
            this._Description = null;
            Neptuo.TemplateEngine.Templates.DataSources.ListDataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserRoleListResult.ctor, urlProvider);
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
        Description$$: "System.String",
        get_Description: function (){
            return this._Description;
        },
        set_Description: function (value){
            this._Description = value;
        },
        SetParameters: function (parameterBuilder){
            parameterBuilder.Set("Key", this.get_Key()).Set("Name", this.get_Name()).Set("Description", this.get_Description());
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserRoleDataSource);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserRoleEditDataSource = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.UserRoleEditDataSource",
    baseTypeName: "Neptuo.TemplateEngine.Templates.DataSources.DataSourceProxy$1",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    Kind: "Class",
    definition: {
        ctor: function (modelBinder, urlProvider){
            this._Key = null;
            Neptuo.TemplateEngine.Templates.DataSources.DataSourceProxy$1.ctor.call(this, Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor, modelBinder, urlProvider);
        },
        Key$$: "System.Nullable`1[[System.Int32]]",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        SetParameters: function (parameterBuilder){
            parameterBuilder.Set("Key", this.get_Key());
        },
        OnGetItem: function (callback){
            if (this.get_Key() == 0){
                var model = this.BindModelIfRequired(new Neptuo.TemplateEngine.Accounts.UserRoleEditModel.ctor());
                callback(model);
                return true;
            }
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder", "Neptuo.Templates.IVirtualUrlProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$UserRoleEditDataSource);


