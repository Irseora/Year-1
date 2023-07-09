namespace Curs6
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPerimetru = new System.Windows.Forms.Button();
            this.btnCentruGreutate = new System.Windows.Forms.Button();
            this.btnArie = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Translatie = new System.Windows.Forms.Button();
            this.btn_Scalare = new System.Windows.Forms.Button();
            this.btn_Rotatie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 426);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnPerimetru
            // 
            this.btnPerimetru.Location = new System.Drawing.Point(624, 391);
            this.btnPerimetru.Name = "btnPerimetru";
            this.btnPerimetru.Size = new System.Drawing.Size(150, 34);
            this.btnPerimetru.TabIndex = 1;
            this.btnPerimetru.Text = "Perimetru";
            this.btnPerimetru.UseVisualStyleBackColor = true;
            this.btnPerimetru.Click += new System.EventHandler(this.btnPerimetru_Click);
            // 
            // btnCentruGreutate
            // 
            this.btnCentruGreutate.Location = new System.Drawing.Point(624, 350);
            this.btnCentruGreutate.Name = "btnCentruGreutate";
            this.btnCentruGreutate.Size = new System.Drawing.Size(150, 35);
            this.btnCentruGreutate.TabIndex = 2;
            this.btnCentruGreutate.Text = "Centru de greutate";
            this.btnCentruGreutate.UseVisualStyleBackColor = true;
            this.btnCentruGreutate.Click += new System.EventHandler(this.btnCentruGreutate_Click);
            // 
            // btnArie
            // 
            this.btnArie.Location = new System.Drawing.Point(624, 310);
            this.btnArie.Name = "btnArie";
            this.btnArie.Size = new System.Drawing.Size(150, 34);
            this.btnArie.TabIndex = 3;
            this.btnArie.Text = "Arie";
            this.btnArie.UseVisualStyleBackColor = true;
            this.btnArie.Click += new System.EventHandler(this.btnArie_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(189, 148);
            this.listBox1.TabIndex = 4;
            // 
            // btn_Translatie
            // 
            this.btn_Translatie.Location = new System.Drawing.Point(624, 270);
            this.btn_Translatie.Name = "btn_Translatie";
            this.btn_Translatie.Size = new System.Drawing.Size(150, 34);
            this.btn_Translatie.TabIndex = 5;
            this.btn_Translatie.Text = "Translatie";
            this.btn_Translatie.UseVisualStyleBackColor = true;
            this.btn_Translatie.Click += new System.EventHandler(this.btn_Translatie_Click);
            // 
            // btn_Scalare
            // 
            this.btn_Scalare.Location = new System.Drawing.Point(624, 230);
            this.btn_Scalare.Name = "btn_Scalare";
            this.btn_Scalare.Size = new System.Drawing.Size(150, 34);
            this.btn_Scalare.TabIndex = 6;
            this.btn_Scalare.Text = "Scalare";
            this.btn_Scalare.UseVisualStyleBackColor = true;
            this.btn_Scalare.Click += new System.EventHandler(this.btn_Scalare_Click);
            // 
            // btn_Rotatie
            // 
            this.btn_Rotatie.Location = new System.Drawing.Point(624, 190);
            this.btn_Rotatie.Name = "btn_Rotatie";
            this.btn_Rotatie.Size = new System.Drawing.Size(150, 34);
            this.btn_Rotatie.TabIndex = 7;
            this.btn_Rotatie.Text = "Rotatie";
            this.btn_Rotatie.UseVisualStyleBackColor = true;
            this.btn_Rotatie.Click += new System.EventHandler(this.btn_Rotatie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Rotatie);
            this.Controls.Add(this.btn_Scalare);
            this.Controls.Add(this.btn_Translatie);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnArie);
            this.Controls.Add(this.btnCentruGreutate);
            this.Controls.Add(this.btnPerimetru);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPerimetru;
        private System.Windows.Forms.Button btnCentruGreutate;
        private System.Windows.Forms.Button btnArie;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_Translatie;
        private System.Windows.Forms.Button btn_Scalare;
        private System.Windows.Forms.Button btn_Rotatie;
    }
}

