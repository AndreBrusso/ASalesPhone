using ASalesPhone.Data;
using ASalesPhone.Models;

namespace ASalesPhone.Services
{
    public class CadastroService 
    {
        private readonly ASalesPhoneContext _cadastroService;

        public CadastroService(ASalesPhoneContext cadastroService) {
            _cadastroService = cadastroService;
        }

        public List<Cadastro> FindAll() { 
            return _cadastroService.Cadastro.ToList();
        }

        public void Insert(Cadastro obj)
        {
            _cadastroService.Add(obj);
            _cadastroService.SaveChanges();
        }


    }
}
