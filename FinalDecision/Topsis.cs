using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BILMES_Halil_Kayaci
{
    public partial class Topsis : Form
    {
        public Topsis()
        {
            InitializeComponent();
        }
        public static double[,] normmtrs = new double[50, 50];
        public static double[] Ndstop = new double[50];
        public static double[] dstop = new double[50];
        private void button1_Click(object sender, EventArgs e)
        {
            bool wbayrak = false;
            Double[,] topsiskarar = Form1.kararmtrs;
            TextBox[,] ekle = Form1.ekle;
            TextBox[] wekle = Form1.wekle;
            double[] weight = Form1.weight;
            double alt = Form1.alt;
            double krt = Form1.krt;
            bool veriseti = false;
            bool agirlik = false;
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (ekle[j + 1, i + 1].Text == "")
                    {
                        veriseti = true;
                        break;
                    }
                }
            }
            if (veriseti == true)
            {
                MessageBox.Show("Veri Seti Değerleri Boş Olamaz...");
            }
            else
            {
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < alt; j++)
                    {
                        topsiskarar[j, i] = Convert.ToDouble(ekle[j + 1, i + 1].Text);
                    }
                }
             
                for (int i = 0; i < krt; i++)
                {
                    if (wekle[i].Text == "")
                    {
                        agirlik = true;
                        break;
                    }
                }
                if (agirlik == true)
                {
                    MessageBox.Show("Ağırlık Değerleri Boş Olamaz...");
                }
                else
                {
                    double wtop = 0;
                      for (int i = 0; i < krt; i++)
                    {
                            weight[i] = Convert.ToDouble(wekle[i].Text);
                            double t1 =(weight[i]);
                            wtop += t1;
                    }
                    if (wtop == 1)
                    {
                        wbayrak = false;
                    }
                    else
                    {                        
                        MessageBox.Show("Lütfen Ağırlıklar Toplamı 1  Olacak Şekilde Giriniz");
                        wbayrak = true;
                    }
                    for (int i = 0; i < alt; i++)
                    {
                        for (int j = 0; j < krt; j++)
                        {
                            double a = topsiskarar[i, j];
                            a *= a;
                            normmtrs[i, j] = a;
                        }
                    }
                    double[] sTop = new double[50];
                    for (int i = 0; i < alt; i++)
                    {
                        for (int j = 0; j < krt; j++)
                        {
                            double top = 0;
                            for (int k = 0; k < alt; k++)
                            {
                                double t1 = normmtrs[k, j];
                                top += t1;
                            }
                            sTop[j] = Math.Round(Math.Sqrt(top), 7);
                        }
                    }
                    for (int i = 0; i < alt; i++)
                    {
                        for (int j = 0; j < krt; j++)
                        {
                            for (int k = 0; k < alt; k++)
                            {
                                double a = topsiskarar[k, j];
                                double b = sTop[j];
                                double c = a / b;
                                double d = weight[j];
                                normmtrs[k, j] = Math.Round(c * d, 4);
                            }
                        }
                    }
                    double[] max = new double[50];
                    for (int i = 0; i < krt; i++)
                    {
                        for (int j = 0; j < alt; j++)
                        {
                            if (max[i] < normmtrs[j, i])
                            {
                                max[i] = normmtrs[j, i];
                            }
                        }
                    }
                    double[] min = new double[50];
                    for (int i = 0; i < krt; i++)
                    {
                        min[i] = normmtrs[0, i];
                        for (int j = 0; j < alt; j++)
                        {
                            if (min[i] > normmtrs[j, i])
                            {
                                min[i] = normmtrs[j, i];
                            }
                        }
                    }
                    double[,] dstnc = new double[50, 50];
                    for (int i = 0; i < krt; i++)
                    {
                        for (int j = 0; j < alt; j++)
                        {
                            double a = normmtrs[j, i];
                            double b = max[i];
                            double c = Math.Pow((a - b), 2);
                            dstnc[j, i] = Math.Round(c, 5);
                        }
                    }
                    double[,] Ndstnc = new double[50, 50];
                    for (int i = 0; i < krt; i++)
                    {
                        for (int j = 0; j < alt; j++)
                        {
                            double a = normmtrs[j, i];
                            double b = min[i];
                            double c = Math.Pow((a - b), 2);
                            Ndstnc[j, i] = Math.Round(c, 5);
                        }
                    }
                    for (int j = 0; j < alt; j++)
                    {
                        double top = 0;
                        for (int k = 0; k < krt; k++)
                        {
                            double t1 = dstnc[j, k];
                            top += t1;
                        }
                        dstop[j] = Math.Sqrt(top);
                    }
                    for (int j = 0; j < alt; j++)
                    {
                        double top = 0;
                        for (int k = 0; k < krt; k++)
                        {
                            double t1 = Ndstnc[j, k];
                            top += t1;
                        }
                        Ndstop[j] = Math.Sqrt(top);
                    }
                    if (wbayrak == false) MessageBox.Show("Girilen Veri Setine Göre Karar Matrisi Oluşturuldu.Lütfen Norm Matris Oluştur Butonuna Basarak İşlemlere Devam Ediniz...");
                }
            }
        }
        private void Topsis_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.problem;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TopsisNorm topsisNorm = new TopsisNorm();
            topsisNorm.Show();
        }
    }
}