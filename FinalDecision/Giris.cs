using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Halil_KAYACI_23.04.2018
namespace BILMES_Halil_Kayaci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static double[,] kararmtrs = new double[50, 50];
        public static TextBox[,] ekle = new TextBox[50, 50];
        public static double[] weight = new double[50];
        public static TextBox[] wekle = new TextBox[50];
        public static TextBox[] wekle2 = new TextBox[50];
        public static TextBox[] altekle = new TextBox[50];
        public static TextBox[] krtekle = new TextBox[50];
        public static string[] minmax = new string[50];
        public static string[] altname = new string[50];
        public static string[] krtname = new string[50];
        public static double alt;
        public static double krt;
        public static string problem;
        int yer = 35, yer2 = 35, yer3 = 35;
        private void button1_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            alt = Convert.ToInt32(numericUpDown1.Value);
            krt = Convert.ToInt32(numericUpDown2.Value);
            if (alt == 0 || krt == 0)
            {
                MessageBox.Show("Alternatif ya da kriter değerlerini 0(sıfır) olamaz.Lütfen değerleri kontrol ederek yeniden giriniz...  ");
            }
            else
            {
                Topsis topsis = new Topsis();
                topsis.Show();
                GroupBox grupbox = topsis.Controls["groupBox1"] as GroupBox;
                GroupBox grupbox1 = topsis.Controls["groupBox2"] as GroupBox;
                for (int i = 0; i <= krt; i++)
                {
                    for (int j = 0; j <= alt; j++)
                    {
                        ekle[j, i] = new TextBox();
                        ekle[j, i].Name = "textBox" + j + i;
                        ekle[j, i].Location = new Point((i) * yer, (j + 1) * 23);
                        ekle[j, i].Size = new Size(35, 21);
                        grupbox1.Controls.Add(ekle[j, i]);
                    }
                    yer = 36;
                }
                ekle[0, 0].Visible = false;
                for (int i = 0; i < alt; i++)
                {
                    ekle[i + 1, 0].Text = altname[i];
                    ekle[i + 1, 0].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    ekle[0, i + 1].Text = krtname[i];
                    ekle[0, i + 1].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        wekle[i] = new TextBox();
                        wekle[i].Name = "textBox" + i;
                        wekle[i].Location = new Point((i + 1) * yer2, (j + 1) * 33);
                        wekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(wekle[i]);
                    }
                    yer2 = 36;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            alt = Convert.ToInt32(numericUpDown1.Value);
            krt = Convert.ToInt32(numericUpDown2.Value);
            if (alt == 0 || krt == 0)
            {
                MessageBox.Show("Alternatif ya da kriter değerlerini 0(sıfır) olamaz. Lütfen değerleri kontrol ederek yeniden giriniz... ");
            }
            else
            {
                Moora_Oran mooraoran = new Moora_Oran();
                mooraoran.Show();
                GroupBox grupbox = mooraoran.Controls["groupBox1"] as GroupBox;
                GroupBox grupbox1 = mooraoran.Controls["groupBox2"] as GroupBox;
                for (int i = 0; i <= krt; i++)
                {
                    for (int j = 0; j <= alt; j++)
                    {
                        ekle[j, i] = new TextBox();
                        ekle[j, i].Name = "textBox" + j + i;
                        ekle[j, i].Location = new Point((i) * yer, (j + 1) * 23);
                        ekle[j, i].Size = new Size(35, 21);
                        grupbox1.Controls.Add(ekle[j, i]);
                    }
                    yer = 36;
                }
                ekle[0, 0].Visible = false;
                for (int i = 0; i < alt; i++)
                {
                    ekle[i + 1, 0].Text = altname[i];
                    ekle[i + 1, 0].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    ekle[0, i + 1].Text = krtname[i];
                    ekle[0, i + 1].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        wekle[i] = new TextBox();
                        wekle[i].Name = "textBox" + i;
                        wekle[i].Location = new Point((i + 1) * yer2, (j + 1) * 33);
                        wekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(wekle[i]);
                    }
                    yer2 = 36;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            alt = Convert.ToInt32(numericUpDown1.Value);
            problem = textBox1.Text;
            if (alt == 0)
            {
                MessageBox.Show("Alternatif değeri 0(sıfır) olamaz. Lütfen değeri kontrol ederek yeniden giriniz... ");
            }
            else
            {
                Alternatif alternatif = new Alternatif();
                alternatif.Show();
                GroupBox grupbox = alternatif.Controls["groupBox1"] as GroupBox;
                for (int i = 0; i < alt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        altekle[i] = new TextBox();
                        altekle[i].Name = "textBox" + i;
                        altekle[i].Location = new Point((i) * yer2, (j + 1) * 33);
                        altekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(altekle[i]);
                    }
                    yer2 = 36;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            krt = Convert.ToInt32(numericUpDown2.Value);
            if (krt == 0)
            {
                MessageBox.Show("Kriter değeri 0(sıfır) olamaz. Lütfen değeri kontrol ederek yeniden giriniz... ");
            }
            else
            {
                Kriter kriter = new Kriter();
                kriter.Show();
                GroupBox grupbox = kriter.Controls["groupBox1"] as GroupBox;
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        krtekle[i] = new TextBox();
                        krtekle[i].Name = "textBox" + i;
                        krtekle[i].Location = new Point((i) * yer2, (j + 1) * 33);
                        krtekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(krtekle[i]);
                    }
                    yer2 = 36;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            alt = Convert.ToInt32(numericUpDown1.Value);
            krt = Convert.ToInt32(numericUpDown2.Value);
            if (alt == 0 || krt == 0)
            {
                MessageBox.Show("Alternatif ya da kriter değerlerini 0(sıfır) olamaz. Lütfen değerleri kontrol ederek yeniden giriniz... ");
            }
            else
            {
                Moora_Referans moorareferans = new Moora_Referans();
                moorareferans.Show();
                GroupBox grupbox = moorareferans.Controls["groupBox1"] as GroupBox;
                GroupBox grupbox1 = moorareferans.Controls["groupBox2"] as GroupBox;
                for (int i = 0; i <= krt; i++)
                {
                    for (int j = 0; j <= alt; j++)
                    {
                        ekle[j, i] = new TextBox();
                        ekle[j, i].Name = "textBox" + j + i;
                        ekle[j, i].Location = new Point((i) * yer, (j + 1) * 23);
                        ekle[j, i].Size = new Size(35, 21);
                        grupbox1.Controls.Add(ekle[j, i]);
                    }
                    yer = 36;
                }
                ekle[0, 0].Visible = false;
                for (int i = 0; i < alt; i++)
                {
                    ekle[i + 1, 0].Text = altname[i];
                    ekle[i + 1, 0].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    ekle[0, i + 1].Text = krtname[i];
                    ekle[0,i + 1].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        wekle[i] = new TextBox();
                        wekle[i].Name = "textBox" + i;
                        wekle[i].Location = new Point((i + 1) * yer2, (j + 1) * 33);
                        wekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(wekle[i]);
                    }
                    yer2 = 36;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            problem = textBox1.Text;
            alt = Convert.ToInt32(numericUpDown1.Value);
            krt = Convert.ToInt32(numericUpDown2.Value);
            if (alt == 0 || krt == 0)
            {
                MessageBox.Show("Alternatif ya da kriter değerlerini 0(sıfır) olamaz. Lütfen değerleri kontrol ederek yeniden giriniz... ");
            }
            else
            {
                Gra gra = new Gra();
                gra.Show();
                GroupBox grupbox = gra.Controls["groupBox1"] as GroupBox;
                GroupBox grupbox1 = gra.Controls["groupBox2"] as GroupBox;
                GroupBox grupbox2 = gra.Controls["groupBox3"] as GroupBox;
                for (int i = 0; i <= krt; i++)
                {
                    for (int j = 0; j <= alt; j++)
                    {
                        ekle[j, i] = new TextBox();
                        ekle[j, i].Name = "textBox" + j + i;
                        ekle[j, i].Location = new Point((i) * yer, (j + 1) * 23);
                        ekle[j, i].Size = new Size(35, 21);
                        grupbox1.Controls.Add(ekle[j, i]);
                    }
                    yer = 36;
                }
                ekle[0, 0].Visible = false;
                for (int i = 0; i < alt; i++)
                {
                    ekle[i + 1, 0].Text = altname[i];
                    ekle[i + 1, 0].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    ekle[0, i + 1].Text = krtname[i];
                    ekle[0,i + 1].ReadOnly = true;
                }
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        wekle[i] = new TextBox();
                        wekle[i].Name = "textBox" + i;
                        wekle[i].Location = new Point((i + 1) * yer2, (j + 1) * 23);
                        wekle[i].Size = new Size(35, 21);
                        grupbox.Controls.Add(wekle[i]);
                    }
                    yer2 = 36;
                }
                for (int i = 0; i < krt; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        wekle2[i] = new TextBox();
                        wekle2[i].Name = "textBox" + i;
                        wekle2[i].Location = new Point((i + 1) * yer3, (j + 1) * 23);
                        wekle2[i].Size = new Size(35, 21);
                        grupbox2.Controls.Add(wekle2[i]);
                    }
                    yer3 = 36;
                }
            }
        }
    }
}