using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class Menu
    {        
        public MyContext db = new MyContext();

        public void Lista()
        {            
            System.Console.WriteLine("");
            System.Console.WriteLine("[ 1] - Cadastra Corretora:");
            System.Console.WriteLine("[ 2] - Cadastra Moeda;");
            System.Console.WriteLine("[ 3] - Cadastra Cliente:");
            System.Console.WriteLine("[ 4] - Cadastra Pares Moedas:");
            System.Console.WriteLine("[ 5] - Abrir Carteira:");
            System.Console.WriteLine("[ 6] - Insere Iten na Cartiera:");           
            System.Console.WriteLine("[ 7] - Lista Corretoras ");
            System.Console.WriteLine("[ 8] - Lista Clientes");
            System.Console.WriteLine("[ 9] - Lista Moedas");
            System.Console.WriteLine("[10] - Lista Pares Moedas");
            System.Console.WriteLine("[11] - Lista Carteiras");
            System.Console.WriteLine("[12] - Lista Cliente por ID");

            System.Console.WriteLine("[0] - {Exit}\n");
        }
  

        public void Start()
        {
            var init = true;
            while (init)
            {
                Lista(); // CHAMA LISTA DE OPÇÕES

                System.Console.WriteLine("Cod opção");
                string cod = System.Console.ReadLine();
                switch (cod)
                {
                    case "1":                        
                        System.Console.WriteLine("\n1- CADATRAR CORRETORA\n");
                        new Corretora().ManterCorreotra();
                        break;
                    case "2":
                        System.Console.WriteLine("\n2- CADASTRAR MOEDA\n");                       
                        new Moeda().MantemMoedas();
                        break;
                    case "3":
                        System.Console.WriteLine("\n3- CADASTRAR CLIENTE\n");
                        new Cliente().MantemCliente();
                        break;
                    case "4":
                        System.Console.WriteLine("\n4- CADASTRAR PARES MOEDAS\n");
                        new ParMoeda().ManterParMoeda();
                        break;
                    case "5":
                        System.Console.WriteLine("\n5- CADASTRAR CARTEIRA\n");
                        new Carteira().ManterCarteira();
                        break;
                    case "6":
                        System.Console.WriteLine("6- INSERE ITENS NA CARTEIRA\n");
                        new ItemCarteira().MantemItens();
                        break;
                    case "7":
                        System.Console.WriteLine("7- LISTA CORREOTORAS\n");
                        new Corretora().Imprime();
                        break;
                    case "8":
                        System.Console.WriteLine("8- LISTA CLIENTE\n");
                        new Cliente().Imprime();
                        break;
                    case "9":
                        System.Console.WriteLine("9- LISTA MOEDAS\n");
                        new Moeda().Imprime();
                        break;
                    case "10":
                        System.Console.WriteLine("10- LISTA PARES MOEDAS\n");
                        new ParMoeda().Imprime();
                        break;
                    case "11":
                        System.Console.WriteLine("11- LISTA CARTEIRAS\n");
                        new Carteira().Imprime();
                        break;
                    case "12":
                        System.Console.WriteLine("11- LISTA CLIENTE POR ID\n");
                        new Cliente().BuscaCliente();
                        break;
                    case "0":
                        System.Console.WriteLine("BYE!!!");
                        init = false;
                        break;
                    default:
                        System.Console.WriteLine("[Erro!]");
                        break;
                }
            }

        }

    }
}
