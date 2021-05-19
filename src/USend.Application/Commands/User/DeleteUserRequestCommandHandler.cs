using USend.Application.Requests.User;
using USend.Application.Responses.ApiResponse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using USend.Domain.Interfaces;


namespace USend.Application.Commands.User
{
    public class DeleteUserRequestCommandHandler :
        CommandHandler, IRequestHandler<DeleteUserRequest, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public DeleteUserRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                AddError("Usuário não encontrado.");
                return Response;
            }

            _userRepository.Delete(user);

            return await PersistDataAsync(_unitOfWork);
        }
    }
}
