using System;
using System.Collections.Generic;

namespace modul6_103082400028
{
    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        private string Username;

        public SayaTubeUser(string username)
        {
            // Precondition
            if (username == null)
                throw new ArgumentException("Username tidak boleh null.");
            if (username.Length > 100)
                throw new ArgumentException("Username maksimal 100 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 100000);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
                total += video.GetPlayCount();
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null)
                throw new ArgumentException("Video yang ditambahkan tidak boleh null.");
            if (video.GetPlayCount() >= int.MaxValue)
                throw new ArgumentException("PlayCount video sudah mencapai batas maksimum integer.");

            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            // Postcondition: hanya print maksimal 8 video
            int maxPrint = Math.Min(uploadedVideos.Count, 8);
            for (int i = 0; i < maxPrint; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
            if (uploadedVideos.Count > 8)
            {
                Console.WriteLine($"(Dan {uploadedVideos.Count - 8} video lainnya tidak ditampilkan sesuai postcondition)");
            }
        }
    }
}
