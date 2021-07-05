using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class Corretora
    {
        public int CorretoraID { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Carteira> Carteiras { get; set; } 

        public MyContext db = new MyContext();

        public Corretora()
        {
            this.Carteiras = new List<Carteira>();
        }
       
        public void ManterCorreotra()
        {
            System.Console.WriteLine("Nome Corretora:");
            string nome = System.Console.ReadLine();

            System.Console.WriteLine("Codigo Corretora:");
            int codigo = Int32.Parse(System.Console.ReadLine());

            Corretora corr = new Corretora();
            corr.Nome = nome;
            corr.Codigo = codigo;
            

            db.Corretoras.Add(corr);

            db.SaveChanges();
        }


        public void Imprime()
        {
            // READ CORRETORA ----------------------> OK
            System.Console.WriteLine("CORRETORAS CADASTRADAS\n");

            var qcorr = from corr in db.Corretoras select new { corr.Codigo, corr.Nome, corr.Carteiras };
            foreach (var item in qcorr)
            {
                System.Console.WriteLine($"Cod: {item.Codigo} | Nome: {item.Nome} | Quantidade Carteiras {item.Carteiras.Count}");
            }

            System.Console.WriteLine("\n---APERTE ENTER---\n");
            System.Console.ReadKey();
        }

    }
}
