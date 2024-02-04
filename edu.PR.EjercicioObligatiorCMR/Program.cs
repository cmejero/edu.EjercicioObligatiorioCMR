using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int[,] array = new int[5, 10];

        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                array[i, j] = random.Next(1, 31);
            }
        }


        Console.WriteLine("Array con 5 vectores de 10 columnas:");
        MostrarArray(array);

        int[] primerVector = ObtenerVector(array, 0);
        

            
        int[] valoresCoincidentes = ObtenerValoresCoincidentes(array, primerVector);

        Console.WriteLine("Valores coincidentes (metodo For)");
       
        for (int i = 0; i < valoresCoincidentes.Length; i++)
        {
            Console.Write(valoresCoincidentes[i] + " ");
        }
        Array.Sort(valoresCoincidentes);

      
        Console.WriteLine("\nValores coincidentes ordenados ascendente (metodo Foreach):");
        foreach (var valor in valoresCoincidentes)
        {
            Console.Write(valor + " ");
        }
    }

    
    static int[] ObtenerVector(int[,] array, int indice)
    {
        int[] vector = new int[10];
        for (int i = 0; i < 10; i++)
        {
            vector[i] = array[indice, i];
        }
        return vector;
    }

    static int[] ObtenerValoresCoincidentes(int[,] array, int[] primerVector)
    {
        int[] valoresCoincidentes = new int[0];

        for (int i = 1; i < 5; i++)
        {
            int[] vectorActual = ObtenerVector(array, i);
            valoresCoincidentes = valoresCoincidentes.Concat(vectorActual.Intersect(primerVector)).ToArray();
        }

        return valoresCoincidentes;
    }

    
    static void MostrarArray(int[,] array)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}