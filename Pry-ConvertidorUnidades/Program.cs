namespace Pry_ConvertidorUnidades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionPrincipal;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CONVERTIDOR DE UNIDADES ===");
                Console.WriteLine("1. Longitud");
                Console.WriteLine("2. Peso");
                Console.WriteLine("3. Temperatura");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcionPrincipal = Convert.ToInt32(Console.ReadLine());

                switch (opcionPrincipal)
                {
                    case 1:
                        ConvertirLongitud();
                        break;
                    case 2:
                        ConvertirPeso();
                        break;
                    case 3:
                        ConvertirTemperatura();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcionPrincipal != 0);
        }

        static void ConvertirLongitud()
        {
            Console.Clear();
            Console.WriteLine("=== CONVERSIÓN DE LONGITUD ===");
            Console.WriteLine("1. Metros a Kilómetros");
            Console.WriteLine("2. Kilómetros a Millas");
            Console.WriteLine("3. Millas a Pies");
            Console.WriteLine("4. Pies a Metros");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el valor a convertir: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            double resultado = 0;
            string unidadDestino = "";

            switch (opcion)
            {
                case 1:
                    resultado = valor / 1000;
                    unidadDestino = "kilómetros";
                    break;
                case 2:
                    resultado = valor * 0.621371;
                    unidadDestino = "millas";
                    break;
                case 3:
                    resultado = valor * 5280;
                    unidadDestino = "pies";
                    break;
                case 4:
                    resultado = valor * 0.3048;
                    unidadDestino = "metros";
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    return;
            }

            Console.WriteLine($"Resultado: {resultado} {unidadDestino}");
        }

        static void ConvertirPeso()
        {
            Console.Clear();
            Console.WriteLine("=== CONVERSIÓN DE PESO ===");
            Console.WriteLine("1. Kilogramos a Libras");
            Console.WriteLine("2. Gramos a Kilogramos");
            Console.WriteLine("3. Libras a Kilogramos");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el valor a convertir: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            double resultado = 0;
            string unidadDestino = "";

            switch (opcion)
            {
                case 1:
                    resultado = valor * 2.20462;
                    unidadDestino = "libras";
                    break;
                case 2:
                    resultado = valor / 1000;
                    unidadDestino = "kilogramos";
                    break;
                case 3:
                    resultado = valor / 2.20462;
                    unidadDestino = "kilogramos";
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    return;
            }

            Console.WriteLine($"Resultado: {resultado} {unidadDestino}");
        }

        static void ConvertirTemperatura()
        {
            Console.Clear();
            Console.WriteLine("=== CONVERSIÓN DE TEMPERATURA ===");
            Console.WriteLine("1. Celsius a Fahrenheit");
            Console.WriteLine("2. Fahrenheit a Celsius");
            Console.WriteLine("3. Celsius a Kelvin");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la temperatura: ");
            double temp = Convert.ToDouble(Console.ReadLine());

            double resultado = 0;
            string unidadDestino = "";

            switch (opcion)
            {
                case 1:
                    resultado = (temp * 9 / 5) + 32;
                    unidadDestino = "°F";
                    break;
                case 2:
                    resultado = (temp - 32) * 5 / 9;
                    unidadDestino = "°C";
                    break;
                case 3:
                    resultado = temp + 273.15;
                    unidadDestino = "K";
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    return;
            }

            Console.WriteLine($"Resultado: {resultado} {unidadDestino}");
        }
    }
}
