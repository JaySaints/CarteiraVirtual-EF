using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext db = new MyContext())
            {
                // PARA PRIMEIRA EXECUÇÃO É FEITA UMA VERIFICAÇÃO SE Á CONTEUDO NA TELA CLIENTES. 
                // CASO NÃO TENHA É GERADO UMA PRIMEIRA INSERÇAÕ DE DADOS NAS TABELAS PARA EVITAR CONFLITAS DE (NullReferencesException).
                var q = from tb in db.Clientes select tb;
                if (q.Count() == 0)
                {
                    new Start001();
                }
            }

            //CHAMA MENU DE OPÇÕES
            new Menu().Start();
                       

            System.Console.WriteLine("\n\n[THE END]");
            System.Console.ReadKey();

        }
    }
}
