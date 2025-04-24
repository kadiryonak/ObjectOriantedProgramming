//Nesne oluşturma sorumluluğunu alt sınıflara devretmek. Üst sınıf ne oluşturulacağını değil, nasıl oluşturulacağını bilir.
//Kodda bağımlılığı azaltır (Loosely Coupled).
//Yeni türler eklemek kolaydır (yeni sınıf ve fabrika yazmak yeterli).
//Açık/kapalı prensibi (Open/Closed Principle): Mevcut kodu değiştirmeden yeni türler eklenebilir.
    
using System;

namespace FactoryMethodDeseniOrnegi
{
    // IAnimal: Tüm hayvanların uygulaması gereken ortak davranışları tanımlar.
    // Bu örnekte her hayvanın bir "konuşma" (Speak) davranışı vardır.
    public interface IAnimal
    {
        void Speak(); // Her hayvan konuşmalıdır.
    }

    // Cat sınıfı: IAnimal arayüzünü uygular ve kendine özgü ses verir.
    public class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Meow! I am a Cat.");
        }
    }

    // Dog sınıfı: IAnimal arayüzünü uygular ve kendine özgü ses verir.
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Woof! I am a Dog.");
        }
    }

    // AnimalFactory: Soyut fabrika sınıfıdır.
    // Alt sınıflar, hangi hayvanın üretileceğine karar verir.
    public abstract class AnimalFactory
    {
        // Factory Method: Hayvan nesnesini oluşturacak soyut metod.
        // Alt sınıflar bu metodu override ederek hangi hayvanı üreteceğini belirler.
        public abstract IAnimal CreateAnimal();
    }

    // CatFactory: AnimalFactory sınıfını genişletir.
    // Bu fabrika sadece kedi üretmek için kullanılır.
    public class CatFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Cat(); // Cat nesnesi oluşturulup geri döndürülür.
        }
    }

    // DogFactory: AnimalFactory sınıfını genişletir.
    // Bu fabrika sadece köpek üretmek için kullanılır.
    public class DogFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog(); // Dog nesnesi oluşturulup geri döndürülür.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. CatFactory ile kedi nesnesi oluşturuluyor.
            AnimalFactory catFactory = new CatFactory();
            IAnimal cat = catFactory.CreateAnimal(); // Kedi üretilir.
            cat.Speak(); // Çıktı: Meow! I am a Cat.

            // 2. DogFactory ile köpek nesnesi oluşturuluyor.
            AnimalFactory dogFactory = new DogFactory();
            IAnimal dog = dogFactory.CreateAnimal(); // Köpek üretilir.
            dog.Speak(); // Çıktı: Woof! I am a Dog.
        }
    }
}
