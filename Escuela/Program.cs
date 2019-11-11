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
            /******EVENTOOOSSS*/
            //AppDomain es de .netcore y es donde se ejecutan las aplicaciones en un momento determinado
            //current domain es donde se esta ejecutando la aplicacion
            //este evento es lo que pasa cuando la aplicacion esta finalizando
            AppDomain.CurrentDomain.ProcessExit += accionDelMetodo;
            //se puede tener dos eventos para un caso y se acumulan
            //la expresion lamda recibe cualquiercosa por parametros, pero el los pide dependiendo el metodo
            AppDomain.CurrentDomain.ProcessExit += (s,h)=>Console.WriteLine("evento2 saliendo");
            //se pueden tener la candidad de delegados que uno quiera como eventos, asi se puede quitar la accion, y nunca la realiza
            AppDomain.CurrentDomain.ProcessExit -= accionDelMetodo;
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
            engine.ImprimirDiccionario(dicTemp);

            var repor = new Reporteador(engine.GetDiccionarioObjetos());
            var evaList = repor.getListaEvaluaciones();
            var asigList = repor.GetListaAsignaturas();
            var listaEvaluacionesXAsing = repor.GetDicEvaluXAsign();
            

        }

        private static void accionDelMetodo(object sender, EventArgs e)
        {
            Printer.dibujarTitulo("Saliendo");
            Console.WriteLine("beeeppp");
            Printer.dibujarTitulo("Salio");
        }

        private static bool predicado(Curso c)
        {
            return c.Nombre == "vacacional";
        }
    }
}
