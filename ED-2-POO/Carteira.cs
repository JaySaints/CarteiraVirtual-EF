using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ED_2_POO
{
    class Carteira
    {
        public int CarteiraID { get; set; }
        public string Endereco { get; set; } 
        public Cliente Cliente { get; set; }
        public Corretora Corretora { get; set; }
        public List<ItemCarteira> ItensCarteiras { get; set; }

        public MyContext db = new MyContext();


        public Carteira()
        {
            this.ItensCarteiras = new List<ItemCarteira>();
        }

        public void ManterCarteira()
        {
            System.Console.WriteLine("ABRIR CARTEIRA VIRTUAL");
            // MOSTRA AS CORRETORAS DISPONIVEIS PARA SEREM ESCOLHIDAS ATRAVES DE SEU ID
            new Corretora().Imprime();
            System.Console.WriteLine("ESCOLHA UMA CORRETORA");
            System.Console.WriteLine("ID da Corretora:");
            int corretoraID = Int32.Parse(System.Console.ReadLine());
            
            //System.Console.WriteLine("Endereço Carteira:");
            //string endereco = System.Console.ReadLine();

            System.Console.WriteLine("ID do Cliente:");
            int clienteID = Int32.Parse(System.Console.ReadLine());
            
            // LOCALIZA A CORRETORA ESCOLHIDA PARA ADICIONAR NA CARTEIRA
            var corretora = (from corre in db.Corretoras where corre.Codigo == corretoraID select corre).First();
            // CRIA UM NOVO OBJETO DA CLASSE CARTEIRA
            Carteira cart = new Carteira();            
            cart.Cliente = db.Clientes.Find(clienteID);
            cart.Corretora = corretora;

            // GERA UM ENDEREÇO DE CARTEIRA ALEATÓRIO
            Random ranNum = new Random();
            cart.Endereco = ($"{ranNum.Next(10000)}!s(f&s{ranNum.Next(10000)}-{ranNum.Next(10)}");

            // LOCALIZA A CORRETORA ESCOLHIDA PARA ADICIONAR A NOVA CARTEIRA CRIADA EM SUA LISTA            
            corretora.Carteiras.Add(cart);                       

            // INSERE O NAVA CARTEIRA NA TABELA CARTEIRAS
            db.Carteiras.Add(cart);

            // COMMIT DA OPERAÇÃO
            db.SaveChanges();
        }  

        public void Imprime()
        {
            // READ CARTEIRA -----------------------------> FAILE 
            System.Console.WriteLine("CARTEIRAS CADASTRADAS\n");
            var qcart = from cart in db.Carteiras select new { cart.CarteiraID, cart.Endereco, cart.Corretora, cart.Cliente };
            foreach (var item in qcart)
            {                
                System.Console.WriteLine($"ID {item.CarteiraID} | Endereço: {item.Endereco} | " +
                    $"Corretora: {item.Corretora.Nome} | Cliente: {item.Cliente.Nome}");
            }
            System.Console.WriteLine("\n---APERTE ENTER---\n");
            System.Console.ReadKey();
        }
    }
}
