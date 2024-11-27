namespace Business.Dtos.Requests.UserOperationClaimRequests
{
    public class CreateUserOperationClaimRequest
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

    }
} 