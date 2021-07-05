using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class ItemCarteira
    {
        public int ItemCarteiraID { get; set; }
        public Moeda Moeda { get; set; }
        public double Quantidade { get; set; }
        public Carteira  Carteira { get; set; }


        public MyContext db = new MyContext();

        public void MantemItens()
        {
            System.Console.WriteLine("Listar Clientes para encontrar seu ID? Sim = 1 ou Não = 0");
            int aux = Int32.Parse(System.Console.ReadLine());
            if (aux == 1)
            {
                new Cliente().Imprime();
            }

            System.Console.WriteLine("ID do Cliente:");
            int IDcliente = Int32.Parse(System.Console.ReadLine());

            // IMPRIME AS MOEDAS DISPONIVEIS NO SISTEMA
            new Moeda().Imprime();
            System.Console.WriteLine("ID moeda");
            int IDmoeda = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Quantidade:");
            double qtd = Double.Parse(System.Console.ReadLine());
            
            // CRIA O OBJETO ITEM CARTEIRA 
            ItemCarteira newItem = new ItemCarteira();
            newItem.Moeda = db.Moedas.Find(IDmoeda);
            newItem.Quantidade = qtd;

            // PROCURA A CARTEIRA DO CLIENTE ATRAVEZ DE SEU ID.
            // DEPOIS DE LOCALIZAR O ID DA CARTEIRA DO CLIENTE É ADICIONADO O NOVO ITEM NA LISTA DA CARTEIRA DO CLIENTE
            var carteira = (from cart in db.Carteiras where cart.Cliente.ClienteID == IDcliente select cart).First();
            carteira.ItensCarteiras.Add(newItem);

            db.ItensCartiras.Add(newItem);

            db.SaveChanges();           
        }


        public void Imprime(int codCli)
        {
            var query = from cart in db.Carteiras
                             join itm in db.ItensCartiras
                                 on cart equals itm.Carteira 
                                    where cart.Cliente.ClienteID == codCli 
                                        select new { codMod = itm.Moeda.Codigo, qtd = itm.Quantidade };

            foreach (var item in query)
            {
                var valor = new ParMoeda().CalculaCota(item.codMod, item.qtd);

                System.Console.WriteLine($"Moeda: {item.codMod} - Quantidade: {item.qtd} - Valor: {valor.ToString()}");
            }
            
        }
    }

       




}
