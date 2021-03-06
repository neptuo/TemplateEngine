﻿using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Converts JSON object to <see cref="PartialResponse"/>
    /// </summary>
    public class PartialResponseConverter : ConverterBase<JsObject, PartialResponse>
    {
        public override bool TryConvert(JsObject sourceValue, out PartialResponse targetValue)
        {
            if (sourceValue == null)
            {
                targetValue = null;
                return false;
            }

            MessageStorage messageStorage = new MessageStorage();
            if (sourceValue["Messages"] != null)
            {
                JsObject messages = sourceValue["Messages"].As<JsObject>();
                foreach (string key in messages)
                {
                    JsArray messageList = messages[key].As<JsArray>();
                    for (int i = 0; i < messageList.length; i++)
                    {
                        JsObject message = messageList[i].As<JsObject>();
                        messageStorage.Add(key, message["Key"].As<string>(), message["Text"].As<string>(), message["Type"].As<MessageType>());
                    }
                }
            }

            targetValue = new PartialResponse(messageStorage, sourceValue["Navigation"].As<string>());
            return true;
        }
    }
}
