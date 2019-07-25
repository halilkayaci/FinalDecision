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
    public partial class Gra : Form
    {
        public Gra()
        {
            InitializeComponent();
        }
        private void Gra_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.problem;
        }
        public static double[,] normmtrs = new double[50, 50];
        public static double[,] mutlakmtrs = new double[50, 50];
        public static double[,] greymtrs = new double[50, 50];
        private void button1_Click(object sender, EventArgs e)
        {
            bool wbayrak = false;
            Double[,] grakarar = Form1.kararmtrs;
            TextBox[,] ekle = Form1.ekle;
            TextBox[] wekle = Form1.wekle;
            TextBox[] wekle2 = Form1.wekle2;
            double[] weight = Form1.weight;
            string[] minmax = Form1.minmax;
            double alt = Form1.alt;
            double krt = Form1.krt;
            bool veriseti = false;
            bool maxmin = false;
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
                        grakarar[j, i] = Convert.ToDouble(ekle[j + 1, i + 1].Text);
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
                    double top = 0;
                    for (int i = 0; i < krt; i++)
                    {
                        weight[i] = Convert.ToDouble(wekle[i].Text);
                        double t1 = (weight[i]);
                        top += t1;
                    }
                    if (top == 1)
                    {
                        wbayrak = false;
                    }
                    else
                    {
                        wbayrak = true;
                        MessageBox.Show("Lütfen Ağırlıklar Toplamı 1  Olacak Şekilde Giriniz");
                    }
                    bool bayrak = false;
                    for (int i = 0; i < krt; i++)
                    {
                        if (wekle2[i].Text == "")
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
                            if (wekle2[i].Text == "max" || wekle2[i].Text == "min")
                            {
                                minmax[i] = (wekle2[i].Text);
                            }
                            else bayrak = true;
                        }
                        if (bayrak == true)
                        {
                            MessageBox.Show("Lütfen Maksimum Olacak Kritere (max), Minimum Olacak Kritere (min) Yazınız ");
                        }
                        else bayrak = false;
                        if (bayrak == false && wbayrak == false) MessageBox.Show("Girilen Veri Setine Göre Karar Matrisi Oluşturuldu.Lütfen Norm Matris Oluştur Butonuna Basarak İşlemlere Devam Ediniz...");
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Gra_Norm granorm = new Gra_Norm();
            granorm.Show();
            Double[,] grakarar = Form1.kararmtrs;
            double alt = Form1.alt;
            double krt = Form1.krt;
            string[] minmax = Form1.minmax;
            double[] max = new double[50];
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "max")
                {
                    max[i] = grakarar[i, i];
                    for (int j = 0; j < alt; j++)
                    {
                        if (max[i] < grakarar[j, i])
                        {
                            max[i] = grakarar[j, i];
                        }
                    }
                    max[i] = max[i];
                }
            }
            double[] min = new double[50];
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "min")
                {
                    min[i] = grakarar[0, i];
                    for (int j = 0; j < alt; j++)
                    {
                        if (min[i] > grakarar[j, i])
                        {
                            min[i] = grakarar[j, i];
                        }
                    }
                    min[i] = min[i];
                }
            }
            double[] sutunmax = new double[50];
            for (int i = 0; i < krt; i++)
            {
                sutunmax[i] = grakarar[0, i];
                for (int j = 0; j < alt; j++)
                {
                    if (sutunmax[i] < grakarar[j, i])
                    {
                        sutunmax[i] = grakarar[j, i];
                    }
                }
            }
            double[] sutunmin = new double[50];
            for (int i = 0; i < krt; i++)
            {
                sutunmin[i] = grakarar[0, i];
                for (int j = 0; j < alt; j++)
                {
                    if (sutunmin[i] > grakarar[j, i])
                    {
                        sutunmin[i] = grakarar[j, i];
                    }
                }
            }
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "max")
                {
                    for (int j = 0; j < alt; j++)
                    {
                        double d = (grakarar[j, i] - sutunmin[i]) / (sutunmax[i] - sutunmin[i]);
                        normmtrs[j, i] = Math.Round(d, 4);
                    }
                }
            }
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "min")
                {
                    for (int j = 0; j < alt; j++)
                    {
                        double d = (sutunmax[i] - grakarar[j, i]) / (sutunmax[i] - sutunmin[i]);
                        normmtrs[j, i] = Math.Round(d, 4);
                    }
                }
            }
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "max")
                {
                    double d = (max[i] - sutunmin[i]) / (sutunmax[i] - sutunmin[i]);
                    max[i] = Math.Round(d, 4);
                }
            }
            for (int i = 0; i < krt; i++)
            {
                if (minmax[i] == "min")
                {
                    double d = (sutunmax[i] - min[i]) / (sutunmax[i] - sutunmin[i]);
                    min[i] = Math.Round(d, 4);
                }
            }
        }
    }
}