using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRsach
{
    class QRdecomposition
    {
        public double[,] Q; // Нормированная матрица Q
        public double[,] Qt;    // Нормированная матрица Qt
        public double[,] R; // Нормированная матрица R
        public double[,] QR;    // Нормированная матрица QR
        public int Column;  // Нормированная матрица Q
        public int Row; // Нормированная матрица Q
        public double[,] nvecs;
        double[] c;
        double[,] B;
        double[,] D;

        public void Reflections(double[,] A)    // QR-разложение Хаусхолдера(Отражений)
        {
            Row = Replacement(A).GetUpperBound(0) + 1;
            Column = Replacement(A).Length / Row;
            c = new double[Row];
            B = new double[Row, Column];
            D = Replacement(A);
            Q = new double[Row, Column];
            Qt = new double[Row, Column];
            R = new double[Row, Column];
            QR = new double[Row, Column];
            for (int i = 0; i < Row; i++)
            { B[i, 0] = D[i, 0]; }
            for (int x = 1; x < Row; x++)
            {
                for (int i = 0; i < x; i++)
                { c[i] = householder(D, x, B, i) / householder(B, i, B, i); }
                B = MatrixCon(D, B, c, x);
            }
            Q = QNormal(B);
            Qt = QtNormal(B);
            R = MultiMatrix(D, QNormal(B));
            QR = MultiMatrix(R, Qt);
        }

        public void Householder(double[,] A)    // QR-разложение Хаусхолдера
        {
            Row = Replacement(A).GetUpperBound(0) + 1;
            Column = Replacement(A).Length / Row;
            c = new double[Row];
            B = new double[Row, Column];
            D = Replacement(A);
            Q = new double[Row, Column];
            Qt = new double[Row, Column];
            R = new double[Row, Column];
            QR = new double[Row, Column];
            for (int i = 0; i < Row; i++)
            { B[i, 0] = D[i, 0]; }
            for (int x = 1; x < Row; x++)
            {
                for (int i = 0; i < x; i++)
                { c[i] = householder(D, x, B, i) / householder(B, i, B, i); }
                B = MatrixCon(D, B, c, x);
            }
            Q = QNormal(B);
            Qt = QtNormal(B);
            R = MultiMatrix(D, QNormal(B));
            QR = MultiMatrix(R, Qt);
        }

        public void Rotation(double[,] A)   // QR-разложение методом вращения
        {
            Row = Replacement(A).GetUpperBound(0) + 1;
            Column = Replacement(A).Length / Row;
            c = new double[Row];
            B = new double[Row, Column];
            D = Replacement(A);
            Q = new double[Row, Column];
            Qt = new double[Row, Column];
            R = new double[Row, Column];
            QR = new double[Row, Column];
            for (int i = 0; i < Row; i++)
            { B[i, 0] = D[i, 0]; }
            for (int x = 1; x < Row; x++)
            {
                for (int i = 0; i < x; i++)
                { c[i] = rotation(D, x, B, i) / rotation(B, i, B, i); }
                B = MatrixCon(D, B, c, x);
            }
            Q = QNormal(B);
            Qt = QtNormal(B);
            R = MultiMatrix(D, QNormal(B));
            QR = MultiMatrix(R, Qt);
        }

        public void FastRotation(double[,] A)   // QR-разложение методом быстрого вращения
        {
            Row = Replacement(A).GetUpperBound(0) + 1;
            Column = Replacement(A).Length / Row;
            c = new double[Row];
            B = new double[Row, Column];
            D = Replacement(A);
            Q = new double[Row, Column];
            Qt = new double[Row, Column];
            R = new double[Row, Column];
            QR = new double[Row, Column];
            for (int i = 0; i < Row; i++)
            { B[i, 0] = D[i, 0]; }
            for (int x = 1; x < Row; x++)
            {
                for (int i = 0; i < x; i++)
                { c[i] = fact(D, x, B, i) / fact(B, i, B, i); }
                B = MatrixCon(D, B, c, x);
            }
            Q = QNormal(B);
            Qt = QtNormal(B);
            R = MultiMatrix(D, QNormal(B));
            QR = MultiMatrix(R, Qt);
        }

        private double[,] Replacement(double[,] a)  // Подмена массива
        {
            int x = a.GetUpperBound(0) + 1;
            int y = a.Length / x;
            double min = SearchMinMax(a)[0];
            double max = SearchMinMax(a)[1];
            Random r = new Random();
            if (x > y) { y = x; }
            if (y > x) { x = y; }
            double[,] X = new double[x, y];
            for (int f = 0; f < x; f++)
            {
                for (int i = 0; i < y; i++)
                { try { X[f, i] = a[f, i]; } catch (Exception) { X[f, i] = r.Next((int)min, (int)max); } }
            }
            return X;
        }

        private double[,] MatrixCon(double[,] a, double[,] b, double[] c, int x)    // Преобразование над рядами 
        {
            double[] jh = new double[Row];
            for (int f = 0; f < x; f++)
            {
                for (int i = 0; i < Row; i++)
                { jh[i] += (c[f] * b[i, f]); }
            }
            for (int i = 0; i < Row; i++)
            { b[i, x] = a[i, x] - (jh[i]); }
            return b;
        }

        private double householder(double[,] a, int a1, double[,] b, int b1)    // Сумма двух столбцов 
        {
            double h = 0;
            for (int n = 0; n < Row; n++)
            { h += a[n, a1] * b[n, b1]; }
            return h;
        }

        private double[,] QNormal(double[,] QN) // Нормализация матрицы с результатом Q
        {
            double[] e1;
            double[,] Qnormal;
            e1 = new double[Column];
            Qnormal = new double[Row, Column];
            for (int e = 0; e < Column; e++)
            {
                for (int i = 0; i < Row; i++)
                { e1[e] += QN[i, e] * QN[i, e]; }
            }
            for (int e = 0; e < Column; e++)
            {
                for (int i = 0; i < Row; i++)
                { Qnormal[i, e] = QN[i, e] / (double)Math.Sqrt(e1[e]); }
            }
            return Qnormal;
        }

        private double[,] QtNormal(double[,] QN)    // Нормализация матрицы с результатом Qt
        {
            double[] e1;
            double[,] Qnormal;
            e1 = new double[Column];
            Qnormal = new double[Row, Column];
            for (int e = 0; e < Column; e++)
            {
                for (int i = 0; i < Row; i++)
                { e1[e] += QN[i, e] * QN[i, e]; }
            }
            for (int e = 0; e < Row; e++)
            {
                for (int i = 0; i < Column; i++)
                { Qnormal[e, i] = QN[i, e] / (double)Math.Sqrt(e1[e]); }
            }
            return Qnormal;
        }

        private double rotation(double[,] a, int a1, double[,] b, int b1)   // Сумма двух столбцов
        {
            double r = 0;
            for (int n = 0; n < Row; n++) { r += a[n, a1] * b[n, b1]; }
            return r;
        }

        private double[,] MultiMatrix(double[,] MatrixA, double[,] MatrixB) //Перемножение двух матриц
        {
            double[,] MultiR;
            MultiR = new double[Row, Column];
            for (int s = 0; s < Row; s++)
            {
                for (int e = 0; e < Row; e++)
                {
                    for (int i = 0; i < Row; i++)
                    { MultiR[e, s] += MatrixA[i, s] * MatrixB[i, e]; }
                }
            }
            return MultiR;
        }

        private double[] SearchMinMax(double[,] d)  // Поиск минимального и максимального значений в массиве
        {
            double[] MinMax = new double[2];
            MinMax[0] = 0;
            MinMax[1] = 0;
            int a = d.GetUpperBound(0) + 1;
            int b = d.Length / a;
            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    if (d[x, y] < MinMax[0]) { MinMax[0] = d[x, y]; }
                    if (d[x, y] > MinMax[1]) { MinMax[1] = d[x, y]; }
                }
            }
            return MinMax;
        }

        private double fact(double[,] a, int a1, double[,] b, int b1)   // Произведение двух столбцов
        {
            double f = 0;
            for (int n = 0; n < Row; n++)
            { f += a[n, a1] * b[n, b1]; }
            return f;
        }
        public double[,] Norm_Vecs(double[,]A)
        {
            nvecs = new double[Row, Column];
            double[] length = new double[Column];
            for(int i = 0; i < Column; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    length[i] += A[j, i] * A[j, i];
                }
                length[i] = Math.Sqrt(length[i]);
                for (int j = 0; j < Row; j++)
                {
                    nvecs[j,i] += A[j, i] / length[i];
                }
            }
            return nvecs;
        }
    }
}

