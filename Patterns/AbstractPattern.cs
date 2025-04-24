// Birbiriyle ilişkili veya bağımlı nesnelerin ailelerini (gruplarını) 
// alt sınıfları belirtmeden oluşturmak.
// Bir fabrikalar grubu yaratılır. Her fabrika, ilgili nesnelerin ailelerini üretir.
// - Ürünlerin birlikte çalışmasını garanti eder (örn: Windows button + Windows checkbox gibi).
// - Ürün ailesi genişletilebilir (örneğin: Mac, Windows, Linux).
// - Üretim detayları istemciden gizlenir.
// - Yüksek düzeyde bağımsızlık sağlar (Loosely Coupled).
// - Open/Closed Principle uygulanır: yeni ürün aileleri eklenebilir.

using System;

namespace AbstractFactoryDeseni
{
    // Ürün ailesi 1: Button
    public interface IButton
    {
        void Render();
    }

    // Ürün ailesi 2: Checkbox
    public interface ICheckbox
    {
        void Render();
    }

    // Concrete Product 1A: Windows için Button
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Windows tarzı buton çizildi.");
        }
    }

    // Concrete Product 2A: Windows için Checkbox
    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Windows tarzı checkbox çizildi.");
        }
    }

    // Concrete Product 1B: Mac için Button
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Mac tarzı buton çizildi.");
        }
    }

    // Concrete Product 2B: Mac için Checkbox
    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Mac tarzı checkbox çizildi.");
        }
    }

    // Abstract Factory: Ürün ailelerini üretecek fabrika arayüzü
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // Concrete Factory A: Windows ürünlerini üretir
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    // Concrete Factory B: Mac ürünlerini üretir
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    // Client: Uygulama kodu ürünlerin nasıl üretildiğini bilmeden kullanır
    public class Application
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        // Constructor: Abstract Factory alır ve ürünleri oluşturur
        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        // Uygulama içinde kullanımı
        public void RenderUI()
        {
            _button.Render();
            _checkbox.Render();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Platforma göre hangi factory kullanılacak belirlenir
            Console.WriteLine("Platform: Windows");
            IGUIFactory windowsFactory = new WindowsFactory();
            Application windowsApp = new Application(windowsFactory);
            windowsApp.RenderUI();

            Console.WriteLine();

            Console.WriteLine("Platform: Mac");
            IGUIFactory macFactory = new MacFactory();
            Application macApp = new Application(macFactory);
            macApp.RenderUI();
        }
    }
}
