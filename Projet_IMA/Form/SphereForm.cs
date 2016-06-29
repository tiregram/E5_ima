using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projet_IMA
{
    public partial class Form2 : Form
    {
        private ListBox PutInThislistBox;
        


        public void setLB(ListBox lb)
        { this.PutInThislistBox = lb; }

        public Form2()
        {
            InitializeComponent();
            this.color_rb.Checked = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            float x,y,z;
            float r;

            if ( 
                ! float.TryParse(this.x_tb.Text,out x) || 
                ! float.TryParse(this.y_tb.Text,out y) ||
                ! float.TryParse(this.z_tb.Text,out z) ||
                ! float.TryParse(this.rayon_tb.Text,out r))
            {
                System.Console.WriteLine("Erreur sur les donnée.");
                return; }


           
            V3 position  = new V3(x, y, z);
            Sphere create;
            if (this.color_rb.Checked)
            {
                
                Couleur cl = new Couleur();
                cl.B = ((float)(this.colorDialog1.Color.B))/256.0f;
                cl.R = ((float)(this.colorDialog1.Color.R)) / 256.0f; ;
                cl.V = ((float)(this.colorDialog1.Color.G)) / 256.0f; ; // hahah fr vs en

                create = new Sphere(position, r, cl);
            }
            else
            {
                
                Texture texture = new Texture(this.openFileDialog1.FileName);


                if (this.checkBox1.Checked)
                {
                    Texture bump = new Texture(this.openFileDialog2.FileName);
                    create = new Sphere(position, r, texture, bump);
                }
                else
                {

                    create = new Sphere(position, r, texture, null);
                }
            }

            this.PutInThislistBox.Items.Add(create);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.openFileDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
