using USend.Application.Interfaces;
using USend.Application.Requests.User;
using USend.Application.Responses.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace USend.Api.Controllers
{
    [ApiVersion("1.0")]
    public class AuthenticateController : BaseController
    {
        private readonly IUserQueries _userQueries;

        public AuthenticateController(
            IUserQueries userQueries
        )
        {
            _userQueries = userQueries;
        }

        /// <summary>
        /// Autenticação do Usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        public async Task<IActionResult> CreateAsync([FromBody] AuthenticateRequest request)
            => CustomResponse(await _userQueries.AuthenticateAsync(request));
    }
}
