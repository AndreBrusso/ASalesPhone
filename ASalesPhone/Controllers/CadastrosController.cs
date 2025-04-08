using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASalesPhone.Data;
using ASalesPhone.Models;
using ASalesPhone.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace ASalesPhone.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly ASalesPhoneContext _cadastroService;

        public CadastrosController(ASalesPhoneContext context)
        {
            _cadastroService = context;
        }

        // GET: Cadastros
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logado()
        {
            return View();
        }



        // POST: Cadastros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CPF,Email,Celular,Senha")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _cadastroService.Add(cadastro);
                await _cadastroService.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(cadastro);
        }

        private bool CadastroExists(int id)
        {
            return _cadastroService.Cadastro.Any(e => e.Id == id);
        }

        public IActionResult Cadastrar()
        {
            return View(new Cadastro()); // Passa um único objeto Cadastro para a view
        }

       
        
    }
}
