// Open-Closed prensibi bize şunu söyler: 
// Yazdığınız kod geliştirilmeye açık, ancak değişime kapalı olmalıdır. 
// Bu prensibi sağlamanın yolu soyut sınıflar veya interface kullanmaktır. 

// Abstract sınıf ile interface arasında bazı farklar bulunur: 
// Abstract sınıfın içinde hem soyut hem somut metotlar bulunabilirken, 
// bir alt sınıf yalnızca bir abstract sınıfı miras alabilir. 
// Buna karşılık, bir alt sınıf birden fazla interface'i miras alabilir. 
// Bu noktada Interface Segregation prensibi de devreye girer. 

// Yeni bir özellik eklemek istediğinizde, 
// soyut sınıfın metotlarını alt sınıfta implemente ederek 
// temel sınıfa dokunmadan yeni özellikler ekleyebilirsiniz. 
// Abstract sınıftan override yaparak ata sınıfın metodunu ezebilir 
// ve çekirdeğini değiştirebilirsiniz. 
// Böylece türetilmiş sınıfta kendi implementasyonunuzu sağlayarak 
// temel sınıf davranışını değiştirme şansı elde edersiniz. 

// Interface kullanıldığında ise, 
// interface'i miras alır ve soyut (boş) metotları alt sınıfta implemente ederek (kodlayarak) 
// kendi çözümünüzü oluşturursunuz. 
// Bu yaklaşım da esnek ve genişletilebilir bir yapı sağlar.

using System;
using System.Collections.Generic;

namespace RocknRoll
{
    // Temel sınıf - Genişletilmeye açık, değişikliğe kapalı
    public abstract class Muzisyen
    {
        // Her müzisyenin performans sergilemesi gereken bir metot
        public abstract void PerformansYap();
    }

    // Gitarist sınıfı - Muzisyen sınıfından türetilmiş
    public class Gitarist : Muzisyen
    {
        public override void PerformansYap()
        {
            Console.WriteLine("Gitarist bir solo çalıyor");
        }
    }

    // Davulcu sınıfı - Muzisyen sınıfından türetilmiş
    public class Davulcu : Muzisyen
    {
        public override void PerformansYap()
        {
            Console.WriteLine("Davulcu ritim atıyor");
        }
    }

    // Vokalist sınıfı - Muzisyen sınıfından türetilmiş
    public class Vokalist : Muzisyen
    {
        public override void PerformansYap()
        {
            Console.WriteLine("Vokalist yüksek bir notaya çıkıyor");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Müzisyenlerden oluşan bir liste oluşturuyoruz
            List<Muzisyen> grup = new List<Muzisyen>
            {
                new Gitarist(), // Gitarist ekleniyor
                new Davulcu(),  // Davulcu ekleniyor
                new Vokalist()  // Vokalist ekleniyor
            };

            Console.WriteLine("Rock'n Roll Şovuna Hoş Geldiniz");

            // Her bir müzisyeni performans sergilemesi için sırayla çağırıyoruz
            foreach (var muzisyen in grup)
            {
                muzisyen.PerformansYap();
            }
        }
    }
}

