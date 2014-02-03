/* Generated by SharpKit 5 v5.3.4 */
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
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource =
{
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserAccountDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.DataSources.IListDataSource"],
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
        GetTotalCount: function ()
        {
            return 0;
        },
        GetData: function (pageIndex, pageSize, callback)
        {
            setTimeout($CreateAnonymousDelegate(this, function ()
            {
                callback((function ()
                {
                    var $v1 = new System.Collections.Generic.List$1.ctor(System.Object.ctor);
                    $v1.Add((function ()
                    {
                        var $v2 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v2.set_Key(1);
                        $v2.set_Username("New user");
                        $v2.set_IsEnabled(true);
                        return $v2;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v3 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v3.set_Key(2);
                        $v3.set_Username("New user");
                        $v3.set_IsEnabled(false);
                        return $v3;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v4 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v4.set_Key(3);
                        $v4.set_Username("New user");
                        $v4.set_IsEnabled(false);
                        return $v4;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v5 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v5.set_Key(4);
                        $v5.set_Username("New user");
                        $v5.set_IsEnabled(false);
                        return $v5;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v6 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v6.set_Key(5);
                        $v6.set_Username("New user");
                        $v6.set_IsEnabled(true);
                        return $v6;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v7 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v7.set_Key(6);
                        $v7.set_Username("New user");
                        $v7.set_IsEnabled(false);
                        return $v7;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v8 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v8.set_Key(7);
                        $v8.set_Username("New user");
                        $v8.set_IsEnabled(false);
                        return $v8;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v9 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v9.set_Key(8);
                        $v9.set_Username("New user");
                        $v9.set_IsEnabled(true);
                        return $v9;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v10 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v10.set_Key(9);
                        $v10.set_Username("New user");
                        $v10.set_IsEnabled(true);
                        return $v10;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v11 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v11.set_Key(10);
                        $v11.set_Username("New user");
                        $v11.set_IsEnabled(true);
                        return $v11;
                    }).call(this));
                    $v1.Add((function ()
                    {
                        var $v12 = new Neptuo.TemplateEngine.Accounts.UserAccountEditModel.ctor();
                        $v12.set_Key(11);
                        $v12.set_Username("New user");
                        $v12.set_IsEnabled(true);
                        return $v12;
                    }).call(this));
                    return $v1;
                }).call(this));
            }), 1000);
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserAccountDataSource);
var Neptuo$TemplateEngine$Accounts$Web$DataSources$UserRoleDataSource =
{
    fullname: "Neptuo.TemplateEngine.Accounts.Web.DataSources.UserRoleDataSource",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Accounts.Client",
    interfaceNames: ["Neptuo.TemplateEngine.Web.DataSources.IListDataSource"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this._Key = null;
            this._Name = null;
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
        Name$$: "System.String",
        get_Name: function ()
        {
            return this._Name;
        },
        set_Name: function (value)
        {
            this._Name = value;
        },
        GetTotalCount: function ()
        {
            return 0;
        },
        GetData: function (pageIndex, pageSize, callback)
        {
            callback(new System.Collections.Generic.List$1.ctor(System.Object.ctor));
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Accounts$Web$DataSources$UserRoleDataSource);
