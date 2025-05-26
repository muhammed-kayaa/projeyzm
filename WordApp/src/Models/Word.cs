namespace WordApp.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string EngWordName { get; set; }
        public string TurWordName { get; set; }
        public string Picture { get; set; }

        // Parametresiz constructor EKLE!
        public Word() { }

        // Eğer gerekiyorsa parametreli constructor da kalabilir:
        public Word(int wordId, string engWordName, string turWordName, string picture)
        {
            WordId = wordId;
            EngWordName = engWordName;
            TurWordName = turWordName;
            Picture = picture;
        }
    }
}