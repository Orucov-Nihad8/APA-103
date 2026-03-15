using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3 };

        int[] resized = CustomArrResize(numbers, 4, 5, 6);

    
        for (int i = 0; i < resized.Length; i++)
        {
            Console.Write(resized[i] + " "); 
        }
        Console.WriteLine(); 
    }

    
    static int[] CustomArrResize(int[] arr, params int[] newNumbers)
    {
        int[] newArr = new int[arr.Length + newNumbers.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = arr[i];
        }

      
        for (int i = 0; i < newNumbers.Length; i++)
        {
            newArr[arr.Length + i] = newNumbers[i];
        }

        return newArr;
    }
}
