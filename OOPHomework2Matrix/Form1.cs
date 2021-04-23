using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        const int ELEMANLAR_ARASI_BOSLUK = 35, GENISLIK = 30, UST_BOSLUK = 20, MAX = 99, MIN = -99;

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
            buttonMatrisTers2.Click += new System.EventHandler(ButtonMatrisTers2_Click);
            buttonMatrisTranspoz.Click += new System.EventHandler(ButtonMatrisTranspoz_Click);
            buttonMatrisTranspoz2.Click += new System.EventHandler(ButtonMatrisTranspoz2_Click);
            buttonMatrisIz.Click += new System.EventHandler(ButtonMatrisIz_Click);
            buttonMatrisIz2.Click += new System.EventHandler(ButtonMatrisIz2_Click);
            buttonKaydet.Click += new System.EventHandler(ButtonKaydet_Click);
            buttonGecmis.Click += new System.EventHandler(ButtonGecmis_Click);
            buttonSifirla.Click += new System.EventHandler(GecmisiSifirla_Click);

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                matris1.Add(new List<NumericUpDown>());

                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    matris1[i].Add(new NumericUpDown());
                    matris1[i][j].Left = (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Width = GENISLIK;
                    matris1[i][j].Minimum = MIN;
                    matris1[i][j].Maximum = MAX;
                }
            }

            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                matris2.Add(new List<NumericUpDown>());

                for (int j = 0; j < numericUpDown4.Value; j++)
                {
                    matris2[i].Add(new NumericUpDown());
                    matris2[i][j].Left = this.Width / 2 + (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Width = GENISLIK;
                    matris2[i][j].Minimum = MIN;
                    matris2[i][j].Maximum = MAX;
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
                    matris1[i][j].Left = (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Width = GENISLIK;
                    matris1[i][j].Minimum = MIN;
                    matris1[i][j].Maximum = MAX;
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
                    matris1[i][j].Left = (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris1[i][j].Width = GENISLIK;
                    matris1[i][j].Minimum = MIN;
                    matris1[i][j].Maximum = MAX;
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
                    matris2[i][j].Left = this.Width / 2 + (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Width = GENISLIK;
                    matris2[i][j].Minimum = MIN;
                    matris2[i][j].Maximum = MAX;
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
                    matris2[i][j].Left = this.Width / 2 + (j + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Top = UST_BOSLUK + (i + 1) * ELEMANLAR_ARASI_BOSLUK;
                    matris2[i][j].Width = GENISLIK;
                    matris2[i][j].Minimum = MIN;
                    matris2[i][j].Maximum = MAX;
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
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris 1:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nMatris 2:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris toplama\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisToplami(matris1, matris2));
        }

        private void ButtonCarpim_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris 1:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nMatris 2:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris çarpma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisCarpimi(matris1, matris2));
        }

        private void ButtonMatrisTers_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matrisin tersini bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTers(matris1));
        }

        private void ButtonMatrisTers2_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matrisin tersini bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTers(matris2));
        }

        private void ButtonMatrisTranspoz_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris transpoz bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTranspoz(matris1));
        }

        private void ButtonMatrisTranspoz2_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris transpoz bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTranspoz(matris2));
        }

        private void ButtonMatrisIz_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris izi bulma\r\n\r\nSonuç:\r\n";
            textBoxSonuc.Text += Matrix.MatrisIz(matris1).ToString() + "\r\n";
        }

        private void ButtonMatrisIz2_Click(Object sender, EventArgs e)
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris izi bulma\r\n\r\nSonuç:\r\n";
            textBoxSonuc.Text += Matrix.MatrisIz(matris2).ToString() + "\r\n";
        }

        private void ButtonKaydet_Click(Object sender, EventArgs e)
        {
            Matrix.MatrisYazdirma(textBoxSonuc.Lines);
        }

        private void ButtonGecmis_Click(Object seber, EventArgs e)
        {
            richTextBox1.Lines = Matrix.MatrisOkuma();
        }

        private void SonucYazdir<T>(List<List<T>> sonuc)
        {
            for (int i = 0; i < sonuc.Count; i++)
            {
                for (int j = 0; j < sonuc[i].Count; j++)
                {
                    textBoxSonuc.Text += sonuc[i][j] + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void Matris1Yazdir()
        {
            for (int i = 0; i < matris1.Count; i++)
            {
                for (int j = 0; j < matris1[i].Count; j++)
                {
                    textBoxSonuc.Text += matris1[i][j].Value + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void Matris2Yazdir()
        {
            for (int i = 0; i < matris2.Count; i++)
            {
                for (int j = 0; j < matris2[i].Count; j++)
                {
                    textBoxSonuc.Text += matris2[i][j].Value + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void GecmisiSifirla_Click(Object sender, EventArgs e)
        {
            richTextBox1.Clear();
            File.Delete("kayit.dat");
        }
    }
}