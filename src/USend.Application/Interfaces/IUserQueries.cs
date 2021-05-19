using USend.Application.Requests.User;
using USend.Application.Responses.ApiResponse;
using System.Threading.Tasks;


namespace USend.Application.Interfaces
{
    public interface IUserQueries
    {
        Task<ApiResponse> AuthenticateAsync(AuthenticateRequest request);
        Task<ApiResponse> GetByIdAsync(UserRequest request);
        Task<ApiResponse> GetByEmailAsync(UserRequestByEmail request);
        Task<ApiResponse> GetAllAsync();
    }
}
