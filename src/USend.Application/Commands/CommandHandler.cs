using USend.Application.Responses.ApiResponse;
using USend.Domain.Interfaces;
using System.Threading.Tasks;

namespace USend.Application.Commands
{
    public abstract class CommandHandler : ResponseHandler
    {
        protected async Task<ApiResponse> PersistDataAsync(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("Houve um erro ao persistir os dados");

            return Response;
        }
    }
}
