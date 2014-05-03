using Neptuo.Data;
using Neptuo.Reflection;
using Neptuo.TemplateEngine.Providers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class ControllerBase : IController
    {
        protected IControllerContext Context { get; private set; }

        protected MessageStorage Messages
        {
            get { return Context.Messages; }
        }

        public void Execute(IControllerContext context)
        {
            Guard.NotNull(context, "context");
            Context = context;

            Type type = GetType();
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                ActionAttribute action = ReflectionHelper.GetAttribute<ActionAttribute>(methodInfo);
                if (action != null)
                {
                    if (action.ActionName == context.ActionName)
                    {
                        object[] parameters = BindActionParameters(context, methodInfo);
                        if (TryValidate(methodInfo, parameters))
                        {
                            TransactionalDisposable transaction = TryTransaction(methodInfo);
                            object result = ExecuteAction(context, methodInfo, parameters);
                            transaction.Dispose(result != null);

                            ProcessActionResult(context, methodInfo, result);
                        }
                        break;
                    }
                }
            }
        }

        private object[] BindActionParameters(IControllerContext context, MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();
            if (parameters.Length == 0)
                return null;

            List<object> values = new List<object>();
            foreach (ParameterInfo parameter in parameters)
            {
                object value = context.ModelBinder.Bind(parameter.ParameterType);
                values.Add(value);
            }
            return values.ToArray();
        }

        private object ExecuteAction(IControllerContext context, MethodInfo methodInfo, object[] parameters)
        {
            return methodInfo.Invoke(this, parameters);
        }

        private void ProcessActionResult(IControllerContext context, MethodInfo methodInfo, object result)
        {
            string stringResult = result as string;
            if (stringResult != null)
                context.Navigation = stringResult;
        }


        private bool TryValidate(MethodInfo methodInfo, object[] parameters)
        {
            bool result = true;
            ValidateAttribute validate = ReflectionHelper.GetAttribute<ValidateAttribute>(methodInfo);
            if (validate != null)
            {
                IValidatorService validatorService = Context.DependencyProvider.Resolve<IValidatorService>();
                foreach (object parameter in parameters)
                {
                    IValidationResult validationResult = validatorService.Validate(parameter);
                    if (!validationResult.IsValid)
                    {
                        Messages.AddValidationResult(validationResult, validate.MessageKey);
                        result = false;
                    }
                }
            }
            return result;
        }

        private TransactionalDisposable TryTransaction(MethodInfo methodInfo)
        {
            IUnitOfWork transaction = null;
            TransactionalAttribute transactional = ReflectionHelper.GetAttribute<TransactionalAttribute>(methodInfo);
            if (transactional != null)
                transaction = Context.DependencyProvider.Resolve<IUnitOfWorkFactory>().Create();

            return new TransactionalDisposable(transaction);
        }
    }
}
