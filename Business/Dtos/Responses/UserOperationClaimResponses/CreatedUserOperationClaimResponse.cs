namespace Business.Dtos.Responses.UserOperationClaimResponses
{
    public class CreatedUserOperationClaimResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
} 