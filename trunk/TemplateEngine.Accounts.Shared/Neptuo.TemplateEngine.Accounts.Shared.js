/* Generated by SharpKit 5 v5.3.6 */

if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Accounts$Bootstrap$AccountBootstrapTaskBase = {
    fullname: "Neptuo.TemplateEngine.Accounts.Bootstrap.AccountBootstrapTaskBase",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        },
        SetupForms: function (formRegistry){
            formRegistry.Register("Accounts.Login", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/Login")).Register("Accounts.User.List", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/UserList")).Register("Accounts.User.Edit", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/UserEdit")).Register("Accounts.Role.List", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/RoleList")).Register("Accounts.Role.Edit", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/RoleEdit")).Register("Accounts.Log.List", Neptuo.TemplateEngine.Web.Routing.TemplateRouteParameterBase.FormatUrl("~/Accounts/LogList"));
        },
        SetupGlobalNavigations: function (globalNavigations){
            globalNavigations.Add("Accounts.User.Deleted", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.User.List")).Add("Accounts.User.Created", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.User.List")).Add("Accounts.User.Updated", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.User.List")).Add("Accounts.Role.Deleted", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.Role.List")).Add("Accounts.Role.Created", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.Role.List")).Add("Accounts.Role.Updated", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.Role.List")).Add("Accounts.LoggedIn", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.User.List")).Add("Accounts.LoggedOut", Neptuo.TemplateEngine.Navigation.FormUri.op_Explicit("Accounts.Login"));
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Bootstrap$AccountBootstrapTaskBase);
var Neptuo$TemplateEngine$Accounts$Commands$UserAccountCreateCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserAccountCreateCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Username = null;
            this._Password = null;
            this._PasswordAgain = null;
            this._IsEnabled = false;
            this._RoleKeys = null;
            System.Object.ctor.call(this);
        },
        Username$$: "System.String",
        get_Username: function (){
            return this._Username;
        },
        set_Username: function (value){
            this._Username = value;
        },
        Password$$: "System.String",
        get_Password: function (){
            return this._Password;
        },
        set_Password: function (value){
            this._Password = value;
        },
        PasswordAgain$$: "System.String",
        get_PasswordAgain: function (){
            return this._PasswordAgain;
        },
        set_PasswordAgain: function (value){
            this._PasswordAgain = value;
        },
        IsEnabled$$: "System.Boolean",
        get_IsEnabled: function (){
            return this._IsEnabled;
        },
        set_IsEnabled: function (value){
            this._IsEnabled = value;
        },
        RoleKeys$$: "System.Collections.Generic.IEnumerable`1[[System.Int32]]",
        get_RoleKeys: function (){
            return this._RoleKeys;
        },
        set_RoleKeys: function (value){
            this._RoleKeys = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserAccountCreateCommand);
var Neptuo$TemplateEngine$Accounts$Commands$UserAccountDeleteCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserAccountDeleteCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._UserKey = 0;
            System.Object.ctor.call(this);
        },
        UserKey$$: "System.Int32",
        get_UserKey: function (){
            return this._UserKey;
        },
        set_UserKey: function (value){
            this._UserKey = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserAccountDeleteCommand);
var Neptuo$TemplateEngine$Accounts$Commands$UserAccountEditCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserAccountEditCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Key = 0;
            this._Username = null;
            this._Password = null;
            this._PasswordAgain = null;
            this._IsEnabled = false;
            this._RoleKeys = null;
            System.Object.ctor.call(this);
        },
        Key$$: "System.Int32",
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
        Password$$: "System.String",
        get_Password: function (){
            return this._Password;
        },
        set_Password: function (value){
            this._Password = value;
        },
        PasswordAgain$$: "System.String",
        get_PasswordAgain: function (){
            return this._PasswordAgain;
        },
        set_PasswordAgain: function (value){
            this._PasswordAgain = value;
        },
        IsEnabled$$: "System.Boolean",
        get_IsEnabled: function (){
            return this._IsEnabled;
        },
        set_IsEnabled: function (value){
            this._IsEnabled = value;
        },
        RoleKeys$$: "System.Collections.Generic.IEnumerable`1[[System.Int32]]",
        get_RoleKeys: function (){
            return this._RoleKeys;
        },
        set_RoleKeys: function (value){
            this._RoleKeys = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserAccountEditCommand);
var Neptuo$TemplateEngine$Accounts$Commands$UserRoleCreateCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserRoleCreateCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Name = null;
            this._Description = null;
            System.Object.ctor.call(this);
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserRoleCreateCommand);
var Neptuo$TemplateEngine$Accounts$Commands$UserRoleDeleteCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserRoleDeleteCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._RoleKey = 0;
            System.Object.ctor.call(this);
        },
        RoleKey$$: "System.Int32",
        get_RoleKey: function (){
            return this._RoleKey;
        },
        set_RoleKey: function (value){
            this._RoleKey = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserRoleDeleteCommand);
var Neptuo$TemplateEngine$Accounts$Events$UserSignedIn = {
    fullname: "Neptuo.TemplateEngine.Accounts.Events.UserSignedIn",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, username){
            this._Key = 0;
            this._Username = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.Positive(key, "key");
            Neptuo.Guard.NotNullOrEmpty(username, "username");
            this.set_Key(key);
            this.set_Username(username);
        },
        Key$$: "System.Int32",
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Events$UserSignedIn);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$IUserAccountDataSourceFilter = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.IUserAccountDataSourceFilter",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$IUserAccountDataSourceFilter);
var Neptuo$TemplateEngine$Accounts$Templates$DataSources$IUserRoleDataSourceFilter = {
    fullname: "Neptuo.TemplateEngine.Accounts.Templates.DataSources.IUserRoleDataSourceFilter",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Templates$DataSources$IUserRoleDataSourceFilter);
var Neptuo$TemplateEngine$Accounts$UserAccountLoginModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountLoginModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Username = null;
            this._Password = null;
            System.Object.ctor.call(this);
        },
        Username$$: "System.String",
        get_Username: function (){
            return this._Username;
        },
        set_Username: function (value){
            this._Username = value;
        },
        Password$$: "System.String",
        get_Password: function (){
            return this._Password;
        },
        set_Password: function (value){
            this._Password = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountLoginModel);
var Neptuo$TemplateEngine$Accounts$UserAccountRowViewModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountRowViewModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, username){
            this._Key = 0;
            this._Username = null;
            System.Object.ctor.call(this);
            this.set_Key(key);
            this.set_Username(username);
        },
        Key$$: "System.Int32",
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountRowViewModel);
var Neptuo$TemplateEngine$Accounts$UserAccountViewModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountViewModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, username, isEnabled, roles){
            this._Key = 0;
            this._Username = null;
            this._IsEnabled = false;
            this._Roles = null;
            System.Object.ctor.call(this);
            this.set_Key(key);
            this.set_Username(username);
            this.set_IsEnabled(isEnabled);
            this.set_Roles(roles);
        },
        Key$$: "System.Int32",
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
        IsEnabled$$: "System.Boolean",
        get_IsEnabled: function (){
            return this._IsEnabled;
        },
        set_IsEnabled: function (value){
            this._IsEnabled = value;
        },
        Roles$$: "System.Collections.Generic.IEnumerable`1[[Neptuo.TemplateEngine.Accounts.UserRoleRowViewModel]]",
        get_Roles: function (){
            return this._Roles;
        },
        set_Roles: function (value){
            this._Roles = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String", "System.Boolean", "System.Collections.Generic.IEnumerable"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountViewModel);
var Neptuo$TemplateEngine$Accounts$Commands$UserRoleEditCommand = {
    fullname: "Neptuo.TemplateEngine.Accounts.Commands.UserRoleEditCommand",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Key = 0;
            this._Name = null;
            this._Description = null;
            System.Object.ctor.call(this);
        },
        Key$$: "System.Int32",
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Commands$UserRoleEditCommand);
var Neptuo$TemplateEngine$Accounts$Events$UserAccountCreated = {
    fullname: "Neptuo.TemplateEngine.Accounts.Events.UserAccountCreated",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (userKey, username){
            this._UserKey = 0;
            this._Username = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.Positive(userKey, "userKey");
            Neptuo.Guard.NotNullOrEmpty(username, "username");
            this.set_UserKey(userKey);
            this.set_Username(username);
        },
        UserKey$$: "System.Int32",
        get_UserKey: function (){
            return this._UserKey;
        },
        set_UserKey: function (value){
            this._UserKey = value;
        },
        Username$$: "System.String",
        get_Username: function (){
            return this._Username;
        },
        set_Username: function (value){
            this._Username = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Events$UserAccountCreated);
var Neptuo$TemplateEngine$Accounts$Events$UserAccountDeleted = {
    fullname: "Neptuo.TemplateEngine.Accounts.Events.UserAccountDeleted",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (userKey){
            this._UserKey = 0;
            System.Object.ctor.call(this);
            Neptuo.Guard.Positive(userKey, "userKey");
            this.set_UserKey(userKey);
        },
        UserKey$$: "System.Int32",
        get_UserKey: function (){
            return this._UserKey;
        },
        set_UserKey: function (value){
            this._UserKey = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Events$UserAccountDeleted);
var Neptuo$TemplateEngine$Accounts$Events$UserAccountUpdated = {
    fullname: "Neptuo.TemplateEngine.Accounts.Events.UserAccountUpdated",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (userKey){
            this._UserKey = 0;
            System.Object.ctor.call(this);
            Neptuo.Guard.Positive(userKey, "userKey");
            this.set_UserKey(userKey);
        },
        UserKey$$: "System.Int32",
        get_UserKey: function (){
            return this._UserKey;
        },
        set_UserKey: function (value){
            this._UserKey = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Events$UserAccountUpdated);
var Neptuo$TemplateEngine$Accounts$UserAccountEditModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserAccountEditModel",
    baseTypeName: "Neptuo.TemplateEngine.Accounts.Commands.UserAccountEditCommand",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.TemplateEngine.Accounts.Commands.UserAccountEditCommand.ctor.call(this);
        },
        IsNew$$: "System.Boolean",
        get_IsNew: function (){
            return this.get_Key() == 0;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserAccountEditModel);
var Neptuo$TemplateEngine$Accounts$UserLogViewModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserLogViewModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, user, signedIn, signedOut, lastActivity, isCurrent){
            this._Key = null;
            this._User = null;
            this._SignedIn = System.DateTime.MinValue;
            this._SignedOut = null;
            this._LastActivity = null;
            this._IsCurrent = false;
            System.Object.ctor.call(this);
            this.set_Key(key);
            this.set_User(user);
            this.set_SignedIn(signedIn);
            this.set_SignedOut(signedOut);
            this.set_LastActivity(lastActivity);
            this.set_IsCurrent(isCurrent);
        },
        Key$$: "System.String",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        User$$: "Neptuo.TemplateEngine.Accounts.UserAccountRowViewModel",
        get_User: function (){
            return this._User;
        },
        set_User: function (value){
            this._User = value;
        },
        SignedIn$$: "System.DateTime",
        get_SignedIn: function (){
            return this._SignedIn;
        },
        set_SignedIn: function (value){
            this._SignedIn = value;
        },
        SignedOut$$: "System.Nullable`1[[System.DateTime]]",
        get_SignedOut: function (){
            return this._SignedOut;
        },
        set_SignedOut: function (value){
            this._SignedOut = value;
        },
        LastActivity$$: "System.Nullable`1[[System.DateTime]]",
        get_LastActivity: function (){
            return this._LastActivity;
        },
        set_LastActivity: function (value){
            this._LastActivity = value;
        },
        IsCurrent$$: "System.Boolean",
        get_IsCurrent: function (){
            return this._IsCurrent;
        },
        set_IsCurrent: function (value){
            this._IsCurrent = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "Neptuo.TemplateEngine.Accounts.UserAccountRowViewModel", "System.DateTime", "System.Nullable", "System.Nullable", "System.Boolean"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserLogViewModel);
var Neptuo$TemplateEngine$Accounts$UserRoleEditModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleEditModel",
    baseTypeName: "Neptuo.TemplateEngine.Accounts.Commands.UserRoleEditCommand",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.TemplateEngine.Accounts.Commands.UserRoleEditCommand.ctor.call(this);
        },
        IsNew$$: "System.Boolean",
        get_IsNew: function (){
            return this.get_Key() == 0;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleEditModel);
var Neptuo$TemplateEngine$Accounts$UserRoleRowViewModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleRowViewModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, name){
            this._Key = 0;
            this._Name = null;
            System.Object.ctor.call(this);
            this.set_Key(key);
            this.set_Name(name);
        },
        Key$$: "System.Int32",
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleRowViewModel);
var Neptuo$TemplateEngine$Accounts$UserRoleViewModel = {
    fullname: "Neptuo.TemplateEngine.Accounts.UserRoleViewModel",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Shared",
    Kind: "Class",
    definition: {
        ctor: function (key, name, description){
            this._Key = 0;
            this._Name = null;
            this._Description = null;
            System.Object.ctor.call(this);
            this.set_Key(key);
            this.set_Name(name);
            this.set_Description(description);
        },
        Key$$: "System.Int32",
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
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Int32", "System.String", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$UserRoleViewModel);

