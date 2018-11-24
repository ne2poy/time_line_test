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

            label17.Text = textBox1.Text;


            int dur_proj = Convert.ToInt32(textBox1.Text);
            int coef = Convert.ToInt32(textBox2.Text);
            int step = coef * dur_proj;
            int v_pech = Convert.ToInt32(textBox3.Text);
            //double res1 = Convert.ToInt32(textBox4.Text);
            double cost_res1 = Convert.ToInt32(textBox5.Text);

            Graphics g = pictureBox1.CreateGraphics();

            int z = 0;
            if (dur_proj == 12)
              z = 100;

            if (dur_proj == 24)
                z = 50;
            if (dur_proj == 36)
                z = 34;


            int test = dur_proj * v_pech;



            g.DrawLine(new Pen(Color.Gray, 1), new Point(10, 30), new Point((step*z)+10, 30));
            g.DrawLine(new Pen(Color.Gray, 1), new Point(10, 180), new Point((step*z)+10, 180));

            //int k = z;
            int x = 10;
            int a1 = 10;
            //int a2 = a1+ k;
            for (int i = 0; i <= step; i++)
            {
                
                //int k = 1010 / step;
                g.DrawLine(new Pen(Color.Gray, 1), new Point(a1, 30), new Point(a1, 180));
                //x = x + (1010 / step)-2;
                a1 = a1 + z;
            }
            //g.DrawLine(new Pen(Color.Gray, 2), new Point(x - 9, 30), new Point(x - 9, 180));


            double cost_res2 = Convert.ToInt32(textBox7.Text);

            int kol = print_res(step, v_pech, Convert.ToInt32(textBox4.Text), dur_proj, coef, 30, new Pen(Color.Red, 4), z, test);
            label6.Text = Convert.ToString(kol);
            label7.Text = Convert.ToString(kol * cost_res1);

            int kol2 = print_res(step, v_pech, Convert.ToInt32(textBox6.Text), dur_proj, coef, 60, new Pen(Color.Green, 4), z, test);
            label10.Text = Convert.ToString(kol2);
            label11.Text = Convert.ToString(kol2 * cost_res2);

            int kol3 = print_res(step, v_pech, Convert.ToInt32(textBox8.Text), dur_proj, coef, 90, new Pen(Color.Blue, 4), z, test);
            label13.Text = Convert.ToString(kol3);
            label14.Text = Convert.ToString(kol3 * cost_res2);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int print_res(int step, int v_pech, int res, int dur_proj, int coef, int smeshenie, Pen p, int z, int test)
        {
            Graphics g = pictureBox1.CreateGraphics();

            //double pixel = 0;
            //pixel = (1000 / step);
            //pixel = (pixel / v_pech);
            //double pix_for_one_del = 0;
            //pix_for_one_del = res * pixel;
            //int check = 0;

            double copy_in_one_pix = v_pech / z;

            int new_kol = test / res; 

            //if (pix_for_one_del % 2 != 0) check = 1;
            //pix_for_one_del = Math.Round(pix_for_one_del);

            int x = 10;
            int a1 = 10;
            //int a2 = Convert.ToInt32(pix_for_one_del)+10;
            int step1 = Convert.ToInt32(res / copy_in_one_pix);
            int a2 = Convert.ToInt32(res / copy_in_one_pix)+10;
            int kol = 0;
            double cur_res = 0;
            //while (a2 <= ((dur_proj * v_pech)/copy_in_one_pix)+10)
            for (int i = 0; i < new_kol; i++)
            {
                g.DrawLine(p, new Point(a1 , 30+smeshenie), new Point((a2), 30+smeshenie));
                g.DrawLine(p, new Point((a1), 25+smeshenie), new Point((a1), 40+smeshenie));
                a1 = a2;
                //a2 = a2 + Convert.ToInt32(pix_for_one_del);
                //if (check > 0)
                //check++;
                //if (check % 2 == 0)
                {
                //    x = x + Convert.ToInt32(pix_for_one_del) + 1;
                  //  a2 = a2 + Convert.ToInt32(step1) + 1;

                }
                //else
                //{
                    //x = x + Convert.ToInt32(pix_for_one_del);
                    a2 = a2 + Convert.ToInt32(step1);
                //}
                cur_res = cur_res + res;
                kol++;
            }

            return new_kol;
        }


        void graph (int res, int cost_res, int j, double[] nums)
        {
            //double[] nums2 = new double[12];
            int dur_proj = Convert.ToInt32(textBox1.Text);
            int v_pech = Convert.ToInt32(textBox3.Text);
            //double res1 = Convert.ToInt32(textBox4.Text);
            //double cost_res1 = Convert.ToInt32(textBox5.Text);

            double ostatok = 0;
            for (int i = 0; i < dur_proj; i++)
            {
                double qty_for_one_month = ((v_pech - ostatok) / res);
                //listBox1.Items.Add(i + " month= " + Math.Ceiling(qty_for_one_month));
                nums[i] = Math.Ceiling(qty_for_one_month);

                ostatok = ((Math.Ceiling(qty_for_one_month) - qty_for_one_month) * res);

                
                chart1.Series[j].Points.AddY(Math.Ceiling(qty_for_one_month) * cost_res);

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dur_proj = Convert.ToInt32(textBox1.Text);

            double[] nums1 = new double[dur_proj];
            double[] nums2 = new double[dur_proj];
            double[] nums3 = new double[dur_proj];
            listBox1.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();



            graph(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), 0, nums1);
            graph(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), 1, nums2);
            graph(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), 2, nums3);


            for (int i = 0; i < dur_proj; i++)
            {
                double summa = nums1[i] * Convert.ToInt32(textBox5.Text) +
                                nums2[i] * Convert.ToInt32(textBox7.Text) +
                                nums3[i] * Convert.ToInt32(textBox9.Text);
                listBox1.Items.Add(i+1 + " month= " + nums1[i]* Convert.ToInt32(textBox5.Text) + " + " + nums2[i]* Convert.ToInt32(textBox7.Text) + " + " + nums3[i]* Convert.ToInt32(textBox9.Text) + " = " + summa);
                //nums[i] = Math.Ceiling(qty_for_one_month);
            }



                //for (int i = 0; i < dur_proj; i++)
                {
                    //  chart1.Series[0].Points.AddY(Math.Ceiling(qty_for_one_month) * cost_res1);
                }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
