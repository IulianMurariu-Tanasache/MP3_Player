using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistControls
{
    /// <summary>
    /// Clasa <c>PlaylistManager</c> ajuta la gestionarea tuturor playlist-urilor.
    /// </summary>
    public class PlaylistManager
    {
        private List<Playlist> _playlists; //lista playlist-urilor

        ///<value>Este lista obiectelor de tip Playlist ce reprezinta playlist-urile utilizatorului.</value>
        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }

        /// <summary>
        /// Constructor ce initializeaza lista playlist-urilor.
        /// </summary>
        
        // Pot adauga incarcarea unui director de playlist-uri direct in constructor
        public PlaylistManager()
        {
            _playlists = new List<Playlist>();
        }

        /// <summary>
        /// Constructor ce incarca toate fisierele XML corespunzatoare unor playlist-uri.
        /// Playlist-urile create vor fi adaugate in lista.
        /// </summary>
        /// <param name="playlistsDirectory">Path-ul directorului in care se afla fisierele XML</param>
        /// <remarks>
        /// Fisierele XML trebuie sa aiba acelasi format ca cel descris la functia de Serializare din <c>Playlist</c>.
        /// </remarks>
        public PlaylistManager(String playlistsDirectory) : this()
        {
            DirectoryInfo d = new DirectoryInfo(playlistsDirectory);
            FileInfo[] Files = d.GetFiles("*.xml");

            foreach (FileInfo file in Files)
            {
                AddPlaylist(Playlist.FromXml(file.FullName));
            }
        }

        /// <summary>
        /// Creeaza un playlist nou, gol.
        /// </summary>
        /// <param name="name">Numele playlist-ului.</param>
        public void AddPlaylist(string name)
        {
            _playlists.Add(new Playlist(name));
        }

        /// <summary>
        /// Adauga un obiect Playlist care exista deja in lista.
        /// </summary>
        /// <param name="playlist">Obiect de tip Playlist.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddPlaylist(Playlist playlist)
        {
            if (playlist == null)
                //exceptie custom i guess?
                throw new ArgumentNullException("playlist null");
            _playlists.Add(playlist);
        }

        /// <summary>
        /// Sterge Un playlist din lista.
        /// </summary>
        /// <param name="name">Numele playlist-ului de sters.</param>
         
        // Sa adauga  si aici exceptie daca nu exista??
        public void RemovePlaylist(string name)
        {
            foreach (Playlist playlist in _playlists)
            {
                if (playlist.Name == name)
                {
                    _playlists.Remove(playlist);
                    return;
                }
            }
        }
    }
}
