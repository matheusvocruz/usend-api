using USend.Application.Requests.User;
using USend.Application.Responses.ApiResponse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using USend.Domain.Interfaces;
using USend.Infra.Data.Util;

namespace USend.Application.Commands.User
{
    public class UpdateUserRequestCommandHandler :
        CommandHandler, IRequestHandler<UpdateUserRequest, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UpdateUserRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                AddError("Usuário não encontrado.");
                return Response;
            }

            var userEmail = await _userRepository.GetByEmailAsync(request.Email);
            if(userEmail != null)
            {
                if(userEmail.Id != user.Id)
                {
                    AddError("Já existe outro usuário com esse email.");
                    return Response;
                }
            }

            user.Update(request.Email, request.Name, PasswordUtil.GeneratePassword(request.Password), request.BirthDate.Date, request.Cpf, request.Phone);

            _userRepository.Update(user);

            return await PersistDataAsync(_unitOfWork);
        }
    }
}
