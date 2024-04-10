using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Windows.Forms;
using Tours.Context;
using Tours.Context.Models;

namespace Tours
{
    public partial class OrderGrid : Form
    {
        public OrderGrid()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            comboBox1.SelectedIndex = 0;
            using (var db = new ToursContext())
            {
                dataGridView1.DataSource = db.Orders.Include(x => x.Tours).Include(x => x.User).ToList();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ColumnOrder")
            {
                var tours = (List<Tour>)e.Value;
                var sb = new StringBuilder();

                foreach (var item in tours)
                {
                    sb.Append($"{item.Title} ");
                }

                e.Value = sb.ToString();
            }
        }

        private void Filter(bool isOrder)
        {
            List<Order> orders;

            using (var db = new ToursContext())
            {
                orders = db.Orders.Include(x => x.Tours).Include(x => x.User).ToList();
            }

            if (isOrder)
            {
                orders = orders.OrderBy(x => x.Price).ToList();
            }

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    orders = orders.Where(x => x.AllSale <= 10).ToList();
                    break;
                case 2:
                    orders = orders.Where(x => x.AllSale > 10 && x.AllSale <= 14).ToList();
                    break;
                case 3:
                    orders = orders.Where(x => x.AllSale > 14).ToList();
                    break;
                default:
                    break;
            }

            dataGridView1.DataSource = orders;
        }

        private void btnOrder_Click(object sender, System.EventArgs e)
        {
            Filter(true);
        }

        private void btnDownUp_Click(object sender, System.EventArgs e)
        {
            Filter(false);
        }
    }
}
