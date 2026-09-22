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
       
        [Authorize(Roles = "Recrutador")]
        [HttpGet]
        public async Task<IActionResult> AbaAdmin()
        {
            var estaLogado = _painelAdminService.UsuarioEstaLogado();
            if (estaLogado == false)
            {
                return RedirectToAction("Index");
            }

            List<Vagas> vagas = await _painelAdminService.VisualizarVagas();

            return View(vagas);
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
        public async Task<IActionResult> DetalhesVaga(string id)
        {
            Vagas vaga = await _painelAdminService.VisualizarVagaPorId(id);
            return View(vaga);
        }

        [Authorize(Roles = "Recrutador")]
        [HttpGet]
        public async Task<IActionResult> AdicionarVaga()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AdicionarVagaPost([Required] string titulo, [Required] string descricao,
            [Required] string requisitos, [Required] string estado, [Required] string cidade, [Required] string bairro,
            [Required] string rua, [Required] string cep, [Required] string modelo, [Required] string tipo)
        {
            bool estaSeparadoPorVirgula = requisitos.Contains(",");
            if (estaSeparadoPorVirgula == false)
            {
                ViewBag.Mensagem = "Os requisistos precisam ser separados por vírgula.";
                return View("AdicionarVaga");
            }

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
            return View("AdicionarVaga");
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
