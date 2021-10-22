using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAKATAR_ZGİ_UPDATE
{
    public partial class Görüntüişleme : UserControl
    {
        public Görüntüişleme()
        {
            InitializeComponent();
        }
        int tarama = 0;
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            button3.Visible = false;
            label2.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;

            tarama = 0;
            i = 0;
            pictureBox1.Image = null;
            textBox1.Text = "";

        }



        private void button3_Click(object sender, EventArgs e)
        {
            i++;
            pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/İstenmeyen_Ot" + i + ".jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
            if (i > 1)
            {
                button3.Visible = true;
            }
            if (pictureBox1.Image == pictureBox1.ErrorImage)
            {
                button3.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            i -= 1;
            pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/İstenmeyen_Ot" + i + ".jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
            if (i <= 1)
            {
                button3.Visible = false;
            }
            if (pictureBox1.Image != pictureBox1.ErrorImage)
            {
                button3.Enabled = true;
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            i -= 1;
            pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/detected" + i + ".jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
            if (i <= 1)
            {
                button3.Visible = false;
            }
            if (pictureBox1.Image != pictureBox1.ErrorImage)
            {
                button3.Enabled = true;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try

            {
                tarama = Convert.ToInt32(textBox1.Text);
                pictureBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button3.Visible = true;
                label2.Visible = true;
                button4.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
                i++;
                label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
                pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/detected" + i + ".jpg";




            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen incelemek istediğiniz taramanın sıra numarasını giriniz.", "Hatalı veya Eksik giriş", MessageBoxButtons.OK);

            }
            if (pictureBox1.Image == pictureBox1.ErrorImage)
            {
                button3.Enabled = false;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            i -= 1;
            pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/detected" + i + ".jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
            if (i <= 1)
            {
                button2.Visible = false;
            }
            if (pictureBox1.Image != pictureBox1.ErrorImage)
            {
                button3.Enabled = true;
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;

            tarama = 0;
            i = 0;
            pictureBox1.Image = null;
            textBox1.Text = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            i++;
            pictureBox1.ImageLocation = "C:/Users/pc/Desktop/tarama" + tarama + "/detected" + i + ".jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            label2.Text = "tarama :" + tarama + " fotoğraf :" + i;
            if (i > 1)
            {
                button2.Visible = true;
            }
            if (pictureBox1.Image == pictureBox1.ErrorImage)
            {
                button3.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
    
}