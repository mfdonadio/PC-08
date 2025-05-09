
public class TableroJ2 : TableroJ1
{
    protected string [,] TableroJugador2;
    public TableroJ2()
    {
        TableroJugador2 = new string[6,6];
        EscribirTableroBase2();    

        //Inicializar barcos
        submarino = new Barco("Submarino", 2, 2, 0, 0);
        fragata = new Barco("Fragata", 3, 3, 0, 0);
        destructor = new Barco("Destructor", 4, 4, 0, 0);
    }

    public void EscribirTableroBase2()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                TableroJugador2[i,j] = " ■ ";
            }
        }
    }

    // Sobrescribir el método para generar configuración inicial
    public new void GenerarConfiguracionInicial()
    {
        LimpiarTablero();
        submarino.ColocarBarco(TableroJugador2);
        fragata.ColocarBarco(TableroJugador2);
        destructor.ColocarBarco(TableroJugador2);
    }

    // Método para limpiar el tablero del jugador 2
    public new void LimpiarTablero()
    {
        EscribirTableroBase2();
    }

    public void MostrarTablero2()
    {   
        Console.WriteLine("\t\t=================================");
        Console.Write("\t\tTABLERO POSICIÓN NAVAL: JUGADOR 2");
        Console.WriteLine("\n\t\t=================================");
        Console.WriteLine("   1  2  3  4  5  6");
        for (int i = 0; i < 6; i++)
        {
            Console.Write((char)('A'+ i)+" ");
            for (int j = 0; j < 6; j++)
            {
                if (TableroJugador2[i,j] == " S ")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" ■ ");
                }
                else if(TableroJugador2[i,j] == " F ")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(" ■ ");
                }
                else if(TableroJugador2[i,j] == " D ")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ■ ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(TableroJugador2[i,j]);
                }
                
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        
    }
    
    public  string[,] GetTablero2()
    {
        return TableroJugador2;
    }
}