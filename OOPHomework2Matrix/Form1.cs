using System;
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
        private List<TextBox> matris1 = new List<TextBox>();
        private List<TextBox> matris2 = new List<TextBox>();

        public MatrixCalculator()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += new System.EventHandler(NumericUpDown1_ValueChanged);
            numericUpDown2.ValueChanged += new System.EventHandler(NumericUpDown2_ValueChanged);
            numericUpDown3.ValueChanged += new System.EventHandler(NumericUpDown3_ValueChanged);
            numericUpDown4.ValueChanged += new System.EventHandler(NumericUpDown4_ValueChanged);

            buttonToplama.Click += new System.EventHandler(ButtonToplama_Click);

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1.Add(new TextBox());
                    matris1[i * (int)numericUpDown2.Value + j].Left = (j+1) * 40;
                    matris1[i * (int)numericUpDown2.Value + j].Top = (i+1) * 40;
                    matris1[i * (int)numericUpDown2.Value + j].Width = 25;
                }
            }

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2.Add(new TextBox());
                    matris2[i * (int)numericUpDown4.Value + j].Left = this.Width/2 + (j + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Top = (i + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Width = 25;
                }
            }

            foreach (var eleman in matris1)
            {
                this.Controls.Add(eleman);
            }

            foreach (var eleman in matris2)
            {
                this.Controls.Add(eleman);
            }

        }

        private void NumericUpDown1_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var eleman in matris1)
            {
                this.Controls.Remove(eleman);
            }

            matris1.Clear();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1.Add(new TextBox());
                    matris1[i * (int)numericUpDown2.Value + j].Left = (j + 1) * 40;
                    matris1[i * (int)numericUpDown2.Value + j].Top = (i + 1) * 40;
                    matris1[i * (int)numericUpDown2.Value + j].Width = 25;
                }
            }

            foreach (var eleman in matris1)
            {
                this.Controls.Add(eleman);
            }
        }

        private void NumericUpDown2_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var eleman in matris1)
            {
                this.Controls.Remove(eleman);
            }

            matris1.Clear();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1.Add(new TextBox());
                    matris1[i * (int)numericUpDown2.Value + j].Left = (j + 1) * 40;
                    matris1[i * (int) numericUpDown2.Value + j].Top = (i + 1) * 40;
                    matris1[i * (int)numericUpDown2.Value + j].Width = 25;
                }
            }

            foreach (var eleman in matris1)
            {
                this.Controls.Add(eleman);
            }
        }

        private void NumericUpDown3_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var eleman in matris2)
            {
                this.Controls.Remove(eleman);
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2.Add(new TextBox());
                    matris2[i * (int)numericUpDown4.Value + j].Left = this.Width / 2 + (j + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Top = (i + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Width = 25;
                }
            }

            foreach (var eleman in matris2)
            {
                this.Controls.Add(eleman);
            }
        }

        private void NumericUpDown4_ValueChanged(Object sender, EventArgs e)
        {
            foreach (var eleman in matris2)
            {
                this.Controls.Remove(eleman);
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2.Add(new TextBox());
                    matris2[i * (int)numericUpDown4.Value + j].Left = this.Width / 2 + (j + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Top = (i + 1) * 40;
                    matris2[i * (int)numericUpDown4.Value + j].Width = 25;
                }
            }

            foreach (var eleman in matris2)
            {
                this.Controls.Add(eleman);
            }
        }

        private void ButtonToplama_Click(Object sender, EventArgs e)
        {
            if (numericUpDown1.Value != numericUpDown3.Value || numericUpDown2.Value != numericUpDown4.Value)
            {
                textBoxSonuc.Text =
                    "HATA! Girilen matrislerin tipleri eşit değil! Lütfen aynı tipte matrisler giriniz...";
                return;
            }

            if (!IntKontrol())
            {
                return;
            }

            var sonucMatris = new List<int>();

            for (int i = 0; i < matris1.Count; i++)
            {
                int intDegisken1, intDegisken2;
                int.TryParse(matris1[i].Text, out intDegisken1);
                int.TryParse(matris2[i].Text, out intDegisken2);

                sonucMatris.Add((intDegisken1 + intDegisken2));
            }

            textBoxSonuc.Clear();

            for (int i = 0; i < sonucMatris.Count; i++)
            {
                if (i % (int)numericUpDown1.Value == 0)
                {
                    textBoxSonuc.Text += "\r\n";
                }

                textBoxSonuc.Text += sonucMatris[i] + " ";
            }
        }

        private bool IntKontrol()
        {
            int intDegisken;
            bool hataVarMi1 = false, hataVarMi2 = false;

            foreach (var eleman in matris1)
            {
                if (!int.TryParse(eleman.Text, out intDegisken))
                {
                    hataVarMi1 = true;
                }
            }

            foreach (var eleman in matris2)
            {
                if (!int.TryParse(eleman.Text, out intDegisken))
                {
                    hataVarMi2 = true;
                }
            }

            if (hataVarMi1)
            {
                textBoxSonuc.Text =
                    "HATA! Birinci matriste girilen elemanlardan birisi hatalı, sadece tam sayılar giriniz...";
                return false;
            }

            if (hataVarMi2)
            {
                textBoxSonuc.Text =
                    "HATA! İkinci matriste girilen elemanlardan birisi hatalı, sadece tam sayılar giriniz...";
                return false;
            }

            return true;
        }
    }
}
