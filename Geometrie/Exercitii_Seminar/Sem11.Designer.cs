namespace Exercitii_Seminar
{
    partial class Sem11
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
            this.btnEx1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRezolvare)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxRezolvare
            // 
            this.pctBoxRezolvare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxRezolvare.Location = new System.Drawing.Point(14, 127);
            this.pctBoxRezolvare.Name = "pctBoxRezolvare";
            this.pctBoxRezolvare.Size = new System.Drawing.Size(773, 311);
            this.pctBoxRezolvare.TabIndex = 25;
            this.pctBoxRezolvare.TabStop = false;
            // 
            // lblTextProb
            // 
            this.lblTextProb.AutoSize = true;
            this.lblTextProb.Location = new System.Drawing.Point(14, 59);
            this.lblTextProb.Name = "lblTextProb";
            this.lblTextProb.Size = new System.Drawing.Size(92, 13);
            this.lblTextProb.TabIndex = 24;
            this.lblTextProb.Text = "Alege o problema.";
            // 
            // btnEx1
            // 
            this.btnEx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx1.Location = new System.Drawing.Point(14, 12);
            this.btnEx1.Name = "btnEx1";
            this.btnEx1.Size = new System.Drawing.Size(64, 35);
            this.btnEx1.TabIndex = 23;
            this.btnEx1.Text = "Ex. 1";
            this.btnEx1.UseVisualStyleBackColor = true;
            // 
            // Sem11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctBoxRezolvare);
            this.Controls.Add(this.lblTextProb);
            this.Controls.Add(this.btnEx1);
            this.Name = "Sem11";
            this.Text = "Sem11";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRezolvare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxRezolvare;
        private System.Windows.Forms.Label lblTextProb;
        private System.Windows.Forms.Button btnEx1;
    }
}