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
        string path_in = "..\\..\\input.txt";   //Хранилище Матрицы А
        string path_out = "..\\..\\output.txt"; //Хранилище матриц Q,R

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
        //Открытие файлов
        private void OpenFile_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start(path_in); }
        private void OpenOut_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start(path_out); }
        // Создать матрицу и вывести ее в файл input
        private void CreateMatr_Click(object sender, EventArgs e)
        {
            try
            {
                double rows, cols, i, j; // кол-во строк, столбцов, счетчики
                rows = Convert.ToDouble(textBox1.Text);
                cols = Convert.ToDouble(textBox2.Text);
                if (rows > 2000 || cols > 2000) { throw new FormatException(); }
                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < cols; i++)
                    {
                        //Заполнить матрицу случайными значениями от -1000 до 1000
                    }
                }
                //Отправить матрицу в файл input

                MessageBox.Show("Матрица отправлена в файл", "Уведомление");

            }
            catch (FormatException) { MessageBox.Show("Размеры созданной матрицы не могут превышать 2000х2000 или быть неопределенными", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }

        }
        /*Для каждого метода произвести QR-разложение и вывести в файл output в формате 
Q:
Марица Q
R:
Матрица R
*/

        private void QuickRotation_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FileLoadException) { MessageBox.Show("Файл не найден", "Ошибка"); }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FileLoadException) { MessageBox.Show("Файл не найден", "Ошибка"); }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void HouseHolder_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FileLoadException) { MessageBox.Show("Файл не найден", "Ошибка"); }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }

        private void MirrorBlock_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FileLoadException) { MessageBox.Show("Файл не найден", "Ошибка"); }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Файл пуст", "Ошибка"); }
            catch (FormatException) { MessageBox.Show("Некорректные данные в файле", "Ошибка"); }
            catch (Exception exc) { MessageBox.Show(exc.Message, "Ошибка"); }
        }
    }
}
