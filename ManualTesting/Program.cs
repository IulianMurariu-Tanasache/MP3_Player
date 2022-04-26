using PlaylistControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualTesting
{
    internal class Program
    {
        static int whatMenu = 0;
        static PlaylistManager playlistManager = new PlaylistManager();
        static Playlist currentPlaylist = null;

        static void menuPlaylists()
        {
            Console.WriteLine("Meniu Playlists");
            Console.WriteLine("1. Adauga");
            Console.WriteLine("2. Sterge");
            Console.WriteLine("3. Vezi");
            Console.WriteLine("4. Modifica");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            string input = Console.ReadLine();
            int op = int.Parse(input);
            switch (op)
            {
                default:
                    Console.WriteLine("Optiune proasta");
                    break;
                case 1:
                    Console.WriteLine("Nume: ");
                    input = Console.ReadLine();
                    playlistManager.AddPlaylist(input);
                    break;
                case 2:
                    Console.WriteLine("Nume: ");
                    input = Console.ReadLine();
                    playlistManager.RemovePlaylist(input);
                    break;
                case 3:
                    foreach (Playlist playlist in playlistManager.Playlists)
                    {
                        Console.WriteLine(playlist.ToXml());
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine("Nume: ");
                    input = Console.ReadLine();
                    foreach(Playlist playlist in playlistManager.Playlists)
                    {
                        if(playlist.Name == input)
                        {
                            currentPlaylist = playlist;
                            break;
                        }
                    }
                    whatMenu = 1;
                    break;
                case 5:
                    foreach(Playlist playlist in playlistManager.Playlists)
                    {
                        File.WriteAllText(playlist.Name + ".xml",playlist.ToXml());
                    }
                    break;
                case 6:
                    DirectoryInfo d = new DirectoryInfo(".");

                    FileInfo[] Files = d.GetFiles("*.xml");
                    string str = "";

                    foreach (FileInfo file in Files)
                    {
                        playlistManager.AddPlaylist(Playlist.FromXml(file.FullName));
                    }
                    break;
            }
        }

        static void menuPlaylist()
        {
            Console.WriteLine("Meniu Playlist");
            Console.WriteLine("1. Adauga");
            Console.WriteLine("2. Sterge");
            Console.WriteLine("3. Vezi");
            Console.WriteLine("4. Modifica");
            Console.WriteLine("5. Back");
            string input = Console.ReadLine();
            int op = int.Parse(input);
            switch (op)
            {
                default:
                    Console.WriteLine("Optiune proasta");
                    break;
                case 1:
                    Console.WriteLine("Nume Melodie: ");
                    input = Console.ReadLine();
                    currentPlaylist.AddSong(input);
                    break;
                case 2:
                    Console.WriteLine("Nume Melodie: ");
                    input = Console.ReadLine();
                    currentPlaylist.RemoveSong(input);
                    break;
                case 3:
                    Console.WriteLine(currentPlaylist.ToXml());
                    break;
                case 5:
                    currentPlaylist = null;
                    whatMenu = 0;
                    break;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                switch (whatMenu)
                {
                    case 0:
                        menuPlaylists(); 
                        break;
                    case 1:
                        menuPlaylist();
                        break;
                }
            }
        }
    }
}
