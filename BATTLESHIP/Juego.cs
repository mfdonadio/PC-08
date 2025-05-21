public class Juego
{
    private Jugador _jugador1; // primer jugador
    private Jugador _jugador2; // Segundo jugador
    public bool juegoTerminado = false; // Indica si el juego ha terminado. 
    private int turnosJugador1 = 0; // Contador de turnos del jugador 1.
    private int turnosJugador2 = 0; // Contador de turnos del jugador 2. 
    private const int TURNOS_MAXIMOS = 15; // Turnos máximos por jugador.

    public Juego()
    {
        // Inicializar tableros. Crea los tableros para cada jugdor. 
        ITablero tablero1 = new TableroJugador1();
        ITablero tablero2 = new TableroJugador2();

        //Inicializar tableros de ataque. Crea los tableros de ataque  para cada jugador.
        ITableroAtaque tableroAtaque1 = new TableroAtaqueJugador1();
        ITableroAtaque tableroAtaque2 = new TableroAtaqueJugador2();

        //Inicializar jugadores. Crea a los jugadores y se les asigna sus tableros. 
        _jugador1 = new Jugador("Jugador 1", 0, tablero1, tableroAtaque1);
        _jugador2 = new Jugador("Jugador 2", 0, tablero2, tableroAtaque2);
    }

    public void Iniciar()
    {
        MostrarBienvenida(); // Mensaje de bienvenida.
        Console.WriteLine("\nPresiona enter para continuar...");
        Console.Clear();
        ConfigurarTableros(); // Configuracion de tableros para cada jugador.
        Console.ReadLine();
        Console.Clear();
        IniciarBatalla(); // Inicia la batalla principal.
    }

    // Da la bienvenida y expone las reglas del juego. 
    public void MostrarBienvenida()
    {
        Console.WriteLine("¡Bienvenidos al juego de Batalla Naval!");
        Console.WriteLine("Elaborado por: Marco Fabrizzio Donadio Castellanos - 1076925");
        Console.Write("\n\n Presiona enter para continuar....");
        Console.ReadLine();
        Console.WriteLine("\t\t ----------REGLAS BÁSICAS DEL JUEGO----------");
        Console.WriteLine("\n1. Cada jugador podrá elegir la configuración de su tablero a su gusto. Pero una vez que la elija, no podrá volver a cambiarla.");
        Console.WriteLine("2. La partida consta de 15 turnos por jugador, no más ni menos. Así que planeen bien su estrategia para ganarle a su rival antes que el tiempo se acabe...jeje.");
        Console.WriteLine("3. Deberán seguir al pie de la letra las coordenadas de ataque, de lo contrario tendrán que volver a ingresarlas... VIVOS PUES :D.");
        Console.WriteLine("4. Cada impacto a un barco les sumerá un punto, el primero en llegar a 9 puntos ganará.");
        Console.WriteLine("\n Presiona enter para continuar....");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Ahora cada jugador tendrá la oportunidad de configurar su tablero....\n\n Presiona enter para continuar ....");
        Console.ReadLine();
        Console.Clear();
    }


    // Permite a cada jugador configurar su tablero antes de iniciar la partida
    private void ConfigurarTableros()
    {
        //Configuracion del jugador 1
        Console.WriteLine("\n--- CONFIGURACIÓN DEL JUGADOR 1 ---");
        _jugador1.GetTablero().GenerarConfiguracionInicial(); // Genera la configuración inicial del tablero
        _jugador1.GetTablero().MostrarTablero(); // Muestra el tablero generado
        _jugador1.ConfigurarTablero(); // Permite aceptar o cambiar la configuración

        Console.Clear();

        //Configuracion del jugador 2
        Console.WriteLine("\n--- CONFIGURACIÓN DEL JUGADOR 2 ---");
        _jugador2.GetTablero().GenerarConfiguracionInicial(); // Genera la configuración inicial del tablero
        _jugador2.GetTablero().MostrarTablero(); // Muestra el tablero generado
        _jugador2.ConfigurarTablero(); // Permite aceptar o cambiar la configuración

        Console.Clear();
        Console.WriteLine("\n¡Configuración completada! Presiona cualquier letra para continuar...");
        Console.ReadKey();
        Console.WriteLine("\n¡Que comience la batalla naval!");
    }
    
    // Controla el ciclo principal de la batalla entre los jugadores
    private void IniciarBatalla()
    {
        Jugador jugadorActual = _jugador1;
        Jugador jugadorEnemigo = _jugador2;

        while (!juegoTerminado)
        {
            // Verifica si ambos jugadores ya usaron todos sus turnos
            if (turnosJugador1 >= TURNOS_MAXIMOS && turnosJugador2 >= TURNOS_MAXIMOS)
            {
                DeterminarGanadorPorPuntos(); // Determina el ganador por puntos si se acabaron los turnos
                break;
            }

            //Verifica si el jugador en turno ya completó sus turnos correspondientes.
            if ((jugadorActual == _jugador1 && turnosJugador1 >= TURNOS_MAXIMOS) ||
                (jugadorActual == _jugador2 && turnosJugador2 >= TURNOS_MAXIMOS))
            {
                //Cambia al otro jugador si este todavía dispone de turnos
                Jugador cambio = jugadorActual;
                jugadorActual = jugadorEnemigo;
                jugadorEnemigo = cambio;
                continue;
            }

            //Mostrar tableros actualizados del jugador en turno. 
            MostrarTablerosActuales(jugadorActual, jugadorEnemigo);

            // Incrementa el contador de turnos del jugador correspondiente
            if (jugadorActual == _jugador1)
                turnosJugador1++;
            else
                turnosJugador2++;

            Console.WriteLine($"Turno {(jugadorActual == _jugador1 ? turnosJugador1 : turnosJugador2)} de {TURNOS_MAXIMOS}");


            // El jugador actual realiza un ataque; si se rinde, retorna null.
            var resultado = jugadorActual.RealizarAtaque(jugadorEnemigo.GetTablero(), jugadorActual.GetTableroAtaque());

            if (resultado == null)
            {
                // Si el jugador se rinde, termina el juego y declara ganador al enemigo.
                Console.WriteLine($"{jugadorActual.Nombre} se ha rendido. ¡{jugadorEnemigo.Nombre} gana la partida!");
                juegoTerminado = true;
                continue;
            }

            if (resultado == true)
            {
                // Si el ataque fue exitoso, suma un punto al jugador.
                jugadorActual.Puntos++;
                Console.WriteLine($"{jugadorActual.Nombre} ha ganado 1 punto. Puntos totales: {jugadorActual.Puntos}");

                // Verifica si el jugador ya ganó la partida
                if (jugadorActual.Puntos >= 9) // 2+3+4 puntos de todos los barcos.
                {
                    Console.WriteLine($"¡{jugadorActual.Nombre} ha ganado la partida!");
                    juegoTerminado = true;
                }
            }

            // Cambiar turno si el juego no ha terminado.
            if (!juegoTerminado)
            {
                // Intercambiar jugadores para el próximo turno.
                Jugador cambio = jugadorActual;
                jugadorActual = jugadorEnemigo;
                jugadorEnemigo = cambio;

                Console.WriteLine("\nPresiona cualquier tecla para continuar al siguiente turno...");
                Console.ReadKey();
            }
        }
    }

    // Determina al ganador por puntos se se acban los turnos.
    private void DeterminarGanadorPorPuntos()
    {
        Console.WriteLine("\n¡Se han agotado los turnos de la partida!");

        if (_jugador1.Puntos > _jugador2.Puntos)
        {
            Console.WriteLine($"¡{_jugador1.Nombre} ha ganado con {_jugador1.Puntos} puntos contra {_jugador2.Puntos} puntos!");
        }
        else if (_jugador2.Puntos > _jugador1.Puntos)
        {
            Console.WriteLine($"¡{_jugador2.Nombre} ha ganado con {_jugador2.Puntos} puntos contra {_jugador1.Puntos} puntos!");
        }
        else
        {
            Console.WriteLine($"¡La partida ha terminado en empate! Ambos jugadores tienen {_jugador1.Puntos} puntos.");
        }

        juegoTerminado = true;
    }

    // Muestra el estado actual de los tableros del jugador actual.
    private void MostrarTablerosActuales(Jugador jugadorActual, Jugador jugadorEnemigo)
    {
        Console.Clear();
        Console.WriteLine($"--- TURNO DE {jugadorActual.Nombre} ---");

        Console.WriteLine("\nTu flota:");
        jugadorActual.GetTablero().MostrarTablero();

        Console.WriteLine("\nAtaques realizados:");
        jugadorActual.GetTableroAtaque().MostrarTablero();
    }
}