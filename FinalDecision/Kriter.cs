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
    public partial class Kriter : Form
    {
        public Kriter()
        {
            InitializeComponent();
        }
        private void Kriter_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.problem;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] krtekle = Form1.krtekle;
            string[] krtname = Form1.krtname;
            double krt = Form1.krt;
            for (int i = 0; i < krt; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    krtname[i] = (krtekle[i].Text);
                }
            }
            bool bayrak = false;
            for (int i = 0; i < krt; i++)
            {
                if (krtekle[i].Text == "")
                {
                    bayrak =true;
                }
                else
                {
                    bayrak = false;
                }
            }
            if (bayrak==false)
            {
                MessageBox.Show("Kriter İsimleri Başarıyla Eklenmiştir...");
                this.Close();
            }
            else
                MessageBox.Show(" Lütfen Kriter İsimlerini Eksiksiz Bir Şekilde Yazınız...");
        }
    }
}
