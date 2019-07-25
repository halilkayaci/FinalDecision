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
    public partial class MooraReferansNorm : Form
    {
        public MooraReferansNorm()
        {
            InitializeComponent();
        }
        Label[] lbl;
        public static double[] sonuc = new double[50];
        private void button1_Click(object sender, EventArgs e)
        {
            Form normgrnt = new Form();
            normgrnt.Show();
            normgrnt.AutoSize = true;
            normgrnt.Text = "MOORA(Referans Noktası Metodu) - Norm Matris";
            double[,] normmtrs = Moora_Referans.normmtrs;
            double alt = Form1.alt;
            double krt = Form1.krt;
            lbl = new Label[50];
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    lbl[i] = new Label()
                    {
                        Name = "lbl" + (i + 1),
                        Text = normmtrs[j, i].ToString(),
                        AutoSize = true,
                        Visible = true,
                        Location = new Point((i + 1) * 50, (j + 1) * 60),
                    };
                    normgrnt.Controls.Add(lbl[i]);
                }
            }        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form sonucgrnt = new Form();
            sonucgrnt.Show();
            sonucgrnt.AutoSize = true;
            sonucgrnt.Text = "MOORA(Referans Noktası Metodu) - Sonuç";
            double alt = Form1.alt;
            double krt = Form1.krt;
            double[,] normmtrs = Moora_Referans.normmtrs;
            double[] sonuccp = new double[50];
            double[] deger = new double[50];
            lbl = new Label[50];
            for (int i = 0; i < alt; i++)
            {
                sonuc[i] = normmtrs[i, 0];
                for (int j = 0; j < krt; j++)
                {
                    if (sonuc[i] < normmtrs[i, j])
                    {
                        sonuc[i] = Math.Round(normmtrs[i, j], 4);
                    }
                }
            }
            for (int i = 0; i < sonuc.Length; i++)
            {
                sonuccp[i] = sonuc[i];
            }
            string[] altname = Form1.altname;
            for (int i = 0; i < alt; i++)
            {
                lbl[i] = new Label()
                {
                    Name = "lbl" + (i + 1),
                    Text = altname[i] + "\t ---> " + sonuc[i].ToString(),
                    AutoSize = true,
                    Visible = true,
                    Location = new Point(1 * 30, (i +2) * 50),
                };
                sonucgrnt.Controls.Add(lbl[i]);
            }
            double gecici;
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (sonuc[j] > sonuc[i])
                    {
                        gecici = sonuc[i];
                        sonuc[i] = sonuc[j];
                        sonuc[j] = gecici;
                    }
                    deger[i] = (i + 1);
                }
            }
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (sonuc[j] == sonuccp[i])
                    {
                        lbl[i] = new Label()
                        {
                            Name = "lbl" + (i + 1),
                            Text = "--->" + "  " + deger[j].ToString(),
                            AutoSize = true,
                            Visible = true,
                            Location = new Point(5* 30, (i + 2) * 50),
                        };
                    }
                    sonucgrnt.Controls.Add(lbl[i]);
                }
            }
        }
        private void MooraReferansNorm_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.problem;
        }
    }
}