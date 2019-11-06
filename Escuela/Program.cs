using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela;
using CoreEscuela.Entidades;
using School.Util;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.dibujarTitulo("Bienvenidos a la escuela");
            //En el diccionario las llaves son unicas
            Dictionary<int,string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"JuanK");
            diccionario.Add(23,"Lorem Psum");

            foreach (var keyVailPair in diccionario)
            {
                Console.WriteLine("LLave es : "+keyVailPair.Key+ " valor : "+keyVailPair.Value);
            }

            Printer.dibujarTitulo("Acceso a diccionario");
            diccionario[0] = "prueba 0";
            Console.WriteLine(diccionario[23]);

            Printer.dibujarTitulo("Otro Diccionario");
            var dic = new Dictionary<string, string>();

            var dicTemp = engine.GetDiccionarioObjetos();

        }
       

        private static bool predicado(Curso c)
        {
            return c.Nombre == "vacacional";
        }
    }
}
