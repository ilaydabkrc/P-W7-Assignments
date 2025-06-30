using System;
using System.Collections.Generic;
using System.Linq;


namespace MusicDataLinq
{
    public class Singer
    {
        public string FullName { get; set; }
        public string MusicGenre { get; set; }
        public int DebutYear { get; set; }
        public double AlbumSales { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Singer> singers = new List<Singer>
            {
                new Singer { FullName = "Ajda Pekkan", MusicGenre = "Pop", DebutYear = 1968, AlbumSales = 20 },
                new Singer { FullName = "Sezen Aksu", MusicGenre = "Türk Halk Müziği / Pop", DebutYear = 1971, AlbumSales = 10 },
                new Singer { FullName = "Funda Arar", MusicGenre = "Pop", DebutYear = 1999, AlbumSales = 3 },
                new Singer { FullName = "Sertab Erener", MusicGenre = "Pop", DebutYear = 1994, AlbumSales = 5 },
                new Singer { FullName = "Sıla", MusicGenre = "Pop", DebutYear = 2009, AlbumSales = 3 },
                new Singer { FullName = "Serdar Ortaç", MusicGenre = "Pop", DebutYear = 1994, AlbumSales = 10 },
                new Singer { FullName = "Tarkan", MusicGenre = "Pop", DebutYear = 1992, AlbumSales = 40 },
                new Singer { FullName = "Hande Yener", MusicGenre = "Pop", DebutYear = 1999, AlbumSales = 7 },
                new Singer { FullName = "Hadise", MusicGenre = "Pop", DebutYear = 2005, AlbumSales = 5 },
                new Singer { FullName = "Gülben Ergen", MusicGenre = "Pop / Türk Halk Müziği", DebutYear = 1997, AlbumSales = 10 },
                new Singer { FullName = "Neşet Ertaş", MusicGenre = "Türk Halk Müziği / Türk Sanat Müziği", DebutYear = 1960, AlbumSales = 2 }
            };

            var StartWithS = singers
                .Where(s => s.FullName.StartsWith("S"))
                .Select(s => s.FullName);
            Console.WriteLine("S ile başlayan şarkıcılar: ");
            Console.WriteLine(string.Join(",",StartWithS));
            Console.WriteLine();

            var above10Million = singers
               .Where(s => s.AlbumSales > 10)
               .Select(s => s.FullName);
            Console.WriteLine("🔸 Albüm satışı 10 milyondan fazla olanlar:");
            Console.WriteLine(string.Join(", ", above10Million));
            Console.WriteLine();

            // 3. 2000 öncesi çıkış yapmış ve Pop müzik yapanlar (sıralı)
            var pre2000Pop = singers
                .Where(s => s.DebutYear < 2000 && s.MusicGenre.Contains("Pop"))
                .OrderBy(s => s.DebutYear)
                .ThenBy(s => s.FullName);
            Console.WriteLine("🔸 2000 öncesi çıkış yapmış Pop sanatçıları:");
            foreach (var singer in pre2000Pop)
            {
                Console.WriteLine($"{singer.DebutYear} - {singer.FullName}");
            }
            Console.WriteLine();

            // 4. En çok albüm satan şarkıcı
            var topSeller = singers
                .OrderByDescending(s => s.AlbumSales)
                .First();
            Console.WriteLine($"🔸 En çok albüm satan şarkıcı: {topSeller.FullName} ({topSeller.AlbumSales} milyon)");
            Console.WriteLine();

            // 5. En yeni ve en eski çıkış yapan şarkıcılar
            var newestSinger = singers.OrderByDescending(s => s.DebutYear).First();
            var oldestSinger = singers.OrderBy(s => s.DebutYear).First();
            Console.WriteLine($"🔸 En yeni çıkış yapan şarkıcı: {newestSinger.FullName} ({newestSinger.DebutYear})");
            Console.WriteLine($"🔸 En eski çıkış yapan şarkıcı: {oldestSinger.FullName} ({oldestSinger.DebutYear})");




        }



    }

}