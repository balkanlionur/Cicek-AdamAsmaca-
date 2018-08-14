using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cicek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] btn;
        bool sifir = false;
        int harf = 65;
        int r=1,k=0,t=0,sayac=0;
        string[] kelimeler;
        string kelime;
        Label[] lDizi;
        Label[] lDizi2;
        Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void kelimesec()
        {
            kelime = kelimeler[rnd.Next(0, 4)];
            
            lDizi = new Label[kelime.Length];
            lDizi2 = new Label[kelime.Length];
            for (int i = 0; i < kelime.Length; i++)
            {           
                lDizi[i] = new Label();
                lDizi2[i] = new Label();
                
                panel2.Controls.Add(lDizi[i]);
                lDizi[i].BorderStyle = BorderStyle.Fixed3D;
                lDizi[i].Location = new Point(25 * i, 55);
                lDizi[i].Width = 25;
                lDizi[i].Text = "_";
                lDizi2[i].Text = kelime.Substring(0 + i, 1);
                
                lDizi[i].Visible = true;
                lDizi2[i].Visible = false;
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                kelimeler = new string[] { "onur", "dogan", "ali", "veli" };
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                kelimeler = new string[] { "istanbul", "izmir", "adana", "ankara" };
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                kelimeler = new string[] { "kedi", "kopek", "balik", "kus" };
            }

            if (sifir==true)
            {
                sifirla();
            }
            
            Harfler();
            kelimesec();
        }

        private void sifirla()
        {
            harf = 65;
            r = 1; k = 0; t = 0; sayac = 0;
            pictureBox1.Image = Properties.Resources.cicek1;
            for (int i = 0; i < 27; i++)
            {
                panel1.Controls.Remove(btn[i]);
            }
            for (int i = 0; i < kelime.Length; i++)
            {
                panel2.Controls.Remove(lDizi[i]);
            }
            
        }

        /// <summary>
        /// Harflerin Olustugu yer.
        /// </summary>
        private void Harfler()
        {
            sifir = true;
            btn = new Button[27];
           
            for (int i = 0; i < 3; i++)
            {
                for (int s = 0; s < 9; s++)
                {
                    
                    
                    
                    btn[k] = new Button();
                    
                    btn[k].Text = ((char)harf).ToString();
                    
                    btn[k].Size = new Size(50, 50);
                    btn[k].Location = new Point(52 * s, 50 * i);
                    panel1.Controls.Add(btn[k]);
                    harf = harf + 1;
                    btn[k].Click += Btn_Click;
                    btn[k].Visible = true;
                    if (k==26)
                    {
                        btn[k].Text = "İPUCU";
                        break;
                    }
                    k++;
                }
            }
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            
            bool d = false;
            sayac = sayac + 1;
            Button sbuton = (sender as Button);
            
            if (sbuton.Text== "İPUCU")
            {
                
                for (int i = 0; i < kelime.Length; i++)
                {
                    

                    if (lDizi[i].Text=="_")
                    {
                        sbuton.Text = lDizi2[i].Text;
                        break;
                    }
                }
                
                
            }
            for (int i = 0; i < kelime.Length; i++)
            {
                
                if (lDizi2[i].Text==sbuton.Text.ToLower())
                {
                    lDizi2[i].Visible = false;
                    lDizi[i].Text = lDizi2[i].Text;
                    d = true;
                    t = t + 1;
                }
                
                else if (sbuton.Text.ToLower()=="ı" && lDizi2[i].Text=="i")
                {
                    lDizi2[i].Visible = false;
                    lDizi[i].Text = lDizi2[i].Text.ToUpper();
                    d = true;
                    t = t + 1;
                }
                else if (sbuton.Text.ToLower() == "u" && lDizi2[i].Text == "ü")
                {
                    lDizi2[i].Visible = false;
                    lDizi[i].Text = lDizi2[i].Text;
                    d = true;
                    t = t + 1;
                }
                else if (sbuton.Text.ToLower() == "o" && lDizi2[i].Text == "ö")
                {
                    lDizi2[i].Visible = false;
                    lDizi[i].Text = lDizi2[i].Text;
                    d = true;
                    t = t + 1;
                }
                else if (sbuton.Text.ToLower() == "c" && lDizi2[i].Text == "ç")
                {
                    lDizi2[i].Visible = false;
                    lDizi[i].Text = lDizi2[i].Text;
                    d = true;
                    t = t + 1;
                }
                
                 if (t==kelime.Length)
                {
                    MessageBox.Show(sayac + " denemede bildiniz =)","Tebrikler" );
                    for (int k = 0; k < 27; k++)
                    {
                        btn[k].Enabled = false;
                    }
                    break;
                    

                }
                else if (i + 1 == kelime.Length && d == false)
                {
                    r = r + 1;
                    resim();
                    break;

                }

            }
            sbuton.Enabled = false;
        }

        private void resim()
        {
            switch (r)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.cicek1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.cicek2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.cicek3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.cicek4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.cicek5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.cicek6;
                    MessageBox.Show("Tekrar Dene","GameOver");
                    for (int k = 0; k < 27; k++)
                    {
                        btn[k].Enabled = false;
                    }
                    break;
                
            }
            
        }

        
    }
}
