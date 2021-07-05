using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class ParMoeda
    {
        public int ParMoedaID { get; set; }
        public Moeda MoedaBase { get; set; }
        public Moeda MoedaCotacao { get; set; }
        public double Valor { get; set; }

        public MyContext db = new MyContext();

        public void ManterParMoeda()
        {
            new Moeda().Imprime();
            
            System.Console.WriteLine("ID Moeda Base:");
            int BaseID = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("ID Moeda Cotação:");
            int CotacaoID = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Valor R$:");
            double valor = Double.Parse(System.Console.ReadLine());

            ParMoeda parmod = new ParMoeda();
            parmod.MoedaBase = db.Moedas.Find(BaseID);
            parmod.MoedaCotacao = db.Moedas.Find(CotacaoID);
            parmod.Valor = valor;

            db.ParMoedas.Add(parmod);

            db.SaveChanges();
        }

        public double CalculaCota(string codMod, double qtd)
        {
            var cotacao = (from cot in db.ParMoedas
                           where cot.MoedaBase.Codigo.Contains(codMod)
                           select cot).First();
            return cotacao.Valor * qtd;
        }



        public void Imprime()
        {
            // READ PARMOEDA -----------> FAIL
            System.Console.WriteLine("PARES DE MOEDAS CADASTRADAS");

            var qpm = from pm in db.ParMoedas select new { pm.MoedaBase, pm.MoedaCotacao, pm.Valor};            
            foreach (var item in qpm)
            {
                System.Console.WriteLine($"Compra:{item.MoedaBase.Codigo} | " +
                    $"Venda: {item.MoedaCotacao.Codigo} | Valor: {item.Valor}");
            }

            System.Console.WriteLine("\n---APERTE ENTER---\n");
            System.Console.ReadKey();
        }




    }
}
