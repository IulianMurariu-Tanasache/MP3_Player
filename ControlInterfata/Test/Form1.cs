using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private ControlulInterfeteiNameSpace.ControlulInterfetei control;
        List<string> l = new List<string>();
        public Form1()
        {
            InitializeComponent();
            control = ControlulInterfeteiNameSpace.ControlulInterfetei.Instance();
            button1.Text = "Play";
            button2.Text = "Pause";
            button3.Text = "Stop";
            button5.Text = "Next";
            button4.Text = "Previous";
            button6.Text = "Clear";
            l.Add(Directory.GetCurrentDirectory()+"/Metallica_ Nothing Else Matters.mp3");
            l.Add("D:/ProiectIP/ControlInterfata/Test/Metallica - The Unforgiven.mp3");
            l.Add("D:/ProiectIP/ControlInterfata/Test/Metallica_ Enter Sandman.mp3");
            control.AddSongs(l);
            control.Stop();
            timer1.Start();
            checkBox1.Text = "Shuffle";
            label1.Text = "Volume";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            control.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            control.Next();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            control.Previous();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            control.Volume(trackBar1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(control.Time <= 100 && control.Time >= 0)
            trackBar2.Value = control.Time;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            control.Time = trackBar2.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                control.Shuffle(true);
            else
                control.Shuffle(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            control.RemoveSongs(l);
        }
    }
}
