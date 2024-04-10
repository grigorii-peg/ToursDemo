using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tours.Context.Models;
using Tours.Context;

namespace Tours
{
    public partial class TourView : UserControl
    {
        public Tour tour { get; set; }
        public event Action<Tour> AddToOrder;

        public TourView(Tour tour)
        {
            InitializeComponent();
            this.tour = tour;
            InitialComponent(tour);
        }

        private void InitialComponent(Tour tour)
        {
            labelTitle.Text = tour.Title;
            labelActual.Text = tour.IsActual ? "Актуален" : "Не актуален";
            labelActual.ForeColor = tour.IsActual ? Color.Green : Color.Red;
            labelPrice.Text = $"{tour.Price} руб.";
            labelCount.Text = $"Билетов {tour.TicketCount}";
            if (tour.ImagePreview != null)
            {
                var image = Image.FromStream(new MemoryStream(tour.ImagePreview));
                pictureBoxImage.Image = image;
            }
            buttonEdit.Enabled = buttonReview.Enabled = !WorkToUser.CompareRole(Context.Enum.Role.Quest)
                && !WorkToUser.CompareRole(Context.Enum.Role.Client);
        }

        private void buttonReview_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var image = File.ReadAllBytes(openFileDialog1.FileName);
                using (var db = new ToursContext())
                {
                    tour.ImagePreview = image;
                    db.Entry(tour).State = EntityState.Modified;
                    db.SaveChanges();
                }
                pictureBoxImage.Image = Image.FromStream(new MemoryStream(tour.ImagePreview));
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new ToursContext())
            {
                var tour1 = db.Tours.FirstOrDefault(x => x.Id == tour.Id);
                var form = new EditTour(tour1);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var ids = form.GetCheckedTypes();
                    tour1.Types.Clear();
                    tour1.Types = db.TypeTours.Where(x => ids.Contains(x.Id)).ToList();
                    db.SaveChanges();
                    InitialComponent(tour1);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tour.IsActual)
            {
                AddToOrder?.Invoke(tour);
            }
        }
    }
}
