// Clase que representa el tablero naval del Jugador 2.
public class TableroJugador2 : TableroBase
{
    // Sobrescribe el encabezado para personalizarlo para el Jugador 2.
    protected override void MostrarEncabezado()
    {
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("\t\tTABLERO POSICIÓN NAVAL: JUGADOR 2");
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("   1  2  3  4  5  6");
    }
}