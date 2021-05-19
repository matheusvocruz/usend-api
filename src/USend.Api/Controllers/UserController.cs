using USend.Application.Interfaces;
using USend.Application.Requests.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace USend.Api.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    public class UserController : BaseController
    {

        private readonly ISender _mediator;
        private readonly IUserQueries _userQueries;

        public UserController(
            ISender mediator,
            IUserQueries userQueries
        )
        {
            _userQueries = userQueries;
            _mediator = mediator;
        }

        /// <summary>
        /// Buscar todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
            => CustomResponse(await _userQueries.GetAllAsync());

        /// <summary>
        /// Buscar usuário pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] UserRequest request)
            => CustomResponse(await _userQueries.GetByIdAsync(request));

        /// <summary>
        /// Buscar usuário pelo email
        /// </summary>
        /// <returns></returns>
        [HttpGet("email/{Email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] UserRequestByEmail request)
            => CustomResponse(await _userQueries.GetByEmailAsync(request));

        /// <summary>
        /// Inserção de usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
            => CustomResponse(await _mediator.Send(request));

        /// <summary>
        /// Edição de usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditAsync([FromBody] UpdateUserRequest request)
            => CustomResponse(await _mediator.Send(request));

        /// <summary>
        /// Ativar/Desativar usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut("active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ActiveAsync([FromBody] ActiveUserRequest request)
            => CustomResponse(await _mediator.Send(request));

        /// <summary>
        /// Remoção de usuário
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteUserRequest request)
            => CustomResponse(await _mediator.Send(request));
    }
}
