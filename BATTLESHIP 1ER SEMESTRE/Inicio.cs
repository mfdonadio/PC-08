namespace Proyecto2
{
    class Inicio
    {
        static void Main(string[] args)
        {
                inicio();

                TableroJ1 tablero1 = new TableroJ1();

                TableroJ2 tablero2 = new TableroJ2();
                //TableroNaval tableroNaval2 = new TableroNaval();
                //TableroNaval tableroNaval1 = new TableroNaval();

                Jugador jugador1 = new Jugador("Jugador1", "Flotilla1", 0, tablero1);

                Jugador jugador2 = new Jugador("Jugador2", "Flotilla2", 0, tablero2);

                tablero1.GenerarConfiguracionInicial();

                tablero2.GenerarConfiguracionInicial();
                
                Console.WriteLine("\n--- CONFIGURACIÓN DEL JUGADOR 1 ---");
                tablero1.MostrarTablero();
                
                // Permitir al jugador 1 configurar su tablero
                jugador1.ConfigurarTablero(jugador1, jugador2);
                

                tablero2.MostrarTablero2();
                
                // Permitir al jugador 2 configurar su tablero
                jugador2.ConfigurarTablero(jugador1, jugador2);;


                Console.WriteLine("\n¡Configuración completada! Presiona cualquier tecla para continuar...");
                Console.ReadKey();

                Console.WriteLine("\n¡Que comience la batalla naval!");

        }   

        public static void inicio()
        {
            Console.WriteLine("¡Bienvenido a Batalla Naval!");
            Console.WriteLine("Cada jugador tendrá la oportunidad de configurar su tablero.");
        }
    }
}
