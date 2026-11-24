using System;

class Program
{
    static void BubbleSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        Random random = new Random();
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = random.Next(0, 1001);

        BubbleSort(numbers);

        Console.WriteLine("Posortowana tablica: " + string.Join(", ", numbers));

        // test
        bool sorted = true;
        for (int i = 0; i < numbers.Length - 1; i++)
            if (numbers[i] > numbers[i + 1]) sorted = false;
        Console.WriteLine(sorted ? "TEST OK: tablica posortowana" : "TEST BLAD");
    }
}
