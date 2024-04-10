using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tours
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tssLblStatus.Text = $"{WorkToUser.User.LastName} {WorkToUser.User.FirstName} {WorkToUser.User.Patronymic}";
            tsmiBtnHotels.Enabled = !WorkToUser.CompareRole(Context.Enum.Role.Meneger);
            tsmiBtnOrders.Enabled = !WorkToUser.CompareRole(Context.Enum.Role.Quest) &&
                !WorkToUser.CompareRole(Context.Enum.Role.Client);
        }

        private void tsmiBtnTours_Click(object sender, EventArgs e)
        {
            var form = new TourForm();

            form.ShowDialog();
        }

        private void tsmiBtnHotels_Click(object sender, EventArgs e)
        {
            var form = new HotelForm();

            form.ShowDialog();

        }

        private void tsmiBtnOrders_Click(object sender, EventArgs e)
        {
            var form = new OrderGrid();

            form.ShowDialog();

        }
    }
}
