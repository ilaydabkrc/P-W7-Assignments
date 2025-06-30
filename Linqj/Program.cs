using System;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneYonetim
{
    // Yazarlar tablosuna karşılık gelen sınıf
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    // Kitaplar tablosuna karşılık gelen sınıf
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yazarları tanımla
            List<Author> authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "Orhan Pamuk" },
                new Author { AuthorId = 2, Name = "Elif Şafak" },
                new Author { AuthorId = 3, Name = "Ahmet Ümit" }
            };

            // Kitapları tanımla
            List<Book> books = new List<Book>
            {
                new Book { BookId = 1, Title = "Kar", AuthorId = 1 },
                new Book { BookId = 2, Title = "İstanbul", AuthorId = 1 },
                new Book { BookId = 3, Title = "10 Minutes 38 Seconds in This Strange World", AuthorId = 2 },
                new Book { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3 }
            };

            // LINQ JOIN işlemi: Kitapları yazarlarıyla eşleştir
            var kitapYazarListesi = from book in books
                                    join author in authors
                                    on book.AuthorId equals author.AuthorId
                                    select new
                                    {
                                        KitapBaslik = book.Title,
                                        YazarAdi = author.Name
                                    };

            // Sonuçları yazdır
            Console.WriteLine("📚 Kitaplar ve Yazarları:");
            foreach (var item in kitapYazarListesi)
            {
                Console.WriteLine($"- Kitap: {item.KitapBaslik}, Yazar: {item.YazarAdi}");
            }

            Console.WriteLine("\nProgram sona erdi. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}

