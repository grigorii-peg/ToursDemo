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
    public partial class EditTour : Form
    {
        public Tour Tour { get; set; }

        public EditTour()
        {
            InitializeComponent();
            comboBoxCountry.DisplayMember = nameof(Country.Name);
            checkedListBox1.DisplayMember = nameof(TypeTour.Name);
            Tour = new Tour();
            Initialize();
        }

        public EditTour(Tour tour) : this()
        {
            this.Text = "Изменить";
            Tour = tour;
            textBoxTitle.Text = Tour.Title;
            numericUpDownCountTicket.Value = Tour.TicketCount;
            numericUpDownPrice.Value = Tour.Price;

            var ids = Tour.Types.Select(x => x.Id).ToList();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (ids.Contains(((TypeTour)checkedListBox1.Items[i]).Id))
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }

            comboBoxCountry.SelectedItem = comboBoxCountry.Items.Cast<Country>()
                .FirstOrDefault(x => x.Code == Tour.CountryCode);
        }

        private void Initialize()
        {
            using (var db = new ToursContext())
            {
                comboBoxCountry.Items.AddRange(db.Countries.AsNoTracking().ToArray());
                comboBoxCountry.SelectedIndex = 0;
                checkedListBox1.Items.AddRange(db.TypeTours.AsNoTracking().ToArray());
            }
        }

        private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            buttonSave.Enabled = !string.IsNullOrWhiteSpace(textBoxTitle.Text);
        }

        public List<int> GetCheckedTypes()
            => checkedListBox1.CheckedItems.Cast<TypeTour>().Select(x => x.Id).ToList();

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            Tour.Title = textBoxTitle.Text;
            Tour.Description = "";
            Tour.CountryCode = ((Country)comboBoxCountry.SelectedItem).Code;
            Tour.TicketCount = (int)numericUpDownCountTicket.Value;
            Tour.IsActual = true;
            Tour.Price = numericUpDownPrice.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
