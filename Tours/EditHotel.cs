using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tours.Context.Models;
using Tours.Context;

namespace Tours
{
    public partial class EditHotel : Form
    {
        public Hotel Hotel { get; set; }
        public EditHotel()
        {
            InitializeComponent();
            Hotel = new Hotel();
            Init();
        }

        public EditHotel(Hotel hotel) : this()
        {
            Hotel = hotel;
            textBoxTitle.Text = hotel.Title;
            textBoxDescription.Text = hotel.Description;
            numericUpDown1.Value = Hotel.CountOfStars;
            comboBox1.SelectedItem = comboBox1.Items.Cast<Country>()
                .FirstOrDefault(x => x.Code == Hotel.CountryCode);

        }

        private void Init()
        {
            using (var db = new ToursContext())
            {
                comboBox1.Items.AddRange(db.Countries.AsNoTracking().ToArray());
                comboBox1.SelectedIndex = 0;
            }
        }

        private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            buttonSave.Enabled = !string.IsNullOrWhiteSpace(textBoxTitle.Text)
                && !string.IsNullOrWhiteSpace(textBoxDescription.Text);
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            Hotel.Title = textBoxTitle.Text;
            Hotel.Description = textBoxDescription.Text;
            Hotel.CountOfStars = (int)numericUpDown1.Value;
            Hotel.CountryCode = ((Country)comboBox1.SelectedItem).Code;
            DialogResult = DialogResult.OK;
        }
    }
}
