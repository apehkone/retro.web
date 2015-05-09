namespace Retro.Domain.Commands
{
    public class CreateOrUpdateRetrospectiveItemCommand
    {
        public string RetrospectiveId { get; set; }
        public string RetrospectiveItemId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
    }
}