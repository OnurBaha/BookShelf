namespace Business.Dtos.Responses.UserOperationClaimResponses
{
    public class GetListUserOperationClaimResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }

    }
} 