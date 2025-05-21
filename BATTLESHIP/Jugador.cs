public class Jugador
{
    public string Nombre {get; private set;} // Nombre del jugador
    public int Puntos { get; set; } // Puntos acumulados por el jugador
    private ITablero tablero; // Referencia al tablero propio del jugador
    private ITableroAtaque tableroAtaque; // Referencia al tablero de ataques del jugador


    // Constructor: inicializa el jugador con su nombre, puntos y tableros
    public Jugador(string nombre, int puntos, ITablero tablero, ITableroAtaque tableroAtaque)
    {
        Nombre = nombre;
        Puntos = puntos;
        this.tablero = tablero;
        this.tableroAtaque = tableroAtaque;
        this.tableroAtaque.GenerarConfiguracionInicial(); //Inicilizar tablero de ataques. 
    }

    // Permite al jugador aceptar o reorganizar la configuración de su flota
    public void ConfigurarTablero()
    {
        bool configuracionAceptada = false;

        while (!configuracionAceptada)
        {
            Console.WriteLine($"¿{Nombre}, estás de acuerdo con la configuración de tu flota naval? (si/no)");
            string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (respuesta == "si")
            {
                configuracionAceptada = true;
                Console.WriteLine("¡Configuración de la flota naval aceptada!");
            }
            else if (respuesta == "no")
            {
                // Si el jugador no está de acuerdo, reorganiza la flota y muestra el nuevo tablero
                Console.WriteLine($"Reorganizando la flota naval para {Nombre}...");
                tablero.GenerarConfiguracionInicial();
                tablero.MostrarTablero();
            }
            else
            {
                Console.WriteLine("Respuesta no válida. Por favor, responde 'si' o 'no'.");
            }
        }
    }


    // Permite al jugador realizar un ataque o rendirse
    // Devuelve true si el ataque fue exitoso, false si falló, o null si el jugador se rinde
    public bool? RealizarAtaque(ITablero tableroEnemigo, ITableroAtaque actualTableroAtaque)
    {

        bool ataqueValido = false;
        bool resultado = false;

        while (!ataqueValido)
        {

            Console.WriteLine($"{Nombre} es tu turno de lanzar un ataque. Ingresa las coordenadas (ejemplo: A-1). Si te quieres rendir escribe: 4623");
            string coordenadas = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (coordenadas == "4623")
            {
                return null; //El jugador se rinde.
            }

            // Valida el formato de coordenadas
            if (coordenadas.Length < 3 || !coordenadas.Contains("-"))
            {
                Console.WriteLine("Formato de coordenas inválido. Utiliza el formato A-1, B-2, C-3, etc.");
                continue;
            }

            string[] partes = coordenadas.Split('-');
            if (partes.Length == 2 && partes[0].Length == 1)
            {
                char fila = partes[0][0];
                if (int.TryParse(partes[1], out int columna))
                {
                    columna -= 1;  // Ajusta la columna para que coincida con el índice de la matriz (de 1-6 a 0-5)

                    // Verifica que la fila y columna estén dentro del rango permitido
                    if (fila >= 'A' && fila <= 'F' && columna >= 0 && columna <= 5)
                    {
                        //Antes de marcar el ataque, revisa si ya fue atacada la casilla.
                        string valorCelda = tableroEnemigo.GetTablero()[fila - 'A', columna];
                        if (valorCelda == " X " || valorCelda == " O ")
                        {
                            Console.WriteLine("Ya lanzaste un misil en esta coordenada. Inténtalo de nuevo por favor.");
                            continue; // No termina el turno, vuelve a pedir coordenadas
                        }

                        resultado = tableroEnemigo.Atacar(fila, columna); // Realiza el ataque en el tablero enemigo
                        actualTableroAtaque.MarcarAtaque(fila, columna, resultado); // Marca el resultado en el tablero de ataques
                        return resultado; // Sale del ciclo solo si el ataque fue válido
                    }
                    else
                    {
                        Console.WriteLine("Las coordenadas ingresadas están fuera de rango.\nLa fila debe estar entre A y F, y la columna entre 1 y 6.");
                    }
                }
                else
                {
                    Console.WriteLine("La columna dene ser un número entero entre 1 y 6. Vuelve a intentarlo por favor.");
                }
            }
            else
            {
                Console.WriteLine("Formato de coordenadas inválido. Intenta nuevamente con formato A-1.");
            }
        }
        return resultado;
    }


    // Devuelve el tablero propio del jugador
    public ITablero GetTablero()
    {
        return tablero;
    }

    // Devuelve el tablero de ataques del jugador
    public ITableroAtaque GetTableroAtaque()
    {
        return tableroAtaque;
    }
}