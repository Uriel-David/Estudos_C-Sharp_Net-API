using Refit;
using ToDoList.Integrations.Responses;

namespace ToDoList.Integrations.Refits
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
