using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRsach
{
    class WriteQR
    {
        public void Writer(double[,] q, string path)
        {
            int Row = q.GetUpperBound(0) + 1;
            int Column = q.Length / Row;
            FileStream fsr = new FileStream(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fsr);
            writer.Write(Row);
            writer.Write(Column);
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                { writer.Write(q[i, j]); }
            }
            writer.Close();
            fsr.Close();
        }
    }
}
