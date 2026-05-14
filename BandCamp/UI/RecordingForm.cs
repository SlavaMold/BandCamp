using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Structural;
using System;
using System.Windows.Forms;

namespace BandCamp.UI
{
    public partial class RecordingForm : UserControl
    {
        private readonly BandManagerFacade _facade;
        private Contract _selectedContract;

        public RecordingForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadBands();
            LoadContracts();
        }

        private void LoadBands()
        {
            cboBand.Items.Clear();
            var bands = _facade.GetAllBands();
            foreach (var b in bands)
                cboBand.Items.Add(b);
        }

        private void LoadContracts()
        {
            listContracts.Items.Clear();
            var contracts = _facade.GetRecordingContracts();
            foreach (var c in contracts)
                listContracts.Items.Add(c);
            ClearFields();
        }

        private void listContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listContracts.SelectedItem is Contract c)
            {
                _selectedContract = c;
                txtStudio.Text = c.StudioName;
                txtResponsible.Text = c.ResponsiblePerson;
                txtProduct.Text = c.ProductName;
                nudPayment.Value = c.Payment;
                dtpStart.Value = c.StartDate;
                dtpEnd.Value = c.EndDate;

                // Выбираем группу в комбобоксе
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

            if (string.IsNullOrWhiteSpace(txtStudio.Text))
            {
                MessageBox.Show("Укажите название студии", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                MessageBox.Show("Укажите название продукта", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var band = (Band)cboBand.SelectedItem;

            _facade.CreateRecordingContract(
                txtStudio.Text.Trim(),
                txtResponsible.Text.Trim(),
                dtpStart.Value,
                dtpEnd.Value,
                nudPayment.Value,
                band.Id,
                band.Name,
                txtProduct.Text.Trim());

            MessageBox.Show("Контракт сохранён!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadContracts();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedContract = null;
            listContracts.ClearSelected();
            ClearFields();
            txtStudio.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedContract == null) return;

            var result = MessageBox.Show(
                $"Удалить контракт «{_selectedContract.ProductName}»?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var cmd = new DeleteContractCommand(_facade, _selectedContract);
                CommandManager.Instance.Execute(cmd);
                _selectedContract = null;
                LoadContracts();
                (ParentForm as MainForm)?.UpdateUndoRedoButtons();
            }
        }

        private void ClearFields()
        {
            txtStudio.Text = "";
            txtResponsible.Text = "";
            txtProduct.Text = "";
            nudPayment.Value = 0;
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddMonths(1);
            cboBand.SelectedIndex = -1;
            _selectedContract = null;
        }

        private void RecordingForm_Load(object sender, EventArgs e)
        {

        }

        public void RefreshList() => LoadContracts();
    }
}