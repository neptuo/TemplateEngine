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
var Neptuo$PresentationModels$BindingConverters$BindingConverterBase$1 = {
    fullname: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    interfaceNames: ["Neptuo.PresentationModels.IBindingConverter"],
    Kind: "Class",
    definition: {
        ctor: function (T){
            this.T = T;
            System.Object.ctor.call(this);
        },
        TryConvert: function (sourceValue, targetField, targetValue){
            var target;
            if ((function (){
                var $1 = {
                    Value: target
                };
                var $res = this.TryConvertTo(sourceValue, targetField, $1);
                target = $1.Value;
                return $res;
            }).call(this)){
                targetValue.Value = target;
                return true;
            }
            targetValue.Value = Default(this.T);
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: true
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$BindingConverterBase$1);
var Neptuo$PresentationModels$BindingConverters$BindingConverterCollectionExtensions = {
    fullname: "Neptuo.PresentationModels.BindingConverters.BindingConverterCollectionExtensions",
    baseTypeName: "System.Object",
    staticDefinition: {
        AddStandart: function (bindingConverters){
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Boolean.ctor)), new Neptuo.PresentationModels.BindingConverters.BoolBindingConverter.ctor());
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Int32.ctor)), new Neptuo.PresentationModels.BindingConverters.IntBindingConverter.ctor());
            //bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Double.ctor)), new Neptuo.PresentationModels.BindingConverters.DoubleBindingConverter.ctor());
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.String.ctor)), new Neptuo.PresentationModels.BindingConverters.StringBindingConverter.ctor(false, true, true));
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Nullable$1.ctor).MakeGenericType(Typeof(System.Boolean.ctor))), new Neptuo.PresentationModels.BindingConverters.NullBindingConverter$1.ctor(System.Boolean.ctor, new Neptuo.PresentationModels.BindingConverters.BoolBindingConverter.ctor()));
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Nullable$1.ctor).MakeGenericType(Typeof(System.Int32.ctor))), new Neptuo.PresentationModels.BindingConverters.NullBindingConverter$1.ctor(System.Int32.ctor, new Neptuo.PresentationModels.BindingConverters.IntBindingConverter.ctor()));
            //bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Nullable$1.ctor)), new Neptuo.PresentationModels.BindingConverters.NullBindingConverter$1.ctor(System.Double.ctor, new Neptuo.PresentationModels.BindingConverters.DoubleBindingConverter.ctor()));
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Collections.Generic.IEnumerable$1.ctor).MakeGenericType(Typeof(System.Boolean.ctor))), new Neptuo.PresentationModels.BindingConverters.ListBindingConverter$1.ctor(System.Boolean.ctor, ",", new Neptuo.PresentationModels.BindingConverters.BoolBindingConverter.ctor()));
            bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Collections.Generic.IEnumerable$1.ctor).MakeGenericType(Typeof(System.Int32.ctor))), new Neptuo.PresentationModels.BindingConverters.ListBindingConverter$1.ctor(System.Int32.ctor, ",", new Neptuo.PresentationModels.BindingConverters.IntBindingConverter.ctor()));
            //bindingConverters.Add(new Neptuo.PresentationModels.TypeFieldType.ctor(Typeof(System.Collections.Generic.IEnumerable$1.ctor)), new Neptuo.PresentationModels.BindingConverters.ListBindingConverter$1.ctor(System.Double.ctor, ",", new Neptuo.PresentationModels.BindingConverters.DoubleBindingConverter.ctor()));
            return bindingConverters;
        }
    },
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (){
            System.Object.ctor.call(this);
        }
    },
    ctors: [],
    IsAbstract: true
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$BindingConverterCollectionExtensions);
var Neptuo$PresentationModels$BindingConverters$BoolBindingConverter = {
    fullname: "Neptuo.PresentationModels.BindingConverters.BoolBindingConverter",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1.ctor.call(this, System.Boolean.ctor);
        },
        TryConvertTo: function (sourceValue, targetField, targetValue){
            if (sourceValue == null){
                targetValue.Value = false;
                return false;
            }
            var result;
            if ((function (){
                var $1 = {
                    Value: result
                };
                var $res = System.Boolean.TryParse(sourceValue, $1);
                result = $1.Value;
                return $res;
            }).call(this)){
                targetValue.Value = result;
                return true;
            }
            if (sourceValue.ToLowerInvariant() == "on"){
                targetValue.Value = true;
                return true;
            }
            targetValue.Value = false;
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
JsTypes.push(Neptuo$PresentationModels$BindingConverters$BoolBindingConverter);
var Neptuo$PresentationModels$BindingConverters$DoubleBindingConverter = {
    fullname: "Neptuo.PresentationModels.BindingConverters.DoubleBindingConverter",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.FuncBindingConverter$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.PresentationModels.BindingConverters.FuncBindingConverter$1.ctor.call(this, System.Double.ctor, System.Double.TryParse$$String$$Double);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$DoubleBindingConverter);
var Neptuo$PresentationModels$BindingConverters$FuncBindingConverter$1 = {
    fullname: "Neptuo.PresentationModels.BindingConverters.FuncBindingConverter$1",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (T, converter){
            this.T = T;
            this._Converter = null;
            Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1.ctor.call(this, this.T);
            if (System.MulticastDelegate.op_Equality$$MulticastDelegate$$MulticastDelegate(converter, null))
                throw $CreateException(new System.ArgumentNullException.ctor$$String("converter"), new Error());
            this.set_Converter(converter);
        },
        Converter$$: "Neptuo.OutFunc`3[[System.String],[`0],[System.Boolean]]",
        get_Converter: function (){
            return this._Converter;
        },
        set_Converter: function (value){
            this._Converter = value;
        },
        TryConvertTo: function (sourceValue, targetField, targetValue){
            return this.get_Converter()(sourceValue, targetValue);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.OutFunc"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$FuncBindingConverter$1);
var Neptuo$PresentationModels$BindingConverters$IntBindingConverter = {
    fullname: "Neptuo.PresentationModels.BindingConverters.IntBindingConverter",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.FuncBindingConverter$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (){
            Neptuo.PresentationModels.BindingConverters.FuncBindingConverter$1.ctor.call(this, System.Int32.ctor, System.Int32.TryParse$$String$$Int32);
        }
    },
    ctors: [{
        name: "ctor",
        parameters: []
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$IntBindingConverter);
var Neptuo$PresentationModels$BindingConverters$ListBindingConverter$1 = {
    fullname: "Neptuo.PresentationModels.BindingConverters.ListBindingConverter$1",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (T, separator, converter){
            this.T = T;
            this._Separator = null;
            this._Converter = null;
            Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1.ctor.call(this, System.Collections.Generic.IEnumerable$1.ctor);
            Neptuo.Guard.NotNullOrEmpty(separator, "separator");
            Neptuo.Guard.NotNull$$Object$$String(converter, "converter");
            this.set_Separator(separator);
            this.set_Converter(converter);
        },
        Separator$$: "System.String",
        get_Separator: function (){
            return this._Separator;
        },
        set_Separator: function (value){
            this._Separator = value;
        },
        Converter$$: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase`1[[`0]]",
        get_Converter: function (){
            return this._Converter;
        },
        set_Converter: function (value){
            this._Converter = value;
        },
        TryConvertTo: function (sourceValue, targetField, targetValue){
            if (System.String.IsNullOrEmpty(sourceValue)){
                targetValue.Value = null;
                return true;
            }
            var parts = sourceValue.split(this.get_Separator());
            var result = new System.Collections.Generic.List$1.ctor(this.T);
            var $it1 = parts.GetEnumerator();
            while ($it1.MoveNext()){
                var part = $it1.get_Current();
                var notNullValue;
                if ((function (){
                    var $1 = {
                        Value: notNullValue
                    };
                    var $res = this.get_Converter().TryConvertTo(part, targetField, $1);
                    notNullValue = $1.Value;
                    return $res;
                }).call(this))
                    result.Add(notNullValue);
            }
            targetValue.Value = result;
            return true;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.String", "Neptuo.PresentationModels.BindingConverters.BindingConverterBase"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$ListBindingConverter$1);
var Neptuo$PresentationModels$BindingConverters$NullBindingConverter$1 = {
    fullname: "Neptuo.PresentationModels.BindingConverters.NullBindingConverter$1",
    baseTypeName: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    Kind: "Class",
    definition: {
        ctor: function (T, converter){
            this.T = T;
            this._Converter = null;
            Neptuo.PresentationModels.BindingConverters.BindingConverterBase$1.ctor.call(this, System.Nullable$1.ctor);
            Neptuo.Guard.NotNull$$Object$$String(converter, "converter");
            this.set_Converter(converter);
        },
        Converter$$: "Neptuo.PresentationModels.BindingConverters.BindingConverterBase`1[[`0]]",
        get_Converter: function (){
            return this._Converter;
        },
        set_Converter: function (value){
            this._Converter = value;
        },
        TryConvertTo: function (sourceValue, targetField, targetValue){
            if (System.String.IsNullOrEmpty(sourceValue)){
                targetValue.Value = null;
                return true;
            }
            var notNullValue;
            if ((function (){
                var $1 = {
                    Value: notNullValue
                };
                var $res = this.get_Converter().TryConvertTo(sourceValue, targetField, $1);
                notNullValue = $1.Value;
                return $res;
            }).call(this)){
                targetValue.Value = notNullValue;
                return true;
            }
            targetValue.Value = null;
            return false;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["Neptuo.PresentationModels.BindingConverters.BindingConverterBase"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$NullBindingConverter$1);
var Neptuo$PresentationModels$BindingConverters$StringBindingConverter = {
    fullname: "Neptuo.PresentationModels.BindingConverters.StringBindingConverter",
    baseTypeName: "System.Object",
    assemblyName: "Neptuo.PresentationModels.BindingConverters",
    interfaceNames: ["Neptuo.PresentationModels.IBindingConverter"],
    Kind: "Class",
    definition: {
        ctor: function (allowConvertNull, allowConvertEmpty, allowConvertWhitespace){
            this._AllowConvertNull = false;
            this._AllowConvertEmpty = false;
            this._AllowConvertWhitespace = false;
            System.Object.ctor.call(this);
            this.set_AllowConvertNull(allowConvertNull);
            this.set_AllowConvertEmpty(allowConvertEmpty);
            this.set_AllowConvertWhitespace(allowConvertWhitespace);
        },
        AllowConvertNull$$: "System.Boolean",
        get_AllowConvertNull: function (){
            return this._AllowConvertNull;
        },
        set_AllowConvertNull: function (value){
            this._AllowConvertNull = value;
        },
        AllowConvertEmpty$$: "System.Boolean",
        get_AllowConvertEmpty: function (){
            return this._AllowConvertEmpty;
        },
        set_AllowConvertEmpty: function (value){
            this._AllowConvertEmpty = value;
        },
        AllowConvertWhitespace$$: "System.Boolean",
        get_AllowConvertWhitespace: function (){
            return this._AllowConvertWhitespace;
        },
        set_AllowConvertWhitespace: function (value){
            this._AllowConvertWhitespace = value;
        },
        TryConvert: function (sourceValue, targetField, targetValue){
            if (!this.get_AllowConvertNull() && sourceValue == null){
                targetValue.Value = null;
                return false;
            }
            if (!this.get_AllowConvertEmpty() && System.String.IsNullOrEmpty(sourceValue)){
                targetValue.Value = null;
                return false;
            }
            if (!this.get_AllowConvertWhitespace() && System.String.IsNullOrWhiteSpace(sourceValue)){
                targetValue.Value = null;
                return false;
            }
            targetValue.Value = sourceValue;
            return true;
        }
    },
    ctors: [{
        name: "ctor",
        parameters: ["System.Boolean", "System.Boolean", "System.Boolean"]
    }
    ],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$BindingConverters$StringBindingConverter);

