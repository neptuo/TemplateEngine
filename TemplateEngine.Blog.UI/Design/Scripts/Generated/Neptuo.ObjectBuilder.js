/* Generated by SharpKit 5 v5.3.4 */
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
var Neptuo$ObjectBuilder$DependencyContainer =
{
    fullname: "Neptuo.ObjectBuilder.DependencyContainer",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    interfaceNames: ["Neptuo.IDependencyContainer", "Neptuo.Lifetimes.Mapping.ILifetimeMapping$1"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this._IsChildMappingCreated = false;
            this._Registry = null;
            this._LifetimeMapping = null;
            Neptuo.ObjectBuilder.DependencyContainer.ctor$$DependencyRegistry$$LifetimeMapping$1$IDependencyLifetime.call(this, new Neptuo.ObjectBuilder.DependencyRegistry.ctor(), new Neptuo.Lifetimes.Mapping.LifetimeMapping$1.ctor(Neptuo.ObjectBuilder.IDependencyLifetime.ctor));
            this.set_IsChildMappingCreated(true);
        },
        IsChildMappingCreated$$: "System.Boolean",
        get_IsChildMappingCreated: function ()
        {
            return this._IsChildMappingCreated;
        },
        set_IsChildMappingCreated: function (value)
        {
            this._IsChildMappingCreated = value;
        },
        Registry$$: "Neptuo.ObjectBuilder.DependencyRegistry",
        get_Registry: function ()
        {
            return this._Registry;
        },
        set_Registry: function (value)
        {
            this._Registry = value;
        },
        LifetimeMapping$$: "Neptuo.Lifetimes.Mapping.LifetimeMapping`1[[Neptuo.ObjectBuilder.IDependencyLifetime]]",
        get_LifetimeMapping: function ()
        {
            return this._LifetimeMapping;
        },
        set_LifetimeMapping: function (value)
        {
            this._LifetimeMapping = value;
        },
        ctor$$DependencyRegistry$$LifetimeMapping$1$IDependencyLifetime: function (registry, lifetimeMapping)
        {
            this._IsChildMappingCreated = false;
            this._Registry = null;
            this._LifetimeMapping = null;
            System.Object.ctor.call(this);
            if (registry == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("registry"), new Error());
            if (lifetimeMapping == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("lifetimeMapping"), new Error());
            this.set_Registry(registry);
            this.set_LifetimeMapping(lifetimeMapping);
            this.RegisterInstance(Typeof(Neptuo.IDependencyContainer.ctor), null , this);
            this.RegisterInstance(Typeof(Neptuo.IDependencyProvider.ctor), null , this);
        },
        RegisterInstance: function (t, name, instance)
        {
            this.get_Registry().Add(this.GetKey(t), name, (function ()
            {
                var $v1 = new Neptuo.ObjectBuilder.DependencyRegistryItem.ctor();
                $v1.set_Target(t);
                $v1.set_Constructor(null);
                $v1.set_LifetimeManager(new Neptuo.ObjectBuilder.SingletonLifetimeManager.ctor(instance));
                return $v1;
            }).call(this));
            return this;
        },
        RegisterType: function (from, to, name, lifetime)
        {
            if (to.get_IsInterface())
                throw $CreateException(new Neptuo.ObjectBuilder.DependencyException.ctor(System.String.Format$$String$$Object$$Object("Target can\'t be interface. Mapping \'{0}\' to \'{1}\'.", from.get_FullName(), to.get_FullName())), new Error());
            if (to.get_IsAbstract())
                throw $CreateException(new Neptuo.ObjectBuilder.DependencyException.ctor(System.String.Format$$String$$Object$$Object("Target can\'t be abstract class. Mapping \'{0}\' to \'{1}\'.", from.get_FullName(), to.get_FullName())), new Error());
            this.get_Registry().Add(this.GetKey(from), name, (function ()
            {
                var $v2 = new Neptuo.ObjectBuilder.DependencyRegistryItem.ctor();
                $v2.set_Target(to);
                $v2.set_Constructor(this.FindBestConstructor(to));
                $v2.set_LifetimeManager(this.MapLifetime(lifetime));
                return $v2;
            }).call(this));
            return this;
        },
        CreateChildContainer: function ()
        {
            return new Neptuo.ObjectBuilder.DependencyContainer.ctor$$DependencyRegistry$$LifetimeMapping$1$IDependencyLifetime(new Neptuo.ObjectBuilder.DependencyRegistry.ctor$$Dictionary$2(this.get_Registry().CopyRegistries()), this.get_LifetimeMapping());
        },
        Resolve: function (t, name)
        {
            var key = this.GetKey(t);
            var item = this.get_Registry().GetByKey(key, name);
            if (item == null)
            {
                this.RegisterType(t, t, name, null);
                item = this.get_Registry().GetByKey(key, name);
            }
            return this.Build(item);
        },
        ResolveAll: function (t)
        {
            var result = new System.Collections.Generic.List$1.ctor(System.Object.ctor);
            var key = this.GetKey(t);
            var $it1 = this.get_Registry().GetAllByKey(key).GetEnumerator();
            while ($it1.MoveNext())
            {
                var item = $it1.get_Current();
                result.Add(this.Build(item));
            }
            return result;
        },
        GetKey: function (t)
        {
            return t.get_FullName();
        },
        Build: function (item)
        {
            if (item == null)
                return null;
            var instance = item.get_LifetimeManager().GetValue();
            if (instance != null)
                return instance;
            if (System.Reflection.ConstructorInfo.op_Equality$$ConstructorInfo$$ConstructorInfo(item.get_Constructor(), null))
                throw $CreateException(new Neptuo.ObjectBuilder.DependencyException.ctor("Missing constructor."), new Error());
            var parameterDefinitions = item.get_Constructor().GetParameters();
            var parameters = new Array(parameterDefinitions.get_Length());
            for (var i = 0; i < parameterDefinitions.get_Length(); i++)
                parameters[i] = this.Resolve(parameterDefinitions[i].get_ParameterType(), null);
            instance = item.get_Constructor().Invoke$$Object$Array(parameters);
            item.get_LifetimeManager().SetValue(instance);
            return instance;
        },
        MapLifetime: function (lifetime)
        {
            var lifetimeManager = null;
            if (lifetime != null)
                lifetimeManager = this.get_LifetimeMapping().Resolve(lifetime);
            else
                lifetimeManager = new Neptuo.ObjectBuilder.TransientLifetimeManager.ctor();
            return lifetimeManager;
        },
        FindBestConstructor: function (type)
        {
            var result = null;
            var $it2 = type.GetConstructors().GetEnumerator();
            while ($it2.MoveNext())
            {
                var ctor = $it2.get_Current();
                if (System.Reflection.ConstructorInfo.op_Equality$$ConstructorInfo$$ConstructorInfo(result, null))
                    result = ctor;
                else if (result.GetParameters().get_Length() < ctor.GetParameters().get_Length())
                    result = ctor;
            }
            return result;
        },
        Map: function (lifetimeType, mapper)
        {
            if (!this.get_IsChildMappingCreated())
            {
                this.set_LifetimeMapping(this.get_LifetimeMapping().CreateChildMapping());
                this.set_IsChildMappingCreated(true);
            }
            this.get_LifetimeMapping().Map(lifetimeType, mapper);
        }
    },
    ctors: [ {name: "ctor", parameters: []}, {name: "ctor$$DependencyRegistry$$LifetimeMapping", parameters: ["Neptuo.ObjectBuilder.DependencyRegistry", "Neptuo.Lifetimes.Mapping.LifetimeMapping"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$DependencyContainer);
var Neptuo$ObjectBuilder$DependencyException =
{
    fullname: "Neptuo.ObjectBuilder.DependencyException",
    baseTypeName: "System.Exception",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    Kind: "Class",
    definition:
    {
        ctor: function (message)
        {
            System.Exception.ctor$$String.call(this, message);
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.String"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$DependencyException);
var Neptuo$ObjectBuilder$DependencyRegistry =
{
    fullname: "Neptuo.ObjectBuilder.DependencyRegistry",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this.registries = null;
            Neptuo.ObjectBuilder.DependencyRegistry.ctor$$Dictionary$2.call(this, new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, System.Collections.Generic.Dictionary$2.ctor));
        },
        ctor$$Dictionary$2: function (registries)
        {
            this.registries = null;
            System.Object.ctor.call(this);
            if (registries == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("registries"), new Error());
            this.registries = registries;
        },
        GetAllByKey: function (key)
        {
            if (key == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("key"), new Error());
            if (this.registries.ContainsKey(key))
                return this.registries.get_Item$$TKey(key).get_Values();
            return new System.Collections.Generic.List$1.ctor(Neptuo.ObjectBuilder.DependencyRegistryItem.ctor);
        },
        GetByKey: function (key, subKey)
        {
            if (key == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("key"), new Error());
            if (this.registries.ContainsKey(key))
            {
                var subRegistry = this.registries.get_Item$$TKey(key);
                if (subKey == null)
                {
                    if (!subRegistry.ContainsKey(System.String.Empty))
                        throw $CreateException(new Neptuo.ObjectBuilder.DependencyException.ctor("Missing default registry for key \'" + key + "\'."), new Error());
                    return subRegistry.get_Item$$TKey(System.String.Empty);
                }
                if (subRegistry.ContainsKey(subKey))
                    return subRegistry.get_Item$$TKey(subKey);
                return null;
            }
            return null;
        },
        Add: function (key, subKey, item)
        {
            if (key == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("key"), new Error());
            if (item == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("item"), new Error());
            if (!this.registries.ContainsKey(key))
                this.registries.set_Item$$TKey(key, new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, Neptuo.ObjectBuilder.DependencyRegistryItem.ctor));
            this.registries.get_Item$$TKey(key).set_Item$$TKey((subKey != null ? subKey : System.String.Empty), item);
        },
        CopyRegistries: function ()
        {
            var result = new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, System.Collections.Generic.Dictionary$2.ctor);
            var $it3 = this.registries.GetEnumerator();
            while ($it3.MoveNext())
            {
                var item = $it3.get_Current();
                var partialResult = new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, Neptuo.ObjectBuilder.DependencyRegistryItem.ctor);
                var $it4 = item.get_Value().GetEnumerator();
                while ($it4.MoveNext())
                {
                    var subItem = $it4.get_Current();
                    partialResult.Add(subItem.get_Key(), subItem.get_Value());
                }
                result.Add(item.get_Key(), partialResult);
            }
            return result;
        }
    },
    ctors: [ {name: "ctor", parameters: []}, {name: "ctor$$Dictionary", parameters: ["System.Collections.Generic.Dictionary"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$DependencyRegistry);
var Neptuo$ObjectBuilder$DependencyRegistryItem =
{
    fullname: "Neptuo.ObjectBuilder.DependencyRegistryItem",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            this._Target = null;
            this._LifetimeManager = null;
            this._Constructor = null;
            System.Object.ctor.call(this);
        },
        Target$$: "System.Type",
        get_Target: function ()
        {
            return this._Target;
        },
        set_Target: function (value)
        {
            this._Target = value;
        },
        LifetimeManager$$: "Neptuo.ObjectBuilder.IDependencyLifetime",
        get_LifetimeManager: function ()
        {
            return this._LifetimeManager;
        },
        set_LifetimeManager: function (value)
        {
            this._LifetimeManager = value;
        },
        Constructor$$: "System.Reflection.ConstructorInfo",
        get_Constructor: function ()
        {
            return this._Constructor;
        },
        set_Constructor: function (value)
        {
            this._Constructor = value;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$DependencyRegistryItem);
var Neptuo$ObjectBuilder$GetterLifetimeManager =
{
    fullname: "Neptuo.ObjectBuilder.GetterLifetimeManager",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    interfaceNames: ["Neptuo.ObjectBuilder.IDependencyLifetime"],
    Kind: "Class",
    definition:
    {
        ctor: function (getter)
        {
            this.getter = null;
            System.Object.ctor.call(this);
            if (System.MulticastDelegate.op_Equality$$MulticastDelegate$$MulticastDelegate(getter, null))
                throw $CreateException(new System.ArgumentNullException.ctor$$String("getter"), new Error());
            this.getter = getter;
        },
        GetValue: function ()
        {
            return this.getter();
        },
        RemoveValue: function ()
        {
            this.getter = $CreateAnonymousDelegate(this, function ()
            {
                return null;
            });
        },
        SetValue: function (newValue)
        {
            this.getter = $CreateAnonymousDelegate(this, function ()
            {
                return newValue;
            });
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Func"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$GetterLifetimeManager);
var Neptuo$ObjectBuilder$IDependencyLifetime = {fullname: "Neptuo.ObjectBuilder.IDependencyLifetime", baseTypeName: "System.Object", assemblyName: "Neptuo.ObjectBuilder.Client", Kind: "Interface", ctors: [], IsAbstract: true};
JsTypes.push(Neptuo$ObjectBuilder$IDependencyLifetime);
var Neptuo$ObjectBuilder$Lifetimes$Mapping$SingletonLifetimeMapper =
{
    fullname: "Neptuo.ObjectBuilder.Lifetimes.Mapping.SingletonLifetimeMapper",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    interfaceNames: ["Neptuo.Lifetimes.Mapping.ILifetimeMapper$1"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        },
        Map: function (lifetime)
        {
            var singletionLifetime = As(lifetime, Neptuo.Lifetimes.SingletonLifetime.ctor);
            Neptuo.Guard.NotNull$$Object$$String(singletionLifetime, "lifetime");
            return new Neptuo.ObjectBuilder.SingletonLifetimeManager.ctor(singletionLifetime.get_Instance());
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$Lifetimes$Mapping$SingletonLifetimeMapper);
var Neptuo$ObjectBuilder$VersionInfo =
{
    fullname: "Neptuo.ObjectBuilder.VersionInfo",
    baseTypeName: "System.Object",
    staticDefinition:
    {
        cctor: function ()
        {
            Neptuo.ObjectBuilder.VersionInfo.Version = "1.1.6";
        },
        GetVersion: function ()
        {
            return new System.Version.ctor$$String("1.1.6");
        }
    },
    assemblyName: "Neptuo.ObjectBuilder.Client",
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
JsTypes.push(Neptuo$ObjectBuilder$VersionInfo);
var Neptuo$ObjectBuilder$SingletonLifetimeManager =
{
    fullname: "Neptuo.ObjectBuilder.SingletonLifetimeManager",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    interfaceNames: ["Neptuo.ObjectBuilder.IDependencyLifetime"],
    Kind: "Class",
    definition:
    {
        ctor: function (value)
        {
            this.value = null;
            System.Object.ctor.call(this);
            this.value = value;
        },
        GetValue: function ()
        {
            return this.value;
        },
        RemoveValue: function ()
        {
        },
        SetValue: function (newValue)
        {
        }
    },
    ctors: [ {name: "ctor", parameters: ["System.Object"]}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$SingletonLifetimeManager);
var Neptuo$ObjectBuilder$TransientLifetimeManager =
{
    fullname: "Neptuo.ObjectBuilder.TransientLifetimeManager",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.ObjectBuilder.Client",
    interfaceNames: ["Neptuo.ObjectBuilder.IDependencyLifetime"],
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            System.Object.ctor.call(this);
        },
        GetValue: function ()
        {
            return null;
        },
        RemoveValue: function ()
        {
        },
        SetValue: function (newValue)
        {
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$ObjectBuilder$TransientLifetimeManager);
