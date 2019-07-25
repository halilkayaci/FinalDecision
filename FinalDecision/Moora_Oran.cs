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
    public partial class Moora_Oran : Form
    {
        public Moora_Oran()
        {
            InitializeComponent();
        }
        public static double[,] normmtrs = new double[50, 50];
        public static double[] maxTop = new double[50];
        public static double[] minTop = new double[50];
        private void button1_Click(object sender, EventArgs e)
        {
            bool bayrak = false;
            Double[,] moorakarar = Form1.kararmtrs;
            TextBox[,] ekle = Form1.ekle;
            TextBox[] wekle = Form1.wekle;
            string[] minmax = Form1.minmax;
            double alt = Form1.alt;
            double krt = Form1.krt;
            bool veriseti = false;
            bool maxmin = false;
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
                        moorakarar[j, i] = Convert.ToDouble(ekle[j + 1, i + 1].Text);
                    }
                }
                for (int i = 0; i < krt; i++)
                {
                    if (wekle[i].Text == "")
                    {
                        maxmin = true;
                        break;
                    }
                }
                if (maxmin == true)
                {
                    MessageBox.Show("Maksimum veya Minimum Değerleri Boş Olamaz...");
                }
                else
                {
                    for (int i = 0; i < krt; i++)
                    {
                        if (wekle[i].Text == "max" || wekle[i].Text == "min")
                        {
                            minmax[i] = (wekle[i].Text);
                        }
                        else bayrak = true;
                    }
                    if (bayrak == true)
                    {
                        MessageBox.Show("Lütfen Maksimum Olacak Kritere (max), Minimum Olacak Kritere (min) Yazınız ");
                    }
                    else bayrak = false;
                    for (int i = 0; i < alt; i++)
                    {
                        for (int j = 0; j < krt; j++)
                        {
                            double a = moorakarar[i, j];
                            a *= a;
                            normmtrs[i, j] = a;
                        }
                    }
                    double[] sTop = new double[50];
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
                    for (int i = 0; i < alt; i++)
                    {
                        for (int j = 0; j < krt; j++)
                        {
                            for (int k = 0; k < alt; k++)
                            {
                                double a = moorakarar[k, j];
                                double b = sTop[j];
                                double c = a / b;
                                normmtrs[k, j] = Math.Round(c, 4);
                            }
                        }
                    }
                    for (int i = 0; i < alt; i++)
                    {
                        double top = 0;
                        for (int j = 0; j < krt; j++)
                        {
                            if (minmax[j] == "max")
                            {
                                double t1 = normmtrs[i, j];
                                top += t1;
                            }
                        }
                        maxTop[i] = top;
                    }
                    for (int i = 0; i < alt; i++)
                    {
                        double top = 0;
                        for (int j = 0; j < krt; j++)
                        {
                            if (minmax[j] == "min")
                            {
                                double t1 = normmtrs[i, j];
                                top += t1;
                            }
                        }
                        minTop[i] = top;
                    }
                    if (bayrak == false) MessageBox.Show("Girilen Veri Setine Göre Karar Matrisi Oluşturuldu.Lütfen Norm Matris Oluştur Butonuna Basarak İşlemlere Devam Ediniz...");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MooraOranNorm mooraorannorm = new MooraOranNorm();
            mooraorannorm.Show();
        }
        private void Moora_Oran_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.problem;
        }
    }
}