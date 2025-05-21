using System.Net;

public class Barco
{ //Propiedades de los barcos
    public string Nombre {get; private set;}
    public int Tamaño {get; private set;}
    public int Puntos {get; private set;}
    public int PosicionX;
    public int PosicionY;

    public Barco(string nombre, int tamaño, int puntos)
    { //Constructor que se encarga de inicializar las propiedades de un barco cuando es instanciado. 
        Nombre = nombre; 
        Tamaño = tamaño;
        Puntos = puntos;
    }
    public void ColocarBarco(string[,] tablero)
    { //Método que se encarga de posicionar de manera aletoria los barcos en el tablero. 
        Random random = new Random();// Iniciliza un random
        bool colocado = false; // Se decalara una variable local que nos ayudará con la iteracion de colocación. 

        string simboloBarco = ObtenerSimbolo(); // Utilizando el método ObtenerSimbolo se extrae el símbolo de barco instanciado y se asigna a la variable local 'simboloBarco'.
        
        // Bucle que coloca los barcos instanciados hasta que se validan las condiciones de posicionamniento y 'colocado' se asigne como "true"
        while (!colocado)
        {
            int x = random.Next(0, tablero.GetLength(0)); //Genera un número aleatorio para 'x' válido, utilizando desde la posición '0' hasta el último valor de la fila. 
            int y = random.Next(0, tablero.GetLength(1)); //Genera un número aleatorio para 'y' válido, utilizando desde la posición '0' hasta el último valor de las columnas
            int orientacion = DeterminarOrientacion(); // LLama a el método DeterminarOrientacion y asigna el valor que regrese a la variable orienctación. 

            if (PuedeColocarse(tablero, x, y, orientacion)) //Crea una condición llamando a el método PuedeColocarse con los parámetros necesarios.
            {
                ColocarEnTablero(tablero, x, y, orientacion, simboloBarco); // Si la copndición se cumple, entonces se llama a el método ColocarEnTablero con los parámetros necesarios. 
                PosicionX = x; // 'x' es asignada a la propiedada PosicionX del barco.
                PosicionY = y; // 'y' es asignada a la propiedada PosicionY del barco. 
                colocado = true; // el valor de colocado se vuelve 'true' y la iteración de colocación se detiene.
            }
        }
    }


    // Este método sirve unicamenate para determinar el símbolo del barco, y según el caso devuelve como valor la inicial del nombre del mismo.
    private string ObtenerSimbolo()
    {
        switch (Nombre)
        {
            case "Submarino": return " S ";
            case "Fragata": return " F ";
            case "Destructor": return " D ";
            default: return " B ";
        }
    }


    //Regresa un número entre 0 y 1, dependiendo del barco y sus condiciones, para determinar si su posición será vertical o horizontal.
    private int DeterminarOrientacion()
    {
        Random random = new Random(); // Se inicializa un nuevo random. 

        switch (Nombre)
        {
            case "Submarino": return 0;// Solo horizontal
            case "Fragata": return 1;// Solo vertical
            case "Destructor": return random.Next(0, 2);// Horizontal o vertical
            default: return random.Next(0, 2); // De ser necesario ...
        }
    }


    // Verifica si un barco se puede colocar en el tablero luego de determinar aleatoriamente su posición en el mismo.
    private bool PuedeColocarse(string[,] tablero, int x, int y, int orientacion)
    {
        //Ya que el tablero es cuadrado (6x6) se determina el valor del tamaño de filas y columnas del mismo. Quiere decir, no importa si es '0' o '1' como el tamaño es lo que nos importa no interfiere. 
        int tamañoTablero = tablero.GetLength(0);

        /* Verifica si cabe horizontalmente.
        Asegura que el barco no se salga del tablero y que todas las casillas donde se quiere poner estén libres.
        Si es así, permite colocarlo; si no, no lo permite.*/
        if (orientacion == 0 && y + Tamaño <= tamañoTablero)
        {
            for (int i = 0; i < Tamaño; i++)
            {
                if (tablero[x, y + i] != " ■ ")
                {
                    return false;
                }
            }
            return true;
        }
        
        /* Verifica si cabe verticalmente.
        Asegura que el barco no se salga del tablero y que todas las casillas donde se quiere poner estén libres.
        Si es así, permite colocarlo; si no, no lo permite.*/
        else if (orientacion == 1 && x + Tamaño <= tamañoTablero)
        {
            for (int i = 0; i < Tamaño; i++)
            {
                if (tablero[x + i, y] != " ■ ")
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    //Coloca el barco en el tablero del jugador. 
    private void ColocarEnTablero(string[,] tablero, int x, int y, int orientacion, string simboloBarco)
    {
        if (orientacion == 0) // Si la horientación es horizontal, en cada iteración del 'for' se le suma una posición a 'y' y se ecribe el símbolo del barco. 
        {
            for (int i = 0; i < Tamaño; i++)
            {
                tablero[x, y + i] = simboloBarco;
            }
        }
        else // Si la horientación vertical, en cada iteración del 'for' se le suma una posición a 'x' y se ecribe el símbolo del barco. 
        {
            for (int i = 0; i < Tamaño; i++)
            {
                tablero[x + i, y] = simboloBarco;
            }
        }
    }
}