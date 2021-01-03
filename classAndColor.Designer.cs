
namespace RSImageProgressing
{
    partial class classAndColor
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
            this.className = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addColor = new System.Windows.Forms.Button();
            this.oK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类名";
            // 
            // className
            // 
            this.className.Location = new System.Drawing.Point(87, 22);
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(100, 21);
            this.className.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "颜色";
            // 
            // addColor
            // 
            this.addColor.Location = new System.Drawing.Point(87, 78);
            this.addColor.Name = "addColor";
            this.addColor.Size = new System.Drawing.Size(100, 24);
            this.addColor.TabIndex = 3;
            this.addColor.Text = "添加颜色";
            this.addColor.UseVisualStyleBackColor = true;
            this.addColor.Click += new System.EventHandler(this.addColor_Click);
            // 
            // oK
            // 
            this.oK.Location = new System.Drawing.Point(23, 145);
            this.oK.Name = "oK";
            this.oK.Size = new System.Drawing.Size(164, 23);
            this.oK.TabIndex = 4;
            this.oK.Text = "确认";
            this.oK.UseVisualStyleBackColor = true;
            this.oK.Click += new System.EventHandler(this.oK_Click);
            // 
            // classAndColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 202);
            this.Controls.Add(this.oK);
            this.Controls.Add(this.addColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.className);
            this.Controls.Add(this.label1);
            this.Name = "classAndColor";
            this.Text = "classAndColor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addColor;
        private System.Windows.Forms.Button oK;
    }
}