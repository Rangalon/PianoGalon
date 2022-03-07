using MidiGalon;
using MidiGalon.MidiFile;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace PianoGalon
{
    public class TExerciceComparer : IComparer<TExercice>
    {
        public static readonly TExerciceComparer Default = new TExerciceComparer();

        public int Compare(TExercice x, TExercice y)
        {
            return x.Rank.CompareTo(y.Rank);
        }
    }

    public class TExercice
    {
        [XmlAttribute]
        public uint Id { get; set; } = TLecons.GetId();

        [XmlAttribute]
        public uint Rank { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute("ET")]
        public EExerciceType ExerciceType { get; set; } = EExerciceType.Standard;

        public override string ToString()
        {
            return string.Format("{0}: {1}", Rank, Name);
        }

        public enum EExerciceType
        {
            Standard,
            RightLeft,
            RightLeftBoth
        }

        internal void ImportMuse(string fileName)
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(fileName);


            List<TChord> lchds = new List<TChord>();

            float N = 4, D = 4;

            foreach (XmlNode xpart in xdoc.SelectNodes("/museScore/Score/Staff"))
            {
                foreach (XmlNode xvbox in xpart.SelectNodes("./VBox"))
                {
                    foreach (XmlNode xtext in xvbox.SelectNodes("./Text"))
                    {
                        switch (xtext.SelectSingleNode("./style").InnerText)
                        {
                            case "Title": Name = xtext.SelectSingleNode("./text").InnerText; break;
                        }
                    }
                }



                float measurestart = 0;
                foreach (XmlNode xmeasure in xpart.SelectNodes("./Measure"))
                {
                    foreach (XmlNode xvoice in xmeasure.SelectNodes("./voice"))
                    {
                        float start = measurestart;
                        foreach (XmlNode xelmt in xvoice.ChildNodes)
                        {
                            switch (xelmt.Name)
                            {
                                case "Rest":
                                    switch (xelmt.SelectSingleNode("./durationType").InnerText)
                                    {
                                        case "measure": break;
                                        default: start += GetDuration(xelmt); break;
                                    }
                                    break;
                                case "TimeSig":
                                    N = float.Parse(xelmt.SelectSingleNode("./sigN").InnerText);
                                    D = float.Parse(xelmt.SelectSingleNode("./sigD").InnerText);
                                    break;
                                case "Chord":
                                    TChord c = new TChord();
                                    c.Start = start;
                                    c.Duration = GetDuration(xelmt) - Gap;
                                    start += c.Duration + Gap;
                                    List<int> ptcs = new List<int>();
                                    foreach (XmlNode xpitch in xelmt.SelectNodes("./Note/pitch"))
                                        ptcs.Add(int.Parse(xpitch.InnerText));
                                    c.Notes = ptcs.ToArray();
                                    lchds.Add(c);
                                    break;
                                default:
                                    throw new Exception("Not implemented!");
                            }
                        }
                    }
                    measurestart += N * Oneth / D;
                }
            }
            Chords = lchds.ToArray();
        }



        static float GetDuration(XmlNode n)
        {
            switch (n.SelectSingleNode("./durationType").InnerText)
            {
                case "eighth": return Eighth;
                default: throw new Exception("Not Implemented: " + n.SelectSingleNode("./durationType").InnerText);
            }
        }


        public static readonly float Eighth = 0.240f;
        public static readonly float Oneth = 1.92f;
        public static readonly float Gap = 0.013f;

        [XmlArray("Chds")]
        [XmlArrayItem("Chd")]
        public TChord[] Chords = { };
        public void ComputePaths(TPiano piano, List<TChordTarget> ChordTargets)
        {
            foreach (TChord chd in Chords)
                chd.ComputePaths(piano, ChordTargets);
            if (Chords.Length > 0)
            {
                float total = ChordTargets.Max(o => o.Date + o.Duration) + Gap;
                switch (ExerciceType)
                {
                    case EExerciceType.RightLeft:
                        foreach (TChordTarget cto in ChordTargets.ToArray())
                            ChordTargets.Add(cto.Clone(-12, total, piano));
                        break;
                    case EExerciceType.RightLeftBoth:
                        foreach (TChordTarget cto in ChordTargets.ToArray())
                        {
                            ChordTargets.Add(cto.Clone(-12, total, piano));
                            ChordTargets.Add(cto.Clone(0, total * 2, piano));
                            ChordTargets.Add(cto.Clone(-12, total * 2, piano));
                        }
                        break;
                }
            }
        }

        internal void ImportMidi(string fileName)
        {
            TMidiFile mfile = new TMidiFile(fileName);
            mfile.Regularize();
            List<TChord> chds = new List<TChord>();
            foreach (TMidiTrack mtrk in mfile.Tracks)
                foreach (TMidiChannel mchn in mtrk.Channels.Where(o => o != null))
                    while (mchn.Events.Count > 0)
                    {
                        TMidiNoteEvent e1 = mchn.Events[0]; mchn.Events.RemoveAt(0);
                        TMidiNoteEvent e2 = mchn.Events.First(o => o.Note == e1.Note); mchn.Events.Remove(e2);
                        chds.Add(new TChord() { Duration = 0.001f * (e2.Date - e1.Date), Start = 0.001f * e1.Date, Notes = new int[] { e1.Note } });
                    }
            Chords = chds.ToArray();
        }
    }


}
