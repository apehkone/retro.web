namespace Retro.Domain.Commands
{
    public class DeleteRetrospectiveItemCommand
    {
        public string RetrospectiveId { get; set; }
        public string CategoryId { get; set; }
        public string RetrospectiveItemId { get; set; }
    }
}