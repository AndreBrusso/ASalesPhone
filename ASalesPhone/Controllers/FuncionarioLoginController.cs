using ASalesPhone.Data;
using ASalesPhone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ASalesPhone.Controllers
{
    public class FuncionarioLoginController : Controller
    {
        private readonly ASalesPhoneContext _context;

        public FuncionarioLoginController(ASalesPhoneContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login(string Email, string Senha)
        {
            var funcionario = _context.CadastroFuncionarios
                .FirstOrDefault(f => f.Email == Email);

            if (funcionario == null)
            {
                ViewBag.Mensagem = "Usuário não encontrado.";
                return View();
            }

            if (funcionario.Senha != Senha)
            {
                ViewBag.Mensagem = "Senha incorreta.";
                return View();
            }

            HttpContext.Session.SetString("UsuarioEmail", funcionario.Email);
            return RedirectToAction("EstoqueCelulares", "CadastroCelulares");
        }


    }
}
 


