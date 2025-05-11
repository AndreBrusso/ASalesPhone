using ASalesPhone.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;


public class LoginsController : Controller
{
    private readonly ASalesPhoneContext _context;

    public LoginsController(ASalesPhoneContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        var usuario = _context.Cadastro.FirstOrDefault(u => u.Email == email);

        if (usuario == null)
        {
            ViewBag.Mensagem = "Usuário não encontrado.";
            return View("~/Views/Cadastros/Login.cshtml");
        }

        if (usuario.Senha != senha)
        {
            ViewBag.Mensagem = "Senha incorreta.";
            return View("~/Views/Cadastros/Login.cshtml");
        }

        
        HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
        return RedirectToAction("Logado", "VendaPhones");

    }

}
