namespace QRsach
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateMatr = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.HouseHolder = new System.Windows.Forms.Button();
            this.MirrorBlock = new System.Windows.Forms.Button();
            this.Rotation = new System.Windows.Forms.Button();
            this.QuickRotation = new System.Windows.Forms.Button();
            this.OpenOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строки";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Столбцы";
            // 
            // CreateMatr
            // 
            this.CreateMatr.Location = new System.Drawing.Point(164, 13);
            this.CreateMatr.Name = "CreateMatr";
            this.CreateMatr.Size = new System.Drawing.Size(80, 52);
            this.CreateMatr.TabIndex = 4;
            this.CreateMatr.Text = "Создать Матрицу";
            this.CreateMatr.UseVisualStyleBackColor = true;
            this.CreateMatr.Click += new System.EventHandler(this.CreateMatr_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(250, 13);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(80, 52);
            this.OpenFile.TabIndex = 5;
            this.OpenFile.Text = "Открыть Файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // HouseHolder
            // 
            this.HouseHolder.Location = new System.Drawing.Point(12, 145);
            this.HouseHolder.Name = "HouseHolder";
            this.HouseHolder.Size = new System.Drawing.Size(150, 60);
            this.HouseHolder.TabIndex = 14;
            this.HouseHolder.Text = "Метод Хаусхолдера";
            this.HouseHolder.Click += new System.EventHandler(this.HouseHolder_Click);
            // 
            // MirrorBlock
            // 
            this.MirrorBlock.Location = new System.Drawing.Point(180, 145);
            this.MirrorBlock.Name = "MirrorBlock";
            this.MirrorBlock.Size = new System.Drawing.Size(150, 60);
            this.MirrorBlock.TabIndex = 13;
            this.MirrorBlock.Text = "Метод блочных отражений";
            this.MirrorBlock.Click += new System.EventHandler(this.MirrorBlock_Click);
            // 
            // Rotation
            // 
            this.Rotation.Location = new System.Drawing.Point(180, 79);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(150, 60);
            this.Rotation.TabIndex = 12;
            this.Rotation.Text = "Метод Гивенса";
            this.Rotation.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // QuickRotation
            // 
            this.QuickRotation.Location = new System.Drawing.Point(12, 79);
            this.QuickRotation.Name = "QuickRotation";
            this.QuickRotation.Size = new System.Drawing.Size(150, 60);
            this.QuickRotation.TabIndex = 11;
            this.QuickRotation.Text = "Метод быстрых вращений";
            this.QuickRotation.Click += new System.EventHandler(this.QuickRotation_Click);
            // 
            // OpenOut
            // 
            this.OpenOut.Location = new System.Drawing.Point(12, 211);
            this.OpenOut.Name = "OpenOut";
            this.OpenOut.Size = new System.Drawing.Size(318, 50);
            this.OpenOut.TabIndex = 10;
            this.OpenOut.Text = "Открыть выходной файл";
            this.OpenOut.UseVisualStyleBackColor = true;
            this.OpenOut.Click += new System.EventHandler(this.OpenOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 273);
            this.Controls.Add(this.OpenOut);
            this.Controls.Add(this.QuickRotation);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.MirrorBlock);
            this.Controls.Add(this.HouseHolder);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.CreateMatr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "QR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateMatr;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button HouseHolder;
        private System.Windows.Forms.Button MirrorBlock;
        private System.Windows.Forms.Button Rotation;
        private System.Windows.Forms.Button QuickRotation;
        private System.Windows.Forms.Button OpenOut;
    }
}

