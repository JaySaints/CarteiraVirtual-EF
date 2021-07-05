using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string PassHash { get; set; }

        public MyContext db = new MyContext();

        public void MantemCliente()
        {
            // INSERE CLIENTE NA LISTA
            System.Console.WriteLine("Nome Cliente:");
            string Nome = System.Console.ReadLine();

            System.Console.WriteLine("Email:");
            string Email = System.Console.ReadLine();

            System.Console.WriteLine("Celular:");
            string Cell = System.Console.ReadLine();

            System.Console.WriteLine("Senha:");
            string PassHash = System.Console.ReadLine();

            Cliente cli = new Cliente()
            {
                ClienteID = 1,
                Nome = Nome,
                Email = Email,
                Celular = Cell,
                PassHash = PassHash
            };
            
            db.Clientes.Add(cli);                    

            db.SaveChanges();
            var q = (from clid in db.Clientes where clid.Celular == Cell select clid).First();
            System.Console.WriteLine($"\nAQUI ESTÁ SEU ID: {q.ClienteID} <<< QUARDE PARA OPERAÇÕES FUTURAS!!!");
        }

        public void Imprime()
        {
            // READ CLIENTES ------------> OK
            System.Console.WriteLine("CLIENTES CADASTRADAOS");

            var qcli = from cli in db.Clientes select cli;
            foreach (var item in qcli)
            {
                System.Console.WriteLine($"ID: {item.ClienteID} | Nome: {item.Nome} | Email: {item.Email} | Cel: {item.Celular}");
            }

            System.Console.WriteLine("\n---APERTE ENTER---\n");
            System.Console.ReadKey();
        }

        public void BuscaCliente()
        {
            System.Console.WriteLine("ID do Cliente:");
            int clienteID = Int32.Parse(System.Console.ReadLine());
            var query = (from clinfo in db.Clientes
                        join cart in db.Carteiras
                            on clinfo equals cart.Cliente
                        where clinfo.ClienteID == clienteID
                        select new { Nome = clinfo.Nome, Email = clinfo.Email, Tel = clinfo.Celular, End = cart.Endereco }).First();

            System.Console.WriteLine($"Nome: {query.Nome}\nEmail: {query.Email}\nCelular: {query.Tel}\nCarteira: {query.End}");
            //MOSTRA ITENS PERTENCENTES A ESTE USUÁRIO
            new ItemCarteira().Imprime(clienteID);
            System.Console.WriteLine("");

        }
    }
}
