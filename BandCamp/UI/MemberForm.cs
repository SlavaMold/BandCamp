using System.Windows.Forms;
using BandCamp.Patterns.Structural;

namespace BandCamp.UI
{
    public partial class MemberForm : UserControl
    {
        public MemberForm(BandManagerFacade facade)
        {
            InitializeComponent();
        }
    }
}