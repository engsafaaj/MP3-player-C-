using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;


namespace MP3_Player
{
    public partial class Form1 : Form
    {
        IWavePlayer player = new WaveOut();
        AudioFileReader AFR;
        string[] list;
        int i;
        float j;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.Filter = "MP3 Files|*.mp3";
            var rs = di.ShowDialog();
            if (rs == DialogResult.OK)
            {
                AFR = new AudioFileReader(di.FileName);
                player.Init(AFR);
                player.Play();
                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
            
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            player.Play();
            btn_play.Visible = false;
            btn_stop.Visible = true;
            pictureBox1.Visible = true;

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Pause();
            btn_stop.Visible = false;
            btn_play.Visible = true;
            pictureBox1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.Multiselect = true;
            di.Filter = "MP3 Files|*.mp3";
            var rs = di.ShowDialog();
            if (rs == DialogResult.OK)
            {
                list = di.FileNames;
                AFR = new AudioFileReader(list[0]);
                player.Init(AFR);
                player.Play();
                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.Dispose();
            i = i + 1;
            AFR = new AudioFileReader(list[i]);
            player.Init(AFR);
            player.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Dispose();
            i = i - 1;
            AFR = new AudioFileReader(list[i]);
            player.Init(AFR);
            player.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                j = j + 0.1F;
                player.Volume = j;

            }
            catch
            {

            }
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                j = j - 0.1F;
                player.Volume = j;

            }
            catch
            {

            }
        }
    }
}
