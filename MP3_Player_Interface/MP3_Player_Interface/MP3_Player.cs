using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MpPlayer; // a lui Stefan
using ControlulInterfeteiNamespace; // a lui Mihai

namespace MP3_Player_Interface
{
    public partial class MP3_Player : Form
    {
        private Load _loadFiles;
        private ControlulInterfetei _controlulInterfetei;

        private int _volume = 100;
        private bool _shuffle = false;
        //private bool _isPlaying = false;

        /// <summary>
        /// Constructor ce initializeaza fereastra grafica a MP# Player-ului.
        /// </summary>
        public MP3_Player()
        {
            InitializeComponent();
            _loadFiles = new Load();
            _controlulInterfetei = ControlulInterfetei.Instance();
        }

        private void MP3_Player_Load(object sender, EventArgs e)
        {
            //assign a contextmenustrip
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Opening += new CancelEventHandler(listboxContextMenu_Opening);
            listBoxPlaylist.ContextMenuStrip = contextMenuStrip;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mp3 Player");
        }

        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loadFiles.LoadMusic(listBoxPlaylist);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //daca melodia e pe pauza sa dea resume
            _controlulInterfetei.AddSongs(_loadFiles.ListOfMusic);
            //if (_isPlaying)
            //{
            //    _controlulInterfetei.Pause();
            //    buttonPlay.BackgroundImage = Properties.Resources.play_50;
            //    _isPlaying = false;
            //}
            //else
            //{
            //    try
            //    {
            //        string currentMusic = _loadFiles.ListOfMusic[listBoxPlaylist.SelectedIndex];
            //        _controlulInterfetei.Play(currentMusic);
            //        buttonPlay.BackgroundImage = Properties.Resources.pause_50;
            //        _isPlaying = true;
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Selectați melodiile!");
            //    }
            //}
            string currentMusic = _loadFiles.ListOfMusic[listBoxPlaylist.SelectedIndex];
            _controlulInterfetei.Play(currentMusic);
        }

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
            ToolStripItem itemRemove = contextMenuStrip.Items.Add("Remove ");
            itemRemove.Click += new EventHandler(itemRemove_Click);
        }

        /// <summary>
        /// Aceasta functie ...
        /// </summary>
        void itemRemove_Click(object sender, EventArgs e)
        {
            _loadFiles.DeleteMusic(listBoxPlaylist);
        }
    }
}
