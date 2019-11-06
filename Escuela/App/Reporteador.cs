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
        public IEnumerable<Escuela> getListaEvaluaciones()
        {
            IEnumerable<Escuela> rta;
            if(_diccionario.TryGetValue(LlavesDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase>lista))
                rta = lista.Cast<Escuela>();
            else
                rta = null;
           return rta;

        }
    }
}