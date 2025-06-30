using System;
using System.Collections.Generic;
using System.Linq;

namespace TVSeriesApp
{
    // Dizi nesnesini temsil eden sınıf
    public class TVSeries
    {
        public string Name { get; set; }             // Dizi adı
        public int ProductionYear { get; set; }      // Yapım yılı
        public string Genre { get; set; }            // Türü
        public int StartYear { get; set; }           // Yayınlanmaya başlama yılı
        public string Director { get; set; }         // Yönetmen
        public string Platform { get; set; }         // Yayınlandığı platform
    }

    // Sadece Dizi Adı / Türü / Yönetmen içeren sınıf
    public class ComedySeriesSummary
    {
        public string Name { get; set; }         // Dizi adı
        public string Genre { get; set; }        // Tür
        public string Director { get; set; }     // Yönetmen
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TVSeries> allSeries = new List<TVSeries>();

            while (true)
            {
                // Console üzerinden kullanıcıdan veri alınıyor
                Console.WriteLine("Yeni dizi ekleyiniz:");

                Console.Write("Dizi adı: ");
                string name = Console.ReadLine();

                Console.Write("Yapım yılı: ");
                int productionYear = int.Parse(Console.ReadLine());

                Console.Write("Türü: ");
                string genre = Console.ReadLine();

                Console.Write("Yayınlanmaya başlama yılı: ");
                int startYear = int.Parse(Console.ReadLine());

                Console.Write("Yönetmen: ");
                string director = Console.ReadLine();

                Console.Write("Yayınlandığı platform: ");
                string platform = Console.ReadLine();

                // Nesne oluşturulup listeye ekleniyor
                allSeries.Add(new TVSeries
                {
                    Name = name,
                    ProductionYear = productionYear,
                    Genre = genre,
                    StartYear = startYear,
                    Director = director,
                    Platform = platform
                });

                // Yeni dizi eklemek istiyor musunuz?
                Console.Write("Yeni bir dizi eklemek istiyor musunuz? (e/h): ");
                string answer = Console.ReadLine().ToLower();

                if (answer != "e")
                    break;

                Console.WriteLine();
            }

            // Komedi türündeki dizileri süzüyoruz
            List<ComedySeriesSummary> comedyList = allSeries
                .Where(d => d.Genre.ToLower().Contains("komedi"))
                .Select(d => new ComedySeriesSummary
                {
                    Name = d.Name,
                    Genre = d.Genre,
                    Director = d.Director
                })
                .OrderBy(d => d.Name)
                .ThenBy(d => d.Director)
                .ToList();

            // Sonuçlar ekrana yazdırılıyor
            Console.WriteLine("\n🔸 Komedi Dizileri (İsim ve Yönetmene göre sıralı):\n");

            foreach (var comedy in comedyList)
            {
                Console.WriteLine($"Dizi: {comedy.Name} | Tür: {comedy.Genre} | Yönetmen: {comedy.Director}");
            }
        }
    }
}
