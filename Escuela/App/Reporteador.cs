using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using Escuela.Entidades;

namespace CoreEscuela.Entidades
{
    //una clase estatica debe tener un constructos estatico, estatica no olvide que no necesita instanciarse
    //los constructores estaticos no reciben parametros, por eso no utilizamos la clase static
    public class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjecEsc)
        {
            //esta excepcion la usamos por si nos mandan un diccionario nulo,, hacemos fallar la aplicacion
            if(dicObjecEsc == null)
                throw new ArgumentNullException(nameof(dicObjecEsc));
            _diccionario = dicObjecEsc;
        }

        //para exponer una lista, es buena practica brindarla en un Ienumerable o en una lista de solo lectura
        public IEnumerable<Evaluacion> getListaEvaluaciones()
        {
            //TryGetVlaue "intenta traerlo y arroja un bool y nos devuelve un parametro de salida en donde se guardara lo que trae"
            if(_diccionario.TryGetValue(LlavesDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase>lista))
                 return lista.Cast<Evaluacion>();
            else
                 return new List<Evaluacion>();
        }
        //Sobrecarga del metodo getListaAsignaturas
        public IEnumerable<String> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<String> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = getListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones 
                    //where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetDicEvaluXAsign()
        {
            var diccionario = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsignaturas = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asignatura in listaAsignaturas)
            {
                var evalsAsign = from ev in listaEvaluaciones
                                 where ev.Asignatura.Nombre == asignatura 
                                 select ev;
                diccionario.Add(asignatura,evalsAsign);
            }

            return diccionario;
        }


    }
}