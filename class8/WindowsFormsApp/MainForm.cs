using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        delegate IEnumerable<Order> Search(string x);
        OrderService os = new OrderService();
        Search search;
        static public Merchandise Beef { get; } = new Merchandise("菲力牛排", 128.88);
        static public Merchandise Chocolate { get; } = new Merchandise("豆腐巧克力", 15);
        static public Merchandise Toy { get; } = new Merchandise("小大疆无人机", 999.99);


        public MainForm()
        {
            InitializeComponent();
            SearchTypeCBX.SelectedIndex = 3;
        }

        private void SearchTypeCBX_Load(object sender, EventArgs e)
        {
            SearchTypeCBX.Items.Add("商品");
            SearchTypeCBX.Items.Add("时间");
            SearchTypeCBX.Items.Add("买家");
            SearchTypeCBX.Items.Add("全部");
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string info = SearchDetailtxt.Text;
            var od = search(info);
            List<Order> ol = new List<Order>();
            foreach (var i in od)
            {
                ol.Add(i);
            }
            if (ol.Count == 0)
                MessageBox.Show("查找为空");
            orderBindingSource.Clear();
            orderBindingSource.DataSource = ol;
        }

        private void SearchTypeCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchTypeCBX.Text == "商品")
            {
                search = new Search(os.FindMerchandise);
            }
            else if (SearchTypeCBX.Text == "时间")
            {
                search = new Search(os.FindTime);
            }
            else if (SearchTypeCBX.Text == "买家")
            {
                search = new Search(os.FindBuyer);
            }
            else
            {
                search = new Search(os.FindAll);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ClientInfoForm a = new ClientInfoForm(os);
            a.Show(this);
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string file = dialog.FileName;
                if (os.Import(file)) MessageBox.Show("导入成功");
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                if(os.Export(foldPath)) MessageBox.Show("导出成功");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            os.DeleteOrder(order);
            SearchBtn_Click(sender, e);//重新显示当前查询状态更新后的数据
        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            ModifyOrderForm a = new ModifyOrderForm(os, order);
            a.Show(this);
        }
    }
}
