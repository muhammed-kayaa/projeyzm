namespace WordApp.Models
{
    public class Word
    {
        public int WordID { get; set; }
        public string EngWordName { get; set; }
        public string TurWordName { get; set; }
        public string Picture { get; set; }

        public Word(int wordId, string engWordName, string turWordName, string picture)
        {
            WordID = wordId;
            EngWordName = engWordName;
            TurWordName = turWordName;
            Picture = picture;
        }
    }
}