using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private ControlulInterfetei.ControlulInterfetei control;
        List<string> l = new List<string>();
        public Form1()
        {
            InitializeComponent();
            control =  ControlulInterfetei.ControlulInterfetei.Instance();
            button1.Text = "Play";
            button2.Text = "Pause";
            button3.Text = "Stop";
            button5.Text = "Next";
            button4.Text = "Previous";
            l.Add("C:/Users/zahar/Downloads/Metallica_ Nothing Else Matters.mp3");
            l.Add("C:/Users/zahar/Downloads/Metallica - The Unforgiven.mp3");
            l.Add("C:/Users/zahar/Downloads/Metallica_ Enter Sandman.mp3");
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
            if(control.time <= 100 && control.time >= 0)
            trackBar2.Value = control.time;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            control.time = trackBar2.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                control.Shuffle(true);
            else
                control.Shuffle(false);
        }
    }
}
