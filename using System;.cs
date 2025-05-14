using System;
using System.Collections.Generic;

namespace GirisSistemi
{
    class Program
    {
                static Dictionary<string, string> kullanicilar = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            
            kullanicilar.Add("admin", "12345");

            while (true)
            {
                Console.WriteLine("1. Giriş Yap");
                Console.WriteLine("2. Kayıt Ol");
                Console.WriteLine("3. Şifremi Unuttum");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        GirisYap();
                        break;
                    case "2":
                        KayitOl();
                        break;
                    case "3":
                        SifremiUnuttum();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void GirisYap()
        {
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            if (kullanicilar.ContainsKey(kullaniciAdi) && kullanicilar[kullaniciAdi] == sifre)
            {
                Console.WriteLine("Giriş başarılı! Hoş geldiniz, " + kullaniciAdi);
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre hatalı.");
            }
        }

        static void KayitOl()
        {
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();

            if (kullanicilar.ContainsKey(kullaniciAdi))
            {
                Console.WriteLine("Bu kullanıcı adı zaten mevcut. Lütfen başka bir kullanıcı adı seçin.");
                return;
            }

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();
            kullanicilar.Add(kullaniciAdi, sifre);
            Console.WriteLine("Kayıt başarılı! Artık giriş yapabilirsiniz.");
        }

        static void SifremiUnuttum()
        {
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();

            if (kullanicilar.ContainsKey(kullaniciAdi))
            {
                Console.WriteLine("Şifreniz: " + kullanicilar[kullaniciAdi]); // Gerçek sistemlerde şifreyi direkt göstermek doğru değildir.
            }
            else
            {
                Console.WriteLine("Bu kullanıcı adı bulunamadı.");
            }
        }
    }
}