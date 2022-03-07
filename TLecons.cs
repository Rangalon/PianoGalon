using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PianoGalon
{
    public abstract class TLecons
    {
        static string mainFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Piano";

        internal static UInt32  GetId()
        {
            List<UInt32> lst = new List<UInt32>();
            lst.Add(0);
            foreach (TExercices exs in Exercices)
            {
                lst.Add(exs.Id);
                foreach (TExercice ex in exs.Exercices)
                    lst.Add(ex.Id);
            }
            return lst.Max() + 1;
        }

        public static DirectoryInfo MainDi
        {
            get
            {
                DirectoryInfo di = new DirectoryInfo(mainFolder);
                if (!di.Exists) di.Create();
                return di;
            }
        }

        static TLecons()
        {
            if (System.IO.File.Exists(MainDi.FullName + "\\Lecons.xml"))
            {
                StreamReader rdr = new StreamReader(MainDi.FullName + "\\Lecons.xml");
                XmlSerializer XS = new XmlSerializer(typeof(TExercices[]));
                Exercices = (TExercices[])XS.Deserialize(rdr);
                rdr.Close(); rdr.Dispose();
            }
        }

        public static TExercices[] Exercices = { };

        public static void Save()
        {
            StreamWriter wtr = new StreamWriter(MainDi.FullName + "\\Lecons.xml");
            XmlSerializer XS = new XmlSerializer(typeof(TExercices[]));
            XS.Serialize(wtr, Exercices);
            wtr.Close(); wtr.Dispose();
        }
    }
}
