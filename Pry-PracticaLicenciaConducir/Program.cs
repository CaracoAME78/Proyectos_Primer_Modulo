namespace Pry_PracticaLicenciaConducir
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Práctica de Examen de Licencia de Conducir";
            Console.WriteLine("=== PRÁCTICA DEL EXAMEN DE LICENCIA DE CONDUCIR ===\n");

            List<Pregunta> preguntas = ObtenerPreguntas();
            int puntaje = 0;

            for (int i = 0; i < preguntas.Count; i++)
            {
                Console.WriteLine($"\nPregunta {i + 1}: {preguntas[i].Texto}");
                for (int j = 0; j < preguntas[i].Opciones.Count; j++)
                {
                    Console.WriteLine($"  {j + 1}. {preguntas[i].Opciones[j]}");
                }

                int respuesta;
                do
                {
                    Console.Write("Tu respuesta (1, 2 o 3): ");
                } while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 3);

                if (respuesta - 1 == preguntas[i].RespuestaCorrecta)
                {
                    Console.WriteLine("✅ Correcto!");
                    puntaje++;
                }
                else
                {
                    Console.WriteLine($"❌ Incorrecto. Respuesta correcta: {preguntas[i].RespuestaCorrecta + 1}. {preguntas[i].Opciones[preguntas[i].RespuestaCorrecta]}");
                }
            }

            Console.WriteLine($"\nResultado final: {puntaje} de {preguntas.Count} correctas.");
            if (puntaje >= preguntas.Count * 0.7)
            {
                Console.WriteLine("🎉 ¡Felicidades! Has aprobado la práctica.");
            }
            else
            {
                Console.WriteLine("😕 No alcanzaste el puntaje mínimo. ¡Sigue practicando!");
            }

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }

        static List<Pregunta> ObtenerPreguntas()
        {
            return new List<Pregunta>
            {
                new Pregunta(
                    "¿Cuál es el límite máximo de velocidad en zona urbana salvo señalización?",
                    new List<string> { "50 km/h", "60 km/h", "40 km/h" },
                    0
                ),
                new Pregunta(
                    "¿Qué indica una luz amarilla intermitente en un semáforo?",
                    new List<string> { "Prohibido el paso", "Precaución, cruce con cuidado", "Debe detenerse completamente" },
                    1
                ),
                new Pregunta(
                    "¿En qué caso se puede adelantar por la derecha?",
                    new List<string> { "Cuando el vehículo adelante gira a la izquierda", "Siempre que haya espacio", "Nunca" },
                    0
                ),
                new Pregunta(
                    "¿Cuál es el nivel permitido de alcohol en sangre para conductores particulares?",
                    new List<string> { "0.5 g/l", "0.8 g/l", "0.0 g/l" },
                    0
                ),
                new Pregunta(
                    "¿Qué debe hacer si se encuentra con un peatón en un paso peatonal sin semáforo?",
                    new List<string> { "Acelerar para pasar primero", "Tocar claxon", "Detenerse y ceder el paso" },
                    2
                ),
            };
        }
    }

    class Pregunta
    {
        public string Texto { get; }
        public List<string> Opciones { get; }
        public int RespuestaCorrecta { get; }

        public Pregunta(string texto, List<string> opciones, int respuestaCorrecta)
        {
            Texto = texto;
            Opciones = opciones;
            RespuestaCorrecta = respuestaCorrecta;
        }
    }
}