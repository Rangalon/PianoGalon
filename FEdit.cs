using System.Windows.Forms;

namespace PianoGalon
{
    public partial class FEdit : Form
    {
        public FEdit(object o)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = o;
        }
    }
}
