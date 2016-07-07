using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using Projet_IMA.form;
using System.Drawing;

namespace Projet_IMA
{
    public partial class Form3 : Form
    {

        private ListBox PutInThislistBox;
        private form.Rectangle formToModif;
        private bool tIsNewFIsModif;

        public void setLB(ListBox lb)
        {
            this.PutInThislistBox = lb;
        }

        public Form3():this(new form.Rectangle(),true)
        {

        }

        public Form3(form.Rectangle form,bool modif= false )
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


        private void button4_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.button4.Image = new Bitmap(this.openFileDialog1.FileName);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x, y, z;
            float xx, yy, zz;
            float xxx, yyy, zzz;
            if (
                !float.TryParse(this.x_tb.Text, out x) ||
                !float.TryParse(this.y_tb.Text, out y) ||
                !float.TryParse(this.z_tb.Text, out z) ||
                !float.TryParse(this.xx_tb.Text, out xx) ||
                !float.TryParse(this.yy_tb.Text, out yy) ||
                !float.TryParse(this.zz_tb.Text, out zz) ||
                !float.TryParse(this.xxx_tb.Text, out xxx) ||
                !float.TryParse(this.yyy_tb.Text, out yyy) ||
                !float.TryParse(this.zzz_tb.Text, out zzz) )
            {
                System.Console.WriteLine("Erreur sur les donnée.");
                return;
            }

            this.outPosition(x,y,z);
            this.outSize(xx,yy,zz,xxx,yyy,zzz);
            this.outTexture();
            this.outColor();
            this.outBump();
                


            if (this.tIsNewFIsModif)
            {
                this.PutInThislistBox.Items.Add(this.formToModif);
            }
            
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.button3.BackColor = this.colorDialog1.Color;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void y_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.ShowDialog();
            this.button5.Image = new Bitmap(this.openFileDialog2.FileName);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

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
            V3 vect1 = this.formToModif.getVect1();
            this.xx_tb.Text = vect1.x.ToString();
            this.yy_tb.Text = vect1.y.ToString();
            this.zz_tb.Text = vect1.z.ToString();

            V3 vect2 = this.formToModif.getVect2();
            this.xxx_tb.Text = vect2.x.ToString();
            this.yyy_tb.Text = vect2.y.ToString();
            this.zzz_tb.Text = vect2.z.ToString();
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
            float xx,
            float yy,
            float zz,
            float xxx,
            float yyy,
            float zzz)
        {
            V3 vect1 = new V3(xx, yy, zz);
            this.formToModif.setVect1(vect1);

            V3 vect2 = new V3(xxx, yyy, zzz);
            this.formToModif.setVect2(vect2);

        }
    }
}
