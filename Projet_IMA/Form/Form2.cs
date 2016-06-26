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
            float x;
            float y;
            float z;
            float r;

            if ( 
                ! float.TryParse(this.x_tb.Text,out x) || 
                ! float.TryParse(this.y_tb.Text,out y) ||
                ! float.TryParse(this.z_tb.Text,out z) ||
                ! float.TryParse(this.rayon_tb.Text,out r))
            { return; }


           
            V3 position  = new V3(x, y, z);
            Sphere create;
            if (this.color_rb.Checked)
            {
                Couleur cl = new Couleur();
                cl.B = this.colorDialog1.Color.B;
                cl.R = this.colorDialog1.Color.R;
                cl.V = this.colorDialog1.Color.G; // hahah fr vs en

                create = new Sphere(position, r, cl);
            }
            else
            {
                
                Texture texture = new Texture(this.openFileDialog1.FileName);
                Texture bump = new Texture(this.openFileDialog1.FileName);
                if (this.checkBox1.FileName)

                new Sphere(position, r,texture);
            }

           

            RenderSing.getCurrentRender()
                .addObject(
                    create
                );

            this.PutInThislistBox.Items.Add(create);
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
    }
}
