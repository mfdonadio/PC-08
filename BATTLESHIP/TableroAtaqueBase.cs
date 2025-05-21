using System.Data;
// Clase base abstracta para los tableros de ataque de los jugadores
public abstract class TableroAtaqueBase : ITableroAtaque
{
    protected const int TAMAÑO_TABLERO = 6; // Tamaño fijo del tablero (6x6)
    protected string[,] tablero; // Matriz que representa el tablero de ataques

    public TableroAtaqueBase()
    {
        // Inicializa la matriz del tablero de ataques
        tablero = new string[TAMAÑO_TABLERO, TAMAÑO_TABLERO];
    }


    // Llena el tablero con el símbolo de agua "~" (sin ataques)
    protected void EscribirTableroBase()
    {
        for (int i = 0; i < TAMAÑO_TABLERO; i++)
        {
            for (int j = 0; j < TAMAÑO_TABLERO; j++)
            {
                tablero[i, j] = " ~ ";
            }
        }
    }


    // Genera la configuración inicial del tablero de ataque (lo limpia)
    public virtual void GenerarConfiguracionInicial()
    {
        LimpiarTablero();
    }


    // Limpia el tablero de ataque, dejándolo vacío (solo agua)
    public virtual void LimpiarTablero()
    {
        EscribirTableroBase();
    }


    // Muestra el tablero de ataque en consola
    public virtual void MostrarTablero()
    {
        MostrarEncabezado();
        MostrarRestoTablero();
    }
 

    // Muestra el encabezado del tablero (título y números de columna)
    protected virtual void MostrarEncabezado()
    {
        Console.WriteLine("\t\t=================================");
        Console.WriteLine("\t\tTABLERO ATAQUES EFECTUADOS");
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


     // Muestra una celda del tablero con color según el resultado del ataque
    protected virtual void MostrarCelda(int i, int j)
    {
        if (tablero[i, j] == " X ") // Color y símbolo para aciertos.
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; 
            Console.Write(" X ");
        }
        else if (tablero[i, j] == " O ") // Color y símbolo para fallos. 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" O ");
        }
        else // Color para el agua. 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(tablero[i, j]);
        }
        Console.ForegroundColor = ConsoleColor.White; // Regresa el color a blanco. 
    }

    // Devuelve la matriz que representa el tablero de ataque
    public virtual string[,] GetTableroAtaque()
    {
        return tablero;
    }
    

    // Marca el resultado de un ataque en el tablero
    // fila: letra de la fila (A-F), columna: número de columna (0-5), impacto: true=acierto, false=fallo
    public void MarcarAtaque(char fila, int columna, bool impacto)
    {
        // Convierte la letra de la fila a un indice numerico
        int filaIndex = fila - 'A';


        // Verifica que la fila y columna estén dentro del rango del tablero
        if (filaIndex >= 0 && filaIndex < TAMAÑO_TABLERO && columna >= 0 && columna < TAMAÑO_TABLERO)
        {
            if (impacto)
            {
                tablero[filaIndex, columna] = " X "; //Marcar acierto
            }
            else
            {
                tablero[filaIndex, columna] = " O "; //Marcar fallo
            }
        }
    }
}