using System.Net.Http;
using System.Text.Json;
using DTOs.DTOAPI;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Forms;

namespace MVC.API.Controllers
{
    [Controller]
    [Route("api/")]
    public class ContatoController : Controller
    {
        private readonly DataContatoContext _dataContatoContext;
        private readonly HttpClient _httpClient;

        public ContatoController(DataContatoContext dataContatoContext, HttpClient httpClient)
        {
            _dataContatoContext = dataContatoContext ?? throw new ArgumentNullException(nameof(dataContatoContext));
            _httpClient = httpClient;
        }

        [HttpGet("nome")]
        public IActionResult Get()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            map.Add("Nome", "Bruno");

            return Ok(map);
        }

        [HttpPost("contato")]
        public async Task<IActionResult> Contato([FromBody] Contato contato)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            int id = 1;
            Contato find = await _dataContatoContext!.Contato.FindAsync(id);
            
            var resposta = await _httpClient.GetAsync("https://brasilapi.com.br/api/feriados/v1/2025");

            var json = await resposta.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<List<FeriadosDTO>>(json);

            return Ok(obj);
        }

    }
}
