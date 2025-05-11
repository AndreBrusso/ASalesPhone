using Microsoft.AspNetCore.Mvc;
using ASalesPhone.Services;

namespace ASalesPhone.Controllers
{
    public class CompraController : Controller
    {
        private readonly EstoqueCelularesService _estoqueService;

        public CompraController(EstoqueCelularesService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarCompra(string modelo)
        {
            var sucesso = await _estoqueService.RealizarCompra(modelo);

            if (!sucesso)
            {
                return Json(new { success = false, message = "Produto indisponível no estoque." });
            }

            return Json(new { success = true, message = "Compra realizada com sucesso!" });
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarEstoque(string modelo)
        {
            var quantidade = await _estoqueService.ConsultarEstoque(modelo);
            return Json(new { quantidade });
        }
    }
} 