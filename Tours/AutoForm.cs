using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tours.Context;
using Tours.Context.Enum;
using Tours.Context.Models;

namespace Tours
{
    public partial class AutoForm : Form
    {
        public AutoForm()
        {
            InitializeComponent();
        }

        private void btnEnterGuest_Click(object sender, EventArgs e)
        {
            WorkToUser.User = new User
            {
                LastName = string.Empty,
                FirstName = "Неавторизованный гость",
                Patronymic = string.Empty,
                Role = Role.Quest
            };
            var form = new MainForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnEnter.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text)
                && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            using (var db = new ToursContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPassword.Text);

                if (user == null)
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль!");
                    txtPassword.Clear();
                }
                else
                {
                    WorkToUser.User = user;
                    var form = new MainForm();
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                }
            }
        }
    }
}
