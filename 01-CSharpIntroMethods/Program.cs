using System;

class Program
{
    // 1. Riyazi əməliyyatlar
    static void Hesabla(int a, int b)
    {
        Console.WriteLine("Toplama: " + (a + b));
        Console.WriteLine("Çıxma: " + (a - b));
        Console.WriteLine("Vurma: " + (a * b));
        Console.WriteLine("Bölmə: " + (a / b));
    }

    // 2. Tək və cüt ədədləri tapır
    static void TekCutTap(int[] arr)
    {
        foreach (int num in arr)
        {
            if (num % 2 == 0)
                Console.WriteLine(num + " cütdür");
            else
                Console.WriteLine(num + " təkdir");
        }
    }

    // 3. 4-ə və 5-ə bölünənlərin cəmi
    static int CemTap(int[] arr)
    {
        int sum = 0;

        foreach (int num in arr)
        {
            if (num % 4 == 0 && num % 5 == 0)
            {
                sum += num;
            }
        }

        return sum;
    }

    // 4. Simvol sayını tapır
    static int SimvolSay(string cumle, char herf)
    {
        int count = 0;

        foreach (char c in cumle)
        {
            if (c == herf)
            {
                count++;
            }
        }

        return count;
    }

    static void Main(string[] args)
    {
        // 1-ci tapşırıq
        Hesabla(10, 5);

        // 2 və 3 üçün array
        int[] arr = { 14, 20, 35, 40, 57, 60, 100 };

        // 2-ci tapşırıq
        TekCutTap(arr);

        // 3-cü tapşırıq
        Console.WriteLine("Cəm: " + CemTap(arr));

        // 4-cü tapşırıq
        string cumle = "Salam dunya";
        char herf = 'a';
        Console.WriteLine("Simvol sayı: " + SimvolSay(cumle, herf));
    }
}
