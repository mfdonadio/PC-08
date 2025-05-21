// Interfaz que define las operaciones básicas para el tablero de ataques en el juego.
public interface ITableroAtaque
{
    // Genera la configuración inicial del tablero de ataque, preparándolo para el juego.
    void GenerarConfiguracionInicial();

    // Muestra el tablero de ataque en pantalla, permitiendo ver los ataques realizados.
    void MostrarTablero();

    // Limpia el tablero de ataque, eliminando cualquier marca previa.
    string[,] GetTableroAtaque();


    // Marca el resultado de un ataque en una posición específica.
    // Recibe la fila (como letra), la columna (como número) y si fue un impacto (true) o no (false).
    void MarcarAtaque(char fila, int columna, bool impacto);
}