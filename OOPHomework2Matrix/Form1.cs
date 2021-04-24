using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OOPHomework2Matrix
{
    public partial class MatrixCalculator : Form
    {
        private List<List<NumericUpDown>> matris1 = new List<List<NumericUpDown>>();        //Formda kullanılacak 2 ana matris tanımlanıyor.
        private List<List<NumericUpDown>> matris2 = new List<List<NumericUpDown>>();

        const int ELEMANLAR_ARASI_BOSLUK = 35, GENISLIK = 30, UST_BOSLUK = 20, MAX = 99, MIN = -99;

        public MatrixCalculator()
        {
            InitializeComponent();

            numericUpDown1.ValueChanged += new System.EventHandler(NumericUpDown1_ValueChanged);                //Event fonksiyonları ile form controlleri bağlanıyor.
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

            for (int i = 0; i < numericUpDown1.Value; i++)                                                      //Default olarak formda 2x2'lik matrisler oluşturuluyor ve özellikleri belirleniyor.
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

            for (int i = 0; i < numericUpDown3.Value; i++)                                                    //İkinci matris oluşturulup özellikleri belirleniyor.
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

            foreach (var satir in matris1)                                                      //İlk matris forma ekleniyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }

            foreach (var satir in matris2)                                                      //İkinci matris forma ekleniyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }

        }

        private void NumericUpDown1_ValueChanged(Object sender, EventArgs e)                                    //İlk matrisin satır belirleyici değiştirilirse bu fonksiyon çalışır.
        {
            foreach (var satir in matris1)                                                      //Formdaki matris kaldırılıyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris1.Clear();                                                                                    //İlk matris temizleniyor.

            for (int i = 0; i < numericUpDown1.Value; i++)                                                     //Yeni satır verisine göre tekrardan matris oluşturuluyor.
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

            foreach (var satir in matris1)                                                  //Matris forma ekleniyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown2_ValueChanged(Object sender, EventArgs e)                                //İlk matrisin sütun belirleyici değiştirilirse bu fonksiyon çalışır.
        {
            foreach (var satir in matris1)                                                  //Formdaki matris kaldırılıyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris1.Clear();                                                                                //İlk matris temizleniyor.

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                matris1.Add(new List<NumericUpDown>());                                                 //Yeni sütun verisine göre tekrardan matris oluşturuluyor.
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

            foreach (var satir in matris1)                                                  //Forma ilk matris tekrardan yeni haliyle ekleniyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown3_ValueChanged(Object sender, EventArgs e)                                //İkinci matrisin satır belirleyicisi değiştirilirse bu fonksiyon çalışır.
        {
            foreach (var satir in matris2)                                                  //Formdaki matris kaldırılıyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)                                                  //Yeni satır değerine göre tekrar matris oluşturuluyor.
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

            foreach (var satir in matris2)                                                  //Yeni matris forma ekleniyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void NumericUpDown4_ValueChanged(Object sender, EventArgs e)                                //İkinci matrisin sütun belirleyicisi değiştirildiğinde çalışır.
        {
            foreach (var satir in matris2)                                                  //Formdan matris kaldırılıyor.
            {
                foreach (var eleman in satir)
                {
                    this.Controls.Remove(eleman);
                }
            }

            matris2.Clear();

            for (int i = 0; i < numericUpDown3.Value; i++)                                                     //Yeni sütun değerine göre tekrar matris oluşturuluyor.
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

            foreach (var satir in matris2)                                                     //Yeni matris forma ekleniyor.
            {   
                foreach (var eleman in satir)
                {
                    this.Controls.Add(eleman);
                }
            }
        }

        private void ButtonToplama_Click(Object sender, EventArgs e)                                           //Toplama butonuna tıklandığında çalışır. Textbox'a işlem yapıldıktan sonra toplama işleminin sonucu yazdırılır.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris 1:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nMatris 2:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris toplama\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisToplami(matris1, matris2));
        }

        private void ButtonCarpim_Click(Object sender, EventArgs e)                                         //Çarpma butonuna tıklandığında çalışır. Çarpa işlemi yapıldıktan sonra sonucu textbox'a yazdırır.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris 1:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nMatris 2:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris çarpma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisCarpimi(matris1, matris2));
        }

        private void ButtonMatrisTers_Click(Object sender, EventArgs e)                                     //İlk matrisin tersini alma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matrisin tersini bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTers(matris1));
        }

        private void ButtonMatrisTers2_Click(Object sender, EventArgs e)                                    //İkinci matrisin tersini alma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matrisin tersini bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTers(matris2));
        }

        private void ButtonMatrisTranspoz_Click(Object sender, EventArgs e)                                //İlk matrisin transpozunu alma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris transpoz bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTranspoz(matris1));
        }

        private void ButtonMatrisTranspoz2_Click(Object sender, EventArgs e)                                //İkinci matrisin transpozunu alma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris transpoz bulma\r\n\r\nSonuç:\r\n";
            SonucYazdir(Matrix.MatrisTranspoz(matris2));
        }

        private void ButtonMatrisIz_Click(Object sender, EventArgs e)                                       //İlk matrisin izini yazdırma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris1Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris izi bulma\r\n\r\nSonuç:\r\n";
            textBoxSonuc.Text += Matrix.MatrisIz(matris1).ToString() + "\r\n";
        }

        private void ButtonMatrisIz2_Click(Object sender, EventArgs e)                                      //İkinci matrisin izini yazdırma butonunun fonksiyonu.
        {
            textBoxSonuc.Clear();
            textBoxSonuc.Text += "Matris:\r\n";
            Matris2Yazdir();
            textBoxSonuc.Text += "\r\nYapilan işlem: Matris izi bulma\r\n\r\nSonuç:\r\n";
            textBoxSonuc.Text += Matrix.MatrisIz(matris2).ToString() + "\r\n";
        }

        private void ButtonKaydet_Click(Object sender, EventArgs e)                                         //Sonucu "kaydet.dat"a kaydetme butonunun fonksiyonu.
        {
            Matrix.MatrisYazdirma(textBoxSonuc.Lines);
        }

        private void ButtonGecmis_Click(Object seber, EventArgs e)                                          //Geçmişi "kayit.dat"tan çekme butonunun fonksiyonu.
        {
            richTextBox1.Lines = Matrix.MatrisOkuma();
        }

        private void SonucYazdir<T>(List<List<T>> sonuc)                                                    //Gelen sonuç matrisini textbox'a yazdırma metodu. Generic progromlama kullanılmıştır.
        {
            for (int i = 0; i < sonuc.Count; i++)                                                           //sonuc matrisinin elemanları tek tek textbox'a yazdırılıyor.                               
            {
                for (int j = 0; j < sonuc[i].Count; j++)
                {
                    textBoxSonuc.Text += sonuc[i][j] + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void Matris1Yazdir()                                                                        //Formdaki ilk matrisi textbox'a yazdırma metodu.
        {
            for (int i = 0; i < matris1.Count; i++)                                                         //İlk matrisin tüm elemanları tek tek textbox'a yazdırılıyor.        
            {
                for (int j = 0; j < matris1[i].Count; j++)
                {
                    textBoxSonuc.Text += matris1[i][j].Value + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void Matris2Yazdir()                                                                        //Formdaki ikinci matrisi textbox'a yazdırma metodu.
        {
            for (int i = 0; i < matris2.Count; i++)                                                         //İkinci matrisin tüm elemanları tek tek textbox'a yazdırılıyor.
            {
                for (int j = 0; j < matris2[i].Count; j++)
                {
                    textBoxSonuc.Text += matris2[i][j].Value + " ";
                }

                textBoxSonuc.Text += "\r\n";
            }
        }

        private void GecmisiSifirla_Click(Object sender, EventArgs e)                                   //"kayit.dat" silinir ve richTextBox1'in yazısı sıfırlanır.
        {
            richTextBox1.Clear();
            File.Delete("kayit.dat");
        }
    }
}