using System;
using System.Collections.Generic;

namespace MultitonPattern
{
    class BaplantiPool
    {
        private static readonly Dictionary<int, BaplantiPool> pool = new Dictionary<int, BaplantiPool>(); // Nesneler için bir liste oluşturduk.
        private const int MAX_INSTANCES = 5;// 5 tane farklı nesnemiz olacak daha fazlası değil. Bunu ben id vererek istediğim nesneyi çağıracağım. İsterseniz bir döngü ile sürekli başa saran bir yapı da oluşturabilirsiniz.

        public int Id { get; private set; }

        // Private constructor — dışarıdan new yapılamaz
        private BaplantiPool(int id)
        {
            Id = id;
            Console.WriteLine($"BaplantiPool #{id} oluşturuldu.");
        }

        // Nesneye ID ile erişim sağlar
        public static BaplantiPool GetInstance(int id)
        {
            if (id < 1 || id > MAX_INSTANCES)
                throw new ArgumentException("ID 1 ile 5 arasında olmalı!");

            if (!pool.ContainsKey(id))
            {
                pool[id] = new BaplantiPool(id); // Yalnızca bir kez oluştur
            }

            return pool[id]; // Her seferinde aynı örneği döndür
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b1 = BaplantiPool.GetInstance(1);
            var b2 = BaplantiPool.GetInstance(2);
            var b3 = BaplantiPool.GetInstance(3);
            var b4 = BaplantiPool.GetInstance(4);
            var b5 = BaplantiPool.GetInstance(5);

            // Aynı ID ile tekrar erişim, aynı nesneyi verir
            var b1Again = BaplantiPool.GetInstance(1);

            Console.WriteLine($"b1 == b1Again ? {b1 == b1Again}"); // true
            // Başka denemeler de yapabilirsiniz. Hangisinin adresi aynı veya farklı.
        }
    }
}
