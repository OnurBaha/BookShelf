namespace Business.Dtos.Requests.UserOperationClaimRequests
{
    public class UpdateUserOperationClaimRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
} 