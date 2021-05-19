using FluentValidation.Results;

namespace USend.Application.Responses.ApiResponse
{
    public class ResponseHandler
    {
        protected ApiResponse Response;

        protected ResponseHandler()
        {
            Response = new ApiResponse { ValidationResult = new ValidationResult() };
        }

        protected void AddError(string mensagem)
        {
            Response.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}
