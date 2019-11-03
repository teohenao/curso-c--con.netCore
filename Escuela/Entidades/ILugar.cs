namespace CoreEscuela.Entidades
{
    /**Interfaz es la deficion o plantilla de lo que debe tener un objeto */
    //las clases de interfaz no tienen modificadores de acceso, buena practica
    public interface ILugar
    {
        string Direccion { get; set; }

        //los metodos de la interfaz solo se declaran para ser usados
        void limpiarLugar();
    }
}