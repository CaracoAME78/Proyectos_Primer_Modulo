namespace Pry_CalculadoraInteresCompuesto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*   Calculadora de Interés Compuesto
             
             Fórmula de Interés Compuesto:
                  A= P x ( 1 + r/n ) ¬ nt

            donde 
                 A = Monto final (capital + intereses)
                P = Capital inicial (principal)
                r = Tasa de interés anual (decimal)
                n = Número de veces que se capitaliza por año
                t = Tiempo en años
             */
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA DE INTERÉS COMPUESTO ===");
                Console.WriteLine("1. Calcular interés compuesto");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    CalcularInteresCompuesto();
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

            Console.WriteLine("Gracias por usar la calculadora. ¡Hasta luego!");
        }

        static void CalcularInteresCompuesto()
        {
            Console.Clear();
            Console.WriteLine("=== CÁLCULO DE INTERÉS COMPUESTO ===");

            Console.Write("Ingrese el capital inicial (P): ");
            double capital = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la tasa de interés anual (%) (r): ");
            double tasaInteres = Convert.ToDouble(Console.ReadLine()) / 100;

            Console.Write("Ingrese el número de periodos por año (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el tiempo en años (t): ");
            double t = Convert.ToDouble(Console.ReadLine());

            double montoFinal = capital * Math.Pow(1 + (tasaInteres / n), n * t);
            double interesesGanados = montoFinal - capital;

            Console.WriteLine($"\nMonto final (A): {montoFinal:C2}");
            Console.WriteLine($"Intereses ganados: {interesesGanados:C2}");
        }
    }
}
