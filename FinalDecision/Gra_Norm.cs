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
    public partial class Gra_Norm : Form
    {
        public Gra_Norm()
        {
            InitializeComponent();
        }
        Label[] lbl;
        private void button2_Click(object sender, EventArgs e)
        {
            Form mutlakgrnt = new Form();
            mutlakgrnt.Show();
            mutlakgrnt.AutoSize = true;
            mutlakgrnt.Text = "GRA - Mutlak Matris";
            double alt = Form1.alt;
            double krt = Form1.krt;
            double[,] mutlakmtrs =Gra.mutlakmtrs;
            double[,] normmtrs = Gra.normmtrs;
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    double a = normmtrs[j, i];
                    mutlakmtrs[j, i] = Math.Abs(1 - a);
                }
            }
            lbl = new Label[50];
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    lbl[i] = new Label()
                    {
                        Name = "lbl" + (i + 1),
                        Text = mutlakmtrs[j, i].ToString(),
                        AutoSize = true,
                        Visible = true,
                        Location = new Point((i + 1) * 50, (j + 1) * 60),
                    };
                    mutlakgrnt.Controls.Add(lbl[i]);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form graygrnt = new Form();
            graygrnt.Show();
            graygrnt.AutoSize = true;
            graygrnt.Text = "GRA - Gri İlişkisel Matris";
            double[,] mutlakmtrs = Gra.mutlakmtrs;
            double[,] normmtrs = Gra.normmtrs;
            double[] weight = Form1.weight;
            double alt = Form1.alt;
            double krt = Form1.krt;
            double deltamax = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (deltamax < normmtrs[j, i])
                    {
                        deltamax = normmtrs[j, i];
                    }
                }
            }
            double deltamin = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (deltamin > normmtrs[j, i])
                    {
                        deltamin = normmtrs[j, i];
                    }
                }
            }
            double grey = (deltamax - deltamin) / 2;
            double[,] greymtrs = Gra.greymtrs;
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    double d = (deltamin + (grey * deltamax)) / (mutlakmtrs[j, i] + (grey * deltamax));
                    greymtrs[j, i] = Math.Round(d, 4);
                }
            }
            lbl = new Label[50];
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    lbl[i] = new Label()
                    {
                        Name = "lbl" + (i + 1),
                        Text = greymtrs[j, i].ToString(),
                        AutoSize = true,
                        Visible = true,
                        Location = new Point((i + 1) * 50, (j + 1) * 60),
                    };
                    graygrnt.Controls.Add(lbl[i]);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form esitgrnt = new Form();
            esitgrnt.Show();
            esitgrnt.AutoSize = true;
            esitgrnt.Text = "GRA - Eşit Öneme Sahip Sonuç";
            double alt = Form1.alt;
            double krt = Form1.krt;
            lbl = new Label[50];
            double[,] greymtrs = Gra.greymtrs;
            double[] esitonem = new double[50];
            double[] esitonemcp = new double[50];
            double[] deger = new double[50];
            double[] weight = Form1.weight;
            double gecici;
            for (int i = 0; i < alt; i++)
            {
                double t = 0, top = 0, ort = 0;
                for (int j = 0; j < krt; j++)
                {
                    t = greymtrs[i, j];
                    top += t;
                }
                ort = top / krt;
                esitonem[i] = Math.Round(ort, 4);
            }
            for (int i = 0; i < esitonem.Length; i++)
            {
                esitonemcp[i] = esitonem[i];
            }
            string[] altname = Form1.altname;
            for (int i = 0; i < alt; i++)
            {
                lbl[i] = new Label()
                {
                    Name = "lbl" + (i + 1),
                    Text = altname[i] + "\t ---> " + esitonem[i].ToString(),
                    AutoSize = true,
                    Visible = true,
                    Location = new Point(1 * 30, (i + 2) * 50),
                };
                esitgrnt.Controls.Add(lbl[i]);
            }
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (esitonem[j] < esitonem[i])
                    {
                        gecici = esitonem[i];
                        esitonem[i] = esitonem[j];
                        esitonem[j] = gecici;
                    }
                    deger[i] = (i + 1);
                }
            }        
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (esitonem[j] == esitonemcp[i])
                    {
                        lbl[i] = new Label()
                        {
                            Name = "lbl" + (i + 1),
                            Text = "--->" + "  " + deger[j].ToString(),
                            AutoSize = true,
                            Visible = true,
                            Location = new Point(5 * 30, (i + 2) * 50),
                        };
                        esitgrnt.Controls.Add(lbl[i]);
                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form farkligrnt = new Form();
            farkligrnt.Show();
            farkligrnt.AutoSize = true;
            farkligrnt.Text = "GRA - Farklı Öneme Sahip Sonuç ";
            double alt = Form1.alt;
            double krt = Form1.krt;
            double[,] greymtrs = Gra.greymtrs;
            double[] weight = Form1.weight;
            double[] farklionem = new double[50];
            double[] farklionemcp = new double[50];
            double[] degerf = new double[50];
            double gecicif;
            lbl = new Label[50];
            for (int i = 0; i < alt; i++)
            {
                double carp, t, top = 0;
                for (int j = 0; j < krt; j++)
                {
                    carp = weight[j] * greymtrs[i, j];
                    t = carp; top += t;
                }
                farklionem[i] = Math.Round(top, 4);
            }
            for (int i = 0; i < alt; i++)
            {
                farklionemcp[i] = farklionem[i];
            }
            string[] altname = Form1.altname;
            for (int i = 0; i < alt; i++)
            {
                lbl[i] = new Label()
                {
                    Name = "lbl" + (i + 1),
                    Text = altname[i] + "\t ---> " + farklionem[i].ToString(),
                    AutoSize = true,
                    Visible = true,
                    Location = new Point(1 * 30, (i + 2) * 50),
                };
                farkligrnt.Controls.Add(lbl[i]);
            }
            for (int i = 0; i <alt; i++)
            {
                for (int j = 0; j <alt; j++)
                {
                    if (farklionem[j] < farklionem[i])
                    {
                        gecicif = farklionem[i];
                        farklionem[i] = farklionem[j];
                        farklionem[j] = gecicif;
                    }
                    degerf[i] = (i + 1);
                }
            }        
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < alt; j++)
                {
                    if (farklionem[j] == farklionemcp[i])
                    {
                        lbl[i] = new Label()
                        {
                            Name = "lbl" + (i + 1),
                            Text = "--->" + "  " + degerf[j].ToString(),
                            AutoSize = true,
                            Visible = true,
                            Location = new Point(5 * 30, (i +2) * 50),
                        };
                    }
                    farkligrnt.Controls.Add(lbl[i]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form normgrnt = new Form();
            normgrnt.Show();
            normgrnt.AutoSize = true;
            normgrnt.Text = "GRA - Norm Matris";
            double alt = Form1.alt;
            double krt = Form1.krt;
            double[,] normmtrs = Gra.normmtrs;
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
        private void Gra_Norm_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.problem;
        }
    }
}