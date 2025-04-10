using System.Security.Cryptography;
using System.Text;


namespace GeneradorContraseñas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Generador y Encriptador de Contraseñas";
            Console.WriteLine("=== GENERADOR DE CONTRASEÑAS ===");

            Console.Write("Ingrese la longitud de la contraseña: ");
            int longitud = Convert.ToInt32(Console.ReadLine());

            Console.Write("¿Incluir letras minúsculas? (s/n): ");
            bool incluirMinusculas = Console.ReadLine().ToLower() == "s";

            Console.Write("¿Incluir letras mayúsculas? (s/n): ");
            bool incluirMayusculas = Console.ReadLine().ToLower() == "s";

            Console.Write("¿Incluir números? (s/n): ");
            bool incluirNumeros = Console.ReadLine().ToLower() == "s";

            Console.Write("¿Incluir símbolos? (s/n): ");
            bool incluirSimbolos = Console.ReadLine().ToLower() == "s";

            string password = GenerarContrasena(longitud, incluirMinusculas, incluirMayusculas, incluirNumeros, incluirSimbolos);

            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("\nDebe seleccionar al menos un tipo de carácter.");
                return;
            }

            Console.WriteLine($"\nContraseña generada: {password}");

            Console.Write("\nIngrese una clave secreta para encriptar: ");
            string claveSecreta = Console.ReadLine();

            string passwordEncriptada = Encriptar(password, claveSecreta);
            Console.WriteLine($"\n🔒 Contraseña encriptada: {passwordEncriptada}");

            Console.Write("\n¿Deseas desencriptarla ahora? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                string desencriptada = Desencriptar(passwordEncriptada, claveSecreta);
                Console.WriteLine($"🔓 Contraseña desencriptada: {desencriptada}");
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }

        static string GenerarContrasena(int longitud, bool minusculas, bool mayusculas, bool numeros, bool simbolos)
        {
            const string letrasMin = "abcdefghijklmnopqrstuvwxyz";
            const string letrasMay = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string nums = "0123456789";
            const string simb = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            StringBuilder conjunto = new StringBuilder();
            if (minusculas) conjunto.Append(letrasMin);
            if (mayusculas) conjunto.Append(letrasMay);
            if (numeros) conjunto.Append(nums);
            if (simbolos) conjunto.Append(simb);

            if (conjunto.Length == 0) return "";

            Random rnd = new Random();
            StringBuilder resultado = new StringBuilder();
            for (int i = 0; i < longitud; i++)
            {
                int index = rnd.Next(conjunto.Length);
                resultado.Append(conjunto[index]);
            }

            return resultado.ToString();
        }

        static string Encriptar(string textoPlano, string clave)
        {
            using (Aes aes = Aes.Create())
            {
                var key = DerivarClave(clave, aes.KeySize / 8);
                var iv = DerivarClave(clave + "iv", aes.BlockSize / 8);

                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(textoPlano);
                    sw.Close();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        static string Desencriptar(string textoEncriptado, string clave)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    var key = DerivarClave(clave, aes.KeySize / 8);
                    var iv = DerivarClave(clave + "iv", aes.BlockSize / 8);

                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor();

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                return "⚠️ Error al desencriptar: clave incorrecta o datos corruptos.";
            }
        }

        static byte[] DerivarClave(string clave, int tamaño)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(clave));
                Array.Resize(ref hash, tamaño);
                return hash;
            }
        }
    }
}