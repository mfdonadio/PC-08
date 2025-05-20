namespace semana08
{
    class clase2_semana08
    {
        static void Main()
        { 
            int numero;
            string entrada;
            while(true)
            {
                
                Console.WriteLine("Bienvenid@, por favor ingresa un numero positivo: ");
                entrada = Console.ReadLine(); 
                if (int.TryParse(entrada, out numero))
                {

                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                    break;   
                }
            
            int resultado = CALCULO_FACTORIAL(numero);
            Console.WriteLine(resultado);
            break;
        }
        }
    
    public static int CALCULO_FACTORIAL(int numero)
    {
        if (numero == 0)
        {
            return 1;
        }
        else
        {
            int factorial = 1;
            for (int i=1; i<= numero; i++)
            {
                factorial *= i;
            }
                return factorial;    
        } 
    }
               
    }
}