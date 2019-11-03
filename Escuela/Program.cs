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

            Printer.dibujarLinea(20);
            Printer.dibujarTitulo("Pruebas de polimorfirmo");

            var alumnoTest = new Alumno { Nombre = "alumno test" };
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.dibujarTitulo("Objeto escuela-alumno");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var evaluacion = new Evaluacion() { Nombre = "Evaluacion de matematicas", Nota = 4.5f };
            Printer.dibujarTitulo("Objeto evaluacion");
            WriteLine($"Alumno: {evaluacion.Nombre}");
            WriteLine($"Alumno: {evaluacion.UniqueId}");
            WriteLine($"Nota : {evaluacion.Nota}");
            WriteLine($"Alumno: {evaluacion.GetType()}");

            ob = evaluacion;
            Printer.dibujarTitulo("Objeto-evaluacion");
            WriteLine($"Nombre: {ob.Nombre}");
            WriteLine($"Id: {ob.UniqueId}");
            WriteLine($"Alumno: {evaluacion.GetType()}");


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
