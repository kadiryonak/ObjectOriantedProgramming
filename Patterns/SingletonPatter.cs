using System;

// Singleton Design Pattern, Factory, Abstract, Behaivor, DoFactory.com
namespace SingletonPatter
{
    class Baplanti
    {
        public int a;
        private Baplanti()
        {
            //1. Adım Baqlantı sınıfı harici sınıflar çağırılmasın
        }
        static Baplanti()
        {
            //2. Adım tekil nesneyi burada üret. Static constructor, tek sefer çalışır ve her çağırdığında aynı yerden nesne üretir sadece referansını değiştirirsin.
            //Yani nesnelerin adresleri aynı olur. Static olmayan bir constructor da her seferinde başka adres atar.
            tekilNesne = new Baplanti();
        }

        //3. adım üretilen nesneyi diğer sınıflara gönder ki kullansınlar.
        // tekil nesneyi return eden metot yazarak diğer sınıfların kullanımına açabilirsin. Çünkü şu anda constructor private metot. 
        static Baplanti tekilNesne;
        public static Baplanti baplantiGonder()
        {
            return tekilNesne;
        }
    }
    class SingletonPatter
    {
        
        static void Main(string[] args)
        {

            Baplanti b1 = new Baplanti();
            b1.a = 5;
            Baplanti b2 = new Baplanti();
            b2.a = 5;
            Baplanti b3 = new Baplanti();
            Baplanti b4 = new Baplanti();

            if(b1 == b2) // if(5000 == 7000)  adreslerine bakıyoruz.
                Console.WriteLine(" Adres aynı");
            else 
                Console.WriteLine("Adres farklı");    //Burası çalışır. Sebebi yukarda dediğim gibi her seferinde farklı adres çalışır.
  
            Baplanti b1 = Baplanti.baplantiGonder();
            Baplanti b2 = Baplanti.baplantiGonder();
            
            if(b1 == b2) // if(5000 == 5000)  adreslerine bakıyoruz. Adresleri aynı çünkü static metotun özelliği gereği, hepsinden önce çalışır ve bir kere çalışır.
                Console.WriteLine(" Adres aynı"); // burası çalışır
            else 
                Console.WriteLine("Adres farklı ");  
        }
    }
    

// Bir sınıfta maksimum 5 tane nesne olsun ve hangi nesne daha önce kullanılmamışsa ona döndereceğimiz bir kod yaz (SingletonPattern.cs de bu kod mevcuttur).

// Bu kodda bir nesne garanti edildi. Ödevde maksimum 5 tane olacak. Sona geldiğinde başa dönecek. 
// Birden fazla nesne oluşturmasını garanti ederek bu yapıyı kuran soru gelir.
}
