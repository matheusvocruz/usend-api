using USend.Application.Interfaces;
using USend.Application.Requests.User;
using USend.Application.Responses.User;
using System.Threading.Tasks;
using USend.Application.Responses.ApiResponse;
using AutoMapper;
using USend.Domain.Interfaces;
using USend.Infra.Data.Util;
using System.Collections.Generic;

namespace USend.Application.Queries
{
    public class UserQueries : ResponseHandler, IUserQueries
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserQueries(
            IMapper mapper,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                AddError("Usuário não encontrado");
                return Response;
            }

            if (PasswordUtil.PasswordIsCorrect(user.Password.Split(".")[1], user.Password.Split(".")[2], request.Password))
            {
                var token = JwtUtil.GenarateToken(user);
                var tokenResponse = new Infra.Data.ValueObjects.TokenResponse
                {
                    User = user,
                    Token = token.Token,
                    Expiration = token.Expiration
                };

                Response.Data = _mapper.Map<TokenResponse>(tokenResponse);
                return Response;
            }

            AddError("Credências inválidas");
            return Response;
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            Response.Data = _mapper.Map<List<UserResponse>>(await _userRepository.GetAllAsync());

            return Response;
        }

        public async Task<ApiResponse> GetByIdAsync(UserRequest request)
        {
            Response.Data = _mapper.Map<UserResponse>(await _userRepository.GetByIdAsync(request.Id));

            return Response;
        }

        public async Task<ApiResponse> GetByEmailAsync(UserRequestByEmail request)
        {
            Response.Data = _mapper.Map<UserResponse>(await _userRepository.GetByEmailAsync(request.Email));

            return Response;
        }
    }
}
