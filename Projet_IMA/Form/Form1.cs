using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Projet_IMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = BitmapEcran.Init(pictureBox1.Width, pictureBox1.Height);
            this.textBox1.Text = RenderSing.getCurrentRender().getResolutionX().ToString();
            this.textBox2.Text = RenderSing.getCurrentRender().getResolutionY().ToString();
        }

        public bool Checked()               { return checkBox1.Checked;   }
        public void PictureBoxInvalidate()  { pictureBox1.Invalidate(); }
        public void PictureBoxRefresh()     { pictureBox1.Refresh();    }

        private void button1_Click(object sender, EventArgs e)
        {
            BitmapEcran.RefreshScreen(new Couleur(0,0,0));
            ProjetEleve.Go();
            BitmapEcran.Show();          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

            RenderSing rnd = RenderSing.getCurrentRender();
            string txt = ((TextBox)sender).Text;
            int value = 0;

            if (rnd.alock && int.TryParse(txt, out value))
            {
                rnd.setResolutionX(value);
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RenderSing rnd = RenderSing.getCurrentRender();
            string txt = ((TextBox)sender).Text;
            int value = 0;
            
            if (rnd.alock && int.TryParse(txt,out value) )
            { 
                rnd.setResolutionY(value);
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image.Save("gen1.jpg");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            RenderSing rnd = RenderSing.getCurrentRender();
            string txt = ((TextBox)sender).Text;
            int value = 0;

            if (rnd.alock && int.TryParse(txt, out value) && value < 0)
            {
                rnd.setEyesPosition(value);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 a =new  Form2();
            a.setLB(this.listBox1);
            a.Activate();
            a.Show();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           


        }

        private void listBox1_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }
    }
}
