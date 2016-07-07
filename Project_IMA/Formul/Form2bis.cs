using Projet_IMA.Lights;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projet_IMA.Formul
{
    public partial class Form2bis : Form
    {
        DirectionalLight light;
        bool tIsNewFIsModif;
        private ListBox PutInThislistBox;

        public void setLB(ListBox lb)
        {
            this.PutInThislistBox = lb;
        }

        public Form2bis():this(new DirectionalLight(),true)
        {

        }

        public Form2bis(DirectionalLight light, bool modif = false)
        {
            InitializeComponent();
            this.light = light;
            this.tIsNewFIsModif = modif;
            this.remplir();

        }

        public void remplir()
        {
            this.textBox1.Text = this.light.getDirection().x.ToString();
            this.textBox2.Text = this.light.getDirection().y.ToString();
            this.textBox3.Text = this.light.getDirection().z.ToString();

            
            Couleur cl = this.light.couleur;
            Color cl2 = Color.FromArgb(
                (int)(cl.R * 256),
                (int)(cl.V * 256),
                (int)(cl.B * 256)
                );
            this.colorDialog1.Color = cl2;
            this.button3.BackColor = cl2;

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            float x, y, z;

            if (
                !float.TryParse(this.textBox1.Text, out x) ||
                !float.TryParse(this.textBox2.Text, out y) ||
                !float.TryParse(this.textBox3.Text, out z) )
            {
                System.Console.WriteLine("Erreur sur les donnée.");
                return;
            }

            this.light.setDirection(new V3(x, y, z));
            Couleur cl = new Couleur();

            cl.B = ((float)(this.colorDialog1.Color.B)) / 256.0f;
            cl.R = ((float)(this.colorDialog1.Color.R)) / 256.0f;
            cl.V = ((float)(this.colorDialog1.Color.G)) / 256.0f;
            this.light.couleur = cl;

            


            if (this.tIsNewFIsModif)
            {
                this.PutInThislistBox.Items.Add(this.light);
            }


            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.button3.BackColor = this.colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
