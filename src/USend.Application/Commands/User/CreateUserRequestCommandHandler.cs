using USend.Application.Requests.User;
using USend.Application.Responses.ApiResponse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using USend.Domain.Interfaces;
using USend.Infra.Data.Util;
using System.IO;
using System;

namespace USend.Application.Commands.User
{
    public class CreateUserRequestCommandHandler : 
        CommandHandler, IRequestHandler<CreateUserRequest, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public CreateUserRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository
        )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (await _userRepository.HasUserWithEmail(request.Email))
            {
                AddError("Já existe usuário com esse email.");
                return Response;
            }

            var user = new Domain.Entities.User(request.Email, request.Name, PasswordUtil.GeneratePassword(request.Password), request.BirthDate.Date, request.Cpf, request.Phone);

            _userRepository.Insert(user);

            return await PersistDataAsync(_unitOfWork);
        }
    }
}
