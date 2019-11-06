
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using Escuela.Entidades;
using School.Util;

namespace CoreEscuela.Entidades
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
        public void ImprimirDiccionario(Dictionary<LlavesDiccionario,IEnumerable<ObjetoEscuelaBase>> dic
                        ,bool imprEval = false)
        {
            foreach (var obj in dic)
            {
                Printer.dibujarTitulo(obj.Key.ToString());
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlavesDiccionario.Evaluacion:
                        if(imprEval)
                            Console.WriteLine(val);
                        break;
                        case LlavesDiccionario.Escuela:
                            Console.WriteLine("Escuela: "+val);
                        break;
                        case LlavesDiccionario.Alumno:
                            Console.WriteLine("Alumno: "+val);
                        break;
                        case LlavesDiccionario.Curso:
                        var cursTemp = val as Curso;
                        if(cursTemp != null){
                            int cantEs = ((Curso)val).Alumnos.Count();
                            Console.WriteLine("Curso: "+val.Nombre+" con cantidad de estudiantes de: "+cantEs);
                        }
                        break;
                        default:
                            Console.WriteLine(val);
                        break;
                    }
                }
            }
        }

        public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            //constantes son valores fijos dentro del programa
            var diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlavesDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlavesDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            //esta lista de evaluaciones toca hacerlo asi por que se estaba repitiendo la llave en el siguiente for
            var listTempEv = new List<Evaluacion>();
            var listTempAs = new List<Asignatura>();
            var listTempAl = new List<Alumno>();
            foreach (var curso in Escuela.Cursos)
            {
                listTempAl.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listTempEv.AddRange(alumno.Evaluaciones);
                }
                listTempAs.AddRange(curso.Asignaturas);
            }
            diccionario.Add(LlavesDiccionario.Asignatura, listTempAs.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.Alumno, listTempAl.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.Evaluacion, listTempEv.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }


        //SobreCarga de metodos, para que no nos brinde ninguna salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
         bool traeEvaluaciones = true,
         bool traeAlumnos = true,
         bool traeAsignaturas = true,
         bool traeCursos = true
         )
        {
            return GetObjetoEscuelaBases(
                out int dummy, out dummy, out dummy, out dummy
            );
        }
        //sobrecarga de metodos para un parametro de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
      )
        {
            return GetObjetoEscuelaBases(
                out conteoEvaluaciones, out int dummy, out dummy, out dummy
            );
        }
        //sobrecarga de metodos para dos parametros de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones, out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
      )
        {
            return GetObjetoEscuelaBases(
                out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy
            );
        }
        //sobrecarga de metodos para tres parametros de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones, out int conteoCursos, out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
      )
        {
            return GetObjetoEscuelaBases(
                out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy
            );
        }
        //metodo que obtiene una lista de todos los objetos "IReadOnlyList para que sea una lista de solo lectura"
        //recordar siempre los parametros opcionales deben estar de ultimos, no acepta los obligatoriosd se ultimo
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            //por ser una lista
            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);
            }
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                }
                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                }
                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            //return (listaObj,conteoEvaluaciones);
            return listaObj.AsReadOnly();
        }


        private List<Alumno> generarAlumnos(int cantidad)
        {
            string[] nombre1 = { "alba", "mateo", "henrry", "geraldine", "santiago" };
            string[] apellido1 = { "ruiz", "sarmiento", "uribe", "trump", "maduro" };
            string[] nombre2 = { "freddy", "anabel", "murty", "silvana", "teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $" {n1} {n2} {a1} " };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        #region Metodos de Carga
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
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                //redondea, y dos numeros de decimales
                                Nota = MathF.Round((float)(5 * rnd.NextDouble())
                                                   ,2),
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
                int cantidadRandom = r.Next(5, 20);
                curso.Alumnos = generarAlumnos(cantidadRandom);
            }
        }
        #endregion

    }
}

