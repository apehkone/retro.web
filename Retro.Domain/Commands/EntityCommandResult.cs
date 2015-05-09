namespace Retro.Domain.Commands
{
    public class EntityCommandResult<T>
    {
        public dynamic Response { get; set; }
        public T Entity { get; set; }
        public bool IsSuccess { get; set; }

        public static EntityCommandResult<T> Success() {
            return new EntityCommandResult<T> {IsSuccess = true};
        }

        public static EntityCommandResult<T> Error() {
            return new EntityCommandResult<T> {IsSuccess = false};
        }
    }
}