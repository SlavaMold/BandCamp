using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Structural;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BandCamp.UI
{
    public partial class MemberForm : UserControl
    {
        private readonly BandManagerFacade _facade;
        private Member _selectedMember;
        private string _selectedPhotoPath;

        public MemberForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadMembers();
        }

        private void LoadMembers()
        {
            listMembers.Items.Clear();
            var members = _facade.GetAllMembers();
            foreach (var m in members)
                listMembers.Items.Add(m);
            ClearFields();
        }

        private void listMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMembers.SelectedItem is Member m)
            {
                _selectedMember = _facade.GetMember(m.Id);
                txtFirstName.Text = _selectedMember.FirstName;
                txtLastName.Text = _selectedMember.LastName;
                txtRole.Text = _selectedMember.Role;
                nudExperience.Value = _selectedMember.ExperienceYears;
                dtpJoinDate.Value = _selectedMember.JoinDate;
                chkIsActive.Checked = _selectedMember.IsActive;
                _selectedPhotoPath = _selectedMember.PhotoPath;

                IMemberImage proxy = new MemberImageProxy(_selectedPhotoPath);
                try { picPhoto.Image = proxy.GetPhoto(); }
                catch { picPhoto.Image = null; }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var member = _selectedMember ?? new Member();
            member.FirstName = txtFirstName.Text.Trim();
            member.LastName = txtLastName.Text.Trim();
            member.Role = txtRole.Text.Trim();
            member.ExperienceYears = (int)nudExperience.Value;
            member.JoinDate = dtpJoinDate.Value;
            member.IsActive = chkIsActive.Checked;
            member.PhotoPath = _selectedPhotoPath ?? "";

            string error = _facade.SaveMember(member, 0);
            if (error != null)
            {
                MessageBox.Show(error, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Участник сохранён!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadMembers();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedMember = null;
            listMembers.ClearSelected();
            ClearFields();
            txtFirstName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMember == null) return;

            var result = MessageBox.Show(
                $"Удалить участника «{_selectedMember.FullName}»?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var cmd = new DeleteMemberCommand(_facade, _selectedMember);
                CommandManager.Instance.Execute(cmd);
                _selectedMember = null;
                LoadMembers();
                (ParentForm as MainForm)?.UpdateUndoRedoButtons();
            }
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
                    try { picPhoto.Image = proxy.GetPhoto(); }
                    catch { MessageBox.Show("Не удалось загрузить изображение"); }
                }
            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRole.Text = "";
            nudExperience.Value = 0;
            dtpJoinDate.Value = DateTime.Today;
            chkIsActive.Checked = true;
            picPhoto.Image = null;
            _selectedPhotoPath = null;
        }

        public void RefreshList() => LoadMembers();
    }
}