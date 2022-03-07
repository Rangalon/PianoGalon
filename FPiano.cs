using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace PianoGalon
{
    public partial class FPiano : Form
    {
        TPiano Piano;

        public FPiano()
        {
            InitializeComponent();
            ICollection<InputDevice> lst = Melanchall.DryWetMidi.Multimedia.InputDevice.GetAll();
            if (lst.Count == 0)
                Piano = new TPiano(null);
            else
                Piano = new TPiano(lst.First());
            Piano.KeyEvent += Piano_KeyEvent;
        }

        private void Piano_KeyEvent(TPianoEvent e)
        {
            TChordTarget ct = ChordTargets.FirstOrDefault(o => o.Number == e.Number && o.EventType == e.EventType && o.Date >= CurrentTarget.Date && o.Date - CurrentTarget.Date < 0.1f);

            if (ct != null)
            {
                ct.Done = true;
                CurrentTarget = ChordTargets.First(o => !o.Done);
            }
        }



        Pen BigBlackPen = new Pen(Color.Black, 3);

        bool DoerDrawEnabled = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateProfils();
            UpdateLecons();
            Thread th;
            th = new Thread(DoerDrawPiano); th.Start();
            th = new Thread(DoerDrawMusicScore); th.Start();
        }
        private void DoerDrawMusicScore()
        {
            Action refresher = new Action(pbMusicScore.Refresh);
            Bitmap bmp;
            Graphics grp;
            Size sz;
            while (DoerDrawEnabled)
            {
                sz = pbMusicScore.Size;
                if (pbMusicScore.BackgroundImage != null)
                {
                    bmp = (Bitmap)pbMusicScore.BackgroundImage;
                    if (bmp.Width != sz.Width || bmp.Height != sz.Height)
                    {
                        pbMusicScore.BackgroundImage = null;
                        bmp.Dispose();
                        bmp = null;
                    }
                }
                if (pbMusicScore.BackgroundImage == null)
                    pbMusicScore.BackgroundImage = new Bitmap(sz.Width, sz.Height);

                try
                {
                    grp = Graphics.FromImage(pbMusicScore.BackgroundImage);
                }
                catch { grp = null; }

                if (grp != null)
                {
                    InitGrp(grp, xratio, 1);
                    if (CurrentExercice != null)
                    {
                        grp.TranslateTransform(0, sz.Height);
                        grp.ScaleTransform(1, -1);
                        foreach (TPiano.TKey key in Piano.Keys.Where(o => o != null && !o.Black))
                        {
                            grp.DrawLine(BackPen, key.MinX, 0, key.MinX, sz.Height);
                            grp.DrawLine(BackPen, key.MaxX, 0, key.MaxX, sz.Height);
                        }
                        if (CurrentTarget != null)
                        {

                            grp.TranslateTransform(0, -CurrentTarget.Date * TChord.DurationRatio);
                            foreach (GraphicsPath path in WhitePaths)
                                grp.FillPath(Brushes.White, path);
                            foreach (GraphicsPath path in BlackPaths)
                                grp.FillPath(Brushes.Black, path);
                            foreach (TChordTarget ct in ChordTargets.Where(o => o.EventType == EChordEventType.Pressed))
                                grp.FillEllipse(Brushes.DarkBlue, ct.Rec);
                            foreach (TChordTarget ct in ChordTargets.Where(o => o.EventType == EChordEventType.Released))
                                grp.FillEllipse(Brushes.DarkGoldenrod, ct.Rec);
                        }

                    }
                    //
                    if (CurrentExercice != null && CurrentProfil != null)
                    {
                        grp.ResetTransform();
                        string s = string.Format("{2}\n{0}\n\t{1}", CurrentExercices.Name, CurrentExercice.Name, CurrentProfil.Name);
                        grp.TranslateTransform(1, 1); grp.DrawString(s, KLabel.Ft, Brushes.Black, 0, 0);
                        grp.TranslateTransform(-1, -1); grp.DrawString(s, KLabel.Ft, Brushes.LightGray, 0, 0);
                    }
                    //
                    grp.Dispose();
                }

                try
                {
                    Invoke(refresher);
                }
                catch { }
                Thread.Sleep(10);
            }
        }


   
        private void DoerDrawPiano()
        {
            Action refresher = new Action(pbPiano.Refresh);
            Bitmap bmp;
            Graphics grp;
            while (DoerDrawEnabled)
            {

                if (pbPiano.BackgroundImage != null)
                {
                    bmp = (Bitmap)pbPiano.BackgroundImage;
                    if (bmp.Width != pbPiano.Width || bmp.Height != pbPiano.Height)
                    {
                        pbPiano.BackgroundImage = null;
                        bmp.Dispose();
                        bmp = null;
                    }
                }
                if (pbPiano.BackgroundImage == null)
                    pbPiano.BackgroundImage = new Bitmap(pbPiano.Width, pbPiano.Height);

                try
                {
                    grp = Graphics.FromImage(pbPiano.BackgroundImage);
                }
                catch { grp = null; }

                if (grp != null)
                {
                    xratio = (float)pbPiano.Width / (Piano.Max - Piano.Min);

                    InitGrp(grp, xratio, xratio);
                    foreach (TPiano.TKey key in Piano.Keys.Where(o => o != null && o.Pnts != null && !o.Black))
                    {
                        grp.FillPath(Brushes.White, key.Path);
                        if (key.Velocity > 0)
                            grp.FillPath(PressedBrs, key.Path);
                        grp.DrawPath(WhiteBorderPen, key.Path);
                        grp.DrawString(key.Name, KLabel .Ft, Brushes.Black, key.MinX, 50);
                    }
                    foreach (TPiano.TKey key in Piano.Keys.Where(o => o != null && o.Pnts != null && o.Black))
                    {
                        grp.FillPath(Brushes.Black, key.Path);
                        if (key.Velocity > 0)
                            grp.FillPath(PressedBrs, key.Path);
                        grp.DrawPath(BlackBorderPen, key.Path);
                    }
                    grp.Dispose();
                }

                try
                {
                    Invoke(refresher);
                }
                catch { }
                Thread.Sleep(10);
            }
        }

        float xratio = 1;

        static Pen WhiteBorderPen = new Pen(Color.FromArgb(64, 0, 0, 0), 4);
        static Pen BlackBorderPen = new Pen(Color.FromArgb(64, 255, 255, 255), 4);

        void InitGrp(Graphics grp, float xr, float yr)
        {
            grp.SmoothingMode = SmoothingMode.AntiAlias;
            grp.Clear(BackBrs.Color);
            grp.ScaleTransform(xr, yr);
            grp.TranslateTransform(-Piano.Min, 0);
        }

        SolidBrush BackBrs = new SolidBrush(Color.FromArgb(64, 64, 64));
        Pen BackPen = new Pen(Color.FromArgb(64, 255, 255, 255), 0.1f);
        SolidBrush PressedBrs = new SolidBrush(Color.FromArgb(192, 255, 255, 0));

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoerDrawEnabled = false;
        }



        void UpdateProfils()
        {

            foreach (TProfil p in TProfil.Profils)
            {
                KProfilButton kb = flpProfils.Controls.OfType<KProfilButton>().FirstOrDefault(o => o.Profil == p);
                if (kb == null)
                {
                    kb = new KProfilButton(p) { Size = KProfilButton.OverallSize };
                    flpProfils.Controls.Add(kb);
                    kb.Margin = new Padding(1);
                    kb.ContextMenuStrip = cmsProfils;
                    kb.Click += Kb_Click;
                }
            }
        }

        private void Kb_Click(object sender, EventArgs e)
        {
            KProfilButton kb = (KProfilButton)sender;
            foreach (KProfilButton kp in flpProfils.Controls.OfType<KProfilButton>()) kp.IsCurrent = false;
            kb.IsCurrent = true;
            CurrentProfil = kb.Profil;
            flpExercices.Enabled = true;
            flpProfils.Refresh();
        }

        void UpdateLecons()
        {

            foreach (TExercices exs in TLecons.Exercices)
            {
                KExercicesButton kes = flpExercices.Controls.OfType<KExercicesButton>().FirstOrDefault(o => o.Exercices == exs);
                if (kes == null)
                {
                    kes = new KExercicesButton(exs); kes.Size = KExercicesButton.OverallSize;
                    kes.Margin = new Padding(1);
                    flpExercices.Controls.Add(kes);
                    kes.Click += Kes_Click;
                }
            }
        }

        private void Kes_Click(object sender, EventArgs e)
        {
            KExercicesButton kes = (KExercicesButton)sender;

            foreach (KExercicesButton kp in flpExercices.Controls.OfType<KExercicesButton>()) kp.IsCurrent = false;
            kes.IsCurrent = true;

            flpExercices.Refresh();

            flpExercice.Enabled = true;

            CurrentExercices = kes.Exercices;
            UpdateExercices();
            label1.Text = CurrentExercices.Name;
        }

        void UpdateExercices()
        {
            foreach (KExerciceButton ke in flpExercice.Controls.OfType<KExerciceButton>().ToArray())
            {
                flpExercice.Controls.Remove(ke);
                ke.Dispose();
            }


            CurrentExercices.Exercices.Sort(TExerciceComparer.Default);

            foreach (TExercice ex in CurrentExercices.Exercices)
            {
                KExerciceButton ke = flpExercices.Controls.OfType<KExerciceButton>().FirstOrDefault(o => o.Exercice == ex);
                if (ke == null)
                {
                    ke = new KExerciceButton(ex); ke.Size = KExerciceButton.OverallSize;
                    flpExercice.Controls.Add(ke);
                    ke.Margin = new Padding(1);
                    ke.Click += Ke_Click;
                }
            }


        }

        private void Ke_Click(object sender, EventArgs e)
        {
            KExerciceButton ke = (KExerciceButton)sender;
            foreach (KExerciceButton kp in flpExercice.Controls.OfType<KExerciceButton>()) kp.IsCurrent = false;
            ke.IsCurrent = true;
            flpExercice.Refresh();

            CurrentExercice = ke.Exercice;
            List<GraphicsPath> wlst = new List<GraphicsPath>();
            List<GraphicsPath> blst = new List<GraphicsPath>();
            List<TChordTarget> ctlst = new List<TChordTarget>();
            CurrentExercice.ComputePaths(Piano, wlst, blst, ctlst);
            WhitePaths = wlst.ToArray();
            BlackPaths = blst.ToArray();
            ctlst.Sort(TChordTargetComparer.Default);
            ChordTargets = ctlst.ToArray();
            if (ChordTargets.Length > 0)
                CurrentTarget = ChordTargets[0];
            else
                CurrentTarget = null;
        }

        TProfil CurrentProfil;


        private void tmrSave_Tick(object sender, EventArgs e)
        {
            TProfil.Save();
        }



        TExercices CurrentExercices;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TLecons.Save();
        }


        TChordTarget CurrentTarget;

        GraphicsPath[] WhitePaths = { };
        GraphicsPath[] BlackPaths = { };
        TChordTarget[] ChordTargets = { };

        TExercice CurrentExercice;

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentExercice == null) return;
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Muse Score|*.mscx" };
            ofd.ShowDialog();
            if (ofd.FileName != "")
                CurrentExercice.ImportMuse(ofd.FileName);

        }

        private void importMidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentExercice == null) return;
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Midi File|*.mid" };
            ofd.ShowDialog();
            if (ofd.FileName != "")
                CurrentExercice.ImportMidi(ofd.FileName);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TProfil p = new TProfil();
            FProfil f = new FProfil(p);
            f.ShowDialog();
            UpdateProfils();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProfil f = new FProfil(CurrentProfil);
            f.ShowDialog();
            flpProfils.Refresh();
        }

        private void pbMusicScore_Click(object sender, EventArgs e)
        {
            TChordTarget ct = ChordTargets.First(o => !o.Done);

            if (ct != null)
            {
                ct.Done = true;
                CurrentTarget = ChordTargets.First(o => !o.Done);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
    }


}
