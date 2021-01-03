
namespace RSImageProgressing
{
    partial class IHS变换
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
            this.save = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.openMsi1 = new System.Windows.Forms.Button();
            this.openPan1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(215, 213);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(141, 53);
            this.save.TabIndex = 11;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(36, 213);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(140, 53);
            this.calculate.TabIndex = 10;
            this.calculate.Text = "进行变换";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // openMsi1
            // 
            this.openMsi1.Location = new System.Drawing.Point(169, 28);
            this.openMsi1.Name = "openMsi1";
            this.openMsi1.Size = new System.Drawing.Size(176, 37);
            this.openMsi1.TabIndex = 9;
            this.openMsi1.Text = "选择多光谱影像";
            this.openMsi1.UseVisualStyleBackColor = true;
            this.openMsi1.Click += new System.EventHandler(this.openMsi1_Click);
            // 
            // openPan1
            // 
            this.openPan1.Location = new System.Drawing.Point(169, 116);
            this.openPan1.Name = "openPan1";
            this.openPan1.Size = new System.Drawing.Size(136, 37);
            this.openPan1.TabIndex = 8;
            this.openPan1.Text = "选择全色影像";
            this.openPan1.UseVisualStyleBackColor = true;
            this.openPan1.Click += new System.EventHandler(this.openPan1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "多光谱影像";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "全色影像";
            // 
            // IHS变换
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 705);
            this.Controls.Add(this.save);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.openMsi1);
            this.Controls.Add(this.openPan1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IHS变换";
            this.Text = "IHS变换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button openMsi1;
        private System.Windows.Forms.Button openPan1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}