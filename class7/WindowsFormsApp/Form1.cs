using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Caylay : Form
    {
        //初始化默认数据
        private Graphics graphics1, graphics2;
        double th1 = 30;//右分支角度
        double th2 = 20;//左分支角度
        double per1 = 0.6;//右分支比
        double per2 = 0.7;//左分支比
        int depth = 10;//递归深度默认10
        int length = 100;//主干长度默认100
        Pen color;//画笔颜色
        int num = 0;//第几块画板

        /// <summary>
        /// 初始化，设置默认画笔颜色为蓝色
        /// </summary>
        public Caylay()
        {
            InitializeComponent();
            PenColor.SelectedIndex = 0;
        }
        /// <summary>
        /// 设置参数，包括：
        /// 画笔颜色，递归深度，左右分支角度、倍率，主干长度
        /// </summary>
        private void ArgumentsChecked()
        {
            double temp;
            graphics1 = drawBoard1.CreateGraphics();
            graphics2 = drawBoard2.CreateGraphics();
            if (textBox1.Text != "") depth = Convert.ToInt32(textBox1.Text);//确定递归深度
            if (textBox2.Text != "") length = Convert.ToInt32(textBox2.Text);//确定主干长度
            if (textBox3.Text != "")
            {
                double.TryParse(textBox3.Text.Trim(), out temp);
                if (temp > 0 && temp < 1)
                    per2 = temp;
                else
                    throw new Exception("Left ratio not legal.");
            }//确定左分支长度比
            if (textBox4.Text != "")
            {
                double.TryParse(textBox4.Text.Trim(), out temp);
                if (temp > 0 && temp < 1)
                    per1 = temp;
                else
                    throw new Exception("Right ratio not legal.");
            }//确定右分支长度比
            if (textBox5.Text != "")
            {
                double.TryParse(textBox5.Text.Trim(), out temp);
                if (temp > 0 && temp < 180)
                    th2 = temp;
                else
                    throw new Exception("Left angle not legal.");
            }//确定左分支角度
            if (textBox6.Text != "")
            {
                double.TryParse(textBox6.Text.Trim(), out temp);
                if (temp > 0 && temp < 180)
                    th1 = temp;
                else
                    throw new Exception("Right angle not legal.");
            }//确定右分支角度
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            ArgumentsChecked();
            //清空画图界面
            if (num % 2 == 0) graphics1.Clear(drawBoard1.BackColor);
            else graphics2.Clear(drawBoard2.BackColor);
            drawCayleyTree(depth, 250, 350, length, -Math.PI / 2);
            //MessageBox.Show("Color is " + PenColor.Text
            //    + "\nDepth is " + depth
            //    + "\nLength is " + length
            //    + "\nLeft ratio is " + per2
            //    + "\nRight ratio is " + per1
            //    + "\nLeft angle is " + th2
            //    + "\nRight angle is " + th1, "提示");
            string text = "Color is " + PenColor.Text
                + "\nDepth is " + depth
                + "\nLength is " + length
                + "\nLeft ratio is " + per2
                + "\nRight ratio is " + per1
                + "\nLeft angle is " + th2
                + "\nRight angle is " + th1;
            if (num % 2 == 0) showArg1.Text = text;
            else showArg2.Text = text;
            num++;
        }
        void drawCayleyTree(int n, double xO, double yO, double leng, double th)
        {
            if (n == 0) return;
            double xl = xO + leng * Math.Cos(th); double yl = yO + leng * Math.Sin(th);
            drawLine(xO, yO, xl, yl);
            drawCayleyTree(n - 1, xl, yl, per1 * leng, th + th1 * Math.PI / 180);
            drawCayleyTree(n - 1, xl, yl, per2 * leng, th - th2 * Math.PI / 180);
        }
        /// <summary>
        /// 从(x0,y0)到(x1,y1)的直线的绘制
        /// </summary>
        /// <param name="xO"></param>
        /// <param name="yO"></param>
        /// <param name="xl"></param>
        /// <param name="yl"></param>
        void drawLine(double xO, double yO, double xl, double yl)
        {
            if (PenColor.Text == "红色") color = Pens.Red;
            else if (PenColor.Text == "绿色") color = Pens.Green;
            else color = Pens.Blue; //默认蓝色
            if (num % 2 == 0)
                graphics1.DrawLine(color, (int)xO, (int)yO, (int)xl, (int)yl);
            else
                graphics2.DrawLine(color, (int)xO, (int)yO, (int)xl, (int)yl);
        }
        /// <summary>
        /// 设置可选画笔颜色
        /// 目前可选红绿蓝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PenColor.Items.Contains("蓝色")) PenColor.Items.Add("蓝色");
            if (!PenColor.Items.Contains("红色")) PenColor.Items.Add("红色");
            if (!PenColor.Items.Contains("绿色")) PenColor.Items.Add("绿色");
        }
    }
}
