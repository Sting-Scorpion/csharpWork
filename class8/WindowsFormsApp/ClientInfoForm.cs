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
    public partial class ClientInfoForm : Form
    {
        OrderService ordersevice = new OrderService();
        public ClientInfoForm(OrderService o)
        {
            InitializeComponent();
            ordersevice = o;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Client buyer = new Client(nameTXT.Text, addressTXT.Text);

            AddOrderForm a = new AddOrderForm(ordersevice, buyer);
            a.Show(this);
            this.Hide();
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
