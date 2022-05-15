using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace MpPlayer
{
    public partial class Form1 : Form
    {
        private Load _load;
        public Form1()
        {
            _load = new Load();
            InitializeComponent();
            
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            
            _load.LoadMusic(listBoxMusic);
          
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _load.DeleteMusic(listBoxMusic);
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _load.SearchMusic(listBoxMusic, textBoxSearch);
            
        }

        private void DragAndDrop(object sender, DragEventArgs e)
        {
            _load.DragAndDrop(listBoxMusic, e);
        }

        private void ListBoxEnter(object sender, DragEventArgs e)
        {
            _load.ListBoxEnter(e);
        }
    }
}