using Neptuo.Commands.Handlers;
using Neptuo.Data;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class CommandHandlerControllerFactory<TModel> : IController
    {
        protected IDependencyProvider DependencyProvider { get; private set; }

        public CommandHandlerControllerFactory(IDependencyProvider dependencyProvider)
        {
            DependencyProvider = dependencyProvider;
        }

        public void Execute(IControllerContext context)
        {
            TModel model = context.ModelBinder.Bind<TModel>();
            ICommandHandler<TModel> handler = DependencyProvider.Resolve<ICommandHandler<TModel>>();
            Type handlerType = handler.GetType();

            ValidateAttribute validate = handlerType.GetCustomAttribute<ValidateAttribute>();
            if (validate != null)
            {
                IValidator<TModel> validator = DependencyProvider.Resolve<IValidator<TModel>>();
                IValidationResult validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    MessageStorage messages = DependencyProvider.Resolve<MessageStorage>();
                    messages.AddValidationResult(validationResult, validate.MessageKey);
                    return;
                }
            }

            TransactionalAttribute transactional = handlerType.GetCustomAttribute<TransactionalAttribute>();
            if (transactional != null)
            {
                IUnitOfWorkFactory transactionFactory = DependencyProvider.Resolve<IUnitOfWorkFactory>();
                using (IUnitOfWork transaction = transactionFactory.Create())
                {
                    handler.Handle(model);
                    transaction.SaveChanges();
                }
            }
            else
            {
                handler.Handle(model);
            }
        }
    }
}
