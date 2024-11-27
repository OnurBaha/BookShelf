namespace Business.Dtos.Responses.UserOperationClaimResponses
{
    public class DeletedUserOperationClaimResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
} 