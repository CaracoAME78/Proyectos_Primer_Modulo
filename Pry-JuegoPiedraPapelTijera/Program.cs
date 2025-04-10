namespace Pry_JuegoPiedraPapelTijera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Juego: Piedra, Papel o Tijera";
            Console.WriteLine("=== JUEGO: PIEDRA, PAPEL O TIJERA ===");

            string[] opciones = { "Piedra", "Papel", "Tijera" };
            bool jugarDeNuevo = true;

            while (jugarDeNuevo)
            {
                Console.WriteLine("\nElige una opción:");
                Console.WriteLine("1. Piedra");
                Console.WriteLine("2. Papel");
                Console.WriteLine("3. Tijera");

                int eleccionUsuario;
                while (!int.TryParse(Console.ReadLine(), out eleccionUsuario) || eleccionUsuario < 1 || eleccionUsuario > 3)
                {
                    Console.Write("Entrada inválida. Ingresa 1, 2 o 3: ");
                }

                string eleccionJugador = opciones[eleccionUsuario - 1];

                Random rnd = new Random();
                string eleccionPC = opciones[rnd.Next(0, 3)];

                Console.WriteLine($"\nTú elegiste: {eleccionJugador}");
                Console.WriteLine($"La computadora eligió: {eleccionPC}");

                string resultado = ObtenerResultado(eleccionJugador, eleccionPC);
                Console.WriteLine($"\nResultado: {resultado}");

                Console.Write("\n¿Deseas jugar otra vez? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();
                jugarDeNuevo = (respuesta == "s");
            }

            Console.WriteLine("\nGracias por jugar. ¡Hasta la próxima!");
            Console.ReadKey();
        }

        static string ObtenerResultado(string jugador, string pc)
        {
            if (jugador == pc)
                return "¡Empate!";
            else if ((jugador == "Piedra" && pc == "Tijera") ||
                     (jugador == "Papel" && pc == "Piedra") ||
                     (jugador == "Tijera" && pc == "Papel"))
                return "¡Ganaste!";
            else
                return "Perdiste.";
        }
    }
}