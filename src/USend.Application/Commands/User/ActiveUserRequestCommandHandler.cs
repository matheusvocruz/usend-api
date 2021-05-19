using USend.Application.Requests.User;
using USend.Application.Responses.ApiResponse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using USend.Domain.Interfaces;

namespace USend.Application.Commands.User
{
    public class ActiveUserRequestCommandHandler :
        CommandHandler, IRequestHandler<ActiveUserRequest, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public ActiveUserRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Handle(ActiveUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                AddError("Usuário não encontrado.");
                return Response;
            }

            user.ActiveUser(request.Active);

            _userRepository.Update(user);

            return await PersistDataAsync(_unitOfWork);
        }
    }
}
