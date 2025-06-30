using System;
using System.Collections.Generic;
using System.Linq;

namespace DiziUygulamasi
{
    class Program
    {
        // Ana Dizi sınıfı
        public class Dizi
        {
            public string DiziAdi { get; set; }
            public int YapimYili { get; set; }
            public string Tur { get; set; }
            public int YayinaBaslamaYili { get; set; }
            public string Yonetmen { get; set; }
            public string Platform { get; set; }
        }

        // Komedi dizileri için özel sınıf
        public class KomediDizisi
        {
            public string DiziAdi { get; set; }
            public string Tur { get; set; }
            public string Yonetmen { get; set; }

            public override string ToString()
            {
                return $"Dizi Adı: {DiziAdi}, Tür: {Tur}, Yönetmen: {Yonetmen}";
            }
        }

        static void Main(string[] args)
        {
            List<Dizi> diziler = new List<Dizi>();
            string cevap;

            do
            {
                Dizi dizi = new Dizi();

                Console.Write("Dizi Adı: ");
                dizi.DiziAdi = Console.ReadLine();

                Console.Write("Yapım Yılı: ");
                dizi.YapimYili = int.Parse(Console.ReadLine());

                Console.Write("Türü: ");
                dizi.Tur = Console.ReadLine();

                Console.Write("Yayınlanmaya Başlama Yılı: ");
                dizi.YayinaBaslamaYili = int.Parse(Console.ReadLine());

                Console.Write("Yönetmen: ");
                dizi.Yonetmen = Console.ReadLine();

                Console.Write("Yayınlandığı İlk Platform: ");
                dizi.Platform = Console.ReadLine();

                diziler.Add(dizi);

                Console.Write("Yeni bir dizi eklemek istiyor musunuz? (E/H): ");
                cevap = Console.ReadLine().ToUpper();

            } while (cevap == "E");

            // Komedi türündeki dizileri filtrele
            List<KomediDizisi> komediDizileri = diziler
                .Where(d => d.Tur.ToLower().Contains("komedi"))
                .Select(d => new KomediDizisi
                {
                    DiziAdi = d.DiziAdi,
                    Tur = d.Tur,
                    Yonetmen = d.Yonetmen
                })
                .ToList();

            // Ada göre sıralı yazdır
            Console.WriteLine("\nKomedi Dizileri (Dizi Adına göre sıralı):");
            foreach (var d in komediDizileri.OrderBy(k => k.DiziAdi))
            {
                Console.WriteLine(d);
            }

            // Yönetmene göre sıralı yazdır
            Console.WriteLine("\nKomedi Dizileri (Yönetmen Adına göre sıralı):");
            foreach (var d in komediDizileri.OrderBy(k => k.Yonetmen))
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("\nProgram sona erdi. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}

