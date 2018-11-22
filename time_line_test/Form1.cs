using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_line_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            //int kol = 0;

            int dur_proj = Convert.ToInt32(textBox1.Text);
            int coef = Convert.ToInt32(textBox2.Text);
            int step = coef * dur_proj;
            int v_pech = Convert.ToInt32(textBox3.Text);
            //double res1 = Convert.ToInt32(textBox4.Text);
            double cost_res1 = Convert.ToInt32(textBox5.Text);

            Graphics g = pictureBox1.CreateGraphics();

            int z = 0;
            //if (step <= 20 && step >= 15)
            //  z = 50;

            //if (step <= 14 && step >= 10)
            //  z = 80;

            //if (step <= 9 && step >= 6)
            //  z = 100;
            //if (step <= 5 && step >= 2)
            //  z = 200;
            z = 100;


            g.DrawLine(new Pen(Color.Gray, 2), new Point(10, 30), new Point((step*z)+10, 30));
            g.DrawLine(new Pen(Color.Gray, 2), new Point(10, 180), new Point((step*z)+10, 180));

            //int k = z;
            int x = 10;
            int a1 = 10;
            //int a2 = a1+ k;
            for (int i = 0; i <= step; i++)
            {
                
                //int k = 1010 / step;
                g.DrawLine(new Pen(Color.Gray, 2), new Point(a1, 30), new Point(a1, 180));
                //x = x + (1010 / step)-2;
                a1 = a1 + z;
            }
            //g.DrawLine(new Pen(Color.Gray, 2), new Point(x - 9, 30), new Point(x - 9, 180));


            double cost_res2 = Convert.ToInt32(textBox7.Text);

            int kol = print_res(step, v_pech, Convert.ToInt32(textBox4.Text), dur_proj, coef, 30, new Pen(Color.Red, 5));
            label6.Text = Convert.ToString(kol);
            label7.Text = Convert.ToString(kol * cost_res1);

            int kol2 = print_res(step, v_pech, Convert.ToInt32(textBox6.Text), dur_proj, coef, 60, new Pen(Color.Green, 5));
            label10.Text = Convert.ToString(kol2);
            label11.Text = Convert.ToString(kol2 * cost_res2);

            int kol3 = print_res(step, v_pech, Convert.ToInt32(textBox8.Text), dur_proj, coef, 90, new Pen(Color.Blue, 5));
            label13.Text = Convert.ToString(kol3);
            label14.Text = Convert.ToString(kol3 * cost_res2);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int print_res(int step, int v_pech, double res, int dur_proj, int coef, int smeshenie, Pen p)
        {
            Graphics g = pictureBox1.CreateGraphics();

            double pixel = 0;
            pixel = (1000 / step);
            pixel = (pixel / v_pech);
            double pix_for_one_del = 0;
            pix_for_one_del = res * pixel;
            int check = 0;
            if (pix_for_one_del % 2 != 0) check = 1;
            pix_for_one_del = Math.Round(pix_for_one_del);

            int x = 10;
            int a1 = 10;
            int a2 = Convert.ToInt32(pix_for_one_del)+10;
            int kol = 0;
            double cur_res = 0;
            while (cur_res < dur_proj * v_pech)
            {
                g.DrawLine(p, new Point(a1 , 30+smeshenie), new Point((a2), 30+smeshenie));
                g.DrawLine(p, new Point((x) *coef, 25+smeshenie), new Point((x) * coef, 40+smeshenie));
                a1 = a2 * coef;
                //a2 = a2 + Convert.ToInt32(pix_for_one_del);
                if (check > 0)
                check++;
                if (check % 2 == 0)
                {
                    x = x + Convert.ToInt32(pix_for_one_del) + 1;
                    a2 = a2 + Convert.ToInt32(pix_for_one_del) + 1;

                }
                else
                {
                    x = x + Convert.ToInt32(pix_for_one_del);
                    a2 = a2 + Convert.ToInt32(pix_for_one_del);
                }
                cur_res = cur_res + res;
                kol++;
            }

            return kol;
        }

    }
}
