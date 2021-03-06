/**************************************************************************
 *                                                                        *
 *  File:        PlaylistManager.cs                                       *
 *  Copyright:   (c) 2022, Murariu-Tanasache Iulian                       *
 *  E-mail:      iulian.murariu-tanasache@student.tuiasi.ro               *
 *  Website:     https://github.com/IulianMurariu-Tanasache/MP3_Player    *
 *  Description: Generates file information headers.                      *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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
        private Playlist _currentPlaylist = null;

        ///<value>Este lista obiectelor de tip Playlist ce reprezinta playlist-urile utilizatorului.</value>
        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }

        ///<value>Este Playlist-ul selectat curent.</value>
        public Playlist CurrentPlaylist
        {
            get { return _currentPlaylist; }
        }

        /// <summary>
        /// Seteaza playlist-ul curent dupa nume.
        /// </summary>
        /// <param name="name">Numele playlist-ului</param>
        public void SetCurrentPlaylist(string name)
        {
            if(name == null)
                _currentPlaylist = null;

            foreach (Playlist playlist in _playlists)
            {
                if(playlist.Name == name)
                    _currentPlaylist = playlist;
            }
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
        public PlaylistManager(string playlistsDirectory) : this()
        {
            if (playlistsDirectory == null || playlistsDirectory == "")
                throw new ArgumentNullException("Bad directory!");

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
            if (name == null || name == "")
                throw new ArgumentNullException("Bad name!");
            foreach(Playlist playlist in _playlists)
            {
                if (playlist.Name == name)
                    throw new ArgumentException("Playlist already exists!");
            }
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
                throw new ArgumentNullException("playlist null");
            _playlists.Add(playlist);
        }

        /// <summary>
        /// Sterge Un playlist din lista.
        /// </summary>
        /// <param name="name">Numele playlist-ului de sters.</param>
        public void RemovePlaylist(string name)
        {
            foreach (Playlist playlist in _playlists)
            {
                if (playlist.Name == name)
                {
                    _playlists.Remove(playlist);
                    if(playlist == _currentPlaylist)
                        _currentPlaylist = null;
                    return;
                }
            }
        }

        /// <summary>
        /// Functie ce salveaza in format XML toate lpaylist-urile
        /// </summary>
        public void ExportPlaylists()
        {
            System.IO.Directory.CreateDirectory(@"./Playlists");
            foreach (Playlist playlist in _playlists)
            {
                File.WriteAllText(@"./Playlists/" + playlist.Name + ".xml", playlist.ToXml());
            }
        }
    }
}
