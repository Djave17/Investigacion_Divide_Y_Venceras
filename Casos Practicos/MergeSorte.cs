using System;

namespace MergeSorte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int cant;

            Console.Write("Cantidad de números a ingresar: ");
            cant = int.Parse(Console.ReadLine());

            arr = new int[cant]; 


            for (int i = 0; i < cant; i++)
            {
                Console.Write($"Número {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("------Números sin ordenar------");
            for(int i=0; i<cant; i++)
            {
                Console.WriteLine(arr[i]);
            }

            mergeSort(arr);

            Console.WriteLine("------Números Ordenados------");
            foreach (var dato in arr)
            {
                Console.WriteLine(dato);
            }
        }

        static void mergeSort(int[] arr)
        {
            //verifica que haya solo 1 un elemento 
            if (arr.Length < 2) return;

            //número de elementos en la parte izquierda del arreglo (mitad)
            int izqLength = arr.Length / 2;

            //número de elementos en parte derecha
            int derLength = arr.Length - izqLength;


            //elementos de mitad del arrelo (izquiero y derecho)
            int[] izqArr = new int[izqLength];
            int[] derArr = new int[derLength];

            //dividir el arreglo en 2
            //copia el arreglo original
            Array.Copy(arr, 0, izqArr, 0, izqLength);
            Array.Copy(arr, izqLength, derArr, 0, derLength);

            mergeSort(izqArr);
            mergeSort(derArr);
            SortArr(arr,izqArr,derArr);
        }

        static void SortArr(int[] sortArr, int[] izqArr, int[] derArr)
        {
            //indices
            int i = 0, d = 0, s = 0;
            while (i < izqArr.Length && d < derArr.Length)
            {
                if (izqArr[i] <= derArr[d])
                {
                    sortArr[s++] = izqArr[i++];
                }
                else
                {
                    sortArr[s++] = derArr[d++];
                }
            }

            //verificar que el arreglo este completo 
            while (i < izqArr.Length)
            {
                sortArr[s++] = izqArr[i++];
            }

            while (d < derArr.Length)
            {
                sortArr[s++] = derArr[d++];
            }
        }
    }
}
