
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    /** Selead permite crear instancias de esa clase, pero no heredarla "Sellada" */
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {
            Escuela = new Escuela("escuela teo", 2019, TiposEscuela.Prescolar,
                                   pais: "coooloommmbia", ciudad: "Calarcaaa"
                                 );

            cargarCursos();
            cargarAsignaturas();
            cargarEvaluaciones();
        }

        private void cargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i+1}",
                                Nota = (float)(5*rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void cargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
               var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Español"},
                    new Asignatura{Nombre="Ingles"},
                    new Asignatura{Nombre="Programacion"},
                    new Asignatura{Nombre="Tecnologia"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> generarAlumnos(int cantidad)
        {
            string[] nombre1 = {"alba","mateo","henrry","geraldine","santiago"};
            string[] apellido1 = {"ruiz","sarmiento","uribe","trump","maduro"};
            string[] nombre2 = {"freddy","anabel","murty","silvana","teodoro"};

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno{Nombre= $" {n1} {n2} {a1} " };
            return listaAlumnos.OrderBy( (al)=> al.UniqueId ).Take(cantidad).ToList();
        }

        private void cargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
            new Curso(){Nombre = "101",TipoJornada = TiposJornada.Mañana},
            new Curso(){Nombre = "201",TipoJornada = TiposJornada.Tarde},
            new Curso(){Nombre = "301",TipoJornada = TiposJornada.Noche},
            new Curso(){Nombre = "401",TipoJornada = TiposJornada.Mañana},
            new Curso(){Nombre = "501",TipoJornada = TiposJornada.Mañana}
            };

            Random r = new Random();
            //next para aproximar al entero, entre 5 y 20 estudiantes
            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRandom = r.Next(5,20);
                curso.Alumnos = generarAlumnos(cantidadRandom);
            }
        }

        //metodo que obtiene una lista de todos los objetos 
        public List<ObjetoEscuelaBase> GetObjetoEscuelaBases()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            //por ser una lista
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);
                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }
            return listaObj;
        }

    }
}