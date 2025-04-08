using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASalesPhone.Models;

namespace ASalesPhone.Data
{
    public class ASalesPhoneContext : DbContext
    {
        public ASalesPhoneContext (DbContextOptions<ASalesPhoneContext> options)
            : base(options)
        {
        }

        public DbSet<ASalesPhone.Models.Cadastro> Cadastro { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
