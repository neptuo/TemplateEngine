using Neptuo.Commands.Handlers;
using Neptuo.Commands.Validation;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Commands.Handlers
{
    /// <summary>
    /// Base stuff for handling commands.
    /// </summary>
    /// <typeparam name="TCommand">Type of command to handle.</typeparam>
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>, IValidator<TCommand>
    {
        /// <summary>
        /// Checks <paramref name="command"/> for null, validates it and calls <see cref="CommandHandlerBase<>.HandleValidCommand"/>.
        /// </summary>
        /// <param name="command">Command to handle.</param>
        public void Handle(TCommand command)
        {
            Guard.NotNull(command, "command");

            IValidationResult validationResult = Validate(command);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            HandleValidCommand(command);
        }

        /// <summary>
        /// Handles validated command.
        /// </summary>
        /// <param name="command">Command to handle.</param>
        protected abstract void HandleValidCommand(TCommand command);

        /// <summary>
        /// Checks <paramref name="command"/> for null and calls <see cref="CommandHandlerBase<>.ValidateCommand"/>.
        /// </summary>
        /// <param name="command">Command to validate.</param>
        /// <returns>Validation result for <paramref name="command"/>.</returns>
        public IValidationResult Validate(TCommand command)
        {
            Guard.NotNull(command, "command");

            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateCommand(command, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        /// <summary>
        /// Processes validation on <paramref name="command"/> and stores messages to <paramref name="messages"/>.
        /// </summary>
        /// <param name="command">Command to validate.</param>
        /// <param name="messages">Result collection of validation messages.</param>
        protected abstract void ValidateCommand(TCommand command, List<IValidationMessage> messages);
    }
}
