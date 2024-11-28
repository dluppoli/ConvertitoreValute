using ConvertitoreClient.ConvertitoreService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertitoreClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceClient service = new ServiceClient();
            string scelta = "";

            while(scelta!="9")
            {
                Console.WriteLine("1 - Conversione valute");
                Console.WriteLine("2 - Stampa tassi di conversione");
                Console.WriteLine();
                Console.WriteLine("9 - Uscita");

                scelta = Console.ReadLine();

                switch(scelta)
                {
                    case "1":


                        foreach(valute valuta in Enum.GetValues(typeof(valute)))
                        {
                            Console.WriteLine( ((int)valuta).ToString() + " - "+valuta.ToString());
                        }
                        Console.Write("Importo: ");
                        float importo = float.Parse(Console.ReadLine());
                        Console.Write("Valuta di partenza: ");
                        int da = int.Parse(Console.ReadLine());
                        Console.Write("Valuta di destinazione: ");
                        int a = int.Parse(Console.ReadLine());

                        Console.WriteLine( service.ConvertiValuta(importo,(valute)da,(valute)a));
                        break;
                    case "2":
                        foreach(string tasso in service.TassiConversione() )
                            Console.WriteLine(tasso);
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Scelta errata");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
