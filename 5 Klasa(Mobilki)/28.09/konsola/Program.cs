using System;

class Notatka
{
    private static int licznikNotatek = 0;
    private int id;
    protected string tytul;
    protected string tresc;

    public Notatka(string tytul, string tresc)
    {
        licznikNotatek++;
        id = licznikNotatek;
        this.tytul = tytul;
        this.tresc = tresc;
    }

    public void Wyswietl()
    {
        Console.WriteLine("Tytul: " + tytul);
        Console.WriteLine("Tresc: " + tresc);
    }

    public void Diagnostyka()
    {
        Console.WriteLine(licznikNotatek + ";" + id + ";" + tytul + ";" + tresc);
    }
}

class Program
{
    static void Main()
    {
        Notatka pierwsza = new Notatka("Zakupy", "chleb, maslo, ser");
        Notatka druga = new Notatka("Weekend", "kino, spacer z psem");

        Console.WriteLine("--- Notatka 1 ---");
        pierwsza.Wyswietl();
        pierwsza.Diagnostyka();
        Console.WriteLine("--- Notatka 2 ---");
        druga.Wyswietl();
        druga.Diagnostyka();
    }
}
