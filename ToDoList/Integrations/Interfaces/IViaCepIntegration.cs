using ToDoList.Integrations.Responses;

namespace ToDoList.Integrations.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDataViaCep(string cep);
    }
}
