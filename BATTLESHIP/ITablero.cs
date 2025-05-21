// Interfaz que define las operaciones básicas que debe tener un tablero en el juego de Batalla Naval.
public interface ITablero
{
    // Genera la configuración inicial del tablero, colocando los barcos y preparando el juego.
    void GenerarConfiguracionInicial();

    // Muestra el tablero en pantalla, permitiendo ver el estado actual del juego.
    void MostrarTablero();

    // Limpia el tablero, eliminando cualquier barco o marca previa.
    void LimpiarTablero();

    // Devuelve la matriz que representa el tablero actual.
    string[,] GetTablero();

    // Permite atacar una posición específica del tablero.
    // Recibe la fila (como letra) y la columna (como número).
    // Devuelve true si el ataque fue exitoso (acertó un barco), false si falló.
    bool Atacar(char fila, int columnda);
}