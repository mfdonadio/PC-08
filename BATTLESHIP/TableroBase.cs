public abstract class TableroBase : ITablero
{
    protected const int TAMAÑO_TABLERO = 6; // Tamaño fijo del tablero (6x6)
    protected string[,] tablero; // Matriz que representa el tablero
    protected Barco submarino;  // Referencia al barco Submarino
    protected Barco fragata; // Referencia al barco Fragata
    protected Barco destructor; // Referencia al barco Destructor


        // Constructor: inicializa la matriz y los barcos
    public TableroBase()
    {
        tablero = new string[TAMAÑO_TABLERO, TAMAÑO_TABLERO];
        submarino = new Barco("Submarino", 2, 2);
        fragata = new Barco("Fragata", 3, 3);
        destructor = new Barco("Destructor", 4, 4);
    }


    // Llena el tablero con el símbolo de casilla vacía ("■")
    protected void EscribirTableroBase()
    {
        for (int i = 0; i < TAMAÑO_TABLERO; i++)
        {
            for (int j = 0; j < TAMAÑO_TABLERO; j++)
            {
                tablero[i, j] = " ■ ";
            }
        }
    }

    // Genera la configuración inicial del tablero y coloca los barcos
    public virtual void GenerarConfiguracionInicial()
    {
        LimpiarTablero(); // Limpia el tablero antes de colocar los barcos
        submarino.ColocarBarco(tablero);
        fragata.ColocarBarco(tablero);
        destructor.ColocarBarco(tablero);
    }


    // Limpia el tablero, dejándolo solo con casillas vacías
    public virtual void LimpiarTablero()
    {
        EscribirTableroBase();
    }


    // Muestra el tablero en la consola con encabezado y filas
    public virtual void MostrarTablero()
    {
        // Muestra el encabezado y el resto del tablero
        MostrarEncabezado();
        MostrarRestoTablero();
    }
    
    // Muestra el encabezado del tablero (título y números de columna)
    protected virtual void MostrarEncabezado()
    {
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("\t\tTABLERO POSICIÓN NAVAL");
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("   1  2  3  4  5  6");
    }

    
      // Muestra el resto del tablero, fila por fila
    protected virtual void MostrarRestoTablero()
    {
        for (int i = 0; i < TAMAÑO_TABLERO; i++)
        {
            Console.Write((char)('A' + i) + " "); // Letra de la fila
            for (int j = 0; j < TAMAÑO_TABLERO; j++)
            {
                MostrarCelda(i,j);
            }
            Console.WriteLine();
        }
    }

    // Muestra una celda del tablero con color según el contenido
    protected virtual void MostrarCelda(int i, int j)
    {
        if (tablero[i, j] == " S ") //Color para el submarino. 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ■ ");
        }
        else if (tablero[i, j] == " F ") // Color para la fragata.
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" ■ ");
        }
        else if (tablero[i, j] == " D ") // Color para el destructor. 
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ■ ");
        }
        else if (tablero[i, j] == " X ") // Símbolo y color en donde el enemigo acertó un misil y le dio a un barco.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" X ");
        }
        else if (tablero[i, j] == " O ") // Símbolo y color en donde el enemigo falló su disparo y le dio al agua. 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" O ");
        }
        else // Color azul para casillas vacías (donde hay agua)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(tablero[i, j]);
        }

        Console.ForegroundColor = ConsoleColor.White; // Regresa el color a blanco. 
    }

    public virtual string[,] GetTablero()
    {
        return tablero;
    }

    // Permite atacar una posición específica del tablero
    // fila: letra de la fila (A-F), columna: número de columna (0-5)
    // Devuelve true si el ataque fue exitoso, false si falló o ya fue atacado
    public virtual bool Atacar(char fila, int columna)
    {
        // Convertir la letra de la fila a un índice numérico.
        int filaIndex = fila - 'A';

        // Verificar que las coordenadas sean válidas
        if (filaIndex >= 0 && filaIndex < TAMAÑO_TABLERO && columna >= 0 && columna < TAMAÑO_TABLERO)
        {
            //Verificar si el lanzamitno le atina a un barco
            if (tablero[filaIndex, columna] == " S " || tablero[filaIndex, columna] == " F " ||
                 tablero[filaIndex, columna] == " D ")
            {
                Console.WriteLine("¡Le diste a un barco!");
                tablero[filaIndex, columna] = " X "; //Marcar el impacto
                return true;
            }
            else
            {
                Console.WriteLine("Le diste.... pero al agua :(");
                tablero[filaIndex, columna] = " O "; // Marca el fallo
                return false;
            }
        }
        else
        {
            Console.WriteLine("Coordenadas inválidas. Inténtalo de nuevo.");
            return false;
        }
    }
}