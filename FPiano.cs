using MidiGalon;
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
            ICollection<InputDevice> lst = InputDevice.GetAll();
            if (lst.Count == 0)
                Piano = new TPiano(null);
            else
                Piano = new TPiano(lst.First());
            Piano.KeyEvent += Piano_KeyEvent;
        }

        float CurrentDate = 0;

        private void Piano_KeyEvent(TPianoEvent e)
        {
            switch (PlayMode)
            {
                case EPlayMode.Stairs:
                    {
                        TChordTarget ct = ChordTargets.FirstOrDefault(o => o.Key.Number == e.Number && o.EventType == e.EventType && o.Date >= CurrentDate && o.Date - CurrentDate < 0.1f);

                        if (ct != null)
                        {
                            ct.Done = true;
                            //
                            if (ct.EventType == EChordEventType.Pressed) NotesQty--;
                            ct = ChordTargets.FirstOrDefault(o => !o.Done);
                            PlayerEvents.Add(new TPlayerEvent() { Date = CurrentDate, Good = true, Number = e.Number });
                            if (ct != null) CurrentDate = ct.Date;
                            GoodEvents++;
                        }
                        else
                        {
                            BadEvents++;
                            PlayerEvents.Add(new TPlayerEvent() { Date = CurrentDate, Good = false, Number = e.Number });
                        }
                    }
                    break;
                case EPlayMode.Escalators:
                    {
                        TChordTarget ct = ChordTargets.FirstOrDefault(o => o.Key.Number == e.Number && o.EventType == e.EventType && Math.Abs(o.Date - CurrentDate) < TimeTolerance);
                        if (ct != null)
                        {
                            ct.Done = true;
                            //
                            if (ct.EventType == EChordEventType.Pressed) NotesQty--;
                            GoodEvents++;
                            PlayerEvents.Add(new TPlayerEvent() { Date = CurrentDate, Good = true, Number = e.Number });
                        }
                        else
                        {
                            BadEvents++;
                            PlayerEvents.Add(new TPlayerEvent() { Date = CurrentDate, Good = false, Number = e.Number });
                        }
                    }
                    break;
            }

        }

        static double TimeTolerance = 0.2;


        bool DoerDrawEnabled = true;

        Rectangle RecPlay;

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th;
            th = new Thread(DoerDrawPiano); th.Start();
            th = new Thread(DoerDrawMusicScore); th.Start();
            th = new Thread(DoerDrawResults); th.Start();
            th = new Thread(DoerComputeMusicScore); th.Start();
            th = new Thread(DoerDate); th.Start();
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.KeyDown += Ke_KeyDown;
                c.KeyUp += Ke_KeyUp;
            }
        }

        private void DoerComputeMusicScore()
        {
            Size sz;
            while (DoerDrawEnabled)
            {
                sz = pbMusicScore.Size;
                RecPlayMode = new Rectangle(
                        sz.Width - Properties.Resources.Stairs.Width,
                        0,
                        Properties.Resources.Escalators.Width,
                        Properties.Resources.Escalators.Height);

                RecPlay = new Rectangle(
                    0,
                    0,
                    Properties.Resources.Play.Width,
                    Properties.Resources.Play.Height);

                RecNotes = RecPlay;
                RecNotes.Width *= 2;
                RecNotes.Y += RecNotes.Height;
                RecScore = RecNotes;
                RecScore.Y += RecScore.Height;
                Thread.Sleep(100);
            }
        }

        Rectangle RecNotes;
        Rectangle RecScore;



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
                    if (keButton.Exercice != null)
                    {
                        grp.TranslateTransform(0, sz.Height);
                        grp.ScaleTransform(1, -1);
                        foreach (TPiano.TKey key in Piano.Keys.Where(o => o != null && !o.Black))
                        {
                            grp.DrawLine(BackPen, key.MinX, 0, key.MinX, sz.Height);
                            grp.DrawLine(BackPen, key.MaxX, 0, key.MaxX, sz.Height);
                        }

                        grp.TranslateTransform(0, -CurrentDate * TChord.DurationRatio * 0.5f);
                        foreach (TChordTarget ct in WhiteTargets)
                        {
                            grp.FillPath(Brushes.White, ct.Path);
                            grp.DrawPath(BlackBorderPen, ct.Path);
                        }
                        foreach (TChordTarget ct in BlackTargets)
                        {
                            grp.FillPath(Brushes.Black, ct.Path);
                            grp.DrawPath(WhiteBorderPen, ct.Path);
                        }
                    }
                    //
                    if (keButton.Exercice != null && kpButton.Profil != null)
                    {
                        grp.ResetTransform();
                        string s;
                        //
                        grp.DrawImage(Properties.Resources.Play, RecPlay);
                        //
                        switch (PlayMode)
                        {
                            case EPlayMode.Escalators:
                                grp.DrawImage(Properties.Resources.Escalators, RecPlayMode);
                                break;
                            case EPlayMode.Stairs:
                                grp.DrawImage(Properties.Resources.Stairs, RecPlayMode);
                                break;
                        }
                        //
                        s = string.Format("Time: {1}:{2:00}.{3:000}\n\nNotes: {0}", NotesQty, (int)(CurrentDate / 60), (int)(CurrentDate % 60), 1000 * (CurrentDate % 1));
                        grp.TranslateTransform(1, 1); grp.DrawString(s, KButton.Ft, Brushes.Black, RecNotes, KButton.StrCC);
                        grp.TranslateTransform(-1, -1); grp.DrawString(s, KButton.Ft, Brushes.LightGray, RecNotes, KButton.StrCC);
                        //
                        int r = GoodEvents + BadEvents;
                        if (r > 0) r = (100 * GoodEvents) / r;
                        s = string.Format("Good: {0}\nBad : {1}\nScore: {2}%", GoodEvents, BadEvents, r);
                        grp.TranslateTransform(1, 1); grp.DrawString(s, KButton.Ft, Brushes.Black, RecScore, KButton.StrCC);
                        grp.TranslateTransform(-1, -1); grp.DrawString(s, KButton.Ft, Brushes.LightGray, RecScore, KButton.StrCC);
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

        private void DoerDrawResults()
        {
            Action refresher = new Action(pbResults.Refresh);
            Graphics grp;
            TChordTarget[] cts = { };
            TPlayerEvent[] evts = { };
            float xr;
            float xm;
            Size sz = pbResults.Size;

            if (pbResults.BackgroundImage == null)
                pbResults.BackgroundImage = new Bitmap(sz.Width, sz.Height);

            while (DoerDrawEnabled)
            {

                try
                {
                    grp = Graphics.FromImage(pbResults.BackgroundImage);
                }
                catch { grp = null; }

                if (grp != null)
                {

                    grp.SmoothingMode = SmoothingMode.AntiAlias;

                    try
                    {
                        cts = ChordTargets.ToArray();
                        evts = PlayerEvents.ToArray();
                    }
                    catch { }

                    grp.Clear(Color.Black);

                    if (cts.Length > 0)
                    {
                        xm = cts.Min(o => o.Date);
                        xr = (float)(pbResults.Width - 10) / (cts.Max(o => o.Date) - xm);
                        //
                        grp.FillRectangle(BckResultsBrs, 0, 0, 5 + xr * CurrentDate, sz.Height);
                        //
                        foreach (TChordTarget ct in cts)
                            grp.FillEllipse(NeutralBrs, 5 + (ct.Date - xm) * xr, ct.Key.Number * 0.5f, xr * ct.Duration, 7);
                        foreach (TPlayerEvent ct in evts.Where(o => o.Good))
                            grp.FillEllipse(GoodBrs, 5 + (ct.Date - xm) * xr, ct.Number * 0.5f, 7, 7);
                        foreach (TPlayerEvent ct in evts.Where(o => !o.Good))
                            grp.FillEllipse(BadBrs, 5 + (ct.Date - xm) * xr, ct.Number * 0.5f, 7, 7);
                    }


                    grp.Dispose();
                }

                try
                {
                    Invoke(refresher);
                }
                catch { }
                Thread.Sleep(20);
            }
        }

        SolidBrush BckResultsBrs = new SolidBrush(Color.FromArgb(32, 32, 32));

        SolidBrush NeutralBrs = new SolidBrush(Color.FromArgb(64, 64, 64));
        SolidBrush GoodBrs = new SolidBrush(Color.FromArgb(64, 192, 64));
        SolidBrush BadBrs = new SolidBrush(Color.FromArgb(192, 64, 64));

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
                {
                    pbPiano.BackgroundImage = new Bitmap(pbPiano.Width, pbPiano.Height);
                    PressedShadowBrush = new LinearGradientBrush(
                        new Rectangle(0, 0, pbPiano.Width, 800),
                        Color.FromArgb(0, 0, 0, 0),
                        Color.FromArgb(128, 0, 0, 0),
                        90f);
                }

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
                        if (key.Velocity > 0)
                        {
                            grp.ScaleTransform(1, 0.95f);
                            grp.FillPath(Brushes.White, key.Path);
                            grp.DrawPath(WhiteBorderPen, key.Path);
                            grp.FillPath(PressedBrs, key.Path);
                            grp.FillPath(PressedShadowBrush, key.Path);
                            grp.ScaleTransform(1, 1 / 0.95f);
                        }
                        else
                        {
                            grp.FillPath(Brushes.White, key.Path);
                            grp.DrawPath(WhiteBorderPen, key.Path);
                        }
                        grp.DrawString(key.Name, KLabel.Ft, Brushes.Black, key.MinX, 50);

                    }
                    foreach (TPiano.TKey key in Piano.Keys.Where(o => o != null && o.Pnts != null && o.Black))
                    {
                        if (key.Velocity > 0)
                        {
                            grp.ScaleTransform(1, 0.95f);
                            grp.FillPath(Brushes.Black, key.Path);
                            grp.DrawPath(WhiteBorderPen, key.Path);
                            grp.FillPath(PressedBrs, key.Path);
                            grp.FillPath(PressedShadowBrush, key.Path);
                            grp.ScaleTransform(1, 1 / 0.95f);
                        }
                        else
                        {
                            grp.FillPath(Brushes.Black, key.Path);
                            grp.DrawPath(WhiteBorderPen, key.Path);
                        }
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

        List<TPlayerEvent> PlayerEvents = new List<TPlayerEvent>();

        static Brush PressedShadowBrush;

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







        private int GetPianoKey(int keyValue)
        {
            switch (keyValue)
            {
                case 68: return 55;
                case 70: return 57;
                case 71: return 59;
                case 72: return 60;
                case 85: return 61;
                case 74: return 62;
                case 75: return 64;
                case 76: return 65;
                case 77: return 67;
                case 192: return 69;
                case 220: return 71;
                default: return 0;
            }
        }

        private void Ke_KeyUp(object sender, KeyEventArgs e)
        {
            TPianoEvent pe = new TPianoEvent() { EventType = EChordEventType.Released, Number = GetPianoKey(e.KeyValue) };
            if (Piano.Keys[pe.Number] != null) Piano.Keys[pe.Number].Velocity = 0;
            Piano_KeyEvent(pe);
        }
        private void Ke_KeyDown(object sender, KeyEventArgs e)
        {
            TPianoEvent pe = new TPianoEvent() { EventType = EChordEventType.Pressed, Number = GetPianoKey(e.KeyValue) };
            if (Piano.Keys[pe.Number] != null) Piano.Keys[pe.Number].Velocity = 80;
            Piano_KeyEvent(pe);
        }



        int NotesQty;
        int BadEvents = 0;
        int GoodEvents = 0;

        static double TimeRatio = 1;

        void ResetExercice()
        {
            switch (PlayMode)
            {
                case EPlayMode.Stairs:
                    CurrentDate = ChordTargets.Min(o => o.Date);
                    break;
                case EPlayMode.Escalators:
                    DtStart = DateTime.Now.AddSeconds(5 * TimeRatio);
                    break;
            }
            //
            NotesQty = ChordTargets.Count(o => o.EventType == EChordEventType.Pressed);
            BadEvents = 0;
            GoodEvents = 0;
            PlayerEvents.Clear();
            //
            foreach (TChordTarget ct in ChordTargets) ct.Done = false;
        }

        DateTime DtStart;

        private void tmrSave_Tick(object sender, EventArgs e)
        {
            TProfil.Save();
        }




        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TLecons.Save();
        }



        TChordTarget[] WhiteTargets = { };
        TChordTarget[] BlackTargets = { };
        TChordTarget[] ChordTargets = { };


        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Muse Score|*.mscx", Multiselect = true };
            ofd.ShowDialog();
            foreach (string file in ofd.FileNames)
            {
                SetNewCurrentExercice();
                keButton.Exercice.ImportMuse(file);
            }
        }

        void SetNewCurrentExercice()
        {
            TExercice ex = new TExercice();
            //
            kesButton.Exercices.Exercices.Add(ex);
            ex.Rank = (uint)kesButton.Exercices.Exercices.Count;
            // 
            keButton.Exercice = ex;
            // 
            LoadExercice();
        }

        void LoadExercice()
        {
            List<TChordTarget> ctlst = new List<TChordTarget>();
            keButton.Exercice.ComputePaths(Piano, ctlst);
            ctlst.Sort(TChordTargetComparer.Default);
            ChordTargets = ctlst.ToArray();
            WhiteTargets = ChordTargets.Where(o => !o.Key.Black && o.EventType == EChordEventType.Pressed).ToArray();
            BlackTargets = ChordTargets.Where(o => o.Key.Black && o.EventType == EChordEventType.Pressed).ToArray();
            foreach (TChordTarget ct in ChordTargets.Where(o => o.EventType == EChordEventType.Pressed))
            {
                RectangleF r = new RectangleF(ct.Key.MinX, TChord.DurationRatio * ct.Date * 0.5f, ct.Key.DeltaX, TChord.DurationRatio * ct.Duration * 0.5f);
                //
                GraphicsPath Path = new GraphicsPath();
                Path.AddArc(new RectangleF(r.X + r.Width - (2 + KButton.diameter), r.Y + 2, KButton.diameter, KButton.diameter), 270, 90);
                Path.AddArc(new RectangleF(r.X + r.Width - (2 + KButton.diameter), r.Y + r.Height - (2 + KButton.diameter), KButton.diameter, KButton.diameter), 0, 90);
                Path.AddArc(new RectangleF(r.X + 2, r.Y + r.Height - (2 + KButton.diameter), KButton.diameter, KButton.diameter), 90, 90);
                Path.AddArc(new RectangleF(r.X + 2, r.Y + 2, KButton.diameter, KButton.diameter), 180, 90);
                //
                ct.Rec = r;
                ct.Path = Path;
            }
            ResetExercice();
        }

        private void importMidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (keButton.Exercice == null) SetNewCurrentExercice();
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Midi File|*.mid" };
            ofd.ShowDialog();
            if (ofd.FileName != "")
                keButton.Exercice.ImportMidi(ofd.FileName);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TProfil p = new TProfil();
            FEdit f = new FEdit(p);
            f.ShowDialog();
            kpButton.Profil = p;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEdit f = new FEdit(kpButton.Profil);
            f.ShowDialog();
        }

        private void pbMusicScore_Click(object sender, EventArgs e)
        {
            //TChordTarget ct = ChordTargets.First(o => !o.Done);

            //if (ct != null)
            //{
            //    ct.Done = true;
            //    CurrentTarget = ChordTargets.First(o => !o.Done);
            //}
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TExercices exs = new TExercices();
            FEdit f = new FEdit(exs);
            f.ShowDialog();
            //
            Array.Resize(ref TLecons.Exercices, TLecons.Exercices.Length + 1);
            TLecons.Exercices[TLecons.Exercices.Length - 1] = exs;
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TExercice ex = new TExercice();
            FEdit f = new FEdit(ex);
            f.ShowDialog();
            //
            kesButton.Exercices.Exercices.Add(ex);
            //
        }

        public Rectangle RecPlayMode;

        public EPlayMode PlayMode = EPlayMode.Stairs;

        private void pbMusicScore_MouseClick(object sender, MouseEventArgs e)
        {
            if (RecPlayMode.Contains(e.X, e.Y))
            {
                PlayMode = Pms[(Array.IndexOf(Pms, PlayMode) + 1) % Pms.Length];
                ResetExercice();
            }
            else if (RecPlay.Contains(e.X, e.Y))
            {
                ResetExercice();
            }
        }

        void DoerDate()
        {
            while (DoerDrawEnabled)
            {
                switch (PlayMode)
                {
                    case EPlayMode.Escalators:
                        CurrentDate = (float)(TimeRatio * 0.001 * (DateTime.Now - DtStart).TotalMilliseconds);
                        foreach (TChordTarget ct in ChordTargets.Where(o => !o.Done && CurrentDate - o.Date > TimeTolerance))
                        {
                            BadEvents++;
                            if (ct.EventType == EChordEventType.Pressed)
                                NotesQty--;
                            PlayerEvents.Add(new TPlayerEvent() { Number = ct.Key.Number, Date = ct.Date, Good = false });
                            ct.Done = true;
                        }
                        break;
                }
                Thread.Sleep(10);
            }
        }

        EPlayMode[] Pms = (EPlayMode[])Enum.GetValues(typeof(EPlayMode));

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FEdit f = new FEdit(keButton.Exercice);
            f.ShowDialog();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FEdit f = new FEdit(keButton.Exercice);
            f.ShowDialog();
        }

        private void kProfilButton1_Click(object sender, EventArgs e)
        {
            FChoice f = new FChoice(TProfil.Profils.ToArray(), "Select your Profile");
            f.ShowDialog();
            if (f.SelectedObject != null) kpButton.Profil = (TProfil)f.SelectedObject;
            kpButton.Refresh();
        }

        private void kExercicesButton1_Click(object sender, EventArgs e)
        {
            FChoice f = new FChoice(TLecons.Exercices, "Select the Exercices");
            f.ShowDialog();
            if (f.SelectedObject != null) kesButton.Exercices = (TExercices)f.SelectedObject;
            kesButton.Refresh();
        }

        private void kExerciceButton1_Click(object sender, EventArgs e)
        {
            FChoice f = new FChoice(kesButton.Exercices.Exercices.ToArray(), "Select an Exercice");
            f.ShowDialog();
            if (f.SelectedObject != null) keButton.Exercice = (TExercice)f.SelectedObject;
            keButton.Refresh();
            LoadExercice();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TExercice[] exs = kesButton.Exercices.Exercices.ToArray();
            Array.Sort(exs, TExerciceComparer.Default);
            int i = Array.IndexOf(exs, keButton.Exercice);
            i = (i + 1) % exs.Length;
            keButton.Exercice = exs[i];
            keButton.Refresh();
            LoadExercice();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            TExercice[] exs = kesButton.Exercices.Exercices.ToArray();
            Array.Sort(exs, TExerciceComparer.Default);
            int i = Array.IndexOf(exs, keButton.Exercice);
            i = (i - 1 + exs.Length) % exs.Length;
            keButton.Exercice = exs[i];
            keButton.Refresh();
            LoadExercice();
        }
    }


    public enum EPlayMode
    {
        Stairs,
        Escalators
    }

}
