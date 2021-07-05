using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_2_POO
{
    class Start001
    {
        public Start001()
        {
            using (MyContext db = new MyContext())
            {
                Cliente clinull = new Cliente();
                clinull.Nome = "Marcelo Dias Castro";
                clinull.Email = "mmdias@gmail.com";
                clinull.Celular = "41 988822-3278";
                clinull.PassHash = "1o3i4u1o34up134u1p3u4";

                Corretora cornull = new Corretora();
                cornull.Nome = "Binance";
                cornull.Codigo = 777;

                Carteira carnull = new Carteira();
                carnull.Corretora = cornull;
                carnull.Endereco = "1LKJ23H41LK23JH4L121LKJ3H4";
                carnull.Cliente = clinull;
                cornull.Carteiras.Add(carnull);

                Moeda mod1null = new Moeda();
                mod1null.Nome = "DOLAR";
                mod1null.Codigo = "USD";

                Moeda mod2null = new Moeda();
                mod2null.Nome = "BITCOIN";
                mod2null.Codigo = "BTC";

                ParMoeda parnull = new ParMoeda();
                parnull.MoedaBase = mod2null;
                parnull.MoedaCotacao = mod1null;
                parnull.Valor = 999999;

                ItemCarteira itemnull = new ItemCarteira();
                itemnull.Moeda = mod2null;
                itemnull.Quantidade = 1;
                carnull.ItensCarteiras.Add(itemnull);

                db.Clientes.Add(clinull);
                db.Carteiras.Add(carnull);
                db.Corretoras.Add(cornull);
                db.Moedas.Add(mod1null);
                db.Moedas.Add(mod2null);
                db.ItensCartiras.Add(itemnull);
                db.ParMoedas.Add(parnull);

                db.SaveChanges();
               
            }
        }

    }
}
