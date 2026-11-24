using System;

class Urzadzenie
{
    public void WyswietlKomunikat(string komunikat)
    {
        Console.WriteLine(komunikat);
    }
}

class Pralka : Urzadzenie
{
    private int numerProgramu = 0;

    public int UstawProgram(int numer)
    {
        if (numer >= 1 && numer <= 12)
            numerProgramu = numer;
        else
            numerProgramu = 0;
        return numerProgramu;
    }
}

class Odkurzacz : Urzadzenie
{
    private bool wlaczony = false;

    public void On()
    {
        if (!wlaczony)
        {
            wlaczony = true;
            WyswietlKomunikat("Odkurzacz włączono");
        }
    }

    public void Off()
    {
        if (wlaczony)
        {
            wlaczony = false;
            WyswietlKomunikat("Odkurzacz wyłączono");
        }
    }
}

class Program
{
    static void Main()
    {
        Pralka pralka = new Pralka();
        Odkurzacz odkurzacz = new Odkurzacz();

        Console.WriteLine("Podaj numer prania 1..12");
        int.TryParse(Console.ReadLine(), out int numer);
        if (pralka.UstawProgram(numer) != 0)
            pralka.WyswietlKomunikat("Program został ustawiony");
        else
            pralka.WyswietlKomunikat("Podano niepoprawny numer programu");

        odkurzacz.On();
        odkurzacz.On();
        odkurzacz.On();
        odkurzacz.WyswietlKomunikat("Odkurzacz wyładował się");
        odkurzacz.Off();
    }
}
