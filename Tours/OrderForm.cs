using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using Tours.Context;
using Tours.Context.Models;

namespace Tours
{
    public partial class OrderForm : Form
    {
        private Dictionary<Tour, int> Tours;
        private decimal sum = 0;
        private decimal sale = 0;

        public OrderForm(Dictionary<Tour, int> tours)
        {
            InitializeComponent();
            labelUserName.Text = $"{WorkToUser.User.LastName} {WorkToUser.User.FirstName} {WorkToUser.User.Patronymic}";
            Tours = tours;

            foreach (var item in Tours.Keys)
            {
                var orderView = new OrderView(item, Tours[item]);
                orderView.ChangeCount += UpdateSum;
                orderView.Margin = new Padding(0, 0, 0, 50);
                orderView.Parent = flowLayoutPanel1;
                orderView.Visible = true;
                sum += item.Price * Tours[item];
            }

            labelSum.Text = $"{sum}руб.";

            using (var db = new ToursContext())
            {
                comboBox1.Items.AddRange(db.ReceivingPoints.ToArray());
                comboBox1.SelectedIndex = 0;
            }
        }

        private void UpdateSum()
        {
            sum = 0;

            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (item is OrderView order)
                {
                    sum += order.Tour.Price * order.Count;

                    if (Tours.TryGetValue(order.Tour, out var count))
                    {
                        Tours[order.Tour] = order.Count;
                    }
                }
            }

            labelSum.Text = $"{sum}руб.";
        }

        private void buttonTakeOrder_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var order = new Order
            {
                OrderDate = DateTimeOffset.Now,
                AllSale = 0,
                Price = sum,
                Code = random.Next(100, 1000),
                ReceivingPointId = ((ReceivingPoint)comboBox1.SelectedItem).Id,
                DateReceipt = DateTimeOffset.Now.AddDays(3)
            };

            if (!WorkToUser.CompareRole(Context.Enum.Role.Quest))
            {
                order.UserId = WorkToUser.User.Id;
            }

            using (var db = new ToursContext())
            {
                var ids = Tours.Keys.Select(x => x.Id).ToList();
                var tours = db.Tours.Include(x => x.Country).Where(x => ids.Contains(x.Id)).ToList();
                order.Tours = tours;
                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show("Вы успешно оформили заказ!");
                this.Close();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
