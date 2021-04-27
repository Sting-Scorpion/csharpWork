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
    public partial class ModifyOrderForm : Form
    {
        OrderService os = new OrderService();
        Order order = new Order();
        Client c = new Client();

        public ModifyOrderForm(OrderService os, Order order)
        {
            InitializeComponent();
            this.os = os;
            this.order = order;
        }

        private void ComfirmBtn_Click(object sender, EventArgs e)
        {
            c = new Client(NameTXT.Text, addressTXT.Text);
            os.ModifyOrder(order, c);
            this.Close();
        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
