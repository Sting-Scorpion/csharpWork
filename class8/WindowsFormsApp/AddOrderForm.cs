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
    public partial class AddOrderForm : Form
    {
        OrderService orderService = new OrderService();
        Client buyer = new Client();
        Order order = new Order();
        OrderDetails od = new OrderDetails();
        Merchandise m = new Merchandise();
        public AddOrderForm(OrderService o, Client c)
        {
            InitializeComponent();
            orderService = o;
            string no = Math.Abs(DateTime.Now.GetHashCode()).ToString();
            order = new Order(c, no);
        }

        private void MerNamecbx_Load(object sender, EventArgs e)
        {
            MerNamecbx.Items.Add("菲力牛排");
            MerNamecbx.Items.Add("豆腐巧克力");
            MerNamecbx.Items.Add("小大疆无人机");
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            if (MerNamecbx.Text == "菲力牛排")
                m = MainForm.Beef;
            else if (MerNamecbx.Text == "豆腐巧克力")
                m = MainForm.Chocolate;
            else if (MerNamecbx.Text == "小大疆无人机")
                m = MainForm.Toy;
            od = new OrderDetails(m, (int)MerNumTxt.Value);
            order.AddDetails(od);
            MerNumTxt.Value = 0;
            MerNamecbx.Text = null;
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            orderService.AddOrder(order);
            this.Close();
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
