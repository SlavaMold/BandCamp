using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Structural;
using System;
using System.Windows.Forms;

namespace BandCamp.UI
{
    public partial class ConcertForm : UserControl
    {
        private readonly BandManagerFacade _facade;
        private Concert _selectedConcert;

        public ConcertForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadBands();
            LoadConcerts();
        }

        private void LoadBands()
        {
            cboBand.Items.Clear();
            foreach (var b in _facade.GetAllBands())
                cboBand.Items.Add(b);
        }

        private void LoadConcerts()
        {
            listConcerts.Items.Clear();
            foreach (var c in _facade.GetAllConcerts())
                listConcerts.Items.Add(c);
            ClearFields();
        }

        private void listConcerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listConcerts.SelectedItem is Concert c)
            {
                _selectedConcert = c;
                txtName.Text = c.Name;
                txtResponsible.Text = c.ResponsiblePerson;
                nudPayment.Value = c.Payment;
                dtpDate.Value = c.Date;
                txtComment.Text = c.Comment;

                foreach (Band b in cboBand.Items)
                {
                    if (b.Id == c.BandId)
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
                MessageBox.Show("Укажите название концерта", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var band = (Band)cboBand.SelectedItem;

            _facade.CreateConcert(
                txtName.Text.Trim(),
                band.Id,
                band.Name,
                dtpDate.Value,
                txtResponsible.Text.Trim(),
                nudPayment.Value,
                txtComment.Text.Trim());

            MessageBox.Show("Концерт сохранён!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadConcerts();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedConcert = null;
            listConcerts.ClearSelected();
            ClearFields();
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedConcert == null) return;

            var result = MessageBox.Show(
                $"Удалить концерт «{_selectedConcert.Name}»?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var cmd = new DeleteConcertCommand(_facade, _selectedConcert);
                CommandManager.Instance.Execute(cmd);
                _selectedConcert = null;
                LoadConcerts();
                (ParentForm as MainForm)?.UpdateUndoRedoButtons();
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtResponsible.Text = "";
            nudPayment.Value = 0;
            dtpDate.Value = DateTime.Today;
            txtComment.Text = "";
            cboBand.SelectedIndex = -1;
            _selectedConcert = null;
        }

        public void RefreshList() => LoadConcerts();
    }
}