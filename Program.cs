using System;
using System.Collections.Generic;

namespace modul6_103082400028
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== JURNAL MODUL 6 - EDWARD ADVENTUS DEMBO ===\n");

            // Membuat user dengan username (nama panggilan praktikan)
            SayaTubeUser user = new SayaTubeUser("Edward_Adventus");

            // Daftar judul film bagus (minimal 10)
            string[] judulFilm = {
                "Inception", "The Dark Knight", "Interstellar", "Parasite",
                "Avengers Endgame", "Your Name", "Spirited Away", "The Matrix",
                "John Wick", "Gladiator", "Whiplash", "Coco"
            };

            // Membuat 12 video (lebih dari 8 untuk test postcondition)
            for (int i = 0; i < judulFilm.Length; i++)
            {
                string judul = $"Review Film {judulFilm[i]} oleh Edward Adventus Dembo";
                SayaTubeVideo video = new SayaTubeVideo(judul);
                user.AddVideo(video);
            }

            // Print semua video (hanya 8 pertama karena postcondition)
            user.PrintAllVideoPlaycount();

            // Tampilkan total play count (masih 0 karena belum ditambah)
            Console.WriteLine($"\nTotal Play Count Semua Video: {user.GetTotalVideoPlayCount()}");

            // --- UJI PRECONDITION ---
            Console.WriteLine("\n=== UJI PRECONDITION ===");

            // 1. Judul video null
            try { SayaTubeVideo videoNull = new SayaTubeVideo(null); }
            catch (Exception ex) { Console.WriteLine($"Exception (judul null): {ex.Message}"); }

            // 2. Judul > 200 karakter
            try
            {
                string judulPanjang = new string('X', 250);
                SayaTubeVideo videoPanjang = new SayaTubeVideo(judulPanjang);
            }
            catch (Exception ex) { Console.WriteLine($"Exception (judul >200): {ex.Message}"); }

            // 3. Username null
            try { SayaTubeUser userNull = new SayaTubeUser(null); }
            catch (Exception ex) { Console.WriteLine($"Exception (username null): {ex.Message}"); }

            // 4. Username > 100 karakter
            try
            {
                string usernamePanjang = new string('X', 150);
                SayaTubeUser userPanjang = new SayaTubeUser(usernamePanjang);
            }
            catch (Exception ex) { Console.WriteLine($"Exception (username >100): {ex.Message}"); }

            // 5. Penambahan play count negatif
            SayaTubeVideo videoTest = new SayaTubeVideo("Video Test");
            try { videoTest.IncreasePlayCount(-100); }
            catch (Exception ex) { Console.WriteLine($"Exception (negatif): {ex.Message}"); }

            // 6. Penambahan play count > 25.000.000
            try { videoTest.IncreasePlayCount(30_000_000); }
            catch (Exception ex) { Console.WriteLine($"Exception (>25jt): {ex.Message}"); }

            // 7. AddVideo dengan null
            try { user.AddVideo(null); }
            catch (Exception ex) { Console.WriteLine($"Exception (video null): {ex.Message}"); }

            // --- UJI OVERFLOW DENGAN checked & LOOP ---
            Console.WriteLine("\n=== UJI OVERFLOW (dengan loop) ===");
            SayaTubeVideo overflowVideo = new SayaTubeVideo("Video Overflow Test");
            try
            {
                // Loop untuk mempercepat overflow
                for (int i = 0; i < 2000; i++)
                {
                    overflowVideo.IncreasePlayCount(2_000_000);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OverflowException tertangkap: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception lain: {ex.Message}");
            }

            overflowVideo.PrintVideoDetails();

            Console.WriteLine("\nProgram selesai. Tekan Enter untuk keluar.");
            Console.ReadLine();
        }
    }
}