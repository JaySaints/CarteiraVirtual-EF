using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ED_2_POO
{
    class Moeda
    {
        public int MoedaID { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public MyContext db = new MyContext();
        

        public Moeda()
        {

        }

        public Moeda(int arg)
        {
            // INSERE MOEDAS CASO NÃO EXISTA 
            var checkMoeda = from md in db.Moedas select md;
            if (checkMoeda.Count() == 0)
            {
                // Cria objeto MOEDA --> USD --> Moeda Cotação 
                Moeda moedaUSD = new Moeda("USD", "Dolar");
                Moeda moedaBRL = new Moeda("BRL", "Real");
                // Cria objeto MOEDA --> BITCOIN --> Moeda Base (Ex Real em relação ao Bitcoin)
                Moeda moedaBTC = new Moeda("BTC", "Bitcoin");
                // Cria objeto MOEDA --> LITECOIN --> Moeda Base
                Moeda moedaLTC = new Moeda("LTC", "Litcoin");
                // Cria objeto MOEDA --> ETHEREUM --> Moeda Base
                Moeda moedaETH = new Moeda("ETH", "Ethereum");
                db.Moedas.Add(moedaUSD);
                db.Moedas.Add(moedaBRL);
                db.Moedas.Add(moedaBTC);
                db.Moedas.Add(moedaLTC);
                db.Moedas.Add(moedaETH);
                System.Console.WriteLine($"Moedas Cadastradas!!!");
            }
        }

        public Moeda(string cod, string nome)
        {
            this.Codigo = cod;
            this.Nome = nome;
        }

        public void MantemMoedas()
        {
            // INSERE MOEDAS NA LISTA 
            System.Console.WriteLine("Codigo da Moeda:");
            string CodMoeda = System.Console.ReadLine();

            System.Console.WriteLine("Nome da Moeda:");
            string NomeMoeda = System.Console.ReadLine();

            db.Moedas.Add(new Moeda() 
            { 
                Codigo = CodMoeda, 
                Nome = NomeMoeda 
            });

            db.SaveChanges();
        }


        public void Imprime()
        {
            //READ MOEDAS -------------> OK
            System.Console.WriteLine("MOEDAS CADASTRADAS");

            var qm = from md in db.Moedas select md;
            foreach (var item in qm)
            {
                System.Console.WriteLine($"ID: {item.MoedaID} - {item.Codigo}  Nome: {item.Nome}");
            }

            System.Console.WriteLine("\n---APERTE ENTER---\n");
            System.Console.ReadKey();
        }

    }
}
