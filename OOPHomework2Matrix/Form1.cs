﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPHomework2Matrix
{
    public partial class MatrixCalculator : Form
    {
        private List<List<NumericUpDown>> matris1 = new List<List<NumericUpDown>>();
        private List<List<NumericUpDown>> matris2 = new List<List<NumericUpDown>>();

        public MatrixCalculator()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += new System.EventHandler(NumericUpDown1_ValueChanged);
            numericUpDown2.ValueChanged += new System.EventHandler(NumericUpDown2_ValueChanged);
            numericUpDown3.ValueChanged += new System.EventHandler(NumericUpDown3_ValueChanged);
            numericUpDown4.ValueChanged += new System.EventHandler(NumericUpDown4_ValueChanged);

            buttonToplama.Click += new System.EventHandler(ButtonToplama_Click);
            buttonCarpma.Click += new System.EventHandler(ButtonCarpim_Click);
            buttonMatrisTers.Click += new System.EventHandler(ButtonMatrisTers_Click);

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                matris1.Add(new List<NumericUpDown>());

                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1[i].Add(new NumericUpDown());
                    matris1[i][j].Left = (j+1) * 40;
                    matris1[i][j].Top = (i+1) * 40;
                    matris1[i][j].Width = 25;
                    //matris1.Add(new TextBox());
                    //matris1[i * (int)numericUpDown2.Value + j].Left = (j+1) * 40;
                    //matris1[i * (int)numericUpDown2.Value + j].Top = (i+1) * 40;
                    //matris1[i * (int)numericUpDown2.Value + j].Width = 25;
                }
            }

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                matris2.Add(new List<NumericUpDown>());

                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2[i].Add(new NumericUpDown());
                    matris2[i][j].Left = this.Width/2 + (j + 1) * 40;
                    matris2[i][j].Top = (i + 1) * 40;
                    matris2[i][j].Width = 25;
                }
            }

            foreach (var satir in matris1)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }

            foreach (var satir in matris2)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }

        }

        private void NumericUpDown1_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var satir in matris1)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris1.Clear();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                matris1.Add(new List<NumericUpDown>());

                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1[i].Add(new NumericUpDown());
                    matris1[i][j].Left = (j + 1) * 40;
                    matris1[i][j].Top = (i + 1) * 40;
                    matris1[i][j].Width = 25;
                }
            }

            foreach (var satir in matris1)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown2_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var satir in matris1)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris1.Clear();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                matris1.Add(new List<NumericUpDown>());
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1[i].Add(new NumericUpDown());
                    matris1[i][j].Left = (j + 1) * 40;
                    matris1[i][j].Top = (i + 1) * 40;
                    matris1[i][j].Width = 25;
                }
            }

            foreach (var satir in matris1)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown3_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var satir in matris2)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                matris2.Add(new List<NumericUpDown>());
                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2[i].Add(new NumericUpDown());
                    matris2[i][j].Left = this.Width / 2 + (j + 1) * 40;
                    matris2[i][j].Top = (i + 1) * 40;
                    matris2[i][j].Width = 25;
                }
            }

            foreach (var satir in matris2)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown4_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var satir in matris2)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                matris2.Add(new List<NumericUpDown>());

            for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2[i].Add(new NumericUpDown());
                    matris2[i][j].Left = this.Width / 2 + (j + 1) * 40;
                    matris2[i][j].Top = (i + 1) * 40;
                    matris2[i][j].Width = 25;
                }
            }

            foreach (var satir in matris2)
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void ButtonToplama_Click(Object sender, EventArgs e)
        {
            List<List<int>> sonuc = Matrix.MatrisToplami(matris1, matris2);

            for (int i = 0; i < sonuc.Count; i++)
            {
                for (int j = 0; j < sonuc[i].Count; j++)
                {
                    textBoxSonuc.Text += sonuc[i][j] + " ";
                }
                textBoxSonuc.Text += "\r\n";
            }
        }

        private void ButtonCarpim_Click(Object sender, EventArgs e)
        {
            List<List<int>> sonuc = Matrix.MatrisCarpimi(matris1, matris2);

            for (int i = 0; i < sonuc.Count; i++)
            {
                for (int j = 0; j < sonuc[i].Count; j++)
                {
                    textBoxSonuc.Text += sonuc[i][j] + " ";
                }
                textBoxSonuc.Text += "\r\n";
            }
        }

        private void ButtonMatrisTers_Click(Object sender, EventArgs e)
        {
            List<List<decimal>> sonuc = Matrix.MatrisTers(matris1);

            for (int i = 0; i < sonuc.Count; i++)
            {
                for (int j = 0; j < sonuc[i].Count; j++)
                {
                    textBoxSonuc.Text += sonuc[i][j] + " ";
                }
                textBoxSonuc.Text += "\r\n";
            }
        }
    }
}