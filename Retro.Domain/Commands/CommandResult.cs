namespace Retro.Domain.Commands
{
    public class CommandResult
    {
        public dynamic Response { get; set; }
        public bool IsSuccess { get; set; }

        public static CommandResult Success() {
            return new CommandResult {IsSuccess = true};
        }

        public static CommandResult Error() {
            return new CommandResult {IsSuccess = false};
        }
    }
}