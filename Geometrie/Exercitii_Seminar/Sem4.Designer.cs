﻿namespace Exercitii_Seminar
{
    partial class Sem4
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
            this.pctBoxRezolvare = new System.Windows.Forms.PictureBox();
            this.lblTextProb = new System.Windows.Forms.Label();
            this.btnEx2 = new System.Windows.Forms.Button();
            this.btnEx1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRezolvare)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxRezolvare
            // 
            this.pctBoxRezolvare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxRezolvare.Location = new System.Drawing.Point(19, 156);
            this.pctBoxRezolvare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pctBoxRezolvare.Name = "pctBoxRezolvare";
            this.pctBoxRezolvare.Size = new System.Drawing.Size(1030, 382);
            this.pctBoxRezolvare.TabIndex = 18;
            this.pctBoxRezolvare.TabStop = false;
            this.pctBoxRezolvare.Paint += new System.Windows.Forms.PaintEventHandler(this.pctBoxRezolvare_Paint);
            // 
            // lblTextProb
            // 
            this.lblTextProb.AutoSize = true;
            this.lblTextProb.Location = new System.Drawing.Point(19, 73);
            this.lblTextProb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextProb.Name = "lblTextProb";
            this.lblTextProb.Size = new System.Drawing.Size(118, 16);
            this.lblTextProb.TabIndex = 17;
            this.lblTextProb.Text = "Alege o problema.";
            // 
            // btnEx2
            // 
            this.btnEx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx2.Location = new System.Drawing.Point(124, 15);
            this.btnEx2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEx2.Name = "btnEx2";
            this.btnEx2.Size = new System.Drawing.Size(85, 43);
            this.btnEx2.TabIndex = 16;
            this.btnEx2.Text = "Ex. 2";
            this.btnEx2.UseVisualStyleBackColor = true;
            this.btnEx2.Click += new System.EventHandler(this.btnEx2_Click);
            // 
            // btnEx1
            // 
            this.btnEx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx1.Location = new System.Drawing.Point(19, 15);
            this.btnEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEx1.Name = "btnEx1";
            this.btnEx1.Size = new System.Drawing.Size(85, 43);
            this.btnEx1.TabIndex = 15;
            this.btnEx1.Text = "Ex. 1";
            this.btnEx1.UseVisualStyleBackColor = true;
            this.btnEx1.Click += new System.EventHandler(this.btnEx1_Click);
            // 
            // Sem4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pctBoxRezolvare);
            this.Controls.Add(this.lblTextProb);
            this.Controls.Add(this.btnEx2);
            this.Controls.Add(this.btnEx1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Sem4";
            this.Text = "Sem4";
            this.Load += new System.EventHandler(this.Sem4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRezolvare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxRezolvare;
        private System.Windows.Forms.Label lblTextProb;
        private System.Windows.Forms.Button btnEx2;
        private System.Windows.Forms.Button btnEx1;
    }
}