using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Projet_IMA.form;
using Projet_IMA.Formul;
using Projet_IMA.Lights;

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
            this.textBox3.Text = RenderSing.getCurrentRender().getEyesPosition().y.ToString();
            this.textBox4.Text = "0,5";
            this.textBox5.Text = "0,5";
            this.textBox6.Text = "0,5";

            this.listBox1.Items.Add(new form.Rectangle(new V3(-50f, 0f, -10f),
                                              new V3(100f, 0f, 0f),
                                              new V3(0, 100f, 0f),
                                              new Texture("brick01.jpg"),
                                              new Texture("lead_bump.jpg")));

            this.listBox1.Items.Add(new form.Rectangle(new V3(-20.0f, 50f, 10f),
                                        new V3(20f, 20f, 10f),
                                        new V3(0, 0, 20f),
                                        new Texture("lead.jpg"),
                                        new Texture("lead_bump.jpg")));

                  this.listBox1.Items.Add(new Sphere(new V3(0.0f, 50f, 0.0f),
                                              15f,
                                              new Texture("carreau.jpg"),
                                              new Texture("bump38.jpg")));

                  this.listBox1.Items.Add(new Sphere(new V3(20.0f, 75f, 0.0f),
                                              10f,
                                              new Couleur(1f, 0, 0),
                                              new Texture("bump38.jpg")));


            this.listBox2.Items.Add(new DirectionalLight(new V3(1f, -1f, 1f),
                                                new Couleur(.8f, .8f, .8f)));


        }

        public bool Checked()               { return checkBox1.Checked;   }
        public void PictureBoxInvalidate()  { pictureBox1.Invalidate(); }
        public void PictureBoxRefresh()     { pictureBox1.Refresh();    }

        private void button1_Click(object sender, EventArgs e)
        {
            RenderSing.getCurrentRender().clear();
            RenderSing.getCurrentRender().addObjects(this.listBox1.Items.Cast<Object3D>().ToList());
            RenderSing.getCurrentRender().addLights(this.listBox2.Items.Cast<Light>().ToList());

            float x, y, z;
            x = 0;
            y = 0;
            z = 0;
            if (
                !float.TryParse(this.textBox4.Text, out x) ||
                !float.TryParse(this.textBox5.Text, out y) ||
                !float.TryParse(this.textBox6.Text, out z))
            {
                Console.WriteLine("erreur ambiante");
            }

            RenderSing.getCurrentRender().addLight(new AmbiantLight(new Couleur(x,y,z)));

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

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void zoom(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (e.Delta <= 0)
                {
                    //set minimum size to zoom
                    if (this.pictureBox1.Width < 50)
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (this.pictureBox1.Width > 500)
                        return;
                }
                this.pictureBox1.Width += Convert.ToInt32(this.pictureBox1.Width * e.Delta / 1000);
                this.pictureBox1.Height += Convert.ToInt32(this.pictureBox1.Height * e.Delta / 1000);
            }
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
            this.saveFileDialog1.ShowDialog();
            this.pictureBox1.Image.Save(this.saveFileDialog1.FileName);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.setLB(this.listBox1);
            a.Activate();
            a.Show();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.listBox1.SelectedIndex >= 0)
                    this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
            }
                
        }





        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Object3D elementToModif = (Object3D)this.listBox1.Items[index];
                if (elementToModif is form.Rectangle)
                {
                    form.Rectangle elementToModifCast = (form.Rectangle) elementToModif; 
                    Form3 recModifier = new Form3(elementToModifCast);
                    recModifier.setLB(this.listBox1);
                    recModifier.Activate();
                    recModifier.Show();
                    
                }
                else
                if (elementToModif is Sphere)
                {
                    Sphere elementToModifCast = (Sphere)elementToModif;
                    Form2 spheremodif = new Form2(elementToModifCast);
                    spheremodif.setLB(this.listBox1);
                    spheremodif.Activate();
                    spheremodif.Show();

                }
                                    
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2bis a = new Form2bis();
            a.setLB(this.listBox2);
            a.Activate();
            a.Show();

        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.listBox2.SelectedIndex >= 0)
                    this.listBox2.Items.RemoveAt(this.listBox2.SelectedIndex);
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Light elementToModif = (Light)this.listBox2.Items[index];
               
                    DirectionalLight elementToModifCast = (DirectionalLight) elementToModif;
                    Form2bis recModifier = new Form2bis(elementToModifCast);
                recModifier.setLB(this.listBox2);
                    recModifier.Activate();
                    recModifier.Show();

                
            }
        }
    }
}
