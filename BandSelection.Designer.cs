
namespace RSImageProgressing
{
    partial class BandSelection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.three21Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.band3Com = new System.Windows.Forms.ComboBox();
            this.band2Com = new System.Windows.Forms.ComboBox();
            this.band1Com = new System.Windows.Forms.ComboBox();
            this.band3Label = new System.Windows.Forms.Label();
            this.band2Label = new System.Windows.Forms.Label();
            this.band1Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.three21Button);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "快速操作";
            // 
            // three21Button
            // 
            this.three21Button.Location = new System.Drawing.Point(90, 91);
            this.three21Button.Name = "three21Button";
            this.three21Button.Size = new System.Drawing.Size(302, 54);
            this.three21Button.TabIndex = 0;
            this.three21Button.Text = "真彩色合成（3：2：1）";
            this.three21Button.UseVisualStyleBackColor = true;
            this.three21Button.Click += new System.EventHandler(this.three21Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.selectButton);
            this.groupBox2.Controls.Add(this.band3Com);
            this.groupBox2.Controls.Add(this.band2Com);
            this.groupBox2.Controls.Add(this.band1Com);
            this.groupBox2.Controls.Add(this.band3Label);
            this.groupBox2.Controls.Add(this.band2Label);
            this.groupBox2.Controls.Add(this.band1Label);
            this.groupBox2.Location = new System.Drawing.Point(13, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "波段选择";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(364, 68);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 138);
            this.selectButton.TabIndex = 6;
            this.selectButton.Text = "确认";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // band3Com
            // 
            this.band3Com.FormattingEnabled = true;
            this.band3Com.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.band3Com.Location = new System.Drawing.Point(138, 185);
            this.band3Com.Name = "band3Com";
            this.band3Com.Size = new System.Drawing.Size(121, 26);
            this.band3Com.TabIndex = 5;
            // 
            // band2Com
            // 
            this.band2Com.FormattingEnabled = true;
            this.band2Com.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.band2Com.Location = new System.Drawing.Point(138, 111);
            this.band2Com.Name = "band2Com";
            this.band2Com.Size = new System.Drawing.Size(121, 26);
            this.band2Com.TabIndex = 4;
            // 
            // band1Com
            // 
            this.band1Com.FormattingEnabled = true;
            this.band1Com.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.band1Com.Location = new System.Drawing.Point(138, 42);
            this.band1Com.Name = "band1Com";
            this.band1Com.Size = new System.Drawing.Size(121, 26);
            this.band1Com.TabIndex = 3;
            // 
            // band3Label
            // 
            this.band3Label.AutoSize = true;
            this.band3Label.Location = new System.Drawing.Point(24, 188);
            this.band3Label.Name = "band3Label";
            this.band3Label.Size = new System.Drawing.Size(53, 18);
            this.band3Label.TabIndex = 2;
            this.band3Label.Text = "Band3";
            // 
            // band2Label
            // 
            this.band2Label.AutoSize = true;
            this.band2Label.Location = new System.Drawing.Point(24, 114);
            this.band2Label.Name = "band2Label";
            this.band2Label.Size = new System.Drawing.Size(53, 18);
            this.band2Label.TabIndex = 1;
            this.band2Label.Text = "Band2";
            // 
            // band1Label
            // 
            this.band1Label.AutoSize = true;
            this.band1Label.Location = new System.Drawing.Point(24, 45);
            this.band1Label.Name = "band1Label";
            this.band1Label.Size = new System.Drawing.Size(53, 18);
            this.band1Label.TabIndex = 0;
            this.band1Label.Text = "Band1";
            // 
            // BandSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 580);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BandSelection";
            this.Text = "BandSelection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button three21Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ComboBox band3Com;
        private System.Windows.Forms.ComboBox band2Com;
        private System.Windows.Forms.ComboBox band1Com;
        private System.Windows.Forms.Label band3Label;
        private System.Windows.Forms.Label band2Label;
        private System.Windows.Forms.Label band1Label;
    }
}