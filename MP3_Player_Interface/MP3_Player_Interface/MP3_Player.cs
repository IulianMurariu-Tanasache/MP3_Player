﻿/**************************************************************************
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
using MpPlayer; // a lui Stefan
using ControlulInterfeteiNamespace; // a lui Mihai

namespace MP3_Player_Interface
{
    /// <summary>
    /// Clasa <c>MP3_Player</c> reprezinta interfata grafica a aplicatiei.
    /// </summary>
    public partial class MP3_Player : Form
    {
        private Load _loadFiles;
        private ControlulInterfetei _controlulInterfetei;

        private int _volume = 100;
        private bool _shuffle = false;

        /// <summary>
        /// Constructor ce initializeaza fereastra grafica a MP3 Player-ului.
        /// </summary>
        public MP3_Player()
        {
            InitializeComponent();
            _loadFiles = new Load();
            _controlulInterfetei = ControlulInterfetei.Instance();
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
        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loadFiles.LoadMusic(listBoxPlaylist);
        }

        /// <summary>
        /// Aceasta functie 
        /// </summary>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //daca melodia e pe pauza sa dea resume
            _controlulInterfetei.AddSongs(_loadFiles.ListOfMusic);
            try
            {
                string currentMusic = _loadFiles.ListOfMusic[listBoxPlaylist.SelectedIndex];
                _controlulInterfetei.Play(currentMusic);
                buttonPause.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Selectați melodiile!");
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
            _controlulInterfetei.Next();
        }

        /// <summary>
        /// Aceasta functie permite accesarea melodiei anterioare din playlist.
        /// </summary>
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Previous();
        }

        /// <summary>
        /// Aceasta functie activeaza/dezactiveaza optiunea de Shuffle.
        /// </summary>
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            _shuffle = !_shuffle;
            _controlulInterfetei.Shuffle(_shuffle);
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
            _loadFiles.SearchMusic(listBoxPlaylist, textBoxSearch);
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
        void itemRemove_Click(object sender, EventArgs e)
        {
            _loadFiles.DeleteMusic(listBoxPlaylist);
        }

        private void DragAndDrop(object sender, DragEventArgs e)
        {
            _loadFiles.DragAndDrop(listBoxPlaylist, e);
        }

        private void ListBoxEnter(object sender, DragEventArgs e)
        {
            _loadFiles.ListBoxEnter(e);
        }
    }
}
