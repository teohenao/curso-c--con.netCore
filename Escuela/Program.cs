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
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetoEscuelaBases();

            //Consulta para traer los objetos de un tipo, en este caso de tipo interface que se le dio, trae
            //los que implementan esa interfaz
            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar) obj;

            //engine.Escuela.limpiarLugar();
        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.dibujarLinea(20);
            Printer.dibujarTitulo("cursos de la escuela");
            Printer.dibujarLinea(20);
            if (escuela?.Cursos == null)
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
