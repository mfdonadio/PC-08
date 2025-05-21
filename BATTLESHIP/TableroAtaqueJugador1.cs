    // Clase que representa el tablero de ataques del Jugador 1.
    public class TableroAtaqueJugador1 : TableroAtaqueBase
    {
        // Sobrescribe el encabezado para personalizarlo para el Jugador 1.
        protected override void MostrarEncabezado()
    {
        Console.WriteLine("\t\t===============================");
        Console.WriteLine("\t\tATAQUES REALIZADOS: JUGADOR 1");
        Console.WriteLine("\t\t===============================");
        Console.WriteLine("   1  2  3  4  5  6");
    }
    }