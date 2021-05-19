using USend.Application.Responses.ApiResponse;
using MediatR;

namespace USend.Application.Requests.User
{
    public class ActiveUserRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public bool Active { get; set; }
    }
}
