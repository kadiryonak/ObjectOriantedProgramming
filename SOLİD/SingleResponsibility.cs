using System;

namespace BasketballApp
{
    // Oyuncu sınıfı - Sadece oyuncu bilgilerini ve istatistiklerini tutar.
    public class BasketballPlayer
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }

        public BasketballPlayer(string Name, int Points, int Assists, int Rebounds)
        {
            this.Name = Name;
            this.Points = Points;
            this.Assists = Assists;
            this.Rebounds = Rebounds;
        }
    }

    // Formatlama ve istatistik gösterme işlemleri - Ayrı bir sorumluluk.
    public class PlayerStatisticsFormatter
    {
        public string FormatStatistics(BasketballPlayer player)
        {
            return $"Player: {player.Name}\nPoints: {player.Points}\nAssists: {player.Assists}\nRebounds: {player.Rebounds}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Oyuncu nesnesi oluşturma
            BasketballPlayer player = new BasketballPlayer("LeBron James", 30, 8, 10);

            // Formatlama ve gösterim sınıfını kullanma
            PlayerStatisticsFormatter formatter = new PlayerStatisticsFormatter();
            string formattedStats = formatter.FormatStatistics(player);

            // İstatistiklerin görüntülenmesi
            Console.WriteLine(formattedStats);
        }
    }
}
