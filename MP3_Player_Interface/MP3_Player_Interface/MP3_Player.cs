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

        public MP3_Player()
        {
            InitializeComponent();
            _loadFiles = new Load();
            _controlulInterfetei = ControlulInterfetei.Instance();
        }

        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loadFiles.LoadMusic(listBoxPlaylist);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //daca melodia e pe pauza sa dea resume
            _controlulInterfetei.AddSongs(_loadFiles.ListOfMusic);
            string currentMusic = _loadFiles.ListOfMusic[listBoxPlaylist.SelectedIndex];
            _controlulInterfetei.Play(currentMusic);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Pause();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Next();
        }

        private void progressBarTime_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonVolumeDown_Click(object sender, EventArgs e)
        {
            _volume -= 4;
            Console.WriteLine(_volume);
            _controlulInterfetei.Volume(_volume);
        }

        private void buttonVolumeUp_Click(object sender, EventArgs e)
        {
            _volume += 4;
            _controlulInterfetei.Volume(_volume);
        }

        private void buttonVolumeMute_Click(object sender, EventArgs e)
        {
            _controlulInterfetei.Volume(0);
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            _shuffle = !_shuffle;
            _controlulInterfetei.Shuffle(_shuffle);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
