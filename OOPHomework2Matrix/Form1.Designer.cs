
namespace OOPHomework2Matrix
{
    partial class MatrixCalculator
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.buttonToplama = new System.Windows.Forms.Button();
            this.buttonCarpma = new System.Windows.Forms.Button();
            this.textBoxSonuc = new System.Windows.Forms.TextBox();
            this.buttonMatrisTers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(23, 12);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(80, 12);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 22);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(713, 12);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(51, 22);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(770, 12);
            this.numericUpDown4.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(51, 22);
            this.numericUpDown4.TabIndex = 7;
            this.numericUpDown4.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonToplama
            // 
            this.buttonToplama.Location = new System.Drawing.Point(598, 99);
            this.buttonToplama.Name = "buttonToplama";
            this.buttonToplama.Size = new System.Drawing.Size(36, 30);
            this.buttonToplama.TabIndex = 8;
            this.buttonToplama.Text = "+";
            this.buttonToplama.UseVisualStyleBackColor = true;
            // 
            // buttonCarpma
            // 
            this.buttonCarpma.Location = new System.Drawing.Point(598, 146);
            this.buttonCarpma.Name = "buttonCarpma";
            this.buttonCarpma.Size = new System.Drawing.Size(36, 30);
            this.buttonCarpma.TabIndex = 9;
            this.buttonCarpma.Text = "X";
            this.buttonCarpma.UseVisualStyleBackColor = true;
            // 
            // textBoxSonuc
            // 
            this.textBoxSonuc.Location = new System.Drawing.Point(165, 377);
            this.textBoxSonuc.Multiline = true;
            this.textBoxSonuc.Name = "textBoxSonuc";
            this.textBoxSonuc.ReadOnly = true;
            this.textBoxSonuc.Size = new System.Drawing.Size(369, 157);
            this.textBoxSonuc.TabIndex = 10;
            // 
            // buttonMatrisTers
            // 
            this.buttonMatrisTers.Location = new System.Drawing.Point(12, 373);
            this.buttonMatrisTers.Name = "buttonMatrisTers";
            this.buttonMatrisTers.Size = new System.Drawing.Size(116, 30);
            this.buttonMatrisTers.TabIndex = 11;
            this.buttonMatrisTers.Text = "Matrisin Tersi";
            this.buttonMatrisTers.UseVisualStyleBackColor = true;
            // 
            // MatrixCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 576);
            this.Controls.Add(this.buttonMatrisTers);
            this.Controls.Add(this.textBoxSonuc);
            this.Controls.Add(this.buttonCarpma);
            this.Controls.Add(this.buttonToplama);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MatrixCalculator";
            this.Text = "Matrix Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button buttonToplama;
        private System.Windows.Forms.Button buttonCarpma;
        private System.Windows.Forms.TextBox textBoxSonuc;
        private System.Windows.Forms.Button buttonMatrisTers;
    }
}

