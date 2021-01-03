
namespace RSImageProgressing
{
    partial class Brovey变换
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
            this.label2 = new System.Windows.Forms.Label();
            this.openPan1 = new System.Windows.Forms.Button();
            this.openMsi1 = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "全色影像";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "多光谱影像";
            // 
            // openPan1
            // 
            this.openPan1.Location = new System.Drawing.Point(162, 118);
            this.openPan1.Name = "openPan1";
            this.openPan1.Size = new System.Drawing.Size(136, 37);
            this.openPan1.TabIndex = 2;
            this.openPan1.Text = "选择全色影像";
            this.openPan1.UseVisualStyleBackColor = true;
            this.openPan1.Click += new System.EventHandler(this.openPan1_Click);
            // 
            // openMsi1
            // 
            this.openMsi1.Location = new System.Drawing.Point(162, 30);
            this.openMsi1.Name = "openMsi1";
            this.openMsi1.Size = new System.Drawing.Size(176, 37);
            this.openMsi1.TabIndex = 3;
            this.openMsi1.Text = "选择多光谱影像";
            this.openMsi1.UseVisualStyleBackColor = true;
            this.openMsi1.Click += new System.EventHandler(this.openMsi1_Click);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(29, 215);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(140, 53);
            this.calculate.TabIndex = 4;
            this.calculate.Text = "进行变换";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(208, 215);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(141, 53);
            this.save.TabIndex = 5;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(465, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(866, 702);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 56);
            this.button1.TabIndex = 7;
            this.button1.Text = "平均梯度";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 56);
            this.button2.TabIndex = 8;
            this.button2.Text = "偏差指数";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Brovey变换
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 776);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.openMsi1);
            this.Controls.Add(this.openPan1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Brovey变换";
            this.Text = "Brovey变换";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openPan1;
        private System.Windows.Forms.Button openMsi1;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}