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
            //2. Adım tekil nesneyi burada üret
            tekilNesne = new Baplanti();
        }

        //3. adım üretilen nesneyi diğer sınıflara gönder ki kullansınlar.
        // tekil nesneyi return eden metot yaz.
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
/*
            Baplanti b1 = new Baplanti();
            b1.a = 5;
            Baplanti b2 = new Baplanti();
            b2.a = 5;
            Baplanti b3 = new Baplanti();
            Baplanti b4 = new Baplanti();

            if(b1 == b2) // if(5000 == 7000)  adreslerine bakıyoruz.
                Console.WriteLine(" Adres aynı");
            else 
                Console.WriteLine("Adres farklı kraaal");    Burası çalışır.
  */
            Baplanti b1 = Baplanti.baplantiGonder();
            Baplanti b2 = Baplanti.baplantiGonder();
            if(b1 == b2) // if(5000 == 5000)  adreslerine bakıyoruz. Bu sefer adres aynı 2 pointer var ama bir nesne var
            // Hepsi oradan geliyor
                Console.WriteLine(" Adres aynı"); // burası çalışır
            else 
                Console.WriteLine("Adres farklı ");  
        }
    }
    

// Bir sınıfta maksimum 5 tane nesne olsun ve hangi nesne daha önce kullanılmamışsa ona döndereceğimiz bir kod yaz

// bu kodda bir nesne garanti edildi. Ödevde maksimum 5 tane olacak. Sona geldiğinde başa dönecek.
//Property ile de yap. Constructor ve metotla yap. 
 // Birden fazla nesne oluşturmasını garanti ederek bu yapıyı kuran soru gelir.
}
