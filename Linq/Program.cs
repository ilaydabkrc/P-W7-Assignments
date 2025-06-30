using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        List<int> sayilar = new List<int>();

        for (int i= 0; i < 10; i++)
        {
            sayilar.Add(rnd.Next(-20, 30));
        }

        Console.WriteLine("Rastgele sayılar: "+ string.Join(",",sayilar));

        var ciftSayilar = sayilar.Where(s => s % 2 == 0).ToList();
        Console.WriteLine("Çift sayılar: " +string.Join(",",ciftSayilar));


        var tekSayilar = sayilar.Where(s => s % 2 != 0).ToList();
        Console.WriteLine("Tek sayılar: "+string.Join(",",tekSayilar));


        var negatifSayilar = sayilar.Where(s => s < 0).ToList();
        Console.WriteLine("Tek sayılar: "+string.Join(",",negatifSayilar));


        var pozitifSayılar = sayilar.Where(s => s > 0).ToList();
        Console.WriteLine("Pozitif sayılar: "+string.Join(",",pozitifSayılar));


        var aralikSayilar = sayilar.Where(s => s > 15 && s < 22).ToList();
        Console.WriteLine("15 < s < 22 Sayılar: " + string.Join(", ", aralikSayilar));

        // 7. Listedeki sayıların kareleri
        var karelerListesi = sayilar.Select(s => s * s).ToList();
        Console.WriteLine("Sayıların Kareleri: " + string.Join(", ", karelerListesi));



    }









}
