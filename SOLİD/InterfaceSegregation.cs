// İnterface segragation, bir interface e sadece her alt sınıfın kullanması gerektiği soyut metotları tanımlamayı anlatır
// Yoksa gereksiz metotlar olursa alt sınıflarda implemente etmek gerekir ve bu da saçma ve mantıksız bir şey
// Her özellik için bir tane interface oluşturmak en mantıklı çözümdür bana göre
// Çünkü bir sınıf birden fazla interface class miras alabilir. Her sınıfta hangi özellik varsa miras alır ve implemente ederiz.

using System;

namespace AirplaneMaintenance
{
    public interface IFly
    {
        void Fly();
    }

    public interface IMaintain
    {
        void PerformMaintenance();
    }

    public class Pilot : IFly, IMaintain
    {
        public void Fly()
        {
            Console.WriteLine("Uçak uçuyor.");
        }

        public void PerformMaintenance()
        {
            Console.WriteLine("Pilot bakım yapıyor.");
        }
    }

    public class Technician : IMaintain
    {
        public void PerformMaintenance()
        {
            Console.WriteLine("Teknisyen bakım yapıyor.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pilot pilot = new Pilot();
            Technician technician = new Technician();

            // Pilot hem uçabilir hem bakım yapabilir
            pilot.Fly();
            pilot.PerformMaintenance();

            // Teknisyen sadece bakım yapabilir
            technician.PerformMaintenance();
        }
    }
}
