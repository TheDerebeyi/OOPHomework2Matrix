/****************************************************************************
**	    				    SAKARYA ÜNİVERSİTESİ
**	    			BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**	    			    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**	    			   NESNEYE DAYALI PROGRAMLAMA DERSİ
**		    			    2020-2021 BAHAR DÖNEMİ
**	
**				    ÖDEV NUMARASI..........: Ödev 2 Soru 2
**				    ÖĞRENCİ ADI............: Lütfi Mert Kahraman   
**				    ÖĞRENCİ NUMARASI.......: B201210040
**                  DERSİN ALINDIĞI GRUP...: 1. Öğretim D Grubu
****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OOPHomework2Matrix
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MatrixCalculator());
        }
    }
    public static class Matrix                              //Matris işlemlerinin metodlarının bulunduğu statik matris sınıfı
    {
        //Matrisler List<List<int>>, List<List<decimal>> ve List<List<NumericUpDown>> şeklinde çeşitli fonksiyonlarda yer almıştır.

        public static List<List<int>> MatrisToplami(List<List<NumericUpDown>> matris1, List<List<NumericUpDown>> matris2)       //Parametre olarak girilen iki matrisi toplayıp sonucu geri döndürür.
        {

            List<List<int>> sonucList = new List<List<int>>();                                                  //Sonucun yazdırılacağı matris.

            if (matris1.Count != matris2.Count || matris1[0].Count != matris2[0].Count)                         //Matris toplamı için tiplerin eşit olması gerekmektedir, girilen matrislerin tiplerinin eşit olup olmadığına bakılıyor.
            {
                MessageBox.Show("HATA! Girilen matrislerin tipleri eşit değil! Lütfen aynı tipte matrisler giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)                                                             //Tüm satırlar gezilecek.
            {
                sonucList.Add(new List<int>());                                                             //Matrisin satırı ekleniyor.
                for (int j = 0; j < matris1[i].Count; j++)                                                      //Tüm sütunlar geziliyor.
                {
                    sonucList[i].Add((int)matris1[i][j].Value + (int)matris2[i][j].Value);                  //İki matrisin aynı satır ve sütunundaki elemanlar toplanıp sonuç matrisine ekleniyor.
                }
            }

            return sonucList;
        }

        public static List<List<int>> MatrisCarpimi(List<List<NumericUpDown>> matris1, List<List<NumericUpDown>> matris2)           //Parametre olarak girilen iki matrisi çarpıp sonucu geri döndürür.
        {

            List<List<int>> sonucList = new List<List<int>>();

            if (matris1[0].Count != matris2.Count)                                                                                  //Matris çarpımı için ilk matrisin sütun sayısı ile ikinci matrisin satır sayısının eşit olması lazım. Durum kontrol ediliyor.
            {
                MessageBox.Show("HATA! Girilen matrisler matris çarpımı için uygun değil! Lütfen uygun tipte matrisler giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)                                                                                 //Birinci matrisin satır sayısı kadar sonuç matrisinin satırı yer alacak. Tüm satırlar tek tek geziliyor.
            {
                sonucList.Add(new List<int>());
                for (int j = 0; j < matris2[0].Count; j++)                                                                          //İkinci matrisin sütun sayısı kadar sonuç matrisinin sütunu yer alacak.
                {
                    int toplam = 0;
                    for (int k = 0; k < matris2.Count; k++)                                                                         //İlk matrisin sütun sayısı kere işlem gerçekleşecek.
                    {
                        toplam += (int)matris1[i][k].Value * (int)matris2[k][j].Value;                                              //Matris elemanları işlendikten sonra adımların sonucunda çıkan sonuçların toplamı matrisin i. satırının j. sütununa yazdırılacak.
                    }
                    sonucList[i].Add(toplam);
                }
            }

            return sonucList;
        }

        public static List<List<int>> MatrisTranspoz(List<List<NumericUpDown>> matris1)                                     //Parametre olarak girilen matrisin transpozunu geri döndürür.
        {

            List<List<int>> sonucList = new List<List<int>>();

            if (matris1.Count != matris1[0].Count)                                                                          //Matris kare matris mi kontrol ediliyor.
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)                                                                         //Girilen matrisin i. satırının j. sütunundaki eleman sonuç matrisinin j. satırının i. sütununa yazdırılıyor.
            {
                sonucList.Add(new List<int>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    sonucList[i].Add((int)matris1[j][i].Value);
                }
            }

            return sonucList;
        }

        public static int MatrisIz(List<List<NumericUpDown>> matris1)                                                   //Parametre olarak girilen matrisin izini geri döndürür.
        {

            int sonuc = 0;

            if (matris1.Count != matris1[0].Count)
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonuc;
            }

            for (int i = 0; i < matris1.Count; i++)                                                                 //Matris izi köşegen elemanlarının toplamıdır. Matrisin i. satır ve sütunundaki elemanlar toplanıyor.
            {
                sonuc += (int)matris1[i][i].Value;
            }

            return sonuc;
        }

        static int MatrisDeterminant(List<List<decimal>> matris1)                                                  //Yinelemeli fonksiyon. Girilen matrisin determinantını geri döndürür.
        {
            List<List<decimal>> kucukMatris = new List<List<decimal>>();

            int determinant = 0;

            if (matris1.Count == 2)                                                                                //Eğer matrisin tipi 2x2 ise direkt olarak determinant hesaplanabilir.
            {
                determinant = (int)(matris1[0][0] * matris1[1][1] - matris1[0][1] * matris1[1][0]);
                return determinant;
            }


            int satir = 0;

            //Matris hesabı için ilk satıra göre Laplace açılımı kullanılacaktır.

            List<int> kofaktorList = new List<int>();

            for (int i = 0; i < matris1.Count; i++)                                 //İşaretli minör hesabı için kofaktör matrisine önce elemanın satır ve sütun toplamının tek veya çift olmasına göre -1 veya 1 yerleştiriliyor. Sonra bunlarla elemanın minörleri çarpılıp yerine yazılacak.
            {
                if (satir + i % 2 == 0)
                {
                    kofaktorList.Add(1);
                }
                else
                {
                    kofaktorList.Add(-1);
                }
            }

            for (int i = 0; i < matris1.Count; i++)                             //Laplace açılımında elemanın bulunduğu satır ve sütun harici diğer elemanların oluşturduğu matrisin determinantı gerekmektedir.
            {                                                                   //Bu determinantlardan matrisin satır sayısı tane oluşacak. En dış döngü matrisin satır sayısı kadar dönecek.
                kucukMatris.Clear();                                            //Her adım başı kopyaMatris determinant hesabı için tekrar aynı fonksiyona gönderildikten sonra tekrar kullanım için sıfırlanıyor.
                int indis = 0;
                for (int j = 0; j < matris1.Count; j++)                         //Matrisin tüm satırları taranıyor.
                {
                    if (j == satir)                                             //Eğer j, elemanın (bu durumda satir. satır ve i. sütundaki eleman) satır sayısına eşitse bu adım geçilecektir.
                    {
                        continue;
                    }

                    kucukMatris.Add(new List<decimal>());

                    for (int k = 0; k < matris1.Count; k++)                     //Matrisin tüm sütunları taranıyor.
                    {
                        if (k != i)                                             //Eğer k, elemanın sütun sayısına eşit değilse matrisin j. satır ve k. sütunundaki eleman yeni matrise yazdırılacak.
                        {
                            kucukMatris[indis].Add(matris1[j][k]);
                        }
                    }
                    indis++;
                }
                kofaktorList[i] *= Matrix.MatrisDeterminant(kucukMatris);       //Yeni matris tekrar aynı fonksiyona yollanıyor. Sonuç kofaktör listesindeki işarete göre yerine yazılıyor.
            }

            for (int i = 0; i < matris1.Count; i++)                             //Laplace açılımına göre seçilen satırdaki tüm elemanların kofaktörleri ile çarpımlarının toplamı deterninantı verir. İşlem gerçekleştiriliyor.
            {
                determinant += (int)matris1[satir][i] * kofaktorList[i];
            }

            return determinant;
        }

        public static List<List<decimal>> MatrisTers(List<List<NumericUpDown>> matris1)                                         //Girilen matrisin tersini geri döndürür. Gauss-Jordan yöntemi kullanılmıştır.
        {
            List<List<decimal>> sonucList = new List<List<decimal>>();

            if (matris1.Count != matris1[0].Count)                                                  //Matrisin tersinin hesaplanabilmesi için kare matris olması gerekmektedir.
            {
                MessageBox.Show("HATA! Girilen matris bir kare matris değil! Lütfen bir kare matris giriniz...");
                return sonucList;
            }

            List<List<decimal>> matrisKopya = new List<List<decimal>>();

            for (int i = 0; i < matris1.Count; i++)                                                //Orijinal matris üzerinde oynama yapılmaması için matrisin bir kopyası çıkarılıyor.
            {
                matrisKopya.Add(new List<decimal>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    matrisKopya[i].Add(matris1[i][j].Value);
                }
            }

            if (Matrix.MatrisDeterminant(matrisKopya) == 0)                                         //Eğer matrisin determinantı 0 ise tersi yoktur.
            {
                MessageBox.Show("HATA! Girilen matrisin determinantı sıfır!");
                return sonucList;
            }

            for (int i = 0; i < matris1.Count; i++)                                                 //Gauss jordan yöntemi için girilen matrisin yanında bir tane de birim matris gerekmektedir. Birim matris oluşturuyor.
            {
                sonucList.Add(new List<decimal>());
                for (int j = 0; j < matris1[0].Count; j++)
                {
                    if (i == j)                                                                     //Köşegenlere 1, diğer elemanlara 0 yerleştirilmeli. Satır sayısının sütun sayısına eşit olduğu noktalar köşegen elemanlarıdır. Satır sayısının sütun sayısına eşit olup olmadığı kontrol ediliyor.
                    {
                        sonucList[i].Add(1);
                        continue;
                    }
                    sonucList[i].Add(0);
                }
            }

            decimal payda, carpim;

            for (int i = 0; i < matris1.Count; i++)                                                 //Matrisin tersini alabilmemiz için köşegen elemanlarını bir diğer elemanlar sıfır yapmamız gerekli.
            {                                                                                       //Önce her satırdaki köşegen elemanı bir yapılacak sonra o satır kullanılarak diğer satırlar sıfırlanacaktır.
                if (matrisKopya[i][i] != 0)                                                         //Köşegen elemanı kendisine bölünerek bir yapılacaktır, eğer ki köşegene elemanı zaten sıfır ise kod hata verecektir.
                {                                                                                   //Köşegen elemanının sıfır olup olmadığı kontrol ediliyor.
                    payda = matrisKopya[i][i];
                    for (int j = 0; j < matris1.Count; j++)                                         //Matris sfır değil ise köşegen elemanı kendine bölünerek o elemanın bir olması sağlanıyor. Bu bölmenin satırın geri kalanına da uygulanılması gerek.
                    {                                                                               //Aynı zamanda yapılan tüm işlemler birimler matrisine de uygulanacaktır.
                        matrisKopya[i][j] /= payda;
                        sonucList[i][j] /= payda;
                    }
                }
                else                                                                                //Eğer ki koşegen elemanı sıfır ise;
                {
                    for (int j = 0; j < matrisKopya.Count; j++)                                     //Matris tamamen taranacak ve köşegen elemanının bulunduğu sütundaki ilk sıfır olmayan eleman bir yapılacak ve bu sıfır olmayan elemanın satırı köşegen elemanının bulunduğu satırla toplanacak.
                    {
                        if (matrisKopya[j][i] != 0)
                        {
                            payda = matrisKopya[j][i];
                            for (int l = 0; l < matris1.Count; l++)
                            {
                                matrisKopya[i][l] += matrisKopya[j][l] / payda;                     //Sıfır olmayan elemanın satırındaki tüm elemanlar sıfır olmayan elemana bölünüyor ve köşegen elemanının bulunduğu satıra ekleniyor. Bu şekilde köşegen elemanı bir yapılmış oldu.
                                sonucList[i][l] += sonucList[j][l] / payda;                         //Aynı işlem birim matrise de uygulanıyor.
                            }

                            payda = matrisKopya[i][i];
                            for (int k = 0; j < matris1.Count; j++)
                            {
                                matrisKopya[i][k] /= payda;
                                sonucList[i][k] /= payda;
                            }
                            break;
                        }
                    }
                }

                for (int k = 1 + i; k < matris1.Count; k++)                                         //Köşegen elemanı bir yapıldıktan sonra aynı satırda altta kalan tüm elemanların sıfır yapılması gerekli.
                {
                    carpim = matrisKopya[k][i] * -1;                                                //Hangi eleman sıfır yapılacaksa çarpan o elemanın toplamaya göre tersi olarak ayarlanıyor.
                    for (int l = 0; l < matris1.Count; l++)                                         //Döngüde sırası gelmiş köşegen elemanının satırındaki tüm elemanlar çarpanla çarpılıyor ve aynı sütunlarında bulunan sıfır yapılması istenen elemanın satırındakilerle toplanıyor.
                    {                                                                               //Döngü altta kaç tane satır varsa aynı şekilde devam edecek.
                        matrisKopya[k][l] += carpim * matrisKopya[i][l];
                        sonucList[k][l] += carpim * sonucList[i][l];
                    }
                }
            }
                                                                                                    //Buraya kadar tüm köşegen elemanları bir ve altta kalan tüm elemanlar sıfır yapıldı. Geriye üstte kalan elemanlar en kötü ihtimalle tamamen sıfırdan farklı sayılar.
            for (int i = matris1.Count - 2; i >= 0; i--)                                            //Bu döngü ile en alttaki satırdan başlanıp satırdaki 1 kullanılarak üstteki satırlardaki elemanlar 0 yapılacak. Döngü matrisin satır sayısından bir eksiği kadar devam edecek çünkü en alttaki satır zaten düzgün bir biçimde dönüştürülmüş.
            {
                for (int k = i; k >= 0; k--)                                                        //Satirdaki köşegen elemanı sıfır yapılmak istenen elemanın toplamaya göre tersi ile çarpılıp sıfır yapılmak istenen eleman ile toplanacak.
                {                                                                                   
                    carpim = matrisKopya[k][i + 1] * -1;
                    matrisKopya[k][i + 1] += carpim * matrisKopya[i + 1][i + 1];

                    for (int l = 0; l < matris1.Count; l++)                                         //Aynı işlem satırın diğer elemanları için de uygulanmalı.
                    {
                        sonucList[k][l] += carpim * sonucList[i + 1][l];
                    }
                }
            }

            return sonucList;
        }

        public static void MatrisYazdirma(string[] mesaj)                                           //Dosyaya sonucu yazdırır.
        {
            File.AppendAllLines("kayit.dat", mesaj);                                           //Metoda parametre olarak girilen mesah "kayit.dat" dosyasına yazdırılıyor.
        }

        public static string[] MatrisOkuma()                                                       //Dosyadan metni çekip geri döndürür.
        {
            if (File.Exists("kayit.dat"))                                                      //"kayit.dat" diye bir dosya var mı diye kontrol ediliyor.
            {
                return File.ReadAllLines("kayit.dat");                                          //Eğer varsa dosyadaki tüm satırlar geri döndürülüyor.
            }

            string[] mesaj = new string[0];                                                         //Eğer yoksa boş mesaj geri döndürülüyor.
            return mesaj;

        }
    }
}
