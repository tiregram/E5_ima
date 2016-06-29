namespace Projet_IMA
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.x_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rayon_tb = new System.Windows.Forms.TextBox();
            this.y_tb = new System.Windows.Forms.TextBox();
            this.z_tb = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bump_cb = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.image_rb = new System.Windows.Forms.RadioButton();
            this.color_rb = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(156, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "position";
            // 
            // x_tb
            // 
            this.x_tb.Location = new System.Drawing.Point(150, 12);
            this.x_tb.Name = "x_tb";
            this.x_tb.Size = new System.Drawing.Size(37, 20);
            this.x_tb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "rayon";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // rayon_tb
            // 
            this.rayon_tb.Location = new System.Drawing.Point(150, 38);
            this.rayon_tb.Name = "rayon_tb";
            this.rayon_tb.Size = new System.Drawing.Size(123, 20);
            this.rayon_tb.TabIndex = 6;
            // 
            // y_tb
            // 
            this.y_tb.Location = new System.Drawing.Point(193, 12);
            this.y_tb.Name = "y_tb";
            this.y_tb.Size = new System.Drawing.Size(37, 20);
            this.y_tb.TabIndex = 8;
            this.y_tb.TextChanged += new System.EventHandler(this.y_tb_TextChanged);
            // 
            // z_tb
            // 
            this.z_tb.Location = new System.Drawing.Point(236, 12);
            this.z_tb.Name = "z_tb";
            this.z_tb.Size = new System.Drawing.Size(37, 20);
            this.z_tb.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(245, 95);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(28, 20);
            this.button5.TabIndex = 54;
            this.button5.Text = "D";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(245, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 20);
            this.button4.TabIndex = 53;
            this.button4.Text = "D";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bump_cb
            // 
            this.bump_cb.AutoSize = true;
            this.bump_cb.Location = new System.Drawing.Point(195, 98);
            this.bump_cb.Name = "bump_cb";
            this.bump_cb.Size = new System.Drawing.Size(38, 17);
            this.bump_cb.TabIndex = 52;
            this.bump_cb.Text = "on";
            this.bump_cb.UseVisualStyleBackColor = true;
            this.bump_cb.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "texture";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(161, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 20);
            this.button3.TabIndex = 49;
            this.button3.Text = "C";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Bump";
            // 
            // image_rb
            // 
            this.image_rb.AutoSize = true;
            this.image_rb.Location = new System.Drawing.Point(195, 67);
            this.image_rb.Name = "image_rb";
            this.image_rb.Size = new System.Drawing.Size(53, 17);
            this.image_rb.TabIndex = 48;
            this.image_rb.TabStop = true;
            this.image_rb.Text = "image";
            this.image_rb.UseVisualStyleBackColor = true;
            // 
            // color_rb
            // 
            this.color_rb.AutoSize = true;
            this.color_rb.Location = new System.Drawing.Point(107, 67);
            this.color_rb.Name = "color_rb";
            this.color_rb.Size = new System.Drawing.Size(48, 17);
            this.color_rb.TabIndex = 47;
            this.color_rb.TabStop = true;
            this.color_rb.Text = "color";
            this.color_rb.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.bump_cb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.image_rb);
            this.Controls.Add(this.color_rb);
            this.Controls.Add(this.z_tb);
            this.Controls.Add(this.y_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rayon_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.x_tb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox x_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rayon_tb;
        private System.Windows.Forms.TextBox y_tb;
        private System.Windows.Forms.TextBox z_tb;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox bump_cb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton image_rb;
        private System.Windows.Forms.RadioButton color_rb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}