// Adapter Pattern, farklı arayüzlere (interface) sahip olan iki sınıfı birbiriyle uyumlu hale getirmek için kullanılır. 
// Eski bir sistemle yeni bir sistemin birlikte çalışmasını sağlar.

using System;

namespace AdapterDeseniOrnegi
{
    // ITarget: Müşterinin (Client) kullanmak istediği arayüz.
    // Uygulamanın diğer kısımları bu arayüz üzerinden işlem yapar.
    public interface ITarget
    {
        string GetRequest();
    }

    // Adaptee: Halihazırda var olan, işe yarayan ancak arayüzü uyumsuz olan sınıf.
    // Yani client (istemci) doğrudan bu sınıfla çalışamaz.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Özgül istek"; // Özgün (specific) metodun dönüş değeri
        }
    }

    // Adapter: Hem ITarget arayüzünü uygular (client ile uyumlu olur),
    // hem de içeride Adaptee nesnesini kullanarak onun fonksiyonelliğini sunar.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        // Adapter, içeride kullanılacak Adaptee nesnesini alır.
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        // ITarget arayüzünün metodunu implemente eder ve
        // içeride Adaptee'nin metodunu çağırır.
        public string GetRequest()
        {
            return $"Adapter üzerinden: '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Adaptee sınıfı, mevcut ancak istemcinin beklediği yapıyla uyumlu değil.
            Adaptee adaptee = new Adaptee();

            // Adapter sınıfı, Adaptee nesnesini alır ve ITarget arayüzüne uyarlayarak
            // istemcinin anlayacağı şekilde çalışmasını sağlar.
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee sınıfının arayüzü istemciyle uyumlu değil.");
            Console.WriteLine("Ancak Adapter sayesinde istemci onun metodunu çağırabiliyor.");

            // İstemci artık ITarget arayüzü üzerinden Adaptee'nin metodunu dolaylı olarak çağırabilir.
            Console.WriteLine(target.GetRequest());
        }
    }
}
