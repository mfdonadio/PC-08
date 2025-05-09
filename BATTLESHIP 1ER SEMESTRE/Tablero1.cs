public class TableroJ1
{
    protected string [,] TableroJugador1;
    protected Barco submarino;
    protected Barco fragata;
    protected Barco destructor; 


    
    public TableroJ1()
    {
        TableroJugador1 = new string[6,6];
        EscribirTableroBase();    

        //Inicializar barcos
        submarino = new Barco("Submarino", 2, 2, 0, 0);
        fragata = new Barco("Fragata", 3, 3, 0, 0);
        destructor = new Barco("Destructor", 4, 4, 0, 0);
    }

    public void EscribirTableroBase()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                TableroJugador1[i,j] = " ■ ";
            }
        }
    }

    public void GenerarConfiguracionInicial()
    {
        LimpiarTablero();
        submarino.ColocarBarco(TableroJugador1);
        fragata.ColocarBarco(TableroJugador1);
        destructor.ColocarBarco(TableroJugador1);
    }

    public void LimpiarTablero()
    {
        EscribirTableroBase();
    }

   public void MostrarTablero()
{   
    Console.WriteLine("\t\t=================================");
    Console.Write("\t\tTABLERO POSICIÓN NAVAL: JUGADOR 1");
    Console.WriteLine("\n\t\t=================================");
    Console.WriteLine("   1  2  3  4  5  6");
    for (int i = 0; i < 6; i++)
    {
        Console.Write((char)('A'+ i)+" ");
        for (int j = 0; j < 6; j++)
        {
            if (TableroJugador1[i,j] == " S ")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ■ ");
            }
            else if(TableroJugador1[i,j] == " F ")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" ■ ");
            }
            else if(TableroJugador1[i,j] == " D ")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" ■ ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(TableroJugador1[i,j]);
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
    }
}

    public string[,] GetTablero()
    {
        return TableroJugador1;
    }

}

public class TableroNavalJ1
{}