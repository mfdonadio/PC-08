using System;

    class marco_donadio_numero_primo_semana09
    {
        static void Main()
        {
            int numero, contador;
            Console.WriteLine("Bienvenid@, por favor ingresa un número positivo de no más de 6 cifras para determinar si es o no primo: ");
            numero = Convert.ToInt32(Console.ReadLine()??"");
            while (true)
            {
                if (numero < 0)
                {
                    Console.WriteLine("Ingresa un numero positivo por favor. Vuelve a intentarlo");
                    numero = Convert.ToInt32(Console.ReadLine()??"");
                }
                else
                {
                    contador = numero.ToString().Length;
                    if (contador > 0 && contador <= 6)
                    {
                        Console.WriteLine("El número ingresado es válido.....procesando la solicitud");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR.... el número es muy largo. Vuelve a intentarlo.");
                        numero = Convert.ToInt32(Console.ReadLine()??"");
                    }
                }
            }
            int factor;
            int count = 0;
            for (factor = 1; factor <= numero; factor++)
            {
                if (numero % factor == 0)
                {
                    Console.WriteLine($"{factor} es un factor de {numero}.\n");
                    count++;
                }
            }
            if (count == 2)
            {
                Console.WriteLine($"{numero} es un número primo.");
            }
            else
            {
                Console.WriteLine($"{numero} no es un número primo.");
            }
        }    
    } 