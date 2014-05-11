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
    /// <summary>
    /// Base controller implementation.
    /// Maps methods to actions - enables usage of <see cref="ActionAttribute"/>.
    /// Method outcomes uses as navigation.
    /// Enables start method in transaction, <see cref="TransactionalAttribute"/>.
    /// Enables input validation, see <see cref="ValidateAttribute."/>
    /// </summary>
    public class ControllerBase : IController
    {
        /// <summary>
        /// Current context.
        /// </summary>
        protected IControllerContext Context { get; private set; }

        /// <summary>
        /// List of messages.
        /// </summary>
        protected MessageStorage Messages
        {
            get { return Context.Messages; }
        }

        /// <summary>
        /// Executes controller.
        /// Finds appropriate method using <see cref="ActionAttribute"/>.
        /// </summary>
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

        /// <summary>
        /// Uses <see cref="IModelBinder"/> for binding parameter values to method parameters.
        /// </summary>
        /// <param name="context">Controller context.</param>
        /// <param name="methodInfo">Target method.</param>
        /// <returns>List of parameter values.</returns>
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

        /// <summary>
        /// Do execution of <paramref name="methodInfo"/>.
        /// </summary>
        /// <param name="context">Controller context.</param>
        /// <param name="methodInfo">Target method.</param>
        /// <param name="parameters">Method parameters.</param>
        /// <returns>Method result.</returns>
        private object ExecuteAction(IControllerContext context, MethodInfo methodInfo, object[] parameters)
        {
            return methodInfo.Invoke(this, parameters);
        }

        /// <summary>
        /// Process action method result.
        /// </summary>
        /// <param name="context">Controller context.</param>
        /// <param name="methodInfo">Target method.</param>
        /// <param name="result">Method execution result.</param>
        private void ProcessActionResult(IControllerContext context, MethodInfo methodInfo, object result)
        {
            string stringResult = result as string;
            if (stringResult != null)
                context.Navigation = stringResult;
        }

        /// <summary>
        /// Tries to validate input parameters.
        /// </summary>
        /// <param name="methodInfo">Target method.</param>
        /// <param name="parameters">Method parameters.</param>
        /// <returns>True if succeeded.</returns>
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

        /// <summary>
        /// Tries invoke method in transaction.
        /// Returns object describing transaction and never returns null.
        /// </summary>
        /// <param name="methodInfo">Target method.</param>
        /// <returns><see cref="TransactionalDisposable"/></returns>
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
