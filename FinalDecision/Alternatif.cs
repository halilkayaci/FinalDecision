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
    public partial class Alternatif : Form
    {
        public Alternatif()
        {
            InitializeComponent();
        }
        private void Alternatif_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.problem;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] altekle = Form1.altekle;
            string[] altname = Form1.altname;
            double alt = Form1.alt;
            for (int i = 0; i < alt; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    altname[i] = (altekle[i].Text);
                }
            }
            bool bayrak = false;
            for (int i = 0; i < alt; i++)
            {
                if (altekle[i].Text == "")
                {
                    bayrak = true;
                }
                else
                {
                    bayrak = false;
                }
            }
            if (bayrak == false)
            {
                MessageBox.Show("Alternatif İsimleri Başarıyla Eklenmiştir...");
                this.Close();
            }
            else
                MessageBox.Show("Lütfen Alternatif İsimlerini Eksiksiz Bir Şekilde Yazınız...");
        }
    }
}
