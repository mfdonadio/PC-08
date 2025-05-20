using System;
namespace CLASE2_SEMANA_15;

class MatriculacionEstudiantes
{
    static void Main()
    {    //Declaracion e inicialización de las variables. 
        int edad = 0;
        double notaAdmision = 0;
        string nombre = "", carrera = "", carnet="";
        IngresoDatosEstudiante(ref nombre, ref edad, ref carrera, ref carnet, ref notaAdmision); //Se llama al método en donde el usuario puede ingresar los datos requeridos.
        Console.ReadLine();
        Console.Clear();
        var estudiante = new Estudiante(){Nombre = nombre, Edad = edad, Carrera = carrera, Carnet = carnet, NotaAdmision = notaAdmision}; //Se crea el objeto 'estudiante' y se envían sus propiedades.
        MostrarResumen.EscribirResumen(estudiante); //Se muestra el resumen de la información del usuario llamando al método 'EscribirResumen' de la clase heredada 'MostrarResumen'. Manda como parámetro a el objeto 'estudiante'
        Console.ReadLine();
        Console.Clear();
        ValidarMatriculacion.Matriculacion(estudiante); //Se realiza y muestra la validación de la maatriculación desde el método 'Matriculacion' de la clase heredada 'ValidarMatriculacion'. Manda como parámetro a el objeto 'estudiante'.
        Console.ReadLine();
    }

    //Método en donde el usuario tiene la posibilidad de ingresar los datos en los campos requeridos.
    public static void IngresoDatosEstudiante( ref string nombre, ref int edad, ref string carrera, ref string carnet, ref double notaAdmision){
        Console.WriteLine("¡Hola! por favor ingresa tu nombre:");
        nombre = Console.ReadLine()??"";
        Console.WriteLine("Ingresa tu edad:");
        edad = Convert.ToInt32(Console.ReadLine()??"");
        Console.WriteLine("Ingresa la carrera que deseas o vas a estudiar:");
        carrera = Console.ReadLine()??"";
        Console.WriteLine("Ingresa tu número de carnet:");
        while (true) //Validación del número de carnet, mismo que no debe ser mayor o menor de 7 caracteres. Además, requiere que sí o sí el usuario ingrese un numero. 
        {
            carnet = Console.ReadLine()??"";
            int longitudCarnet = carnet.Length;
            if (string.IsNullOrWhiteSpace(carnet))
            {
                Console.WriteLine("Ingrese un número de carnet.");
                Console.WriteLine("Vuelve a ingresarlo por favor: ");
            }
            else if (longitudCarnet != 7)
            {
                Console.WriteLine("El carnet debe tener 7 caracteres. No más ni menos.");
                Console.WriteLine("Vuelve a ingresarlo por favor: ");

            }
            else
            {
                break;
            }
        }
        Console.WriteLine("Por último, ingresa la nota que obtuviste en el examen de admisión:");
        notaAdmision = Convert.ToDouble(Console.ReadLine()??"");
    }
}

//Clase Estudiante en donde se crea un objeto 'estudiante' y se le asignan las propiedades correspondientes.
public class Estudiante{
    //'get' lee el valor enviado como parámetro y 'set' lo asigna a la propiedad.
    public required string Nombre {get; set;}
    public required int Edad {get; set;}
    public required string Carrera {get; set;}
    public required string Carnet {get; set;}
    public required double NotaAdmision {get; set;}
}

//Se heredan las propiedades desde la clase 'Estudiante' para la clase hija llamada 'MostrarResumen'.
public class MostrarResumen : Estudiante{

    //Se crea un método dentro de la clase para poder llamarlo desde 'Main' como una propiedad de la clase 'MostrarResumen'.
    public static void EscribirResumen(Estudiante estudiante){
        Console.WriteLine("SUS DATOS INGRESADOS SON:");
        Console.WriteLine("NOMBRE: " + estudiante.Nombre);
        Console.WriteLine("EDAD: " + estudiante.Edad);
        Console.WriteLine("CARRERA: " + estudiante.Carrera);
        Console.WriteLine("CARNET: " + estudiante.Carnet);
        Console.WriteLine("NOTA DE ADMISION: " + estudiante.NotaAdmision);
    }
}


//Se heredan las propiedades desde la clase 'Estudiante' para la segunda clase hija llamada 'ValidarMatriculacion'.
public class ValidarMatriculacion : Estudiante{

//Se crea un método dentro de la clase para poder llamarlo desde 'Main' como una propiedad de la clase 'ValidarMatriculacion'.
    public static void Matriculacion(Estudiante estudiante){
    
        int notaEstudiante = Convert.ToInt32(estudiante.NotaAdmision); //Convierte la cadena de texto de ser 'string' a 'int'.
        string añoCarnet = estudiante.Carnet; //Asigna el valor de 'estudiante.Carnet' a 'añoCarnet' para facilitar su uso.

        //Evalua las condiciones que debe cumplir el usuario para poder matricularse a la universidad.
        if (notaEstudiante >= 75 && añoCarnet.EndsWith("25")){
            Console.WriteLine("¡FELICIDADES! usted sí puede matricularse :D.");
        }
        else if(notaEstudiante >= 75 && !añoCarnet.EndsWith("25")){
            Console.WriteLine("USted ha ganado el examen, pero su carnet no es 2025, por lo tanto no puede matricularse. Gracias!!");
        }
        else if(notaEstudiante < 75 && añoCarnet.EndsWith("25")){
            Console.WriteLine("Su carnet sí es 2025, pero parece que no ha ganado el examen de admisión. No es posible que se pueda matricular.");
        }
        else{
            Console.WriteLine("Lo sentimos, no cumple los requisitos para poder matricularse. No pierda el ánimo, sigalo intentando.");
        }
    }
}



/* Ingeniero jeje, a lo mejor no tiene al pie de la letra las instrucciones pero trate de implementar casi todo lo que aprendí de la lectura. Solo espero que no perjudique mucho la nota,
porque aunque es diferente, cumole las funcionalidades minimas requeridas y talvez un poquito más :D. Felíz día!!!*/