using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
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
        [Authorize(Roles = "Recrutador")]
        [HttpGet]
        public IActionResult AbaAdmin()
        {
            var estaLogado = _painelAdminService.UsuarioEstaLogado();
            if (estaLogado == false)
            {
                return RedirectToAction("Index");
            }
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
        [Authorize(Roles = "Recrutador")]
        [HttpGet]
        public async Task<IActionResult> AdicionarRecrutador()
        {
            return View();
        }
        [Authorize(Roles = "Recrutador")]
        [HttpGet]
        public async Task<IActionResult> AdicionarVaga()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> VisualizarVagas()
        {
            return View("AbaAdmin");
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarVagaPost([Required] string titulo, [Required] string descricao,
            [Required] string requisitos, [Required] string estado, [Required] string cidade, [Required] string bairro,
            [Required] string rua, [Required] string cep, [Required] string modelo, [Required] string tipo)
        {
            List<string> requisistosList = requisitos.Replace(" ", "").Split(",").ToList();
            
            Vagas vaga = new Vagas
            {
                titulo = titulo,
                descricao = descricao,
                requisitos = requisistosList,
                localizacao = new Endereco
                {
                    estado = estado,
                    cidade = cidade,
                    bairro = bairro,
                    rua = rua,
                    cep = cep
                },
                modelo = modelo,
                tipo = tipo
            };

            RetornoObjeto res = await _painelAdminService.AdicionarVaga(vaga);

            if (res.sucesso == false)
            {
                ViewBag.Mensagem = res.mensagem;
            }
            else
            {
                ViewBag.Mensagem = "Adicionado com sucesso.";
            }
            return View("AdicionarRecrutador");
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarRecrutadorPost([Required] string nome, [Required][EmailAddress] string email, 
            [Required] string senha)
        {
            
            Recrutadores recrutadorAdd = new Recrutadores
            {
                id = ObjectId.GenerateNewId().ToString(),
                nome = nome,
                email = email,
                senha = senha,
            };
            RetornoObjeto res = await _painelAdminService.AdicionarRecrutador(recrutadorAdd);
            if(res.sucesso == false)
            {
                ViewBag.Mensagem = res.mensagem;
            }
            else
            {
                ViewBag.Mensagem = "Adicionado com sucesso.";
            }
            return View("AdicionarRecrutador");
        }
    }
}
