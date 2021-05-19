using USend.Application.Responses.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace USend.Api.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {

        protected ActionResult CustomResponse(ApiResponse result = null)
        {
            if (IsValidOperation(result))
            {
                result.ValidationResult = null;
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", result.ValidationResult.Errors.Select(c => c.ErrorMessage).ToArray() }
            }));
        }

        protected bool IsValidOperation(ApiResponse result)
        {
            return result != null && result.ValidationResult.IsValid;
        }
    }
}
