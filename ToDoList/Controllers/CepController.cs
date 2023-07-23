using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Integrations.Interfaces;
using ToDoList.Integrations.Responses;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;

        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> ListDataAddress(string cep)
        {
            var responseData = await _viaCepIntegration.GetDataViaCep(cep);

            if (responseData == null)
            {
                return BadRequest("CEP not found.");
            }

            return Ok(responseData);
        }
    }
}
