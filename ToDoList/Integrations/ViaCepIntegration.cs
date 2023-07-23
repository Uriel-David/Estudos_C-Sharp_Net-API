using ToDoList.Integrations.Interfaces;
using ToDoList.Integrations.Refits;
using ToDoList.Integrations.Responses;

namespace ToDoList.Integrations
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            throw responseData?.Error ?? new Exception("Value returned is null.");
        }
    }
}
