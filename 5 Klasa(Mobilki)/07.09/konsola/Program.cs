using System;

class Program
{
    static int[] RollDice(int count)
    {
        Random random = new Random();
        int[] results = new int[count];
        for (int i = 0; i < count; i++)
            results[i] = random.Next(1, 7);
        return results;
    }

    static int CountPoints(int[] results)
    {
        int[] occurrences = new int[7];
        foreach (int value in results)
            occurrences[value]++;

        int points = 0;
        for (int value = 1; value <= 6; value++)
            if (occurrences[value] >= 2)
                points += value * occurrences[value];
        return points;
    }

    static void Main()
    {
        string again;
        do
        {
            int count;
            do
            {
                Console.WriteLine("Ile kostek chcesz rzucić?(3 - 10)");
                int.TryParse(Console.ReadLine(), out count);
            } while (count < 3 || count > 10);

            int[] results = RollDice(count);
            for (int i = 0; i < results.Length; i++)
                Console.WriteLine("Kostka " + (i + 1) + ": " + results[i]);
            Console.WriteLine("Liczba uzyskanych punktów: " + CountPoints(results));

            do
            {
                Console.WriteLine("Jeszcze raz? (t/n)");
                again = Console.ReadLine();
            } while (again != "t" && again != "n");
        } while (again == "t");
    }
}
