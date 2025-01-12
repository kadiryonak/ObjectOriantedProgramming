// Open-Closed prensibi bize der ki. Yazdığınız kod geliştirilmeye açık lakin değişime kapalı olmalı. Bunu sağlamanın yolu
// soyut sınıfları kullanmaktır. Yeni bir özellik eklediğimizde. Soyut sınıfımızdaki metotları alt sınıfta implemente ederek.
// Yeni bir özellik ekleyebiliriz. Aşağıdaki kodda abstract soyut sınıf ve metot kullanılmış ve override edilmiş. İsterseniz
// interface kullanarak da bunu sağlayabilirsiniz. Arasındaki fark abstract sınıfın içinde hem soyut hem somut sınıflar bulunabilir
// alt sınıflar bir tane abstract sınıf miras alabilir. Bir alt sınıf birden fazla interface miras alabilir. İnterface Segragation
// prensibi buna da değinmektedir. Abstract sınıftan override ederek ata sınıfın metodunu ezer ve çekirdeğini değiştirirsiniz.
// interface de miras alıp soyut boş bir sınıfı aşağıda implemente edersiniz (kodlarsınız).

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
            Console.WriteLine("🎸 Gitarist epik bir solo çalıyor!");
        }
    }

    // Davulcu sınıfı - Muzisyen sınıfından türetilmiş
    public class Davulcu : Muzisyen
    {
        public override void PerformansYap()
        {
            Console.WriteLine("🥁 Davulcu etkileyici bir ritim atıyor!");
        }
    }

    // Vokalist sınıfı - Muzisyen sınıfından türetilmiş
    public class Vokalist : Muzisyen
    {
        public override void PerformansYap()
        {
            Console.WriteLine("🎤 Vokalist yüksek bir notaya çıkıyor!");
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

            Console.WriteLine(" Rock'n Roll Şovuna Hoş Geldiniz! ");

            // Her bir müzisyeni performans sergilemesi için sırayla çağırıyoruz
            foreach (var muzisyen in grup)
            {
                muzisyen.PerformansYap();
            }
        }
    }
}

