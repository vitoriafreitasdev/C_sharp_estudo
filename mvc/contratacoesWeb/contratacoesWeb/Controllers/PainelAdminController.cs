using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
namespace contratacoesWeb.Controllers
{
    public class PainelAdminController : Controller
    {
        private readonly IPainelAdminService _painelAdminService;

        public PainelAdminController(IPainelAdminService painelAdminService)
        {
            _painelAdminService = painelAdminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar()
        {
            Recrutadores recrutadorAdd = new Recrutadores
            {
                id = ObjectId.GenerateNewId().ToString(),
                nome = "Julio Santos",
                email = "julio.santos@gmail.com",
                senha = "123456",
            };

            Recrutadores recrutadorAdd1 = new Recrutadores
            {
                id = ObjectId.GenerateNewId().ToString(),
                nome = "Marcelie Gabriela",
                email = "marceliegabriela@gmail.com",
                senha = "123456",
            };


            Recrutadores recrutadorAdd2 = new Recrutadores
            {
                id = ObjectId.GenerateNewId().ToString(),
                nome = "Vitor Almeida",
                email = "vitorAlmeida@gmail.com",
                senha = "123456",
            };
            await _painelAdminService.AdicionarRecrutador(recrutadorAdd);
            await _painelAdminService.AdicionarRecrutador(recrutadorAdd1);
            await _painelAdminService.AdicionarRecrutador(recrutadorAdd2);    
            return RedirectToAction("Index");
        }
    }
}
