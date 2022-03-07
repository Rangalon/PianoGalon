using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoGalon
{
    public partial class FProfil : Form
    {
        public FProfil(object o)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = o;
        }
    }
}
