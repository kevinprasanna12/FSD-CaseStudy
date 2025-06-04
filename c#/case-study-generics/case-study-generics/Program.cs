using System;
using System.Collections.Generic;
using System.Linq;

namespace case_study_generics
{
  
        public class Song
        {
            public int SongId { get; set; }
            public string SongName { get; set; }
            public string SongGenre { get; set; }
        }

        public interface IPlaylist
        {
            void Add(Song song);
            void Remove(int songId);
            Song GetSongById(int songId);
            Song GetSongByName(string songName);
            List<Song> GetAllSongs();
        }

        public class MyPlayList : IPlaylist
        {
            public static List<Song> myPlayList = new List<Song>();
            private const int Capacity = 20;

            public void Add(Song song)
            {
                if (myPlayList.Count >= Capacity)
                {
                    Console.WriteLine("Playlist is full. Cannot add more than 20 songs.");
                    return;
                }

                if (!IsValidGenre(song.SongGenre))
                {
                    Console.WriteLine("Invalid Genre. Allowed genres: Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic");
                    return;
                }

                myPlayList.Add(song);
                Console.WriteLine("Song added successfully.");
            }

            public void Remove(int songId)
            {
                var song = myPlayList.FirstOrDefault(s => s.SongId == songId);
                if (song != null)
                {
                    myPlayList.Remove(song);
                    Console.WriteLine("Song removed successfully.");
                }
                else
                {
                    Console.WriteLine("Song with ID not found.");
                }
            }

            public Song GetSongById(int songId)
            {
                return myPlayList.FirstOrDefault(s => s.SongId == songId);
            }

            public Song GetSongByName(string songName)
            {
                return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
            }

            public List<Song> GetAllSongs()
            {
                return myPlayList;
            }

            private bool IsValidGenre(string genre)
            {
                string[] allowedGenres = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };
                return allowedGenres.Contains(genre, StringComparer.OrdinalIgnoreCase);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                MyPlayList playlist = new MyPlayList();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\n====== SongsHub Menu ======");
                    Console.WriteLine("1. Add Song");
                    Console.WriteLine("2. Remove Song by ID");
                    Console.WriteLine("3. Get Song by ID");
                    Console.WriteLine("4. Get Song by Name");
                    Console.WriteLine("5. View All Songs");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Song newSong = new Song();
                            Console.Write("Enter Song ID: ");
                            newSong.SongId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Song Name: ");
                            newSong.SongName = Console.ReadLine();
                            Console.Write("Enter Song Genre: ");
                            newSong.SongGenre = Console.ReadLine();
                            playlist.Add(newSong);
                            break;

                        case "2":
                            Console.Write("Enter Song ID to remove: ");
                            int removeId = Convert.ToInt32(Console.ReadLine());
                            playlist.Remove(removeId);
                            break;

                        case "3":
                            Console.Write("Enter Song ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var songById = playlist.GetSongById(id);
                            if (songById != null)
                                PrintSong(songById);
                            else
                                Console.WriteLine("Song not found.");
                            break;

                        case "4":
                            Console.Write("Enter Song Name: ");
                            string name = Console.ReadLine();
                            var songByName = playlist.GetSongByName(name);
                            if (songByName != null)
                                PrintSong(songByName);
                            else
                                Console.WriteLine("Song not found.");
                            break;

                        case "5":
                            var allSongs = playlist.GetAllSongs();
                            if (allSongs.Count == 0)
                                Console.WriteLine("Playlist is empty.");
                            else
                                foreach (var song in allSongs)
                                    PrintSong(song);
                            break;

                        case "6":
                            running = false;
                            Console.WriteLine("Exiting SongsHub. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            }

            static void PrintSong(Song song)
            {
                Console.WriteLine($"\nID: {song.SongId}, Name: {song.SongName}, Genre: {song.SongGenre}");
            }
        }
}


