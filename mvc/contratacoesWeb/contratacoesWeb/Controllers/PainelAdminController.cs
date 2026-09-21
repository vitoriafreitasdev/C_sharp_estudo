using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
namespace contratacoesWeb.Controllers
{
    public class PainelAdminController : Controller
    {
        private readonly IPainelAdminService _painelAdminService;
        

        public PainelAdminController(IPainelAdminService painelAdminService)
        {
            _painelAdminService = painelAdminService;
        }
        //fazer a parte de autenficação e autorização https://www.yogihosting.com/aspnet-core-identity-mongodb/#identity-role-mongodb
        [HttpGet]
        public IActionResult AbaAdmin()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar([Required][EmailAddress] string email, [Required] string senha)
        {
            Login login = new Login
            {
                email = email,
                senha = senha
            };

            var res = await _painelAdminService.LogarRecrutador(login);

            if(res.sucesso == false)
            {
                ViewBag.Mensagem = "Falha no login, verificar email ou senha";
                return View("Index");
            }

            return RedirectToAction("AbaAdmin");
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarRecrutador()
        {
            if (ModelState.IsValid)
            {
                Recrutadores recrutadorAdd = new Recrutadores
                {
                    id = ObjectId.GenerateNewId().ToString(),
                    nome = "Anna Julia",
                    email = "anna@hotmail.com",
                    senha = "Admin@123",
                };


                RetornoObjeto res = await _painelAdminService.AdicionarRecrutador(recrutadorAdd);
                if(res.sucesso == false)
                {
                    Console.WriteLine(res.mensagem);
                }
            
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
