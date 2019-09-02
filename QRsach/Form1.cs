using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRsach
{
    public partial class Form1 : Form
    {
        string path_in = "..\\..\\input.txt";
        string path_out = "..\\..\\output.txt";
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

        }
        /*Для каждого метода произвести QR-разложение и вывести в файл output в формате 
        Q:
        Марица Q
        R:
        Матрица R
        */
        private void HouseHolder_Click(object sender, EventArgs e)
        {

        }

        private void MirrorBlock_Click(object sender, EventArgs e)
        {

        }

        private void Rotation_Click(object sender, EventArgs e)
        {

        }

        private void QuickRotation_Click(object sender, EventArgs e)
        {

        }
    }
}
