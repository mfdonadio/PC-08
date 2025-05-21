// Clase que representa el tablero de ataques del Jugador 2.
public class TableroAtaqueJugador2 : TableroAtaqueBase
{
    // Sobrescribe el encabezado para personalizarlo para el Jugador 2.
    protected override void MostrarEncabezado()
    {
        Console.WriteLine("\t\t===============================");
        Console.WriteLine("\t\tATAQUES REALIZADOS: JUGADOR 2");
        Console.WriteLine("\t\t===============================");
        Console.WriteLine("   1  2  3  4  5  6");
    }
}