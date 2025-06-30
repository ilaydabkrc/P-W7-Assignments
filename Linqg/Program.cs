using System;
using System.Collections.Generic;
using System.Linq;

namespace OkulVeritabani
{
    // Öğrenci sınıfı
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }

    // Sınıf sınıfı
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenciler listesi
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali", ClassId = 101 },
                new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 101 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 102 },
                new Student { StudentId = 4, StudentName = "Zeynep", ClassId = 103 },
                new Student { StudentId = 5, StudentName = "Kemal", ClassId = 101 }
            };

            // Sınıflar listesi
            List<Class> classes = new List<Class>
            {
                new Class { ClassId = 101, ClassName = "10-A" },
                new Class { ClassId = 102, ClassName = "10-B" },
                new Class { ClassId = 103, ClassName = "10-C" },
                new Class { ClassId = 104, ClassName = "10-D" } // boş sınıf örneği
            };

            // LINQ Group Join: Sınıf başına öğrencileri grupla
            var siniflarVeOgrenciler = from sinif in classes
                                       join ogrenci in students
                                       on sinif.ClassId equals ogrenci.ClassId into ogrencilerGrubu
                                       select new
                                       {
                                           SinifAdi = sinif.ClassName,
                                           Ogrenciler = ogrencilerGrubu
                                       };

            // Sonuçları yazdır
            Console.WriteLine("📚 Sınıflar ve Öğrencileri:\n");

            foreach (var grup in siniflarVeOgrenciler)
            {
                Console.WriteLine($"Sınıf: {grup.SinifAdi}");

                if (grup.Ogrenciler.Any())
                {
                    foreach (var ogrenci in grup.Ogrenciler)
                    {
                        Console.WriteLine($" - {ogrenci.StudentName}");
                    }
                }
                else
                {
                    Console.WriteLine(" - Bu sınıfta öğrenci yok.");
                }

                Console.WriteLine(); // boşluk bırak
            }

            Console.WriteLine("Program sona erdi. Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
