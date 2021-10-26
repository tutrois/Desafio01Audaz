using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;

namespace TestePleno.Views
{
     class Main 
    {
        public Main()
        {
            var fareController = new FareController();
            while (true)
            {
                Console.Clear();
                try
                {
                var fare = new Fare();
                fare.Id = Guid.NewGuid();

                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                Console.Write("Tarifa:  ");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);

                Console.WriteLine("\nInforme o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                Console.Write("Operadora:  ");
                var operatorCodeInput = Console.ReadLine();

                
                    fareController.CreateFare(fare, operatorCodeInput);
                    Console.WriteLine("\n\n**\tTarifa cadastrada com sucesso!\t**");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

                Console.WriteLine(  "\n\n**\tDeseja continuar no programa?   **\n"+
                                    "**\t[ENTER] Continuar\t\t**\n"+
                                    "**\t[ESC] Sair\t\t\t**");
                var keyboard = Console.ReadKey();
                if (keyboard.Key == ConsoleKey.Escape)break;
            }
        }
    }
}
