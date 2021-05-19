using FluentValidation.Results;

namespace USend.Application.Responses.ApiResponse
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
