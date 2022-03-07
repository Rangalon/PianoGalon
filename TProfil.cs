using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PianoGalon
{
    public class TProfil
    {


        public override string ToString()
        {
            return Name;
        }

        public TProfil()
        {
            Name = "New one";
            Profils.Add(this);
        }


        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public Color BckColor { get; set; }


        [XmlAttribute]
        public byte R { get => BckColor.R; set => BckColor = Color.FromArgb(value, BckColor.G, BckColor.B); }
        [XmlAttribute]
        public byte G { get => BckColor.G; set => BckColor = Color.FromArgb(BckColor.R, value, BckColor.B); }
        [XmlAttribute]
        public byte B { get => BckColor.B; set => BckColor = Color.FromArgb(BckColor.R, BckColor.G, value); }

        static TProfil()
        {
            if (System.IO.File.Exists(TLecons.MainDi.FullName + "\\Profils.xml"))
            {
                StreamReader rdr = new StreamReader(TLecons.MainDi.FullName + "\\Profils.xml");
                XmlSerializer XS = new XmlSerializer(typeof(TProfil[]));
                XS.Deserialize(rdr);
                rdr.Close(); rdr.Dispose();
            }
        }

        public static List<TProfil> Profils = new List<TProfil>();

        public static void Save()
        {
            StreamWriter wtr = new StreamWriter(TLecons.MainDi.FullName + "\\Profils.xml");
            XmlSerializer XS = new XmlSerializer(typeof(TProfil[]));
            XS.Serialize(wtr, Profils.ToArray());
            wtr.Close(); wtr.Dispose();
        }

    }
}
