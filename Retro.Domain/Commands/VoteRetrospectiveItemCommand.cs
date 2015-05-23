namespace Retro.Domain.Commands
{
    public class VoteRetrospectiveItemCommand 
    {
        public string RetrospectiveId { get; set; }
        public string CategoryId { get; set; }
        public string ItemId { get; set; }
    }
}