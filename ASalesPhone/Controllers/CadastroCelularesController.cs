using Microsoft.AspNetCore.Mvc;
using ASalesPhone.Data;
using ASalesPhone.Models;

namespace ASalesPhone.Controllers
{
    public class CadastroCelularesController : Controller
    {
        private readonly ASalesPhoneContext _context;
        public CadastroCelularesController(ASalesPhoneContext context)
        {
            _context = context;
        }

        public IActionResult EstoqueCelulares()
        {
            return View(); // Vai procurar por Views/CadastroCelulares/EstoqueCelulares.cshtml
        }

        [HttpPost]
        public IActionResult AddEstoqueCelular(int id, int quantidade)
        {
            var celular = _context.EstoqueCelulares.FirstOrDefault(e => e.Id == id);
            if (celular == null)
            {
                return Json(new { success = false, message = "Celular não encontrado." });
            }
            celular.Quantidade += quantidade;
            _context.SaveChanges();
            return Json(new { success = true, message = "Quantidade adicionada com sucesso!" });
        }
    }
} 