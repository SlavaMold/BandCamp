using BandCamp.Models;
using BandCamp.Patterns.Structural;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BandCamp.UI
{
    public partial class BandForm : UserControl
    {
        private readonly BandManagerFacade _facade;
        private Band _selectedBand;
        private string _selectedPhotoPath;

        public BandForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadBands();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите фото участника";
                dlg.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _selectedPhotoPath = dlg.FileName;

                    IMemberImage proxy = new MemberImageProxy(_selectedPhotoPath);
                    picMemberPhoto.Image = proxy.GetPhoto();
                }
            }
        }

        private void LoadBands()
        {
            listBands.Items.Clear();
            var bands = _facade.GetAllBands();
            foreach (var b in bands)
                listBands.Items.Add(b);

            ClearFields();
        }

        private void listBands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBands.SelectedItem is Band band)
            {
                _selectedBand = _facade.GetBand(band.Id);
                txtName.Text = _selectedBand.Name;
                txtGenre.Text = _selectedBand.Genre;
                dtpFormation.Value = _selectedBand.FormationDate;
                txtDescription.Text = _selectedBand.Description;

                listMembers.Items.Clear();
                foreach (var m in _selectedBand.Members)
                    listMembers.Items.Add(m);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var band = _selectedBand ?? new Band();
            band.Name = txtName.Text.Trim();
            band.Genre = txtGenre.Text.Trim();
            band.FormationDate = dtpFormation.Value;
            band.Description = txtDescription.Text.Trim();

            string error = _facade.SaveBand(band);
            if (error != null)
            {
                MessageBox.Show(error, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Группа сохранена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBands();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedBand = null;
            listBands.ClearSelected();
            ClearFields();
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBand == null) return;

            var result = MessageBox.Show(
                $"Удалить группу «{_selectedBand.Name}»?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _facade.DeleteBand(_selectedBand.Id);
                _selectedBand = null;
                LoadBands();
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (_selectedBand == null) return;
            if (listMembers.SelectedItem is Member member)
            {
                _facade.RemoveMemberFromBand(member.Id, _selectedBand.Id);
                LoadBands();
                listBands.SelectedItem = listBands.Items
                    .Cast<Band>()
                    .FirstOrDefault(b => b.Id == _selectedBand.Id)
                    ?? listBands.Items[0];
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtGenre.Text = "";
            dtpFormation.Value = DateTime.Today;
            txtDescription.Text = "";
            listMembers.Items.Clear();
            picMemberPhoto.Image = null;
            _selectedPhotoPath = null;
        }

        private void BandForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_selectedBand == null)
            {
                MessageBox.Show("Сначала выберите группу");
                return;
            }

            // Показываем Bridge в действии — сначала preview
            string preview = _facade.ExportMembersPreview(_selectedBand.Id);
            MessageBox.Show(preview, "Предпросмотр экспорта");

            // Потом предлагаем сохранить CSV
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV файлы|*.csv";
                dlg.FileName = $"{_selectedBand.Name}_members.csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _facade.ExportMembersCsv(_selectedBand.Id, dlg.FileName);
                    MessageBox.Show("Файл сохранён!", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}