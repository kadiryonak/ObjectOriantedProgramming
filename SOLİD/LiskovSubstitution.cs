/*
Liskov Yerine Geçme Prensibi (LSP), nesne yönelimli programlamada alt sınıfların, 
üst sınıflarının yerine geçebilmesini ve bu değişikliğin programın doğru çalışmasını bozmayacağını ifade eder.
Yani, bir alt sınıf, üst sınıfın beklenen tüm davranışlarını koruyarak yerini almalı ve hiçbir beklenmedik hata yaratmamalıdır.
Bu prensip, kalıtım ve polimorfizmin doğru şekilde kullanılmasını sağlar.
*/

using System;

public abstract class Animal
{
    public abstract void Describe();
}

public class Dog : Animal
{
    public override void Describe()
    {
        Console.WriteLine("I'm a dog. I bark and wag my tail!");
    }
}

public class Cat : Animal
{
    public override void Describe()
    {
        Console.WriteLine("I'm a cat. I meow and chase mice!");
    }
}

public class Fish : Animal
{
    public override void Describe()
    {
        Console.WriteLine("I'm a fish. I swim silently in the water!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal myDog = new Dog();
        Animal myCat = new Cat();
        Animal myFish = new Fish();

        myDog.Describe(); // "I'm a dog. I bark and wag my tail!"
        myCat.Describe(); // "I'm a cat. I meow and chase mice!"
        myFish.Describe(); // "I'm a fish. I swim silently in the water!"
    }
}

