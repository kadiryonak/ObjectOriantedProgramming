using System;

namespace SingletonPoolPattern
{
    class BaplantiPool
    {
        private static readonly BaplantiPool[] pool = new BaplantiPool[5];
        private static readonly bool[] isUsed = new bool[5]; 
        private static int currentIndex = 0;

        public int Id { get; private set; } 

        private BaplantiPool(int id)
        {
            Id = id;
        }

        static BaplantiPool()
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = new BaplantiPool(i + 1); // 1'den 5'e kadar ID atanır
                isUsed[i] = false; // Tüm nesneler başlangıçta boş
            }
        }

        public static BaplantiPool GetNextAvailable()
        {
            for (int i = 0; i < pool.Length; i++)
            {
                int index = (currentIndex + i) % pool.Length; // Döngüsel kontrol
                if (!isUsed[index])
                {
                    isUsed[index] = true; // Nesne kullanımda olarak işaretlenir
                    currentIndex = index; // Son kullanılan index güncellenir
                    return pool[index];
                }
            }
            
            throw new InvalidOperationException("Tüm nesneler kullanımda!");
        }

        public static void Release(BaplantiPool obj)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                if (pool[i] == obj)
                {
                    isUsed[i] = false; // Nesne boş olarak işaretlenir
                    return;
                }
            }
            throw new ArgumentException("Nesne havuzda bulunmuyor!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b1 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B1 ID: " + b1.Id);

            var b2 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B2 ID: " + b2.Id);

            var b3 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B3 ID: " + b3.Id);

            var b4 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B4 ID: " + b4.Id);

            var b5 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B5 ID: " + b5.Id);

            // Serbest bırakılan nesneler tekrar kullanılabilir
            BaplantiPool.Release(b3);
            var b6 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B6 ID (B3 tekrar kullanıldı): " + b6.Id);

            BaplantiPool.Release(b1);
            var b7 = BaplantiPool.GetNextAvailable();
            Console.WriteLine("B7 ID (B1 tekrar kullanıldı): " + b7.Id);
        }
    }
}