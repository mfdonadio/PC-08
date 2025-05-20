using System;

namespace SEMANA_18
{
    public interface IAlumnos 
    {
        string Nombre { get; set; }
        double [] Notas { get; set;}

        void IngresarNotas();
        void MostrarNotas();
        void MostrarNotasPerdidas();
    }
}