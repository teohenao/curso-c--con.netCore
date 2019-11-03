using static System.Console;

namespace School.Util
{
    public static class Printer
    {
        public static void dibujarLinea(int tamanio = 10)
        {
            //padleft sirve para rellenar , cantidad int, char ''
            WriteLine("".PadLeft(tamanio,'='));
        }
        public static void dibujarTitulo(string titulo)
        {
            var tamanio = titulo.Length+4;
            dibujarLinea(tamanio);
            WriteLine($"| {titulo} |");
            dibujarLinea(tamanio);
        }
    }
}
