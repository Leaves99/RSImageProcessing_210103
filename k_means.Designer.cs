
namespace RSImageProgressing
{
    partial class k_means
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
            this.classNumber = new System.Windows.Forms.Label();
            this.classNum = new System.Windows.Forms.DomainUpDown();
            this.ChangeSe = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxIter = new System.Windows.Forms.DomainUpDown();
            this.outFile = new System.Windows.Forms.GroupBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.outFilename = new System.Windows.Forms.Label();
            this.calculate = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // classNumber
            // 
            this.classNumber.AutoSize = true;
            this.classNumber.Location = new System.Drawing.Point(14, 99);
            this.classNumber.Name = "classNumber";
            this.classNumber.Size = new System.Drawing.Size(62, 18);
            this.classNumber.TabIndex = 2;
            this.classNumber.Text = "类别数";
            // 
            // classNum
            // 
            this.classNum.Items.Add("1");
            this.classNum.Items.Add("2");
            this.classNum.Items.Add("3");
            this.classNum.Items.Add("4");
            this.classNum.Items.Add("5");
            this.classNum.Items.Add("6");
            this.classNum.Items.Add("7");
            this.classNum.Items.Add("8");
            this.classNum.Location = new System.Drawing.Point(267, 99);
            this.classNum.Name = "classNum";
            this.classNum.Size = new System.Drawing.Size(166, 28);
            this.classNum.TabIndex = 4;
            // 
            // ChangeSe
            // 
            this.ChangeSe.AutoSize = true;
            this.ChangeSe.Location = new System.Drawing.Point(12, 166);
            this.ChangeSe.Name = "ChangeSe";
            this.ChangeSe.Size = new System.Drawing.Size(242, 18);
            this.ChangeSe.TabIndex = 5;
            this.ChangeSe.Text = "聚类中心变化阈值（0-100%）";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(134, 28);
            this.textBox2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "最大迭代次数";
            // 
            // maxIter
            // 
            this.maxIter.Items.Add("1");
            this.maxIter.Items.Add("2");
            this.maxIter.Items.Add("3");
            this.maxIter.Items.Add("4");
            this.maxIter.Items.Add("5");
            this.maxIter.Items.Add("6");
            this.maxIter.Items.Add("7");
            this.maxIter.Items.Add("8");
            this.maxIter.Items.Add("9");
            this.maxIter.Items.Add("10");
            this.maxIter.Location = new System.Drawing.Point(267, 224);
            this.maxIter.Name = "maxIter";
            this.maxIter.Size = new System.Drawing.Size(165, 28);
            this.maxIter.TabIndex = 8;
            // 
            // outFile
            // 
            this.outFile.Controls.Add(this.saveFile);
            this.outFile.Controls.Add(this.textBox3);
            this.outFile.Controls.Add(this.outFilename);
            this.outFile.Location = new System.Drawing.Point(15, 295);
            this.outFile.Name = "outFile";
            this.outFile.Size = new System.Drawing.Size(376, 198);
            this.outFile.TabIndex = 10;
            this.outFile.TabStop = false;
            this.outFile.Text = "输出";
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(6, 136);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(86, 40);
            this.saveFile.TabIndex = 2;
            this.saveFile.Text = "保存";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 90);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(296, 28);
            this.textBox3.TabIndex = 1;
            // 
            // outFilename
            // 
            this.outFilename.AutoSize = true;
            this.outFilename.Location = new System.Drawing.Point(6, 51);
            this.outFilename.Name = "outFilename";
            this.outFilename.Size = new System.Drawing.Size(80, 18);
            this.outFilename.TabIndex = 0;
            this.outFilename.Text = "输出文件";
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(22, 553);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(94, 46);
            this.calculate.TabIndex = 11;
            this.calculate.Text = "计算";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(195, 553);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(122, 46);
            this.close.TabIndex = 12;
            this.close.Text = "退出";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "%";
            // 
            // k_means
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 692);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.close);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.outFile);
            this.Controls.Add(this.maxIter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ChangeSe);
            this.Controls.Add(this.classNum);
            this.Controls.Add(this.classNumber);
            this.Name = "k_means";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "k_means";
            this.outFile.ResumeLayout(false);
            this.outFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label classNumber;
        private System.Windows.Forms.DomainUpDown classNum;
        private System.Windows.Forms.Label ChangeSe;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown maxIter;
        private System.Windows.Forms.GroupBox outFile;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label outFilename;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label3;
    }
}