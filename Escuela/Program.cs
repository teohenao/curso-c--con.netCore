using System;
using System.Collections.Generic;
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
            ImprimirCursosEscuela(engine.Escuela);
        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.dibujarLinea(20);
            Printer.dibujarTitulo("cursos de la escuela");
            Printer.dibujarLinea(20);
            if(escuela?.Cursos==null)
            return;
            else
            {
                 foreach (var curso in escuela.Cursos)
                {
                 WriteLine($"nombre: {curso.Nombre}, id: {curso.UniqueId}");
                }
            }
        }

        private static bool predicado(Curso c)
        {
            return c.Nombre == "vacacional";
        }
    }
}
