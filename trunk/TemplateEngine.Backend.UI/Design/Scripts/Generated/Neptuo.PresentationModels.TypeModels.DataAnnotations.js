/* Generated by SharpKit 5 v5.3.4 */
if (typeof(JsTypes) == "undefined")
    var JsTypes = [];
var Neptuo$PresentationModels$TypeModels$DataAnnotations$DescriptionMetadataReader =
{
    fullname: "Neptuo.PresentationModels.TypeModels.DataAnnotations.DescriptionMetadataReader",
    baseTypeName: "Neptuo.PresentationModels.TypeModels.MetadataReaderBase$1",
    assemblyName: "Neptuo.PresentationModels.TypeModels.DataAnnotations",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            Neptuo.PresentationModels.TypeModels.MetadataReaderBase$1.ctor.call(this, System.ComponentModel.DescriptionAttribute.ctor);
        },
        ApplyInternal: function (attribute, builder)
        {
            builder.Set("Description", attribute.get_Description());
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$TypeModels$DataAnnotations$DescriptionMetadataReader);
var Neptuo$PresentationModels$TypeModels$DataAnnotations$RequiredMetadataReader =
{
    fullname: "Neptuo.PresentationModels.TypeModels.DataAnnotations.RequiredMetadataReader",
    baseTypeName: "Neptuo.PresentationModels.TypeModels.MetadataReaderBase$1",
    assemblyName: "Neptuo.PresentationModels.TypeModels.DataAnnotations",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            Neptuo.PresentationModels.TypeModels.MetadataReaderBase$1.ctor.call(this, System.ComponentModel.DataAnnotations.RequiredAttribute.ctor);
        },
        ApplyInternal: function (attribute, builder)
        {
            builder.Set("Required", true);
            builder.Set("Required.AllowEmptyStrings", attribute.get_AllowEmptyStrings());
            builder.Set("Required.ErrorMessage", attribute.get_ErrorMessage());
            builder.Set("Required.Attribute", attribute);
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$TypeModels$DataAnnotations$RequiredMetadataReader);
var Neptuo$PresentationModels$TypeModels$DataAnnotations$Validators$RequiredMetadataValidator =
{
    fullname: "Neptuo.PresentationModels.TypeModels.DataAnnotations.Validators.RequiredMetadataValidator",
    baseTypeName: "Neptuo.PresentationModels.Validation.FieldMetadataValidatorBase$2",
    assemblyName: "Neptuo.PresentationModels.TypeModels.DataAnnotations",
    Kind: "Class",
    definition:
    {
        ctor: function ()
        {
            Neptuo.PresentationModels.Validation.FieldMetadataValidatorBase$2.ctor.call(this, System.Boolean.ctor, System.Object.ctor, "Required");
        },
        Validate$$Object$$Boolean$$FieldMetadataValidatorContext: function (fieldValue, metadataValue, context)
        {
            if (fieldValue == null)
            {
                context.get_ResultBuilder().AddMessage(new Neptuo.Validation.TextValidationMessage.ctor(context.get_FieldDefinition().get_Identifier(), Neptuo.PresentationModels.MetadataCollectionExtensions.GetOrDefault$1$$IFieldMetadataCollection$$String$$T(System.String.ctor, context.get_FieldDefinition().get_Metadata(), "Required.ErrorMessage", System.String.Format$$String$$Object("Missing value for required field \'{0}\'!", context.get_FieldDefinition().get_Identifier()))));
                return false;
            }
            var targetValue = fieldValue.ToString();
            if (!Neptuo.PresentationModels.MetadataCollectionExtensions.GetOrDefault$1$$IFieldMetadataCollection$$String$$T(System.Boolean.ctor, context.get_FieldDefinition().get_Metadata(), "Required.AllowEmptyStrings", false) && System.String.IsNullOrEmpty(targetValue))
            {
                context.get_ResultBuilder().AddMessage(new Neptuo.Validation.TextValidationMessage.ctor(context.get_FieldDefinition().get_Identifier(), Neptuo.PresentationModels.MetadataCollectionExtensions.GetOrDefault$1$$IFieldMetadataCollection$$String$$T(System.String.ctor, context.get_FieldDefinition().get_Metadata(), "Required.ErrorMessage", System.String.Format$$String$$Object("Missing value for required field \'{0}\'!", context.get_FieldDefinition().get_Identifier()))));
                return false;
            }
            return true;
        },
        MissingMetadataKey: function (fieldDefinition, getter, resultBuilder)
        {
            return true;
        }
    },
    ctors: [ {name: "ctor", parameters: []}],
    IsAbstract: false
};
JsTypes.push(Neptuo$PresentationModels$TypeModels$DataAnnotations$Validators$RequiredMetadataValidator);
