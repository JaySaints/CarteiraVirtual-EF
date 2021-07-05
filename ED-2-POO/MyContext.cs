using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;


namespace ED_2_POO
{
    class MyContext : DbContext
    {
        public DbSet<Moeda> Moedas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ParMoeda> ParMoedas { get; set; }
        public DbSet<Corretora> Corretoras { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<ItemCarteira> ItensCartiras { get; set; }
    }
}
