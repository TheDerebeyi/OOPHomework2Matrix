using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPHomework2Matrix
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MatrixCalculator());
        }
    }
    public static class Matrix
    {
        public static List<List<int>> MatrisToplami(List<List<NumericUpDown>> matris1, List<List<NumericUpDown>> matris2)
        {

            List<List<int>> sonucList = new List<List<int>>();

            if (matris1.Count != matris2.Count || matris1[0].Count != matris2[0].Count)
            {
                MessageBox.Show("HATA! Girilen matrislerin tipleri eşit değil! Lütfen aynı tipte matrisler giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)
            {
                sonucList.Add(new List<int>());
                for (int j = 0; j < matris1[i].Count; j++)
                {
                    sonucList[i].Add((int)matris1[i][j].Value + (int)matris2[i][j].Value);
                }
            }

            return sonucList;
        }

        public static List<List<int>> MatrisCarpimi(List<List<NumericUpDown>> matris1, List<List<NumericUpDown>> matris2)
        {

            List<List<int>> sonucList = new List<List<int>>();

            if (matris1[0].Count != matris2.Count)
            {
                MessageBox.Show("HATA! Girilen matrisler matris çarpımı için uygun değil! Lütfen uygun tipte matrisler giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)
            {
                sonucList.Add(new List<int>());
                for (int j = 0; j < matris2[0].Count; j++)
                {
                    int toplam = 0;
                    for (int k = 0; k < matris2.Count; k++)
                    {
                        toplam += (int) matris1[i][k].Value * (int) matris2[k][j].Value;
                    }
                    sonucList[i].Add(toplam);
                }
            }

            return sonucList;
        }

        public static List<List<int>> MatrisTranspoz(List<List<NumericUpDown>> matris1)
        {

            List<List<int>> sonucList = new List<List<int>>();

            if (matris1.Count != matris1[0].Count)
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)
            {
                sonucList.Add(new List<int>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    sonucList[i].Add((int)matris1[j][i].Value);
                }
            }

            return sonucList;
        }

        public static int MatrisIz(List<List<NumericUpDown>> matris1)
        {

            int sonuc = 0;

            if (matris1.Count != matris1[0].Count)
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonuc;
            }

            for (int i = 0; i < matris1.Count; i++)
            {
                sonuc += (int)matris1[i][i].Value;
            }

            return sonuc;
        }

        public static List<List<decimal>> MatrisTers(List<List<NumericUpDown>> matris1)
        {

            List<List<decimal>> sonucList = new List<List<decimal>>();


            if (matris1.Count != matris1[0].Count)
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonucList;
            }


            List<List<decimal>> matrisKopya = new List<List<decimal>>();

            for (int i = 0; i < matris1.Count; i++)
            {
                matrisKopya.Add(new List<decimal>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    matrisKopya[i].Add(matris1[i][j].Value);
                }
            }

            for (int i = 0; i < matris1.Count; i++)
            {
                sonucList.Add(new List<decimal>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    if (i == j)
                    {
                        sonucList[i].Add(1);
                        continue;
                    }
                    sonucList[i].Add(0);
                }
            }

            decimal payda, carpim;

            for (int i = 0; i < matris1.Count; i++)
            {
                payda = matrisKopya[i][i];
                for (int j = 0; j < matris1.Count; j++)
                {
                    matrisKopya[i][j] /= payda;
                    sonucList[i][j] /= payda;
                }

                for (int k = 1+i; k < matris1.Count; k++)
                {
                    carpim = matrisKopya[k][i] * -1;
                    for (int l = 0; l < matris1.Count; l++)
                    {
                        matrisKopya[k][l] += carpim * matrisKopya[i][l];
                        sonucList[k][l] += carpim * sonucList[i][l];
                    }
                }
            }

            for (int i = matris1.Count; i > 0; i--)
            {
                payda = matrisKopya[i][i];
                for (int j = 0; j < matris1.Count; j++)
                {
                    matrisKopya[i][j] /= payda;
                    sonucList[i][j] /= payda;
                }

                for (int k = 1 + i; k < matris1.Count; k++)
                {
                    carpim = matrisKopya[k][i] * -1;
                    for (int l = 0; l < matris1.Count; l++)
                    {
                        matrisKopya[k][l] += carpim * matrisKopya[i][l];
                        sonucList[k][l] += carpim * sonucList[i][l];
                    }
                }
            }

            return sonucList;
        }

    }
}
