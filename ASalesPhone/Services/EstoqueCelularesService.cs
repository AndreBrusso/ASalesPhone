using ASalesPhone.Data;
using ASalesPhone.Models;
using Microsoft.EntityFrameworkCore;

namespace ASalesPhone.Services
{
    public class EstoqueCelularesService
    {
        private readonly ASalesPhoneContext _context;

        public EstoqueCelularesService(ASalesPhoneContext context)
        {
            _context = context;
        }

        public async Task<bool> RealizarCompra(string modelo)
        {
            var celular = await _context.EstoqueCelulares
                .FirstOrDefaultAsync(e => e.Modelo == modelo);

            if (celular == null || celular.Quantidade <= 0)
            {
                return false;
            }

            celular.Quantidade--;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> ConsultarEstoque(string modelo)
        {
            var celular = await _context.EstoqueCelulares
                .FirstOrDefaultAsync(e => e.Modelo == modelo);

            return celular?.Quantidade ?? 0;
        }
    }
} 