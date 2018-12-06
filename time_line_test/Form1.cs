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
            chart3.ChartAreas[0].AxisY.CustomLabels.Clear();
            chart3.Series.Clear();
            int step_month = 0;
            int numb_month = comboBox1.SelectedIndex;
            for (int i = 1; i <= kol; i++)
            {
                chart3.Series.Add(i.ToString());
                chart3.Series[i - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                chart3.Series[i - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
                chart3.Series[i - 1].Color = Color.Blue;
                chart3.Series[i - 1].BackSecondaryColor = Color.LightSkyBlue;
                chart3.Series[i - 1].BorderColor = Color.Black;
                chart3.Series[i - 1].BorderWidth = 2;
                //chart3.Series[i - 1].Points.AddXY("Картридж", Convert.ToInt32(textBox4.Text));
                //chart3.Series[i - 1].Points.AddXY("Барабан", Convert.ToInt32(textBox6.Text));
                //chart3.Series[i - 1].Points.AddXY("Печка", Convert.ToInt32(textBox8.Text));

                //chart3.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                chart3.ChartAreas[0].AxisY.Interval = Convert.ToInt32(textBox3.Text);
                //chart3.ChartAreas[0].AxisY.CustomLabels.Add(step_month, (step_month + Convert.ToInt32(textBox3.Text)), Convert.ToString(comboBox1.Items[numb_month]));
                //step_month = step_month + Convert.ToInt32(textBox3.Text);

                if (numb_month < 11)
                    numb_month++;
                else
                    numb_month = numb_month - 11;
            }




            for (int i1 = 1; i1 <= kol; i1++)
            {
                try
                {
                    chart3.Series.Add(i1.ToString());
                    chart3.Series[i1 - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                    chart3.Series[i1 - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
                    chart3.Series[i1 - 1].Color = Color.Red;
                    chart3.Series[i1 - 1].BackSecondaryColor = Color.LightSkyBlue;
                    chart3.Series[i1 - 1].BorderColor = Color.Black;
                    chart3.Series[i1 - 1].BorderWidth = 2;

                    chart3.Series[i1 - 1].Points.AddXY("Картридж", Convert.ToInt32(textBox4.Text));

                }
                catch
                { }


            }






            for (int i2 = 1; i2 <= kol2; i2++)
            {
                try
                {
                    chart3.Series.Add(i2.ToString());
                    chart3.Series[i2 - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                    chart3.Series[i2 - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
                    chart3.Series[i2 - 1].Color = Color.Blue;
                    chart3.Series[i2 - 1].BackSecondaryColor = Color.LightSkyBlue;
                    chart3.Series[i2 - 1].BorderColor = Color.Black;
                    chart3.Series[i2 - 1].BorderWidth = 2;

                    chart3.Series[i2 - 1].Points.AddXY("Барабан", Convert.ToInt32(textBox6.Text));

                }
                catch
                { }


            }

            for (int i3 = 1; i3 <= kol3; i3++)
            {
                try
                {
                    chart3.Series.Add(i3.ToString());
                    chart3.Series[i3 - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                    chart3.Series[i3 - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
                    chart3.Series[i3 - 1].Color = Color.Green;
                    chart3.Series[i3 - 1].BackSecondaryColor = Color.LightSkyBlue;
                    chart3.Series[i3 - 1].BorderColor = Color.Black;
                    chart3.Series[i3 - 1].BorderWidth = 2;

                    chart3.Series[i3 - 1].Points.AddXY("Печка", Convert.ToInt32(textBox8.Text));

                }
                catch
                { }

            }






            //chart3.ChartAreas[1].AxisY.CustomLabels.Clear();
            //chart3.Series.Clear();
            //step_month = 0;
            //numb_month = comboBox1.SelectedIndex;
            //for (int i = 1; i <= kol; i++)
            //{
            //    chart3.Series.Add(i.ToString());
            //    chart3.Series[i - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            //    chart3.Series[i - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            //    chart3.Series[i - 1].Color = Color.Blue;
            //    chart3.Series[i - 1].BackSecondaryColor = Color.LightSkyBlue;
            //    chart3.Series[i - 1].BorderColor = Color.Black;
            //    chart3.Series[i - 1].BorderWidth = 2;
            //    chart3.Series[i - 1].Points.AddXY("Барабан", Convert.ToInt32(textBox4.Text));
            //    //chart3.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //    chart3.ChartAreas[1].AxisY.Interval = Convert.ToInt32(textBox3.Text);
            //    chart3.ChartAreas[1].AxisY.CustomLabels.Add(step_month, (step_month + Convert.ToInt32(textBox3.Text)), Convert.ToString(comboBox1.Items[numb_month]));
            //    step_month = step_month + Convert.ToInt32(textBox3.Text);

            //    if (numb_month < 11)
            //        numb_month++;
            //    else
            //        numb_month = numb_month - 11;
            //}





            //chart3.ChartAreas[0].AxisY.CustomLabels.Clear();
            //chart3.Series.Clear();
            //step_month = 0;
            //numb_month = comboBox1.SelectedIndex;
            //for (int i = 1; i <= kol; i++)
            //{
            //    chart3.Series.Add(i.ToString());
            //    chart3.Series[i - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            //    chart3.Series[i - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            //    chart3.Series[i - 1].Color = Color.Blue;
            //    chart3.Series[i - 1].BackSecondaryColor = Color.LightSkyBlue;
            //    chart3.Series[i - 1].BorderColor = Color.Black;
            //    chart3.Series[i - 1].BorderWidth = 2;
            //    chart3.Series[i - 1].Points.AddXY("Картридж", Convert.ToInt32(textBox4.Text));
            //    //chart3.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //    chart3.ChartAreas[0].AxisY.Interval = Convert.ToInt32(textBox3.Text);
            //    chart3.ChartAreas[0].AxisY.CustomLabels.Add(step_month, (step_month + Convert.ToInt32(textBox3.Text)), Convert.ToString(comboBox1.Items[numb_month]));
            //    step_month = step_month + Convert.ToInt32(textBox3.Text);

            //    if (numb_month < 11)
            //        numb_month++;
            //    else
            //        numb_month = numb_month - 11;
            //}









        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            
            //var dp = new DataPoint(8D, 12D);
            //dp.Color = Color.Red;
            //dp.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            //var series = this.chart1.Series[0];
            //series.Points.Add(dp);



            ////int new_res = 0;
            //for (int i = 1; i <= 5; i++)
            //{
            //    //new_res = new_res + Convert.ToInt32(textBox4.Text);
            //    chart3.Series.Add(i.ToString());
            //    chart3.Series[i - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            //    chart3.Series[i - 1].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            //    chart3.Series[i - 1].Color = Color.Blue;
            //    chart3.Series[i - 1].BackSecondaryColor = Color.LightSkyBlue;
            //    chart3.Series[i - 1].BorderColor = Color.Black;
            //    chart3.Series[i - 1].BorderWidth = 2;
            //    chart3.Series[i-1].Points.AddXY("res1", Convert.ToInt32(textBox4.Text));
            //}
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
            //double[] nums2 = new double[12];
            int dur_proj = Convert.ToInt32(comboBox2.Text);
            int v_pech = Convert.ToInt32(textBox3.Text);
            //double res1 = Convert.ToInt32(textBox4.Text);
            //double cost_res1 = Convert.ToInt32(textBox5.Text);

            int numb_month = 0;
            numb_month = comboBox1.SelectedIndex;
            double ostatok = 0;
            for (int i = 0; i < dur_proj; i++)
            {
                double qty_for_one_month = ((v_pech - ostatok) / res);
                //listBox1.Items.Add(i + " month= " + Math.Ceiling(qty_for_one_month));
                nums[i] = Math.Ceiling(qty_for_one_month);

                ostatok = ((Math.Ceiling(qty_for_one_month) - qty_for_one_month) * res);



                chart1.Series[j].Points.AddXY(comboBox1.Items[numb_month], Math.Ceiling(qty_for_one_month) * cost_res);

                //chart1.Series[j].Points.AddY(Math.Ceiling(qty_for_one_month) * cost_res, comboBox1.Items[i]);

                //chart2.Series[j].Points.AddY(Math.Ceiling(qty_for_one_month));

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
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();

            

            graph(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), 0, nums1);
            graph(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), 1, nums2);
            graph(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), 2, nums3);

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
