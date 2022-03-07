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
    public partial class FChoice : Form
    {
        public FChoice()
        {
            InitializeComponent();
        }

        object[] Objects;

        public FChoice(object[] objects,string text)
        {
            Objects = objects;
            InitializeComponent();

            label1.Text = text;
            if (objects[0] is TProfil)
            {
                foreach (TProfil p in objects.OfType<TProfil>())
                {
                    KProfilButton kb = new KProfilButton() { Size = KProfilButton.OverallSize, Profil = p };
                    kFlowLayoutPanel1.Controls.Add(kb);
                    kb.Margin = new Padding(1);
                    kb.Click += Kb_Click;
                }
            }
            else if (objects[0] is TExercices)
            {
                foreach (TExercices p in objects.OfType<TExercices>())
                {
                    KExercicesButton kb = new KExercicesButton() { Size = KExercicesButton.OverallSize, Exercices = p };
                    kFlowLayoutPanel1.Controls.Add(kb);
                    kb.Margin = new Padding(1);
                    kb.Click += Kb_Click;
                }
            }
            else if (objects[0] is TExercice)
            {
                foreach (TExercice p in objects.OfType<TExercice>())
                {
                    KExerciceButton kb = new KExerciceButton() { Size = KExerciceButton.OverallSize, Exercice = p };
                    kFlowLayoutPanel1.Controls.Add(kb);
                    kb.Margin = new Padding(1);
                    kb.Click += Kb_Click;
                }
            }
        }

        public object SelectedObject { get; private set; }

        private void Kb_Click(object sender, EventArgs e)
        {
            if (sender is KProfilButton kb)
                SelectedObject = kb.Profil;
            else if (sender is KExercicesButton kes)
                SelectedObject = kes.Exercices;
            else if (sender is KExerciceButton ke)
                SelectedObject = ke.Exercice;
            Close();
        }
    }
}
