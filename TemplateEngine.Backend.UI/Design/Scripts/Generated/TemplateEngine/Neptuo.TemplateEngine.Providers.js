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
var Neptuo$TemplateEngine$Providers$ModelBinders$BindingValueStorage = {
    fullname: "Neptuo.TemplateEngine.Providers.ModelBinders.BindingValueStorage",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    interfaceNames: ["Neptuo.PresentationModels.IBindingModelValueStorage"],
    Kind: "Class",
    definition: {
        ctor: function (parameterProvider){
            this._ParameterProvider = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(parameterProvider, "parameterProvider");
            this.set_ParameterProvider(parameterProvider);
        },
        ParameterProvider$$: "Neptuo.TemplateEngine.Providers.IParameterProvider",
        get_ParameterProvider: function (){
            return this._ParameterProvider;
        },
        set_ParameterProvider: function (value){
            this._ParameterProvider = value;
        },
        GetValue: function (identifier){
            Neptuo.Guard.NotNull$$Object$$String(identifier, "identifier");
            var value;
            if ((function (){
                var $1 = {
                    Value: value
                };
                var $res = this.get_ParameterProvider().TryGet(identifier, $1);
                value = $1.Value;
                return $res;
            }).call(this))
                return Cast(value, System.String.ctor);
            return null;
        },
        TryGetValue: function (identifier, targetValue){
            Neptuo.Guard.NotNull$$Object$$String(identifier, "identifier");
            var value;
            if ((function (){
                var $1 = {
                    Value: value
                };
                var $res = this.get_ParameterProvider().TryGet(identifier, $1);
                value = $1.Value;
                return $res;
            }).call(this)){
                targetValue.Value = Cast(value, System.String.ctor);
                return true;
            }
            targetValue.Value = null;
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.IParameterProvider"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ModelBinders$BindingValueStorage);
var Neptuo$TemplateEngine$Providers$ModelBinders$IModelBinder = {
    fullname: "Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ModelBinders$IModelBinder);
var Neptuo$TemplateEngine$Providers$ModelBinders$ModelBinder = {
    fullname: "Neptuo.TemplateEngine.Providers.ModelBinders.ModelBinder",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    interfaceNames: ["Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder"],
    Kind: "Class",
    definition: {
        ctor: function (parameterProvider, modelFactory, valueProviderFactory, bindingConverters, dependencyContainer){
            this._ParameterProvider = null;
            this._ModelFactory = null;
            this._ValueProviderFactory = null;
            this._BindingConverters = null;
            this._DependencyContainer = null;
            System.Object.ctor.call(this);
            this.set_ParameterProvider(parameterProvider);
            this.set_ModelFactory(modelFactory);
            this.set_ValueProviderFactory(valueProviderFactory);
            this.set_BindingConverters(bindingConverters);
            this.set_DependencyContainer(dependencyContainer);
        },
        ParameterProvider$$: "Neptuo.TemplateEngine.Providers.IParameterProvider",
        get_ParameterProvider: function (){
            return this._ParameterProvider;
        },
        set_ParameterProvider: function (value){
            this._ParameterProvider = value;
        },
        ModelFactory$$: "Neptuo.PresentationModels.TypeModels.IModelDefinitionFactory",
        get_ModelFactory: function (){
            return this._ModelFactory;
        },
        set_ModelFactory: function (value){
            this._ModelFactory = value;
        },
        ValueProviderFactory$$: "Neptuo.PresentationModels.TypeModels.IModelValueProviderFactory",
        get_ValueProviderFactory: function (){
            return this._ValueProviderFactory;
        },
        set_ValueProviderFactory: function (value){
            this._ValueProviderFactory = value;
        },
        BindingConverters$$: "Neptuo.PresentationModels.IBindingConverterCollection",
        get_BindingConverters: function (){
            return this._BindingConverters;
        },
        set_BindingConverters: function (value){
            this._BindingConverters = value;
        },
        DependencyContainer$$: "Neptuo.IDependencyContainer",
        get_DependencyContainer: function (){
            return this._DependencyContainer;
        },
        set_DependencyContainer: function (value){
            this._DependencyContainer = value;
        },
        Bind$$Type: function (targetType){
            if (System.Type.op_Equality$$Type$$Type(targetType, null))
                throw $CreateException(new System.ArgumentNullException.ctor$$String("targetType"), new Error());
            var instance = this.get_DependencyContainer().Resolve(targetType, null);
            return this.Bind$$Object(instance);
        },
        Bind$$Object: function (instance){
            if (instance == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("instance"), new Error());
            var modelDefinition = this.get_ModelFactory().Create(instance.GetType());
            var storage = new Neptuo.TemplateEngine.Providers.ModelBinders.BindingValueStorage.ctor(this.get_ParameterProvider());
            var copyProvider = new Neptuo.PresentationModels.CopyModelValueProvider.ctor(modelDefinition);
            var model = this.get_ValueProviderFactory().Create(instance);
            var getters = [new Neptuo.PresentationModels.BindingModelValueGetter.ctor(storage, this.get_BindingConverters(), modelDefinition)];
            copyProvider.Update(model, getters);
            return instance;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.IParameterProvider", "Neptuo.PresentationModels.TypeModels.IModelDefinitionFactory", "Neptuo.PresentationModels.TypeModels.IModelValueProviderFactory", "Neptuo.PresentationModels.IBindingConverterCollection", "Neptuo.IDependencyContainer"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ModelBinders$ModelBinder);
var Neptuo$TemplateEngine$Providers$ModelBinders$ModelBinderExtensions = {
    fullname: "Neptuo.TemplateEngine.Providers.ModelBinders.ModelBinderExtensions",
    baseTypeName: "System.Object",
    staticDefinition: {
        Bind$1$$IModelBinder: function (T, binder){
            return Cast(binder.Bind$$Type(Typeof(T)), T);
        },
        Bind$1$$IModelBinder$$T: function (T, binder, instance){
            return Cast(binder.Bind$$Object(instance), T);
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ModelBinders$ModelBinderExtensions);
var Neptuo$TemplateEngine$Web$DictionaryParameterProvider = {
    fullname: "Neptuo.TemplateEngine.Web.DictionaryParameterProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    interfaceNames: ["Neptuo.TemplateEngine.Providers.IParameterProvider"],
    Kind: "Class",
    definition: {
        ctor: function (parameters){
            this._Parameters = null;
            System.Object.ctor.call(this);
            this.set_Parameters(parameters);
        },
        Parameters$$: "System.Collections.Generic.Dictionary`2[[System.String],[System.String]]",
        get_Parameters: function (){
            return this._Parameters;
        },
        set_Parameters: function (value){
            this._Parameters = value;
        },
        Keys$$: "System.Collections.Generic.IEnumerable`1[[System.String]]",
        get_Keys: function (){
            return this.get_Parameters().get_Keys();
        },
        TryGet: function (key, value){
            var targetValue;
            if ((function (){
                var $1 = {
                    Value: targetValue
                };
                var $res = this.get_Parameters().TryGetValue(key, $1);
                targetValue = $1.Value;
                return $res;
            }).call(this)){
                value.Value = targetValue;
                return true;
            }
            value.Value = null;
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Collections.Generic.Dictionary"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Web$DictionaryParameterProvider);
var Neptuo$TemplateEngine$Providers$GlobalNavigationCollection = {
    fullname: "Neptuo.TemplateEngine.Providers.GlobalNavigationCollection",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (){
            this.storage = new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, Neptuo.TemplateEngine.Navigation.FormUri.ctor);
            System.Object.ctor.call(this);
        },
        Add: function (on, to){
            if (on == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("name"), new Error());
            if (to == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("to"), new Error());
            this.storage.set_Item$$TKey(on, to);
            return this;
        },
        TryGetValue: function (on, to){
            if (on == null){
                to.Value = null;
                return false;
            }
            return this.storage.TryGetValue(on, to);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$GlobalNavigationCollection);
var Neptuo$TemplateEngine$Providers$ICurrentUrlProvider = {
    fullname: "Neptuo.TemplateEngine.Providers.ICurrentUrlProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ICurrentUrlProvider);
var Neptuo$TemplateEngine$Providers$IParameterProvider = {
    fullname: "Neptuo.TemplateEngine.Providers.IParameterProvider",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$IParameterProvider);
var Neptuo$TemplateEngine$Providers$IParameterProviderFactory = {
    fullname: "Neptuo.TemplateEngine.Providers.IParameterProviderFactory",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$IParameterProviderFactory);
var Neptuo$TemplateEngine$Providers$IRequestContext = {
    fullname: "Neptuo.TemplateEngine.Providers.IRequestContext",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    interfaceNames: ["Neptuo.TemplateEngine.Providers.ICurrentUrlProvider", "Neptuo.Templates.IVirtualUrlProvider", "Neptuo.TemplateEngine.Providers.IParameterProviderFactory"],
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$IRequestContext);
var Neptuo$TemplateEngine$Providers$ITemplateUrlFormatter = {
    fullname: "Neptuo.TemplateEngine.Providers.ITemplateUrlFormatter",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ITemplateUrlFormatter);
var Neptuo$TemplateEngine$Providers$JsonResponse = {
    fullname: "Neptuo.TemplateEngine.Providers.JsonResponse",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (response){
            this._Response = null;
            this._ContentType = null;
            System.Object.ctor.call(this);
            this.set_Response(response);
            this.set_ContentType("application/json");
        },
        Response$$: "System.String",
        get_Response: function (){
            return this._Response;
        },
        set_Response: function (value){
            this._Response = value;
        },
        ContentType$$: "System.String",
        get_ContentType: function (){
            return this._ContentType;
        },
        set_ContentType: function (value){
            this._ContentType = value;
        },
        ReponseLength$$: "System.Int32",
        get_ReponseLength: function (){
            return this.get_Response().get_Length();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$JsonResponse);
var Neptuo$TemplateEngine$Providers$Message = {
    fullname: "Neptuo.TemplateEngine.Providers.Message",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (key, text, type){
            this._Key = null;
            this._Type = Neptuo.TemplateEngine.Providers.MessageType.Error;
            this._Text = null;
            System.Object.ctor.call(this);
            if (text == null)
                throw $CreateException(new System.ArgumentNullException.ctor$$String("text"), new Error());
            this.set_Key(key);
            this.set_Text(text);
            this.set_Type(type);
        },
        Key$$: "System.String",
        get_Key: function (){
            return this._Key;
        },
        set_Key: function (value){
            this._Key = value;
        },
        Type$$: "Neptuo.TemplateEngine.Providers.MessageType",
        get_Type: function (){
            return this._Type;
        },
        set_Type: function (value){
            this._Type = value;
        },
        Text$$: "System.String",
        get_Text: function (){
            return this._Text;
        },
        set_Text: function (value){
            this._Text = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "System.String", "Neptuo.TemplateEngine.Providers.MessageType"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$Message);
var Neptuo$TemplateEngine$Providers$MessageType = {
    fullname: "Neptuo.TemplateEngine.Providers.MessageType",
    staticDefinition: {
        Error: 0,
        Info: 1,
        Warn: 2
    },
    Kind: "Enum",
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$MessageType);
var Neptuo$TemplateEngine$Providers$MessageStorage = {
    fullname: "Neptuo.TemplateEngine.Providers.MessageStorage",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (){
            this.storage = new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, System.Collections.Generic.List$1.ctor);
            System.Object.ctor.call(this);
        },
        Add: function (group, key, text, type){
            if (group == null)
                group = System.String.Empty;
            var list;
            if (!(function (){
                var $1 = {
                    Value: list
                };
                var $res = this.storage.TryGetValue(group, $1);
                list = $1.Value;
                return $res;
            }).call(this)){
                list = new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Providers.Message.ctor);
                this.storage.Add(group, list);
            }
            list.Add(new Neptuo.TemplateEngine.Providers.Message.ctor(key, text, type));
        },
        GetList: function (key){
            if (key == null)
                key = System.String.Empty;
            var list;
            if (!(function (){
                var $1 = {
                    Value: list
                };
                var $res = this.storage.TryGetValue(key, $1);
                list = $1.Value;
                return $res;
            }).call(this))
                return new System.Collections.Generic.List$1.ctor(Neptuo.TemplateEngine.Providers.Message.ctor);
            return list;
        },
        GetStorage: function (){
            return this.storage;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$MessageStorage);
var Neptuo$TemplateEngine$Providers$MessageStorageExtensions = {
    fullname: "Neptuo.TemplateEngine.Providers.MessageStorageExtensions",
    baseTypeName: "System.Object",
    staticDefinition: {
        AddValidationResult: function (messageStorage, validationResult, group, addFillAll){
            if (!validationResult.get_IsValid()){
                if (addFillAll)
                    messageStorage.Add(group, System.String.Empty, "Please fill all required values correctly.", Neptuo.TemplateEngine.Providers.MessageType.Error);
                var $it1 = validationResult.get_Messages().GetEnumerator();
                while ($it1.MoveNext()){
                    var message = $it1.get_Current();
                    messageStorage.Add(group, message.get_Key(), message.get_Message(), Neptuo.TemplateEngine.Providers.MessageType.Error);
                }
            }
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$MessageStorageExtensions);
var Neptuo$TemplateEngine$Providers$ParameterProviderExtensions = {
    fullname: "Neptuo.TemplateEngine.Providers.ParameterProviderExtensions",
    baseTypeName: "System.Object",
    staticDefinition: {
        GetAllParameters: function (provider){
            var result = new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, System.Object.ctor);
            var value;
            var $it2 = provider.get_Keys().GetEnumerator();
            while ($it2.MoveNext()){
                var key = $it2.get_Current();
                if ((function (){
                    var $1 = {
                        Value: value
                    };
                    var $res = provider.TryGet(key, $1);
                    value = $1.Value;
                    return $res;
                })())
                    result.set_Item$$TKey(key, value);
            }
            return result;
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ParameterProviderExtensions);
var Neptuo$TemplateEngine$Providers$ParameterProviderType = {
    fullname: "Neptuo.TemplateEngine.Providers.ParameterProviderType",
    staticDefinition: {
        All: 0,
        Url: 1,
        Form: 2
    },
    Kind: "Enum",
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$ParameterProviderType);
var Neptuo$TemplateEngine$Providers$PartialResponse = {
    fullname: "Neptuo.TemplateEngine.Providers.PartialResponse",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Providers",
    Kind: "Class",
    definition: {
        ctor: function (messages, navigation){
            this._Messages = null;
            this._Navigation = null;
            System.Object.ctor.call(this);
            this.set_Messages(messages);
            this.set_Navigation(navigation);
        },
        Messages$$: "Neptuo.TemplateEngine.Providers.MessageStorage",
        get_Messages: function (){
            return this._Messages;
        },
        set_Messages: function (value){
            this._Messages = value;
        },
        Navigation$$: "System.String",
        get_Navigation: function (){
            return this._Navigation;
        },
        set_Navigation: function (value){
            this._Navigation = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.TemplateEngine.Providers.MessageStorage", "System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Providers$PartialResponse);


