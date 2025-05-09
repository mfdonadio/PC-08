public class Barco
{
    public string NombreBarco;
    public int TamañoBarco;
    public int PuntosBarco;
    public int PosicionXBarco;
    public int PosicionYBarco;

    public Barco(string nombreBarco, int tamañoBarco, int puntosBarco, int posicionXBarco, int posicionYBarco)
    {
        NombreBarco = nombreBarco;
        TamañoBarco = tamañoBarco;
        PosicionXBarco = posicionXBarco;
        PosicionYBarco = posicionYBarco;
        PuntosBarco = puntosBarco;
    }
    public void ColocarBarco(string[,] tablero)
    {
        Random random = new Random();
        bool colocado = false;

        string simboloBarco = " B ";

        if (NombreBarco == "Submarino") simboloBarco = " S ";
        if (NombreBarco == "Fragata") simboloBarco = " F ";
        if (NombreBarco == "Destructor") simboloBarco = " D ";


        while (!colocado)
        {
            int x = random.Next(0, 6);
            int y = random.Next(0, 6);
            int orientacion = 0; // 0 = horizontal, 1 = vertical

            if (NombreBarco == "Submarino")
            {
                orientacion = 0; //Solo horizontal
            }
            else if (NombreBarco == "Fragata")
            {
                orientacion = 1; //Solo vertical
            }
            else if (NombreBarco == "Destructor")
            {
                orientacion = random.Next(0, 2); // Horizontal o vertical
            }

            bool espacioLibre = true;
            //Verifica si el barco cabe horizontalmente
            if (orientacion == 0 && y + TamañoBarco <= 6 )
            {

                //Corroborar si hay espacio libre en las casillas
                for (int i = 0; i < TamañoBarco; i++)
                {   
                    if (tablero[x, y + i] != " ■ ")
                    {
                        espacioLibre = false;
                        break;
                    }
                }

                if(espacioLibre)
                {   //Coloca el barco en el tablero
                    for (int i = 0; i < TamañoBarco; i++)
                    {   //La coordenada x se queda igual y se modidifica la y para que a partir de ese punto se escriba el barco en la matriz.
                        tablero[x, y + i] = simboloBarco;
                    }
                    colocado = true;
                }

            } //Verifica si el barco cabe verticalmente
            else if (orientacion == 1 && x + TamañoBarco <= 6)
            {
                espacioLibre = true;
                for (int i = 0; i < TamañoBarco; i++)
                {
                    if (tablero[x + i, y] != " ■ ")
                    {
                        espacioLibre = false;
                        break;
                    }
                }

                if(espacioLibre)
                {
                    for (int i = 0; i < TamañoBarco; i++)
                    {
                        tablero[x + i, y] = simboloBarco;
                    }
                    colocado = true;
                }
            }
        }
    }
}