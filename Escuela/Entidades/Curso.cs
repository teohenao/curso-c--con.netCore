using System;
using System.Collections.Generic;
using School.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {
        public TiposJornada TipoJornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public void limpiarLugar()
        {
            Printer.dibujarLinea();
            Console.WriteLine("Limpiando establecimiento....");
            Console.Write(Nombre + " limpio");
        }

        public Curso()
        {

        }
    }
}