using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Structural;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using static BandCamp.Patterns.Behavioral.DeleteContractCommand;

namespace BandCamp.UI
{
    public partial class TourForm : UserControl
    {
        private readonly BandManagerFacade _facade;
        private Tour _selectedTour;

        public TourForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadBands();
            LoadTours();
        }

        private void LoadBands()
        {
            cboBand.Items.Clear();
            foreach (var b in _facade.GetAllBands())
                cboBand.Items.Add(b);
        }

        public void LoadTours()
        {
            listTours.Items.Clear();
            foreach (var t in _facade.GetAllTours())
                listTours.Items.Add(t);
            ClearFields();
        }

        public void RefreshList() => LoadTours();

        private void listTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTours.SelectedItem is Tour t)
            {
                _selectedTour = t;
                txtName.Text = t.Name;
                txtCountry.Text = t.Country;
                nudBudget.Value = t.Budget;
                dtpStart.Value = t.StartDate;
                dtpEnd.Value = t.EndDate;

                foreach (Band b in cboBand.Items)
                {
                    if (b.Id == t.BandId)
                    {
                        cboBand.SelectedItem = b;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboBand.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Укажите название тура", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var band = (Band)cboBand.SelectedItem;

            // Builder вызывается внутри фасада через TourService
            string error = _facade.CreateTour(
                txtName.Text.Trim(),
                band.Id,
                band.Name,
                dtpStart.Value,
                dtpEnd.Value,
                nudBudget.Value,
                txtCountry.Text.Trim());

            if (error != null)
            {
                MessageBox.Show(error, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Тур сохранён!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTours();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedTour = null;
            listTours.ClearSelected();
            ClearFields();
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedTour == null) return;

            var result = MessageBox.Show(
                $"Удалить тур «{_selectedTour.Name}»?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var cmd = new DeleteTourCommand(_facade, _selectedTour);
                CommandManager.Instance.Execute(cmd);
                _selectedTour = null;
                LoadTours();
                (ParentForm as MainForm)?.UpdateUndoRedoButtons();
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtCountry.Text = "";
            nudBudget.Value = 0;
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddMonths(1);
            cboBand.SelectedIndex = -1;
            _selectedTour = null;
        }
    }
}