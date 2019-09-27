using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRsach
{
    class ReadQR
    {
        public double[,] Readr(string path)
        {
            FileStream fsr = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fsr);
            int Row = r.ReadInt32();
            int Column = r.ReadInt32();
            double[,] g = new double[Column, Row];
            for (int a = 0; a < Column; a++)
            {
                for (int b = 0; b < Row; b++)
                { g[a, b] = r.ReadDouble(); }             
            }
            r.Close();
            fsr.Close();
            return g;
        }
    }
}
