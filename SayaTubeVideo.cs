using System;

namespace modul6_103082400028
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            // Precondition
            if (title == null)
                throw new ArgumentException("Judul video tidak boleh null.");
            if (title.Length > 200)
                throw new ArgumentException("Judul video maksimal 200 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 100000); // 5 digit random
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int increment)
        {
            // Precondition
            if (increment < 0)
                throw new ArgumentException("Increment play count tidak boleh negatif.");
            if (increment > 25_000_000)
                throw new ArgumentException("Penambahan play count maksimal 25.000.000 per panggilan.");

            // Exception: checked untuk overflow
            checked
            {
                this.playCount += increment;
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"Video ID: {id} | Judul: {title} | Play Count: {playCount}");
        }

        public int GetPlayCount() => playCount;
        public string GetTitle() => title;
    }
}