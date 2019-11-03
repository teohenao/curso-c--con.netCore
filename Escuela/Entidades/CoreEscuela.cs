using System;
using System.Collections.Generic;

namespace  CoreEscuela.Entidades
{
    //no importa el nombre de la clase coincida con el de la clase
    public class Escuela :ObjetoEscuelaBase
    {
        //asi el, se encarga de generar la logica de arriba de get setm y incluso los declara
        public int añoCreacion{get;set;}
        public string Pais { get; set;}
        public string Ciudad { get; set;}
        public TiposEscuela TipoEscuela {get; set;}    
        public List<Curso> Cursos { get; set; }

        //inicializador
        public Escuela(string nombre,int año)=> (Nombre,añoCreacion) = (nombre,año);
        public Escuela(string nombre,int año,
            TiposEscuela tipos, string pais = "", string ciudad ="")
        {
            //asignacion de tuplas 
            (Nombre,añoCreacion) = (nombre,año);
            Pais = pais;
            Ciudad = ciudad;
        }

        //ToString del objeto
        public override string ToString()
        {
            return $"Nombre: {Nombre},Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}