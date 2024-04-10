using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using Tours.Context;
using Tours.Context.Models;
using System.Collections.Generic;

namespace Tours
{
    public partial class TourForm : Form
    {
        private int allToursSum = 0;
        private Dictionary<Tour, int> Tours = new Dictionary<Tour, int>();
        public TourForm()
        {
            InitializeComponent();
            comboBoxType.DisplayMember = nameof(TypeTour.Name);
            comboBoxType.ValueMember = nameof(TypeTour.Id);
            btnAdd.Enabled = !WorkToUser.CompareRole(Context.Enum.Role.Quest)
                && !WorkToUser.CompareRole(Context.Enum.Role.Client);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var form = new EditTour();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var db = new ToursContext())
                {
                    var ids = form.GetCheckedTypes();
                    form.Tour.Types = db.TypeTours.Where(x => ids.Contains(x.Id)).ToList();
                    db.Tours.Add(form.Tour);
                    db.SaveChanges();
                }
            }

            var tourView = new TourView(form.Tour);
            tourView.Parent = flowLayoutPanel1;
            allToursSum += (int)(tourView.tour.Price * tourView.tour.TicketCount);
            lbl123.Text = allToursSum.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            Filter();
        }

        private void TourForm_Load(object sender, System.EventArgs e)
        {
            using (var db = new ToursContext())
            {
                var types = db.TypeTours.ToArray();
                var defaultType = new TypeTour
                {
                    Id = -1,
                    Name = "Все типы"
                };

                comboBoxType.Items.AddRange(types);
                comboBoxType.Items.Insert(0, defaultType);
                comboBoxType.SelectedIndex = 0;

                var tours = db.Tours.Include(x => x.Types).Include(x => x.Country).ToList();
                allToursSum = 0;

                foreach (var item in tours)
                {
                    var tourView = new TourView(item);
                    tourView.AddToOrder += VisibleList;
                    tourView.Parent = flowLayoutPanel1;

                    allToursSum += (int)(item.Price * item.TicketCount);
                }

                lbl123.Text = allToursSum.ToString();
            }
        }

        private void VisibleList(Tour tour)
        {
            if (Tours.TryGetValue(tour, out var count))
            {
                Tours[tour] = ++count;
            }
            else
            {
                Tours.Add(tour, 1);
            }

            if (!btnOrder.Visible)
            {
                btnOrder.Visible = true;
            }
        }
        private void Filter()
        {
            if (comboBoxType.SelectedItem == null)
            {
                return;
            }

            var selectedTypeId = ((TypeTour)comboBoxType.SelectedItem).Id;
            allToursSum = 0;

            foreach (var item in flowLayoutPanel1.Controls)
            {
                var visible = true;

                if (item is TourView tourView)
                {
                    if (selectedTypeId != -1
                        && !tourView.tour.Types.Any(x => x.Id == selectedTypeId))
                    {
                        visible = false;
                    }

                    if (checkBox1.Checked && !tourView.tour.IsActual)
                    {
                        visible = false;
                    }

                    if (!string.IsNullOrWhiteSpace(txtReach.Text)
                        && !tourView.tour.Title.Contains(txtReach.Text))
                    {
                        visible = false;
                    }

                    if (visible)
                    {
                        allToursSum += (int)(tourView.tour.Price * tourView.tour.TicketCount);
                    }
                    tourView.Visible = visible;
                }
            }

            lbl123.Text = allToursSum.ToString();
        }

        private void txtReach_TextChanged(object sender, System.EventArgs e)
        {
            Filter();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Filter();
        }

        private void btnOrder_Click(object sender, System.EventArgs e)
        {
            var form = new OrderForm(Tours);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Tours.Clear();
                btnOrder.Visible = false;
            }
        }
    }
}
