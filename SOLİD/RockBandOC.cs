using System;
using System.Collections.Generic;

// Abstract base class
abstract class RockBand
{
    public abstract string Name { get; }
    public abstract decimal CalculateCost(decimal basePrice);
}

// Concrete class for a specific band
class Metallica : RockBand
{
    public override string Name => "Metallica";
    public override decimal CalculateCost(decimal basePrice) => basePrice + 50000; // Metallica'nın ek maliyeti
}

class Nirvana : RockBand
{
    public override string Name => "Nirvana";
    public override decimal CalculateCost(decimal basePrice) => basePrice + 30000; // Nirvana'nın ek maliyeti
}

class LedZeppelin : RockBand
{
    public override string Name => "Led Zeppelin";
    public override decimal CalculateCost(decimal basePrice) => basePrice + 70000; // Led Zeppelin'in ek maliyeti
}

class RockConcert
{
    private readonly List<RockBand> _bands;

    public RockConcert()
    {
        _bands = new List<RockBand>();
    }

    public void AddBand(RockBand band)
    {
        _bands.Add(band);
    }

    public void ShowCosts(decimal basePrice)
    {
        foreach (var band in _bands)
        {
            Console.WriteLine($"{band.Name} sahne fiyatı: {band.CalculateCost(basePrice)} TL");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        decimal basePrice = 100000;

        
        RockBand metallica = new Metallica();
        RockBand nirvana = new Nirvana();
        RockBand ledZeppelin = new LedZeppelin();

        
        RockConcert concert = new RockConcert();
        concert.AddBand(metallica);
        concert.AddBand(nirvana);
        concert.AddBand(ledZeppelin);

        // Grupların sahne fiyatlarını göster
        concert.ShowCosts(basePrice);

        Console.ReadLine();
    }
}
