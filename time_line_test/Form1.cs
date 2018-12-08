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

            int numb_month2 = comboBox1.SelectedIndex;
            label12.Text = Convert.ToString(comboBox1.Items[numb_month2]);
            //label17.Text = Convert.ToString(comboBox1.Items[numb_month2]);

            if (numb_month2 <= 0)
                label17.Text = Convert.ToString(comboBox1.Items[numb_month2 + 11]);
            else
                label17.Text = Convert.ToString(comboBox1.Items[numb_month2 - 1]);



            int dur_proj = Convert.ToInt32(comboBox2.Text);
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
            g.DrawLine(new Pen(Color.Gray, 1), new Point(10, 150), new Point((step*z)+10, 150));

            //int k = z;
            int x = 10;
            int a1 = 10;
            //int a2 = a1+ k;
            for (int i = 0; i <= step; i++)
            {
                
                //int k = 1010 / step;
                g.DrawLine(new Pen(Color.Gray, 1), new Point(a1, 30), new Point(a1, 150));
                //x = x + (1010 / step)-2;
                a1 = a1 + z;

                if (i == step)
                {
                    //label17.Location = new Point(a1, 19);
                    //label17.Visible = true;
                    //this.Controls.Add(label17);
                    
                }
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





















            //-----------------------------------------------------------------------------------------------------------------
            chart3.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart3.Series.Clear();
            int step_month = 0;
            int numb_month = comboBox1.SelectedIndex;

            chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 1000;
            chart3.ChartAreas[0].AxisX.Minimum = 0;

            int step_line = 0;

            int qty_items = dataGridView2.RowCount-1;
            int qty_series = 0;

            int position = 0;


            for (int i = 0; i < qty_items; i++)
            {
                qty_series = qty_series + Convert.ToInt32(dataGridView2[2, i].Value);
            }




            step_line = 0;
            //int i2 = 2;
            for (int j = 0; j <= qty_series; j++)
            {
                chart3.Series.Add(j.ToString());
                chart3.Series[j].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart3.Series[j].Color = Color.Blue;
                chart3.Series[j].BorderWidth = 2;
                chart3.Series[j].IsVisibleInLegend = false;

                chart3.ChartAreas[0].AxisX.CustomLabels.Add(step_month, (step_month + Convert.ToInt32(textBox3.Text)), Convert.ToString(comboBox1.Items[numb_month]));
                step_month = step_month + Convert.ToInt32(textBox3.Text);

                if (numb_month < 11)
                    numb_month++;
                else
                    numb_month = numb_month - 11;

            }





            int k = 0;

                for (int j = 0; j < qty_series;)
                {
                    int plus_step = Convert.ToInt32(dataGridView2[1, k].Value);

                    position = position + 5;
                    step_line = 0;
                    for (int i = 0; i < Convert.ToInt32(dataGridView2[2, k].Value); i++)
                    {
                        chart3.ChartAreas[0].AxisY.CustomLabels.Add(position - 2, position + 2, dataGridView2[0, k].Value.ToString());

                        chart3.Series[j].Color = Color.Red;         //tyt perechislenie colors i vinesti eto za cikle
                        chart3.Series[j].Points.AddXY(step_line, position - 2);
                        chart3.Series[j].Points.AddXY(step_line, position + 2);

                        chart3.Series[j].Points.AddXY(step_line, position);
                        chart3.Series[j].Points.AddXY(step_line + plus_step, position);

                        step_line = step_line + plus_step;
                        j++;
                    }

                    k++;

                }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            
        }

        int print_res(int step, int v_pech, int res, int dur_proj, int coef, int smeshenie, Pen p, int z, int test)
        {
            Graphics g = pictureBox1.CreateGraphics();

            //double pixel = 0;
            //pixel = ((z*dur_proj) / step);
            //pixel = (pixel / v_pech);
            //double pix_for_one_del = 0;
            //pix_for_one_del = res * pixel;
            int check = 0;

            double copy_in_one_pix = v_pech / z;

            double new_kol1 = (Convert.ToDouble(test) / Convert.ToDouble(res) );
            int new_kol = Convert.ToInt32(Math.Ceiling(new_kol1));

            //if (pix_for_one_del % 2 != 0) check = 1;
            //pix_for_one_del = Math.Round(pix_for_one_del);

            int x = 10;
            int a1 = 10;
            //int a2 = Convert.ToInt32(pix_for_one_del)+10;
            //double step1_1 = res / copy_in_one_pix;


            double proverka1 = (res / copy_in_one_pix);
            if ( (proverka1 - Math.Floor(proverka1)) > 0)
                check=1;


            int step1 = Convert.ToInt32(res / copy_in_one_pix);

            //double proverka = ((step * z) / step1);

            double proverka2 = ((step * z) / Convert.ToDouble(step1));
            if ((proverka2 % 2) > 0)
                check=1;


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
                if (check > 0)
                check++;
                if (check % 2 == 0)
                {
                //    x = x + Convert.ToInt32(pix_for_one_del) + 1;
                    a2 = a2 + Convert.ToInt32(step1);

                }
                else
                //{
                    //x = x + Convert.ToInt32(pix_for_one_del);
                    a2 = a2 + Convert.ToInt32(step1) +1;
                //}
                cur_res = cur_res + res;
                kol++;
            }

            return new_kol;
        }


        void graph (int res, int cost_res, int j, double[] nums)
        {
            int dur_proj = Convert.ToInt32(comboBox2.Text);
            int v_pech = Convert.ToInt32(textBox3.Text);
            int numb_month = comboBox1.SelectedIndex;
            double ostatok = 0;

            chart1.Series.Add(dataGridView2[0, j].Value.ToString());
            chart2.Series.Add(dataGridView2[0, j].Value.ToString());


            for (int i = 0; i < dur_proj; i++)
            {
                double qty_for_one_month = ((v_pech - ostatok) / res);
                nums[i] = Math.Ceiling(qty_for_one_month);

                ostatok = ((Math.Ceiling(qty_for_one_month) - qty_for_one_month) * res);


                chart1.Series[j].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[j].Points.AddXY(comboBox1.Items[numb_month], Math.Ceiling(qty_for_one_month) * cost_res);

                //chart2.Series.Add(j.ToString());
                chart2.Series[j].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart2.Series[j].Points.AddXY(comboBox1.Items[numb_month], Math.Ceiling(qty_for_one_month));

                if (numb_month <11)
                numb_month++;
                else
                    numb_month = numb_month -11;

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numb_month1 = comboBox1.SelectedIndex;


            int dur_proj = Convert.ToInt32(comboBox2.Text);

            double[] nums1 = new double[dur_proj];
            double[] nums2 = new double[dur_proj];
            double[] nums3 = new double[dur_proj];
            listBox1.Items.Clear();

            chart1.Series.Clear();
            chart2.Series.Clear();

            //chart1.Series[0].Points.Clear();
            //chart1.Series[1].Points.Clear();
            //chart1.Series[2].Points.Clear();

            //chart2.Series[0].Points.Clear();
            //chart2.Series[1].Points.Clear();
            //chart2.Series[2].Points.Clear();

            int qty_items = dataGridView2.RowCount - 1;


            for (int i = 0; i < qty_items; i++)
            {
                graph(Convert.ToInt32(dataGridView2[2, i].Value), Convert.ToInt32(dataGridView2[3, i].Value), i, nums1);

                //graph(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), 0, nums1);
                //graph(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), 1, nums2);
                //graph(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), 2, nums3);

            }
            double z1 = 0, z2 = 0, z3 = 0, z4 = 0, z5 = 0, z6 = 0, z7 = 0, z8 = 0, z9 = 0;
            for (int i = 0; i < dur_proj; i++)
            {
                double kol_vo = nums1[i] + nums2[i] + nums3[i];

                double summa = nums1[i] * Convert.ToInt32(textBox5.Text) +
                                nums2[i] * Convert.ToInt32(textBox7.Text) +
                                nums3[i] * Convert.ToInt32(textBox9.Text);
                listBox1.Items.Add(i+1 + "    " + comboBox1.Items[numb_month1] + " =" + "\t" + nums1[i]* Convert.ToInt32(textBox5.Text) + " + " + nums2[i]* Convert.ToInt32(textBox7.Text) + " + " + nums3[i]* Convert.ToInt32(textBox9.Text) + " = " + summa);

                listBox2.Items.Add(i + 1 + "    " + comboBox1.Items[numb_month1] + " =" + "\t" + nums1[i] + " + " + nums2[i] + " + " + nums3[i] + " = " + kol_vo);

                dataGridView1.Rows.Add(i + 1, comboBox1.Items[numb_month1], nums1[i], nums2[i], nums3[i], kol_vo, nums1[i] * Convert.ToInt32(textBox5.Text), nums2[i] * Convert.ToInt32(textBox7.Text), nums3[i] * Convert.ToInt32(textBox9.Text), summa, textBox3.Text);
                //nums[i] = Math.Ceiling(qty_for_one_month);

                z1 = z1 + nums1[i];
                z2 = z2 + nums2[i];
                z3 = z3 + nums3[i];
                z4 = z4 + kol_vo;
                z5 = z5 + nums1[i] * Convert.ToInt32(textBox5.Text);
                z6 = z6 + nums2[i] * Convert.ToInt32(textBox7.Text);
                z7 = z7 + nums3[i] * Convert.ToInt32(textBox9.Text);
                z8 = z8 + summa;
                z9 = z9 + Convert.ToDouble(textBox3.Text);

                if (numb_month1 < 11)
                    numb_month1++;
                else
                    numb_month1 = numb_month1 - 11;

            }

            dataGridView1.Rows.Add(" ", "Итог проекта", z1, z2, z3, z4, z5, z6, z7, z8, z9);
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;



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
