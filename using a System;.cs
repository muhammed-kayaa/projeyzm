using System;

namespace KelimeEzberlemeSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kelime Ezberleme Sistemine Hoş Geldiniz!\n");

            UserSystem userSystem = new UserSystem();
            if (!userSystem.Login())
            {
                Console.WriteLine("Giriş yapılamadı. Programdan çıkılıyor...");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nAna Menü:");
                Console.WriteLine("1. Kullanıcı Yönetimi");
                Console.WriteLine("2. Kelime Yönetimi");
                Console.WriteLine("3. Sınav Modülü");
                Console.WriteLine("4. Ayarlar");
                Console.WriteLine("5. Analiz Raporları");
                Console.WriteLine("6. Çıkış");

                Console.Write("Seçiminizi yapın: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        userSystem.ManageUsers();
                        break;
                    case "2":
                        WordSystem wordSystem = new WordSystem();
                        wordSystem.ManageWords();
                        break;
                    case "3":
                        QuizSystem quizSystem = new QuizSystem();
                        quizSystem.StartQuiz();
                        break;
                    case "4":
                        Settings settings = new Settings();
                        settings.UpdateSettings();
                        break;
                    case "5":
                        Report report = new Report();
                        report.GenerateReport();
                        break;
                    case "6":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }

    class UserSystem
    {
        public bool Login()
        {
            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();
            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "1234")
            {
                Console.WriteLine("Giriş başarılı!");
                return true;
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen tekrar deneyin.");
                return false;
            }
        }

        public void ManageUsers()
        {
            Console.WriteLine("Kullanıcı Yönetim Bölümü");
        }
    }

    class WordSystem
    {
        public void ManageWords()
        {
            Console.WriteLine("Kelime Yönetim Bölümü");
        }
    }

    class QuizSystem
    {
        public void StartQuiz()
        {
            Console.WriteLine("Sınav Modülü Başlatıldı");
        }
    }

    class Settings
    {
        public void UpdateSettings()
        {
            Console.WriteLine("Ayarlar Güncellendi");
        }
    }

    class Report
    {
        public void GenerateReport()
        {
            Console.WriteLine("Analiz Raporları Üretildi");
        }
    }
}