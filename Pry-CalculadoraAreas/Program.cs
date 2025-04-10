namespace Pry_CalculadoraAreas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA DE ÁREAS ===");
                Console.WriteLine("1. Área de un Cuadrado");
                Console.WriteLine("2. Área de un Rectángulo");
                Console.WriteLine("3. Área de un Círculo");
                Console.WriteLine("4. Área de un Triángulo");
                Console.WriteLine("5. Área de un Trapecio");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AreaCuadrado();
                        break;
                    case 2:
                        AreaRectangulo();
                        break;
                    case 3:
                        AreaCirculo();
                        break;
                    case 4:
                        AreaTriangulo();
                        break;
                    case 5:
                        AreaTrapecio();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void AreaCuadrado()
        {
            Console.Clear();
            Console.Write("Ingrese el lado del cuadrado: ");
            double lado = Convert.ToDouble(Console.ReadLine());
            double area = lado * lado;
            Console.WriteLine($"Área del cuadrado: {area:F2} unidades cuadradas");
        }

        static void AreaRectangulo()
        {
            Console.Clear();
            Console.Write("Ingrese la base del rectángulo: ");
            double baseRect = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la altura del rectángulo: ");
            double altura = Convert.ToDouble(Console.ReadLine());
            double area = baseRect * altura;
            Console.WriteLine($"Área del rectángulo: {area:F2} unidades cuadradas");
        }

        static void AreaCirculo()
        {
            Console.Clear();
            Console.Write("Ingrese el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            double area = Math.PI * radio * radio;
            Console.WriteLine($"Área del círculo: {area:F2} unidades cuadradas");
        }

        static void AreaTriangulo()
        {
            Console.Clear();
            Console.Write("Ingrese la base del triángulo: ");
            double baseTri = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la altura del triángulo: ");
            double altura = Convert.ToDouble(Console.ReadLine());
            double area = (baseTri * altura) / 2;
            Console.WriteLine($"Área del triángulo: {area:F2} unidades cuadradas");
        }

        static void AreaTrapecio()
        {
            Console.Clear();
            Console.Write("Ingrese la base mayor del trapecio: ");
            double baseMayor = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la base menor del trapecio: ");
            double baseMenor = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la altura del trapecio: ");
            double altura = Convert.ToDouble(Console.ReadLine());
            double area = ((baseMayor + baseMenor) * altura) / 2;
            Console.WriteLine($"Área del trapecio: {area:F2} unidades cuadradas");
        }
    }
}
