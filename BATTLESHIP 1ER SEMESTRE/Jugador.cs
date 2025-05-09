class Jugador
{
    public string Nombre;
    public string Flotilla;
    public int Puntos;
    private TableroJ1 tablero;
    public Jugador(string nombre, string flotilla, int puntos, TableroJ1 tableroJugador)
    {
        this.Nombre = nombre; 
        this.Flotilla = flotilla;
        this.Puntos = puntos; 
        this.tablero = tableroJugador;
    }
    public string ConfigurarTablero(Jugador jugador1, Jugador jugador2)
    {
        string opcion = "";
        bool configuracionAceptada = false;
        
        while (!configuracionAceptada)
        {
            Console.WriteLine($"¿{Nombre}, estás de acuerdo con la configuración de tu flota naval? (si/no)");
            opcion = Console.ReadLine()?.Trim().ToLower()??"";

            if (opcion == "si" || opcion == "no")
            {
                if (opcion == "si")
                {
                    configuracionAceptada = true;
                    Console.WriteLine("Configuración de la flota naval aceptada");
                }
                
                else
                {
                    Console.WriteLine($"Reorganizando la flota naval para {Nombre} ...");
                    if (this == jugador1)
                    {
                        ((TableroJ1)tablero).GenerarConfiguracionInicial();
                        ((TableroJ1)tablero).MostrarTablero();
                    }
                    else if (this == jugador2)
                    {
                        TableroJ2 tableroJ2 = (TableroJ2)tablero;
                        tableroJ2.GenerarConfiguracionInicial();
                        tableroJ2.MostrarTablero2();
                    }
                }
            }
            else
            {
                Console.WriteLine("Por favor ingresa una opción válida (si/no).");
            }
        }

        return "COnfiguracion finalizada.";
    }
}