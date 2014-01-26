/* Generated by SharpKit 5 v5.2.9 */
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
var Neptuo$Bootstrap$AutomaticBootstrapper =
{
    fullname: "Neptuo.Bootstrap.AutomaticBootstrapper",
    baseTypeName: "Neptuo.Bootstrap.BaseBootstraper",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapper"],
    Kind: "Class",
    definition:
    {
        ctor$$Func$2$Type$IBootstrapTask$$IBootstrapConstraintProvider: function (factory, provider)
        {
            this.types = null;
            Neptuo.Bootstrap.BaseBootstraper.ctor.call(this, factory, provider);
        },
        ctor$$Func$2$Type$IBootstrapTask$$IEnumerable$1$Type$$IBootstrapConstraintProvider: function (factory, types, provider)
        {
            this.types = null;
            Neptuo.Bootstrap.BaseBootstraper.ctor.call(this, factory, provider);
            this.types = this.AddSupportedTypes(new System.Collections.Generic.List$1.ctor(System.Type.ctor), types);
        },
        Initialize: function ()
        {
            if (this.types == null)
                this.types = this.FindTypes();
            var $it1 = this.types.GetEnumerator();
            while ($it1.MoveNext())
            {
                var type = $it1.get_Current();
                this.get_Tasks().Add(this.CreateInstance$$Type(type));
            }
            Neptuo.Bootstrap.BaseBootstraper.commonPrototype.Initialize.call(this);
        },
        FindTypes: function ()
        {
            var types = new System.Collections.Generic.List$1.ctor(System.Type.ctor);
            this.SearchAssemblies(types);
            return types;
        },
        SearchAssemblies: function (types)
        {
            var $it2 = System.AppDomain.get_CurrentDomain().GetAssemblies().GetEnumerator();
            while ($it2.MoveNext())
            {
                var assembly = $it2.get_Current();
                try
                {
                    this.AddSupportedTypes(types, assembly.GetTypes());
                }
                catch ($$e1)
                {
                }
            }
            return types;
        },
        AddSupportedTypes: function (target, sourceTypes)
        {
            if (target == null)
                target = new System.Collections.Generic.List$1.ctor(System.Type.ctor);
            var bootstrapInterfaceType = Typeof(Neptuo.Bootstrap.IBootstrapTask.ctor);
            var $it3 = sourceTypes.GetEnumerator();
            while ($it3.MoveNext())
            {
                var type = $it3.get_Current();
                if (bootstrapInterfaceType.IsAssignableFrom(type) && System.Type.op_Inequality$$Type$$Type(bootstrapInterfaceType, type) && !type.get_IsAbstract() && !type.get_IsInterface())
                    target.Add(type);
            }
            return target;
        }
    },
    ctors: [ {name: "ctor$$Func$$IBootstrapConstraintProvider", parameters: ["System.Func", "Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"]}, {name: "ctor$$Func$$IEnumerable$$IBootstrapConstraintProvider", parameters: ["System.Func", "System.Collections.Generic.IEnumerable", "Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$AutomaticBootstrapper);
var Neptuo$Bootstrap$BaseBootstraper =
{
    fullname: "Neptuo.Bootstrap.BaseBootstraper",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapper"],
    Kind: "Class",
    definition:
    {
        ctor: function (factory, provider)
        {
            this.provider = null;
            this.factory = null;
            this._Tasks = null;
            System.Object.ctor.call(this);
            if (System.MulticastDelegate.op_Equality$$MulticastDelegate$$MulticastDelegate(factory, null))
                throw $CreateException(new System.ArgumentNullException.ctor$$String("factory"), new Error());
            this.factory = factory;
            this.provider = (provider != null ? provider : new Neptuo.Bootstrap.Constraints.NullObjectConstrainProvider.ctor());
            this.set_Tasks(new System.Collections.Generic.List$1.ctor(Neptuo.Bootstrap.IBootstrapTask.ctor));
        },
        Tasks$$: "System.Collections.Generic.List`1[[Neptuo.Bootstrap.IBootstrapTask]]",
        get_Tasks: function ()
        {
            return this._Tasks;
        },
        set_Tasks: function (value)
        {
            this._Tasks = value;
        },
        CreateInstance$$Type: function (type)
        {
            return this.factory(type);
        },
        CreateInstance$1: function (T)
        {
            return this.factory(Typeof(T));
        },
        Initialize: function ()
        {
            var context = new Neptuo.Bootstrap.Constraints.DefaultBootstrapConstraintContext.ctor(this);
            var $it4 = this.get_Tasks().GetEnumerator();
            while ($it4.MoveNext())
            {
                var task = $it4.get_Current();
                if (Neptuo.Bootstrap.IEnumerableConstraintExtensions.Satisfies(this.provider.GetConstraints(task.GetType()), context))
                    task.Initialize();
            }
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func", "Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"]}],
    IsAbstract: true
};
JsTypes.push(Neptuo$Bootstrap$BaseBootstraper);
var Neptuo$Bootstrap$IEnumerableConstraintExtensions =
{
    fullname: "Neptuo.Bootstrap.IEnumerableConstraintExtensions",
    baseTypeName: "System.Object",
    staticDefinition:
    {
        Satisfies: function (constraints, context)
        {
            var $it5 = constraints.GetEnumerator();
            while ($it5.MoveNext())
            {
                var constraint = $it5.get_Current();
                if (!constraint.Satisfies(context))
                    return false;
            }
            return true;
        }
    },
    assemblyName: "Neptuo.Bootstrap",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$Bootstrap$IEnumerableConstraintExtensions);
var Neptuo$Bootstrap$ConstraintAttribute =
{
    fullname: "Neptuo.Bootstrap.ConstraintAttribute",
    baseTypeName: "System.Attribute",
    assemblyName: "Neptuo.Bootstrap",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this._Type = null;
            System.Attribute.ctor.call(this);
        },
        Type$$: "System.Type",
        get_Type: function ()
        {
            return this._Type;
        },
        set_Type: function (value)
        {
            this._Type = value;
        },
        ctor$$Type: function (type)
        {
            this._Type = null;
            System.Attribute.ctor.call(this);
            this.set_Type(type);
        },
        GetConstraintType: function ()
        {
            if (System.Type.op_Inequality$$Type$$Type(this.get_Type(), null))
                return this.get_Type();
            throw $CreateException(new System.ArgumentNullException.ctor$$String("Type"), new Error());
        }
    },
    ctors: [ {name: "ctor", parameters: []}, {name: "ctor$$Type", parameters: ["System.Type"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$ConstraintAttribute);
var Neptuo$Bootstrap$Constraints$AttributeConstraintProvider =
{
    fullname: "Neptuo.Bootstrap.Constraints.AttributeConstraintProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"],
    Kind: "Class",
    definition:
    {
        ctor: function (factory)
        {
            this.factory = null;
            System.Object.ctor.call(this);
            this.factory = factory;
        },
        GetConstraints: function (bootstrapTask)
        {
            var result = new System.Collections.Generic.List$1.ctor(Neptuo.Bootstrap.Constraints.IBootstrapConstraint.ctor);
            var $it6 = bootstrapTask.GetCustomAttributes$$Boolean(true).GetEnumerator();
            while ($it6.MoveNext())
            {
                var attribute = $it6.get_Current();
                if (Is(attribute, Neptuo.Bootstrap.ConstraintAttribute.ctor))
                {
                    var constraint = null;
                    if (Is(attribute, Neptuo.Bootstrap.Constraints.IBootstrapConstraint.ctor))
                        constraint = Cast(attribute, Neptuo.Bootstrap.Constraints.IBootstrapConstraint.ctor);
                    else
                        constraint = this.CreateInstance((Cast(attribute, Neptuo.Bootstrap.ConstraintAttribute.ctor)).GetConstraintType());
                    if (constraint != null)
                        result.Add(constraint);
                }
            }
            return result;
        },
        CreateInstance: function (type)
        {
            return this.factory(type);
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$Constraints$AttributeConstraintProvider);
var Neptuo$Bootstrap$Constraints$CachingConstraintProvider =
{
    fullname: "Neptuo.Bootstrap.Constraints.CachingConstraintProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"],
    Kind: "Class",
    definition:
    {
        ctor: function (provider)
        {
            this.cache = new System.Collections.Generic.Dictionary$2.ctor(System.Type.ctor, System.Collections.Generic.IEnumerable$1.ctor);
            this.provider = null;
            System.Object.ctor.call(this);
            this.provider = provider;
        },
        GetConstraints: function (bootstrapTask)
        {
            if (this.cache.ContainsKey(bootstrapTask))
                return this.cache.get_Item$$TKey(bootstrapTask);
            var constraints = this.provider.GetConstraints(bootstrapTask);
            this.cache.set_Item$$TKey(bootstrapTask, constraints);
            return constraints;
        },
        ClearCache: function ()
        {
            this.cache.Clear();
        }
    },
    ctors: [ {name: "ctor", parameters: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$Constraints$CachingConstraintProvider);
var Neptuo$Bootstrap$Constraints$DefaultBootstrapConstraintContext =
{
    fullname: "Neptuo.Bootstrap.Constraints.DefaultBootstrapConstraintContext",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraintContext"],
    Kind: "Class",
    definition:
    {
        ctor: function (bootstrapper)
        {
            this._Bootstrapper = null;
            System.Object.ctor.call(this);
            this.set_Bootstrapper(bootstrapper);
        },
        Bootstrapper$$: "Neptuo.Bootstrap.IBootstrapper",
        get_Bootstrapper: function ()
        {
            return this._Bootstrapper;
        },
        set_Bootstrapper: function (value)
        {
            this._Bootstrapper = value;
        }
    },
    ctors: [ {name: "ctor", parameters: ["Neptuo.Bootstrap.IBootstrapper"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$Constraints$DefaultBootstrapConstraintContext);
var Neptuo$Bootstrap$Constraints$IBootstrapConstraint = {fullname: "Neptuo.Bootstrap.Constraints.IBootstrapConstraint", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$Constraints$IBootstrapConstraint);
var Neptuo$Bootstrap$Constraints$IBootstrapConstraintContext = {fullname: "Neptuo.Bootstrap.Constraints.IBootstrapConstraintContext", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$Constraints$IBootstrapConstraintContext);
var Neptuo$Bootstrap$Constraints$IBootstrapConstraintProvider = {fullname: "Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$Constraints$IBootstrapConstraintProvider);
var Neptuo$Bootstrap$Constraints$NullObjectConstrainProvider =
{
    fullname: "Neptuo.Bootstrap.Constraints.NullObjectConstrainProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraintProvider"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this.result = new System.Collections.Generic.List$1.ctor(Neptuo.Bootstrap.Constraints.IBootstrapConstraint.ctor);
            System.Object.ctor.call(this);
        },
        GetConstraints: function (bootstrapTask)
        {
            return this.result;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$Constraints$NullObjectConstrainProvider);
var Neptuo$Bootstrap$HierarchicalBootstrapper =
{
    fullname: "Neptuo.Bootstrap.HierarchicalBootstrapper",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$HierarchicalBootstrapper);
var Neptuo$Bootstrap$IBootstrapper = {fullname: "Neptuo.Bootstrap.IBootstrapper", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$IBootstrapper);
var Neptuo$Bootstrap$IBootstrapTaskRegistry = {fullname: "Neptuo.Bootstrap.IBootstrapTaskRegistry", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$IBootstrapTaskRegistry);
var Neptuo$Bootstrap$IBootstrapTask = {fullname: "Neptuo.Bootstrap.IBootstrapTask", baseTypeName: "System.Object", assemblyName: "Neptuo.Bootstrap", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$Bootstrap$IBootstrapTask);
var Neptuo$Bootstrap$IgnoreAutomaticConstraintAttribute =
{
    fullname: "Neptuo.Bootstrap.IgnoreAutomaticConstraintAttribute",
    baseTypeName: "Neptuo.Bootstrap.ConstraintAttribute",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.Constraints.IBootstrapConstraint"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            Neptuo.Bootstrap.ConstraintAttribute.ctor.call(this);
        },
        Satisfies: function (context)
        {
            return !(Is(context.get_Bootstrapper(), Neptuo.Bootstrap.AutomaticBootstrapper.ctor));
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$IgnoreAutomaticConstraintAttribute);
var Neptuo$Bootstrap$ManualBootstrapper =
{
    fullname: "Neptuo.Bootstrap.ManualBootstrapper",
    baseTypeName: "Neptuo.Bootstrap.BaseBootstraper",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapper", "Neptuo.Bootstrap.IBootstrapTaskRegistry"],
    Kind: "Class",
    definition:
    {
        ctor: function (factory)
        {
            Neptuo.Bootstrap.BaseBootstraper.ctor.call(this, factory, null);
        },
        Register$$Type: function (type)
        {
            this.Register$$IBootstrapTask(this.CreateInstance$$Type(type));
        },
        Register$1: function (T)
        {
            this.Register$$Type(Typeof(T));
        },
        Register$$IBootstrapTask: function (task)
        {
            if (task != null)
                this.get_Tasks().Add(task);
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$ManualBootstrapper);
var Neptuo$Bootstrap$VersionInfo =
{
    fullname: "Neptuo.Bootstrap.VersionInfo",
    baseTypeName: "System.Object",
    staticDefinition:
    {
        cctor: function ()
        {
            Neptuo.Bootstrap.VersionInfo.Version = "3.3.0";
        },
        GetVersion: function ()
        {
            return new System.Version.ctor$$String("3.3.0");
        }
    },
    assemblyName: "Neptuo.Bootstrap",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$Bootstrap$VersionInfo);
var Neptuo$Bootstrap$ProxyBootstrapTask =
{
    fullname: "Neptuo.Bootstrap.ProxyBootstrapTask",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.Bootstrap",
    interfaceNames: ["Neptuo.Bootstrap.IBootstrapTask"],
    Kind: "Class",
    definition:
    {
        ctor: function (factory)
        {
            this.factory = null;
            System.Object.ctor.call(this);
            if (System.MulticastDelegate.op_Equality$$MulticastDelegate$$MulticastDelegate(factory, null))
                throw $CreateException(new System.ArgumentNullException.ctor$$String("factory"), new Error());
            this.factory = factory;
        },
        Initialize: function ()
        {
            var task = this.factory();
            if (task != null)
                task.Initialize();
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$ProxyBootstrapTask);
var Neptuo$Bootstrap$SequenceBootstrapper =
{
    fullname: "Neptuo.Bootstrap.SequenceBootstrapper",
    baseTypeName: "Neptuo.Bootstrap.ManualBootstrapper",
    assemblyName: "Neptuo.Bootstrap",
    Kind: "Class",
    definition:
    {
        ctor: function (factory)
        {
            Neptuo.Bootstrap.ManualBootstrapper.ctor.call(this, factory);
        },
        Register$$Type: function (type)
        {
            Neptuo.Bootstrap.ManualBootstrapper.commonPrototype.Register$$IBootstrapTask.call(this, new Neptuo.Bootstrap.ProxyBootstrapTask.ctor($CreateAnonymousDelegate(this, function ()
            {
                return this.CreateInstance$$Type(type);
            })));
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$Bootstrap$SequenceBootstrapper);
