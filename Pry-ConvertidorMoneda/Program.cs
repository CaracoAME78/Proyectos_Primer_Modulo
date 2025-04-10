namespace Pry_ConvertidorMoneda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CONVERTIDOR DE MONEDA ===");
                Console.WriteLine("1. Convertir moneda");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    ConvertirMoneda();
                }
                else if (opcion != 0)
                {
                    Console.WriteLine("Opción inválida.");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);

            Console.WriteLine("Gracias por usar el convertidor. ¡Hasta luego!");
        }

        static void ConvertirMoneda()
        {
            Console.Clear();
            Console.WriteLine("=== MONEDAS DISPONIBLES ===");
            Console.WriteLine("1. USD - Dólar Americano");
            Console.WriteLine("2. EUR - Euro");
            Console.WriteLine("3. PEN - Sol Peruano");
            Console.WriteLine("4. JPY - Yen Japonés");

            Console.Write("\nSeleccione la moneda de origen (1-4): ");
            int origen = Convert.ToInt32(Console.ReadLine());

            Console.Write("Seleccione la moneda de destino (1-4): ");
            int destino = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el monto a convertir: ");
            double monto = Convert.ToDouble(Console.ReadLine());

            string[] monedas = { "USD", "EUR", "PEN", "JPY" };

            double[,] tasas = {
                // USD,    EUR,    PEN,    JPY
                { 1.00,   0.91,   3.75,   151.23 }, // USD
                { 1.10,   1.00,   4.10,   166.01 }, // EUR
                { 0.27,   0.24,   1.00,   40.00  }, // PEN
                { 0.0066, 0.0060, 0.025,  1.00   }  // JPY
            };

            if (origen < 1 || origen > 4 || destino < 1 || destino > 4)
            {
                Console.WriteLine("Selección inválida de monedas.");
                return;
            }

            double tasaCambio = tasas[origen - 1, destino - 1];
            double resultado = monto * tasaCambio;

            Console.WriteLine($"\n{monto} {monedas[origen - 1]} equivale a {resultado:F2} {monedas[destino - 1]}");

        }
    }
}
