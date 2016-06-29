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
        private Sphere formToModif;
        private bool tIsNewFIsModif;

        public Form2():this(new Sphere(),true)
        {

        }

        public Form2(Sphere form, bool modif = false)
        {
            InitializeComponent();
            this.color_rb.Checked = true;
            this.formToModif = form;
            this.tIsNewFIsModif = modif;
            this.remplir();

        }

        public void remplir()
        {
            this.inPosition();
            this.inSize();
            this.inTextureOrColor();
            this.inBump();
        }

        public void setLB(ListBox lb)
        { this.PutInThislistBox = lb; }

      





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

            this.outPosition(x, y, z);
            this.outSize(r);
            this.outTexture();
            this.outColor();
            this.outBump();

            if (this.tIsNewFIsModif)
            {
                this.PutInThislistBox.Items.Add(this.formToModif);
            }



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
            this.button3.BackColor = this.colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.openFileDialog1.ShowDialog();
            this.button4.Image = new Bitmap(this.openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.ShowDialog();
            this.button5.Image = new Bitmap(this.openFileDialog2.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void inBump()
        {
            if (this.formToModif.getBumpMap() == null)
            {
                this.bump_cb.Checked = false;
            }
            else
            {
                this.bump_cb.Checked = true;
                this.openFileDialog2.FileName = this.formToModif.getBumpMap().path;
                this.button5.Image = new Bitmap(this.openFileDialog2.FileName);
            }
        }

        private void inTextureOrColor()
        {
            if (this.formToModif.getTexture() == null)
            {
                this.color_rb.Checked = true;
                Couleur cl = this.formToModif.getCouleur();
                Color cl2 = Color.FromArgb(
                    (int)(cl.R * 256),
                    (int)(cl.V * 256),
                    (int)(cl.B * 256)
                    );
                this.colorDialog1.Color = cl2;
                this.button3.BackColor = cl2;
            }
            else
            {
                this.image_rb.Checked = true;
                this.openFileDialog1.FileName = this.formToModif.getTexture().path;
                this.button4.Image = new Bitmap(this.openFileDialog1.FileName);
            }
        }


        private void inPosition()
        {
            V3 position = this.formToModif.getPosition();
            this.x_tb.Text = position.x.ToString();
            this.y_tb.Text = position.y.ToString();
            this.z_tb.Text = position.z.ToString();
        }

        private void inSize()
        {
            float r = this.formToModif.getRayon();
            this.rayon_tb.Text = r.ToString();
           
        }

        private void outBump()
        {
            if (this.bump_cb.Checked)
            {
                Texture bump = new Texture(this.openFileDialog2.FileName);
                this.formToModif.setBumpMap(bump);
            }
            else
            {
                this.formToModif.setBumpMap(null);
            }
        }

        private void outTexture()
        {
            if (this.image_rb.Checked)
            {
                Texture tex = new Texture(this.openFileDialog1.FileName);

                this.formToModif.setTexture(tex);
            }
            else
            {
                this.formToModif.setTexture(null);

            }
        }

        private void outColor()
        {

            if (this.color_rb.Checked)
            {

                Couleur cl = new Couleur();

                cl.B = ((float)(this.colorDialog1.Color.B)) / 256.0f;
                cl.R = ((float)(this.colorDialog1.Color.R)) / 256.0f;
                cl.V = ((float)(this.colorDialog1.Color.G)) / 256.0f;
                this.formToModif.setCouleur(cl);
            }
            else
            {
                this.formToModif.setCouleur(new Couleur());
            }
        }

        private void outPosition(float x, float y, float z)
        {
            V3 position = new V3(x, y, z);
            this.formToModif.setPosition(position);

        }

        private void outSize(
            float r)
        {
            this.formToModif.setRayon(r);
        }

        private void y_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
