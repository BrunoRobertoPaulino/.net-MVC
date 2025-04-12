using Microsoft.AspNetCore.Mvc;
using MVC.Forms;
using MVC.Services;

namespace MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ContatoService _contatoController;

        public ContatoController(ContatoService contatoService) 
        {
            _contatoController = contatoService;
        }

        [HttpPost]
        public async Task<IActionResult> BotaoClicado(ContatoForm obj)
        {
            
            TempData["Mensagem"] = "O botão foi clicado!";
            TempData["Mensagem"] = "O botão foi clicado!";

            await _contatoController.PuppeterTest(obj);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
