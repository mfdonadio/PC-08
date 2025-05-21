// Clase que representa el tablero naval del Jugador 1.
public class TableroJugador1 : TableroBase
{
    // Sobrescribe el encabezado para personalizarlo para el Jugador 1.
    protected override void MostrarEncabezado()
    {
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("\t\tTABLERO POSICIÓN NAVAL: JUGADOR 1");
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("   1  2  3  4  5  6");
    }
}