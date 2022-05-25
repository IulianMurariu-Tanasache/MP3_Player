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
using FormHelpers;

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
        private string _currentMusic = "<<  No songs playing  >>";

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
        /// Aceasta functie se declanșează când se încarcă form-ul.
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
            timer.Interval = 1000; // 1 sec
        }

        /// <summary>
        /// Aceasta functie este asociata butonului About in bara de meniu
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(path + "\\MP3 Player.chm");
        }

        /// <summary>
        /// Aceasta functie este asociata butonului Load From Directory in bara de meniu
        /// </summary>
        /// _playlistManger,currentplaylist.pathlist
        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> newList = FormHelper.AddWithoutDuplicates(_loadFiles.LoadMusic(), _playlistManager.CurrentPlaylist.PathList);

                _playlistManager.CurrentPlaylist.AddSongs(newList.ToArray());
                _controlulInterfetei.AddSongs(_playlistManager.CurrentPlaylist.PathList);
                foreach (string melody in newList)
                {
                    listBoxPlaylist.Items.Add(System.IO.Path.GetFileName(melody));
                }
            }
            catch (System.NullReferenceException nullEx)
            {
                MessageBox.Show("Nici un playlist selectat!");
            }
        }

        /// <summary>
        /// Functie apelata cand se porneste o noua melodie pentru a reseta enviromentul
        /// </summary>
        private void PlayMusic()
        {
            buttonPause.Enabled = true;
            //trackBarTime.Maximum = _controlulInterfetei.FullDuration;
            //trackBarTime.Value = 0;
            _currentMusic = _playlistManager.CurrentPlaylist.GetFullPath(listBoxPlaylist.SelectedItem.ToString());
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// Functia Tick asociata timerului pentru a face refresh la valorile din interfata
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                labelCurrentSong.Text = System.IO.Path.GetFileName(_currentMusic);
                trackBarTime.Maximum = _controlulInterfetei.FullDuration;
                labelTimeCurrent.Text = FormHelper.ConvertTime(_controlulInterfetei.Time);
                labelTimeEnd.Text = FormHelper.ConvertTime(_controlulInterfetei.FullDuration);
                trackBarTime.Value = _controlulInterfetei.Time;
            }
            catch(Exception excp)
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Aceasta functie permite redarea melodiei curente din playlist.
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
                    PlayMusic();
                    timer.Start();
                }
                else
                {
                    _controlulInterfetei.Play();
                    timer.Start();
                }
            }
            catch (ArgumentOutOfRangeException argExcp)
            {
                return;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        /// <summary>
        /// Aceasta functie permite punerea pe pauza a melodiei curente din playlist.
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
                if (listBoxPlaylist.SelectedIndex != _playlistManager.CurrentPlaylist.PathList.Count-1)
                    listBoxPlaylist.SetSelected(listBoxPlaylist.SelectedIndex + 1, true);
                else
                    listBoxPlaylist.SetSelected(0, true);
                _controlulInterfetei.Next();
                PlayMusic();
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
                if(listBoxPlaylist.SelectedIndex != 0)
                    listBoxPlaylist.SetSelected(listBoxPlaylist.SelectedIndex - 1, true);
                else
                    listBoxPlaylist.SetSelected(_playlistManager.CurrentPlaylist.PathList.Count-1, true);
                _controlulInterfetei.Previous();
                PlayMusic();
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
        /// Aceasta functie permite oprirea melodiei curente.
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Stop();
            timer.Stop();
            labelCurrentSong.Text = "<<  No songs playing  >>";
            labelTimeCurrent.Text = "00:00";
            labelTimeEnd.Text = "00:00";
        }

        /// <summary>
        /// Aceasta functie permite schimbarea momentului curent din melodie prin intermediul trackBar-ului.
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
        /// Aceasta functie creeaza meniu atunci cand dam click-dreapta in lista de melodii
        /// </summary>
        private void listboxContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //clear the menu and add custom items
            contextMenuStrip.Items.Clear();
            ToolStripItem itemRemove = contextMenuStrip.Items.Add("Remove");
            itemRemove.Click += new EventHandler(itemRemove_Click);
        }

        /// <summary>
        /// Aceasta functie creeaza meniu atunci cand dam click-dreapta in lista de playlisturi
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
        /// Aceasta functie asociaza functionalitatea butonului Create din meniul care se deschide atunci cand dam click-dreapta in lista de playlisturi
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
        /// Aceasta functie asociaza functionalitatea butonului Delete din meniul care se deschide atunci cand dam click-dreapta in lista de playlisturi
        /// </summary>
        private void itemDeletePlaylist_Click(object sender, EventArgs e)
        {
            listBoxPlaylists.Items.Remove(_playlistManager.CurrentPlaylist.Name);
            _playlistManager.RemovePlaylist(_playlistManager.CurrentPlaylist.Name);
        }

        /// <summary>
        /// Aceasta functie asociaza functionalitatea butonului Remove din meniul care se deschide atunci cand dam click-dreapta in lista de melodii
        /// </summary>
        void itemRemove_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Stop();
        }

        /// <summary>
        /// Aceasta functie ajuta la adaugarea de noi melodii in playlist prin metoda Drag&Drop
        /// </summary>
        private void DragAndDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<string> newList = FormHelper.AddWithoutDuplicates(_loadFiles.DragAndDrop(e), _playlistManager.CurrentPlaylist.PathList);

                _playlistManager.CurrentPlaylist.AddSongs(newList.ToArray());
                _controlulInterfetei.AddSongs(_playlistManager.CurrentPlaylist.PathList);
                foreach (string melody in newList)
                {
                    listBoxPlaylist.Items.Add(System.IO.Path.GetFileName(melody));
                }
            }
            catch (System.NullReferenceException nullEx)
            {
                MessageBox.Show("Nici un playlist selectat!");
            }
        }

        /// <summary>
        /// Aceasta functie permite ca sa se realizeze eveniment de tip Drag
        /// </summary>
        private void ListBoxEnter(object sender, DragEventArgs e)
        {
            _loadFiles.ListBoxEnter(e);
        }

        /// <summary>
        /// Aceasta functie actualizeaza lista de melodii in functie de playlistul selectat
        /// </summary>
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

        /// <summary>
        /// Aceasta functie este asociata butonului Load Playlists in bara de meniu
        /// </summary>
        private void loadPlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxPlaylists.Items.Clear();
            _playlistManager = new PlaylistManager(@"./Playlists");
            foreach(Playlist playlist in _playlistManager.Playlists)
            {
                listBoxPlaylists.Items.Add(playlist.Name);
            }
        }

        /// <summary>
        /// Aceasta functie este asociata butonului Save Playlists in bara de meniu
        /// /// </summary>
        private void savePlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlistManager.ExportPlaylists();
        }
    }
}
