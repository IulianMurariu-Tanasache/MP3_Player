/**************************************************************************
 *                                                                        *
 *  File:        MP3_Player.cs                                            *
 *  Copyright:   (c) 2022, Pandeleanu Cosmin-Constantin                   *
 *  E-mail:      cosmin-constantin.pandeleanu@student.tuiasi.ro           *
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
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MpPlayer; // a lui Stefan
using ControlulInterfeteiNameSpace; // a lui Mihai
using PlaylistControls; // a lui Iulian
using System.Collections.Generic;

namespace MP3_Player_Interface
{
    /// <summary>
    /// Clasa <c>MP3_Player</c> reprezinta interfata grafica a aplicatiei.
    /// </summary>
    public partial class MP3_Player : Form
    {
        private Load _loadFiles;
        private ControlulInterfetei _controlulInterfetei;
        private PlaylistManager _playlistManager;

        private int _volume = 100;
        private bool _shuffle = false;
        private string _currentMusic = "";

        /// <summary>
        /// Constructor ce initializeaza fereastra grafica a MP3 Player-ului.
        /// </summary>
        public MP3_Player()
        {
            InitializeComponent();
            _loadFiles = new Load();
            _controlulInterfetei = ControlulInterfetei.Instance();
            _playlistManager = new PlaylistManager();
        }

        /// <summary>
        /// Aceasta functie se declanșează când form-ul se încarcă.
        /// </summary>
        private void MP3_Player_Load(object sender, EventArgs e)
        {
            //assign a contextmenustrip
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Opening += new CancelEventHandler(listboxContextMenu_Opening);
            listBoxPlaylist.ContextMenuStrip = contextMenuStrip;

            contextMenuStripPlaylists = new ContextMenuStrip();
            contextMenuStripPlaylists.Opening += new CancelEventHandler(contextMenuStripPlaylists_Opening);
            listBoxPlaylists.ContextMenuStrip = contextMenuStripPlaylists;

            buttonPause.Enabled = false;
        }

        /// <summary>
        /// Aceasta functie este asociata butonului About in bara de meniu
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mp3 Player");
        }

        /// <summary>
        /// Aceasta functie este asociata butonului Load From Directory in bara de meniu
        /// </summary>
        /// _playlistManger,currentplaylist.pathlist
        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                list = _loadFiles.LoadMusic();
                //listBoxPlaylist.Items.Clear();
                foreach (String melody in list)
                {

                    listBoxPlaylist.Items.Add(melody);

                }
                _playlistManager.CurrentPlaylist.AddSongs(_loadFiles.ListOfMusic.ToArray());
                _controlulInterfetei.AddSongs(_playlistManager.CurrentPlaylist.PathList);
            }
            catch (System.NullReferenceException nullEx)
            {
                MessageBox.Show("Nici un playlist selectat!");
            }
        }
		
        /// <summary>
        /// Functie apelata cand se porneste o noua melodie pentru a reseta enviromentul
        /// </summary>
        private void playMusic()
        {
            buttonPause.Enabled = true;
            //while (_controlulInterfetei.FullDuration == 0) ;
            trackBarTime.Maximum = _controlulInterfetei.FullDuration;
            //conversie din secunde in minute:secudne
            labelTimeEnd.Text = _controlulInterfetei.FullDuration.ToString();
            trackBarTime.Value = 0;
            //labelNume = _currentMusic;
        }

        /// <summary>
        /// Aceasta functie 
        /// </summary>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedMusic = _playlistManager.CurrentPlaylist.GetFullPath(listBoxPlaylist.SelectedItem.ToString());
                if (_currentMusic != selectedMusic)
                {
                    _currentMusic = selectedMusic;
                    _controlulInterfetei.Play(_currentMusic);
                    playMusic();
                } else
                {
                    _controlulInterfetei.Play();
                }
            }
            catch(ArgumentOutOfRangeException argExcp)
            {
                return;
            }
            catch(Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        /// <summary>
        /// Aceasta functie 
        /// </summary>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Pause();
        }

        /// <summary>
        /// Aceasta functie permite accesarea melodiei urmatoare din playlist.
        /// </summary>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                _controlulInterfetei.Next();
                playMusic();
            }
            catch(NullReferenceException excp)
            {
                return;
            }
        }

        /// <summary>
        /// Aceasta functie permite accesarea melodiei anterioare din playlist.
        /// </summary>
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                _controlulInterfetei.Previous();
                playMusic();
            }
            catch (NullReferenceException excp)
            {
                return;
            }
        }

        /// <summary>
        /// Aceasta functie activeaza/dezactiveaza optiunea de Shuffle.
        /// </summary>
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            _shuffle = !_shuffle;
            _controlulInterfetei.Shuffle(_shuffle);
            if(_shuffle)
                buttonShuffle.BackColor = System.Drawing.Color.FromArgb(153, 180, 209);
            else
                buttonShuffle.BackColor = System.Drawing.Color.FromArgb(133, 150, 189);
        }

        /// <summary>
        /// Aceasta functie permite scaderea volumului.
        /// </summary>
        private void buttonVolumeDown_Click(object sender, EventArgs e)
        {
            _volume -= 4;
            Console.WriteLine(_volume);
            _controlulInterfetei.Volume(_volume);
        }

        /// <summary>
        /// Aceasta functie permite cresterea volumului.
        /// </summary>
        private void buttonVolumeUp_Click(object sender, EventArgs e)
        {
            _volume += 4;
            _controlulInterfetei.Volume(_volume);
        }

        /// <summary>
        /// Aceasta functie permite scaderea volumului la zero.
        /// </summary>
        private void buttonVolumeMute_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Volume(0);
        }

        /// <summary>
        /// Aceasta functie permite oprirea melodiei curente si inceperea playlistului de la capat.
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Stop();
        }

        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        private void trackBarTime_Scroll(object sender, EventArgs e)
        {
            _controlulInterfetei.Time = trackBarTime.Value;
        }

        /// <summary>
        /// Aceasta functie permite cautarea dupa un sir de caractere a unei melodii in playlist
        /// </summary>
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _loadFiles.SearchMusic(listBoxPlaylist,textBoxSearch, _playlistManager.CurrentPlaylist.PathList);
        
        }

        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        private void listboxContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //clear the menu and add custom items
            contextMenuStrip.Items.Clear();
            ToolStripItem itemRemove = contextMenuStrip.Items.Add("Remove");
            itemRemove.Click += new EventHandler(itemRemove_Click);
        }
		
		 /// <summary>
        /// Aceasta functie ...
        /// </summary>
        private void contextMenuStripPlaylists_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStripPlaylists.Items.Clear();
            ToolStripItem itemCreate = contextMenuStripPlaylists.Items.Add("Create");
            itemCreate.Click += new EventHandler(itemCreatePlaylist_Click);
            ToolStripItem itemDelete = contextMenuStripPlaylists.Items.Add("Delete");
            itemDelete.Click += new EventHandler(itemDeletePlaylist_Click);
        }


        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        private void itemCreatePlaylist_Click(object sender, EventArgs e)
        {
            string playlistName = Interaction.InputBox("Name of the playlist", "New Playlist", "Playlist", 400, 450);
            if (playlistName != "")
            {
                try
                {
                    _playlistManager.AddPlaylist(playlistName);
                    listBoxPlaylists.Items.Add(playlistName);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        private void itemDeletePlaylist_Click(object sender, EventArgs e)
        {
            listBoxPlaylists.Items.Remove(_playlistManager.CurrentPlaylist.Name);
            _playlistManager.RemovePlaylist(_playlistManager.CurrentPlaylist.Name);
        }

        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        void itemRemove_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Stop();
            //_loadFiles.DeleteMusic(listBoxPlaylist);
            string songName = listBoxPlaylist.SelectedItem.ToString();
            _controlulInterfetei.RemoveSongs(new List<string> { _playlistManager.CurrentPlaylist.GetFullPath(songName) });
            _playlistManager.CurrentPlaylist.RemoveSong(songName);
            listBoxPlaylist.Items.Remove(songName);
        }

        private void DragAndDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<string> listaMuzica = _loadFiles.DragAndDrop(e);
                _playlistManager.CurrentPlaylist.AddSongs(listaMuzica.ToArray());
                _controlulInterfetei.AddSongs(_playlistManager.CurrentPlaylist.PathList);
                foreach (string song in listaMuzica)
                {
                    listBoxPlaylist.Items.Add(System.IO.Path.GetFileName(song));
                }
            }
            catch (System.NullReferenceException nullEx)
            {
                MessageBox.Show("Nici un playlist selectat!");
            }
        }

        private void ListBoxEnter(object sender, DragEventArgs e)
        {
            _loadFiles.ListBoxEnter(e);
        }

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPlaylist.Items.Clear();
            if (listBoxPlaylists.SelectedIndex < 0)
            {
                _playlistManager.SetCurrentPlaylist(null);
            }
            else
            {
                _playlistManager.SetCurrentPlaylist(listBoxPlaylists.SelectedItem.ToString());
                foreach (string song in _playlistManager.CurrentPlaylist.PathList)
                {
                    listBoxPlaylist.Items.Add(System.IO.Path.GetFileName(song));
                }
                _controlulInterfetei.AddSongs(_playlistManager.CurrentPlaylist.PathList);
            }
        }

        private void loadPlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           _playlistManager = new PlaylistManager(@"./Playlists");
            foreach(Playlist playlist in _playlistManager.Playlists)
            {
                listBoxPlaylists.Items.Add(playlist.Name);
            }
        }

        private void savePlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlistManager.ExportPlaylists();
        }
    }
}
