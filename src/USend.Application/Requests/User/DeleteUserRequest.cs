using USend.Application.Responses.ApiResponse;
using MediatR;

namespace USend.Application.Requests.User
{
    public class DeleteUserRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
    }
}
