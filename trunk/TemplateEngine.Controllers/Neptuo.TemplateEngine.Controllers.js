/* Generated by SharpKit 5 v5.3.6 */

if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$TemplateEngine$Controllers$ActionAttribute = {
    fullname: "Neptuo.TemplateEngine.Controllers.ActionAttribute",
    baseTypeName: "System.Attribute",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Class",
    definition: {
        ctor: function (actionName){
            this._ActionName = null;
            System.Attribute.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(actionName, "actionName");
            this.set_ActionName(actionName);
        },
        ActionName$$: "System.String",
        get_ActionName: function (){
            return this._ActionName;
        },
        set_ActionName: function (value){
            this._ActionName = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$ActionAttribute);
var Neptuo$TemplateEngine$Controllers$ControllerBase = {
    fullname: "Neptuo.TemplateEngine.Controllers.ControllerBase",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    interfaceNames: ["Neptuo.TemplateEngine.Controllers.IController"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Context = null;
            System.Object.ctor.call(this);
        },
        Context$$: "Neptuo.TemplateEngine.Controllers.IControllerContext",
        get_Context: function (){
            return this._Context;
        },
        set_Context: function (value){
            this._Context = value;
        },
        Messages$$: "Neptuo.TemplateEngine.Providers.MessageStorage",
        get_Messages: function (){
            return this.get_Context().get_Messages();
        },
        Execute: function (context){
            Neptuo.Guard.NotNull$$Object$$String(context, "context");
            this.set_Context(context);
            var type = this.GetType();
            var $it1 = type.GetMethods().GetEnumerator();
            while ($it1.MoveNext()){
                var methodInfo = $it1.get_Current();
                var action = Neptuo.Reflection.ReflectionHelper.GetAttribute$1(Neptuo.TemplateEngine.Controllers.ActionAttribute.ctor, methodInfo);
                if (action != null){
                    if (action.get_ActionName() == context.get_ActionName()){
                        var parameters = this.BindActionParameters(context, methodInfo);
                        if (this.TryValidate(methodInfo, parameters)){
                            var transaction = this.TryTransaction(methodInfo);
                            var result = this.ExecuteAction(context, methodInfo, parameters);
                            transaction.Dispose(result != null);
                            this.ProcessActionResult(context, methodInfo, result);
                        }
                        break;
                    }
                }
            }
        },
        BindActionParameters: function (context, methodInfo){
            var parameters = methodInfo.GetParameters();
            if (parameters.get_Length() == 0)
                return null;
            var values = new System.Collections.Generic.List$1.ctor(System.Object.ctor);
            var $it2 = parameters.GetEnumerator();
            while ($it2.MoveNext()){
                var parameter = $it2.get_Current();
                var value = context.get_ModelBinder().Bind$$Type(parameter.get_ParameterType());
                values.Add(value);
            }
            return values.ToArray();
        },
        ExecuteAction: function (context, methodInfo, parameters){
            return methodInfo.Invoke$$Object$$Object$Array(this, parameters);
        },
        ProcessActionResult: function (context, methodInfo, result){
            var stringResult = As(result, System.String.ctor);
            if (stringResult != null)
                context.set_Navigation(stringResult);
        },
        TryValidate: function (methodInfo, parameters){
            var result = true;
            var validate = Neptuo.Reflection.ReflectionHelper.GetAttribute$1(Neptuo.TemplateEngine.Controllers.ValidateAttribute.ctor, methodInfo);
            if (validate != null){
                var validatorService = Neptuo.DependencyProviderExtensions.Resolve$1$$IDependencyProvider(Neptuo.Validation.IValidatorService.ctor, this.get_Context().get_DependencyProvider());
                var $it3 = parameters.GetEnumerator();
                while ($it3.MoveNext()){
                    var parameter = $it3.get_Current();
                    var validationResult = validatorService.Validate$$Object(parameter);
                    if (!validationResult.get_IsValid()){
                        Neptuo.TemplateEngine.Providers.MessageStorageExtensions.AddValidationResult(this.get_Messages(), validationResult, validate.get_MessageKey(), true);
                        result = false;
                    }
                }
            }
            return result;
        },
        TryTransaction: function (methodInfo){
            var transaction = null;
            var transactional = Neptuo.Reflection.ReflectionHelper.GetAttribute$1(Neptuo.TemplateEngine.Controllers.TransactionalAttribute.ctor, methodInfo);
            if (transactional != null)
                transaction = Neptuo.DependencyProviderExtensions.Resolve$1$$IDependencyProvider(Neptuo.Data.IUnitOfWorkFactory.ctor, this.get_Context().get_DependencyProvider()).Create();
            return new Neptuo.TemplateEngine.Controllers.TransactionalDisposable.ctor(transaction);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$ControllerBase);
var Neptuo$TemplateEngine$Controllers$ControllerContext = {
    fullname: "Neptuo.TemplateEngine.Controllers.ControllerContext",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    interfaceNames: ["Neptuo.TemplateEngine.Controllers.IControllerContext"],
    Kind: "Class",
    definition: {
        ctor: function (action, modelBinder, dependencyProvider, messages){
            this._ActionName = null;
            this._ModelBinder = null;
            this._DependencyProvider = null;
            this._Navigation = null;
            this._Messages = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(action, "action");
            Neptuo.Guard.NotNull$$Object$$String(modelBinder, "modelBinder");
            Neptuo.Guard.NotNull$$Object$$String(dependencyProvider, "dependencyProvider");
            Neptuo.Guard.NotNull$$Object$$String(messages, "messages");
            this.set_ActionName(action);
            this.set_ModelBinder(modelBinder);
            this.set_DependencyProvider(dependencyProvider);
            this.set_Messages(messages);
        },
        ActionName$$: "System.String",
        get_ActionName: function (){
            return this._ActionName;
        },
        set_ActionName: function (value){
            this._ActionName = value;
        },
        ModelBinder$$: "Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder",
        get_ModelBinder: function (){
            return this._ModelBinder;
        },
        set_ModelBinder: function (value){
            this._ModelBinder = value;
        },
        DependencyProvider$$: "Neptuo.IDependencyProvider",
        get_DependencyProvider: function (){
            return this._DependencyProvider;
        },
        set_DependencyProvider: function (value){
            this._DependencyProvider = value;
        },
        Navigation$$: "System.String",
        get_Navigation: function (){
            return this._Navigation;
        },
        set_Navigation: function (value){
            this._Navigation = value;
        },
        Messages$$: "Neptuo.TemplateEngine.Providers.MessageStorage",
        get_Messages: function (){
            return this._Messages;
        },
        set_Messages: function (value){
            this._Messages = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "Neptuo.TemplateEngine.Providers.ModelBinders.IModelBinder", "Neptuo.IDependencyProvider", "Neptuo.TemplateEngine.Providers.MessageStorage"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$ControllerContext);
var Neptuo$TemplateEngine$Controllers$ControllerRegistryBase = {
    fullname: "Neptuo.TemplateEngine.Controllers.ControllerRegistryBase",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    interfaceNames: ["Neptuo.TemplateEngine.Controllers.IControllerRegistry"],
    Kind: "Class",
    definition: {
        ctor: function (){
            this._Storage = null;
            System.Object.ctor.call(this);
            this.set_Storage(new System.Collections.Generic.Dictionary$2.ctor(System.String.ctor, Neptuo.TemplateEngine.Controllers.IControllerFactory.ctor));
        },
        Storage$$: "System.Collections.Generic.Dictionary`2[[System.String],[Neptuo.TemplateEngine.Controllers.IControllerFactory]]",
        get_Storage: function (){
            return this._Storage;
        },
        set_Storage: function (value){
            this._Storage = value;
        },
        Add: function (actionName, factory){
            Neptuo.Guard.NotNull$$Object$$String(actionName, "actionName");
            Neptuo.Guard.NotNull$$Object$$String(factory, "factory");
            this.get_Storage().set_Item$$TKey(actionName, factory);
            return this;
        },
        TryGet: function (actionName, controller){
            Neptuo.Guard.NotNull$$Object$$String(actionName, "actionName");
            var factory;
            if ((function (){
                var $1 = {
                    Value: factory
                };
                var $res = this.get_Storage().TryGetValue(actionName, $1);
                factory = $1.Value;
                return $res;
            }).call(this)){
                controller.Value = factory.Create();
                return true;
            }
            controller.Value = null;
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
JsTypes.push(Neptuo$TemplateEngine$Controllers$ControllerRegistryBase);
var Neptuo$TemplateEngine$Controllers$ControllerRegistryExtensions = {
    fullname: "Neptuo.TemplateEngine.Controllers.ControllerRegistryExtensions",
    baseTypeName: "System.Object",
    staticDefinition: {
        Add$$IControllerRegistry$$IDependencyContainer$$Type: function (controllerRegistry, dependencyContainer, controllerType){
            var $it4 = controllerType.GetMethods().GetEnumerator();
            while ($it4.MoveNext()){
                var methodInfo = $it4.get_Current();
                var action = Neptuo.Reflection.ReflectionHelper.GetAttribute$1(Neptuo.TemplateEngine.Controllers.ActionAttribute.ctor, methodInfo);
                if (action != null)
                    Neptuo.TemplateEngine.Controllers.ControllerRegistryExtensions.Add$$IControllerRegistry$$String$$IDependencyContainer$$Type(controllerRegistry, action.get_ActionName(), dependencyContainer, controllerType);
            }
            return controllerRegistry;
        },
        Add$$IControllerRegistry$$String$$IDependencyContainer$$Type: function (controllerRegistry, actionName, dependencyContainer, controllerType){
            return controllerRegistry.Add(actionName, new Neptuo.TemplateEngine.Controllers.DependencyControllerFactory.ctor(dependencyContainer, controllerType));
        }
    },
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$ControllerRegistryExtensions);
var Neptuo$TemplateEngine$Controllers$DependencyControllerFactory = {
    fullname: "Neptuo.TemplateEngine.Controllers.DependencyControllerFactory",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    interfaceNames: ["Neptuo.TemplateEngine.Controllers.IControllerFactory"],
    Kind: "Class",
    definition: {
        ctor: function (dependencyProvider, handlerType){
            this._DependencyProvider = null;
            this._HandlerType = null;
            System.Object.ctor.call(this);
            Neptuo.Guard.NotNull$$Object$$String(dependencyProvider, "dependencyContainer");
            Neptuo.Guard.NotNull$$Object$$String(handlerType, "handlerType");
            this.set_DependencyProvider(dependencyProvider);
            this.set_HandlerType(handlerType);
        },
        DependencyProvider$$: "Neptuo.IDependencyProvider",
        get_DependencyProvider: function (){
            return this._DependencyProvider;
        },
        set_DependencyProvider: function (value){
            this._DependencyProvider = value;
        },
        HandlerType$$: "System.Type",
        get_HandlerType: function (){
            return this._HandlerType;
        },
        set_HandlerType: function (value){
            this._HandlerType = value;
        },
        Create: function (){
            return Cast(this.get_DependencyProvider().Resolve(this.get_HandlerType(), null), Neptuo.TemplateEngine.Controllers.IController.ctor);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.IDependencyProvider", "System.Type"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$DependencyControllerFactory);
var Neptuo$TemplateEngine$Controllers$IController = {
    fullname: "Neptuo.TemplateEngine.Controllers.IController",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$IController);
var Neptuo$TemplateEngine$Controllers$IControllerContext = {
    fullname: "Neptuo.TemplateEngine.Controllers.IControllerContext",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$IControllerContext);
var Neptuo$TemplateEngine$Controllers$IControllerFactory = {
    fullname: "Neptuo.TemplateEngine.Controllers.IControllerFactory",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$IControllerFactory);
var Neptuo$TemplateEngine$Controllers$IControllerRegistry = {
    fullname: "Neptuo.TemplateEngine.Controllers.IControllerRegistry",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Interface",
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$IControllerRegistry);
var Neptuo$TemplateEngine$Controllers$TransactionalAttribute = {
    fullname: "Neptuo.TemplateEngine.Controllers.TransactionalAttribute",
    baseTypeName: "System.Attribute",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Attribute.ctor.call(this);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$TransactionalAttribute);
var Neptuo$TemplateEngine$Controllers$TransactionalDisposable = {
    fullname: "Neptuo.TemplateEngine.Controllers.TransactionalDisposable",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Class",
    definition: {
        ctor: function (transaction){
            this.transaction = null;
            System.Object.ctor.call(this);
            this.transaction = transaction;
        },
        Dispose: function (saveChanges){
            if (this.transaction != null && saveChanges)
                this.transaction.SaveChanges();
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.Data.IUnitOfWork"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$TransactionalDisposable);
var Neptuo$TemplateEngine$Controllers$ValidateAttribute = {
    fullname: "Neptuo.TemplateEngine.Controllers.ValidateAttribute",
    baseTypeName: "System.Attribute",
    assemblyName: "Neptuo.TemplateEngine.Controllers",
    Kind: "Class",
    definition: {
        ctor: function (messageKey){
            this._MessageKey = null;
            System.Attribute.ctor.call(this);
            this.set_MessageKey(messageKey);
        },
        MessageKey$$: "System.String",
        get_MessageKey: function (){
            return this._MessageKey;
        },
        set_MessageKey: function (value){
            this._MessageKey = value;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$TemplateEngine$Controllers$ValidateAttribute);
