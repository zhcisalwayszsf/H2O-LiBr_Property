using System;
using System.Windows.Forms;

namespace LiBr
{
    public partial class Form1 : Form
    {

        double n1 = 1167.0521452767;
        double n2 = -724213.16703206;
        double n3 = -17.073846940092;
        double n4 = 12020.82470247;
        double n5 = -3232555.0322333;
        double n6 = 14.91510861353;
        double n7 = -4823.2657361591;
        double n8 = 405113.40542057;
        double n9 = -0.23855557567849;
        double n10 = 650.17534844798;

        public Form1()
        {
            InitializeComponent();
        }

        //用饱和压力，浓度算饱和温度
        private double aConculateT_WP(double w, double p)
        {
            double t;
            double t1;

            double b = Math.Pow(p / 1000, 0.25);

            double E = Math.Pow(b, 2) + n3 * b + n6;
            double F = n1 * Math.Pow(b, 2) + n4 * b + n7;
            double G = n2 * Math.Pow(b, 2) + n5 * b + n8;
            double D = 2 * G / (-F - Math.Pow(Math.Pow(F, 2) - 4 * E * G, 0.5));
            t1 = (n10 + D - Math.Pow(Math.Pow(n10 + D, 2) - 4 * (n9 + n10 * D), 0.5)) / 2 - 273;
            double a0 = 140.877;
            double a1 = -8.55749;
            double a2 = 0.16709;

            double a3 = -8.82641 * Math.Pow(10, -4);
            double b0 = 0.770033;
            double b1 = 1.45454 * Math.Pow(10, -2);
            double b2 = -2.63906 * Math.Pow(10, -4);
            double b3 = 2.27609 * Math.Pow(10, -6);
            t = a0 + a1 * (w * 100) + a2 * Math.Pow(w * 100, 2) + a3 * Math.Pow(w * 100, 3) + t1 * (b0 + b1 * (w * 100) + b2 * Math.Pow(w * 100, 2) + b3 * Math.Pow(w * 100, 3));
            return t;
        }

        //用饱和压力，温度算浓度
        private double aConculateW_PT(double p, double t)
        {
            double w;
            double t1;
            double b = Math.Pow(p / 1000, 0.25);
            double E = Math.Pow(b, 2) + n3 * b + n6;
            double F = n1 * Math.Pow(b, 2) + n4 * b + n7;
            double G = n2 * Math.Pow(b, 2) + n5 * b + n8;
            double D = 2 * G / (-F - Math.Pow(Math.Pow(F, 2) - 4 * E * G, 0.5));
            t1 = (n10 + D - Math.Pow(Math.Pow(n10 + D, 2) - 4 * (n9 + n10 * D), 0.5)) / 2 - 273;
            double A0 = 0.31057;

            double A1 = -1.282 * Math.Pow(10, -2);
            double A2 = -1.7312 * Math.Pow(10, -4);
            double A3 = 5.3303 * Math.Pow(10, -7);
            double B0 = 1.232 * Math.Pow(10, -2);
            double B1 = 3.846 * Math.Pow(10, -4);
            double B2 = -7.1457 * Math.Pow(10, -8);
            double B3 = -5.73 * Math.Pow(10, -9);
            double C0 = -1.9166 * Math.Pow(10, -4);
            double C1 = -3.334 * Math.Pow(10, -6);
            double C2 = 5.3123 * Math.Pow(10, -8);
            double C3 = -3.6012 * Math.Pow(10, -10);
            double C4 = 1.0257 * Math.Pow(10, -12);
            double D0 = 1.6386 * Math.Pow(10, -6);
            double D1 = -2.16 * Math.Pow(10, -8);
            double D2 = 1.505 * Math.Pow(10, -10);
            double D3 = -4.678 * Math.Pow(10, -13);

            w = A0 + A1 * t1 + A2 * Math.Pow(t1, 2) + A3 * Math.Pow(t1, 3) + t * (B0 + B1 * t1 + B2 * Math.Pow(t1, 2) + B3 * Math.Pow(t1, 3)) + Math.Pow(t, 2) * (C0 + C1 * t1 + C2 * Math.Pow(t1, 2) + C3 * Math.Pow(t1, 3) + C4 * Math.Pow(t1, 4)) + Math.Pow(t, 3) * (D0 + D1 * t1 + D2 * Math.Pow(t1, 2) + D3 * Math.Pow(t1, 3));
            return w;
        }

        private double bConculateF_TWH(double t, double w, double h)
        {
            double f;
            double a0 = -571.17715;
            double a1 = 7507.234;
            double a2 = -23006.7518;
            double a3 = 28037.3668;
            double a4 = -11610.75;
            double b0 = 4.07;
            double b1 = -5.123;
            double b2 = 2.297;
            double c0 = 0.000496;
            double c1 = 0.003145;
            double c2 = -0.00469;

            double d0 = -3.996 * Math.Pow(10, -6);
            double d1 = 1.46183 * Math.Pow(10, -6);
            double d2 = 4.189 * Math.Pow(10, -6);
            f = a0 * Math.Pow(w, 0) + a1 * w + a2 * Math.Pow(w, 2) + a3 * Math.Pow(w, 3) + a4 * Math.Pow(w, 4) + t * (b0 * Math.Pow(w, 0) + b1 * Math.Pow(w, 1) + b2 * Math.Pow(w, 2)) + Math.Pow(t, 2) * (c0 * Math.Pow(w, 0) + c1 * Math.Pow(w, 1) + c2 * Math.Pow(w, 2)) + Math.Pow(t, 3) * (d0 * Math.Pow(w, 0) + d1 * Math.Pow(w, 1) + d2 * Math.Pow(w, 2)) - h;
            return f;
        }

        //用浓度，温度算比焓
        private double bConculateH_WT(double w, double t)
        {
            double h;
            double a0 = -571.17715;
            double a1 = 7507.234;
            double a2 = -23006.7518;
            double a3 = 28037.3668;
            double a4 = -11610.75;
            double b0 = 4.07;
            double b1 = -5.123;
            double b2 = 2.297;
            double c0 = 0.000496;
            double c1 = 0.003145;
            double c2 = -0.00469;

            double d0 = -3.996 * Math.Pow(10, -6);
            double d1 = 1.46183 * Math.Pow(10, -6);
            double d2 = 4.189 * Math.Pow(10, -6);
            h = a0 * Math.Pow(w, 0) + a1 * w + a2 * Math.Pow(w, 2) + a3 * Math.Pow(w, 3) + a4 * Math.Pow(w, 4) + t * (b0 * Math.Pow(w, 0) + b1 * Math.Pow(w, 1) + b2 * Math.Pow(w, 2)) + Math.Pow(t, 2) * (c0 * Math.Pow(w, 0) + c1 * Math.Pow(w, 1) + c2 * Math.Pow(w, 2)) + Math.Pow(t, 3) * (d0 * Math.Pow(w, 0) + d1 * Math.Pow(w, 1) + d2 * Math.Pow(w, 2));

            return h;
            // t - 溴化锂水溶液温度,℃
            // w - 溴化锂水溶液浓度,1; 使用范围w = 0.4 - 0.65；t = 0 - 160
        }

        //用浓度，压力算密度
        private double bConculateM_WT(double w, double t)
        {
            double m;
            double a0 = 1.637442;

            double a1 = -2.725975 * Math.Pow(10, -3);
            double a2 = 1.358832 * Math.Pow(10, -3);
            double a3 = -1.319372 * Math.Pow(10, -4);
            double a4 = -3.747908 * Math.Pow(10, -2);
            double a5 = -1.078937 * Math.Pow(10, -3);
            double a6 = 5.379461 * Math.Pow(10, -3);
            m = (a0 + a1 * t + a2 * Math.Pow(t, 1.2) + a3 * Math.Pow(t, 1.5) + a4 * w + a5 * Math.Pow(w, 1.2) + a6 * Math.Pow(w, 1.5)) * 1000;

            // m - libr溶液的密度，kg / L
            // t - 溶液的温度，℃
            //w - libr溶液的浓度，%
            return m;
        }

        //计算结晶温度
        private double cConculateT_W(double w)
        {
            double t;
            t = -99431.6 + 640904.8 * w - 1554210.1 * Math.Pow(w, 2) + 1679810.5 * Math.Pow(w, 3) - 682200.4 * Math.Pow(w, 4);
            return t;
        }


        //确保输入
        private void NoInputMessage()
        {
            string Message = "请正确输入数据";
            string Caption = "提示";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(Message, Caption, buttons, icon);

        }

        //确保选择了计算模式
        private void NoSelectionMessage()
        {
            string Message = "请选择计算模式";
            string Caption = "提示";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(Message, Caption, buttons, icon);
        }

        //输入框只能输入数字0-9和退格以及小数点和delete。
        private void OnlyNumbles(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back | e.KeyChar == 46 | e.KeyChar == (char)Keys.Delete)  // 检查输入的字符是否退格，delete或者小数点
            {
                e.Handled = false;
            }
            else
            {
                // 检查输入的字符是否为数字（0-9）
                char[] digits = e.KeyChar.ToString().ToCharArray();
                foreach (char digit in digits)
                {
                    if (!Char.IsDigit(digit))
                    {
                        e.Handled = true; // 不是数字，不处理输入
                        break;
                    }
                    e.Handled = false; // 是数字，处理输入
                }
            }
        }

        private void ConculateButton2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case (0):
                    if (textBoxW.Text == string.Empty | textBoxP.Text == string.Empty)
                    {
                        NoInputMessage();
                        break;
                    }
                    else
                    {
                        resultBox1.Text = aConculateT_WP(Double.Parse(textBoxW.Text), Double.Parse(textBoxP.Text)).ToString();
                        label10.Text = "℃";
                        break;
                    }
                case (1):
                    if (textBoxP.Text == string.Empty | textBoxT.Text == string.Empty)
                    {
                        NoInputMessage();
                        break;
                    }
                    else
                    {
                        resultBox1.Text = aConculateW_PT(Double.Parse(textBoxP.Text), Double.Parse(textBoxT.Text)).ToString();
                        label10.Text = "";
                        break;
                    }
                default:
                    NoSelectionMessage();
                    break;
            }
        }

        private void ConculateButton_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case (0):
                    if (textBoxW2.Text == string.Empty | textBoxT2.Text == string.Empty | textBoxH.Text == string.Empty)
                    {
                        NoInputMessage();
                        break;
                    }
                    else
                    {
                        resultBox2.Text = bConculateF_TWH(Double.Parse(textBoxT2.Text), Double.Parse(textBoxW2.Text), Double.Parse(textBoxH.Text)).ToString();
                        label17.Text = "";
                        break;
                    }
                case (1):
                    if (textBoxW2.Text == string.Empty | textBoxT2.Text == string.Empty)
                    {
                        NoInputMessage();
                        break;
                    }
                    else
                    {
                        resultBox2.Text = bConculateH_WT(Double.Parse(textBoxW2.Text), Double.Parse(textBoxT2.Text)).ToString();
                        label17.Text = "kJ/kg";
                        break;
                    }
                case (2):
                    if (textBoxW2.Text == string.Empty | textBoxT2.Text == string.Empty)
                    {
                        NoInputMessage();
                        break;
                    }
                    else
                    {
                        resultBox2.Text = bConculateM_WT(Double.Parse(textBoxW2.Text), Double.Parse(textBoxT2.Text)).ToString();
                        label17.Text = "kg/m3";
                        break;
                    }
                default:
                    NoSelectionMessage();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxW3.Text == string.Empty)
            {
                NoInputMessage();
            }
            else
            {
                resultBox3.Text = cConculateT_W(Double.Parse(textBoxW3.Text)).ToString();
                label20.Text = "℃";
            }
        }
    }
}

