using System;
using System.Drawing;
using System.Windows.Forms;
using BandCamp.Patterns.Structural;
using BandCamp.UI;

namespace BandCamp
{
    public partial class MainForm : Form
    {
        private readonly BandManagerFacade _facade;
        private UserControl _currentView;
        private Button _activeButton;

        public MainForm()
        {
            InitializeComponent();
            _facade = new BandManagerFacade();
            SetupSidebar();
            ShowView(new BandForm(_facade));
            SetActiveButton(btnNavBands);
        }

        private void SetupSidebar()
        {
            PanelSidebar.BackColor = Color.FromArgb(30, 30, 45);

            StyleNavButton(btnNavBands, "Группы");
            StyleNavButton(btnNavMembers, "Участники");
            StyleNavButton(btnNavTours, "Туры");
            StyleNavButton(btnNavConcerts, "Концерты");

            btnNavBands.Click += (s, e) => { ShowView(new BandForm(_facade)); SetActiveButton(btnNavBands); };
            btnNavMembers.Click += (s, e) => { ShowView(new MemberForm(_facade)); SetActiveButton(btnNavMembers); };
            btnNavTours.Click += (s, e) => { ShowView(new TourForm(_facade)); SetActiveButton(btnNavTours); };
            btnNavConcerts.Click += (s, e) => { MessageBox.Show("Концерты — этап 2"); };
        }

        private void StyleNavButton(Button btn, string text)
        {
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Height = 48;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.FromArgb(180, 180, 200);
            btn.BackColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 10f);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.Transparent;
                _activeButton.ForeColor = Color.FromArgb(180, 180, 200);
            }
            _activeButton = btn;
            _activeButton.BackColor = Color.FromArgb(60, 60, 90);
            _activeButton.ForeColor = Color.White;
        }

        private void ShowView(UserControl view)
        {
            panelContent.Controls.Clear();
            _currentView = view;
            _currentView.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_currentView);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Infrastructure.DatabaseConnection.Instance.Close();
        }
    }
}