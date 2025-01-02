using System;

public interface IAnimal
{
    // Her hayvanın konuşma davranışını tanımlayan bir metod.
    void Speak();
}

public class Cat : IAnimal
{
    // Kedi sınıfı, Speak() metodunu kendi davranışıyla uygular.
    public void Speak()
    {
        Console.WriteLine("Meow! I am a Cat.");
    }
}

public class Dog : IAnimal
{
    // Köpek sınıfı, Speak() metodunu kendi davranışıyla uygular.
    public void Speak()
    {
        Console.WriteLine("Woof! I am a Dog.");
    }
}

// Bu soyut sınıf, fabrika metodunu tanımlar.
// Alt sınıflar, hangi tür hayvanın oluşturulacağını belirler.
public abstract class AnimalFactory
{
    // Fabrika metodu: Alt sınıflar tarafından özelleştirilir.
    public abstract IAnimal CreateAnimal();
}

public class CatFactory : AnimalFactory
{
    // CatFactory, CreateAnimal() metodunu geçersiz kılar ve bir Cat nesnesi oluşturur.
    public override IAnimal CreateAnimal()
    {
        return new Cat();
    }
}

public class DogFactory : AnimalFactory
{
    // DogFactory, CreateAnimal() metodunu geçersiz kılar ve bir Dog nesnesi oluşturur.
    public override IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kedi oluşturmak için CatFactory'yi kullanıyoruz.
        AnimalFactory catFactory = new CatFactory();
        IAnimal cat = catFactory.CreateAnimal(); // Cat nesnesi oluşturulur.
        cat.Speak(); // Çıktı: Meow! I am a Cat.

        // Köpek oluşturmak için DogFactory'yi kullanıyoruz.
        AnimalFactory dogFactory = new DogFactory();
        IAnimal dog = dogFactory.CreateAnimal(); // Dog nesnesi oluşturulur.
        dog.Speak(); // Çıktı: Woof! I am a Dog.
    }
}
