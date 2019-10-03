using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace QRsach
{
    public partial class Form1 : Form
    {
        double[,] MatriX, vl, vr;
        double[] wr, wi;
        int Row = 0;
        int Column =0;
        string path_in = "Matrix.txt";   //Хранилище Матрицы А
        string path_out = "C\\output.txt"; //Хранилище матриц Q,R
        public Form1()
        {
            InitializeComponent();
        }
        // Можно вводить только цифры в текстбоксы
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8) ))
            { e.Handled = true; }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)8)))
            { e.Handled = true; }
        }
        public char sigint(double val)
        {
            char sign = ' ';
            if (val >= 0) { sign = '+'; }
            return sign;
        }
        //Открытие файлов
        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                ReadQR qr = new ReadQR();
                MatriX = qr.Readr(path_in);
                Row = MatriX.GetUpperBound(0) + 1;
                Column = MatriX.Length / Row;
                string info = "";
                for (int a = 0; a < Row; a++)
                {
                    for (int b = 0; b < Column; b++)
                    { info += MatriX[a, b] + "   "; }
                    info += "\r\n";
                }
                MessageBox.Show(info, "Исходная матрица А");               
            }
            catch (FileNotFoundException) { MessageBox.Show("Не найден входной файл.", "Ошибка"); }
            catch (EndOfStreamException) { MessageBox.Show("Файл пуст", "Ошибка"); }
            catch (FormatException exc) { MessageBox.Show(exc.Message, "Ошибка"); };            
        }
        // Создать матрицу и вывести ее в файл input
        private void CreateMatr_Click(object sender, EventArgs e)
        {           
            try
            {            
                int rows, cols; // кол-во строк, столбцов, счетчики
                rows = Convert.ToInt32(textBox1.Text);
                cols = Convert.ToInt32(textBox2.Text);
                MatriX = new double[cols,rows];
                Random r = new Random();
                if (rows > 100 || cols > 100) { throw new FormatException(); }
                if (rows == 0 || cols == 0) { throw new Exception("Параметры не могут быть равны нулю."); }
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    { MatriX[i, j] = r.Next(-1000, 1000); }
                }
                //Отправить матрицу в файл input
                WriteQR qr = new WriteQR();
                qr.Writer(MatriX, path_in);
                MessageBox.Show("Матрица отправлена в файл", "Уведомление");
            }
           catch (FormatException) { MessageBox.Show("Размеры созданной матрицы не могут превышать 100х100 или быть неопределенными.", "Ошибка"); }
           catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
           
        }
        private void QuickRotation_Click(object sender, EventArgs e)
        {
            try
            {
                ReadQR r = new ReadQR();
                MatriX = r.Readr(path_in);
                Row = MatriX.GetUpperBound(0) + 1;
                Column = MatriX.Length / Row;
                QRdecomposition qr = new QRdecomposition();
                qr.FastRotation(MatriX);
                if (Row == Column)
                {
                   alglib.rmatrixevd(MatriX, Row, 0, out wr, out wi, out vl, out vr);
                }
                string sd = "Q" + "\r\n";
                string sr = "R" + "\r\n";
                string se = "QR" + "\r\n";
                string ss = "Собственные числа" + "\r\n";
                for (int t = 0; t < Row; t++)
                {
                    for (int i = 0; i < Column; i++)
                    {
                        sd += qr.Q[t, i].ToString("0.0000") + "   ";
                        sr += qr.R[t, i].ToString("0.0000") + "   ";
                        se += qr.QR[t, i].ToString("0.0000") + "   ";
                        if ((Row == Column) && (t == i))
                        {
                            ss += wr[i].ToString("0.0000") + " " + sigint(wi[i]) + " " + wi[i].ToString("0.0000") + "i";
                        }
                    }                    
                    sd += "\r\n";
                    sr += "\r\n";
                    se += "\r\n";
                    if (Row == Column) { ss += "\r\n"; }
                }
                if (Row != Column) { ss += "Не существуют для данной матрицы"; }
                MessageBox.Show(sd + sr + se + ss, "Метод быстрых вращений");
            }
            catch (FileNotFoundException) { MessageBox.Show("Не найден входной файл.", "Ошибка"); }
            catch (EndOfStreamException) { MessageBox.Show("Входной файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            try
            {
                ReadQR r = new ReadQR();
                MatriX = r.Readr(path_in);
                Row = MatriX.GetUpperBound(0) + 1;
                Column = MatriX.Length / Row;
                QRdecomposition qr = new QRdecomposition();
                qr.Rotation(MatriX);
                if (Row == Column)
                {
                    alglib.rmatrixevd(MatriX, Row, 0, out wr, out wi, out vl, out vr);
                }
                string sd = "Q" + "\r\n";
                string sr = "R" + "\r\n";
                string se = "QR" + "\r\n";
                string ss = "Собственные числа" + "\r\n";
                for (int t = 0; t < Row; t++)
                {
                    for (int i = 0; i < Column; i++)
                    {
                        sd += qr.Q[t, i].ToString("0.0000") + "   ";
                        sr += qr.R[t, i].ToString("0.0000") + "   ";
                        se += qr.QR[t, i].ToString("0.0000") + "   ";
                        if ((Row == Column) && (t == i)) { ss += wr[i].ToString("0.0000") + " " + sigint(wi[i]) + " " + wi[i].ToString("0.0000") + "i"; }
                    }
                    sd += "\r\n";
                    sr += "\r\n";
                    se += "\r\n";
                    if (Row == Column) { ss += "\r\n"; }
                }
                if (Row != Column) { ss += "Не существуют для данной матрицы"; }
                MessageBox.Show(sd + sr + se +ss, "Метод Гивенса");
            }
            catch (FileNotFoundException) { MessageBox.Show("Не найден входной файл", "Ошибка"); }
            catch (EndOfStreamException) { MessageBox.Show("Входной файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void HouseHolder_Click(object sender, EventArgs e)
        {
            try
            {
                ReadQR r = new ReadQR();
                MatriX = r.Readr(path_in);
                Row = MatriX.GetUpperBound(0) + 1;
                Column = MatriX.Length / Row;
                QRdecomposition qr = new QRdecomposition();
                qr.Householder(MatriX);
                if (Row == Column)
                {
                    alglib.rmatrixevd(MatriX, Row, 0, out wr, out wi, out vl, out vr);
                }
                string sd = "Q" + "\r\n";
                string sr = "R" + "\r\n";
                string se = "QR" + "\r\n";
                string ss = "Собственные числа" + "\r\n";
                for (int t = 0; t < Row; t++)
                {
                    for (int i = 0; i < Column; i++)
                    {
                        sd += qr.Q[t, i].ToString("0.0000") + "   ";
                        sr += qr.R[t, i].ToString("0.0000") + "   ";
                        se += qr.QR[t, i].ToString("0.0000") + "   ";
                        if ((Row == Column) && (t == i)) { ss += wr[i].ToString("0.0000") + " " + sigint(wi[i]) + " " + wi[i].ToString("0.0000") + "i"; }
                    }
                    sd += "\r\n";
                    sr += "\r\n";
                    se += "\r\n";
                    if (Row == Column) { ss += "\r\n"; }
                }
                if (Row != Column) { ss += "Не существуют для данной матрицы"; }
                MessageBox.Show(sd + sr + se + ss, "Метод Хаусхолдера");
            }
            catch (FileNotFoundException) { MessageBox.Show("Не найден входной файл", "Ошибка"); }
            catch (EndOfStreamException) { MessageBox.Show("Входной файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void MirrorBlock_Click(object sender, EventArgs e)
        {
            try
            {
                ReadQR r = new ReadQR();
                //MatriX = r.Readr(path_in);
                Row = MatriX.GetUpperBound(0) + 1;
                Column = MatriX.Length / Row;
                QRdecomposition qr = new QRdecomposition();
                qr.Reflections(MatriX);
                if (Row == Column)
                {
                    alglib.rmatrixevd(MatriX, Row, 0, out wr, out wi, out vl, out vr);
                }
                string sd = "Q" + "\r\n";
                string sr = "R" + "\r\n";
                string se = "QR" + "\r\n";
                string ss = "Собственные числа" + "\r\n";
                for (int t = 0; t < Row; t++)
                {
                    for (int i = 0; i < Column; i++)
                    {
                        sd += qr.Q[t, i].ToString("0.0000") + "   ";
                        sr += qr.R[t, i].ToString("0.0000") + "   ";
                        se += qr.QR[t, i].ToString("0.0000") + "   ";
                        if ((Row == Column)&&(t==i)) { ss += wr[i].ToString("0.0000") + " " + sigint(wi[i]) + " " + wi[i].ToString("0.0000")+"i"; }
                    }
                    sd += "\r\n";
                    sr += "\r\n";
                    se += "\r\n";
                    if (Row == Column) { ss += "\r\n"; }
                }
                if (Row != Column) { ss += "Не существуют для данной матрицы"; }
                MessageBox.Show(sd + sr + se + ss, "Метод блочных отражений");
            }
            catch (FileNotFoundException) { MessageBox.Show("Не найден входной файл", "Ошибка"); }
            catch (EndOfStreamException) { MessageBox.Show("Входной файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }
    }
}
