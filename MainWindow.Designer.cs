
namespace RSImageProgressing
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("文件列表");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileList = new System.Windows.Forms.ToolStripMenuItem();
            this.集合处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无人机影像粗校正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配准ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影像融合ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iHS变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brovey变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阈值分割ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阈值分割ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oSTUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息提取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmeans算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.监督分类ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ＥＮＶＩToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFile = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ToolStripButton();
            this.ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.coordanite = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileTree = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgMessge = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.直方图均衡化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线性拉伸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示光谱特征ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowImage = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHistigram = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowImageMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.监督分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.集合处理ToolStripMenuItem,
            this.影像融合ToolStripMenuItem,
            this.阈值分割ToolStripMenuItem,
            this.信息提取ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1328, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Exit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(146, 34);
            this.Open.Text = "打开";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(146, 34);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileList});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // fileList
            // 
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(182, 34);
            this.fileList.Text = "列表信息";
            this.fileList.Click += new System.EventHandler(this.listView_Click);
            // 
            // 集合处理ToolStripMenuItem
            // 
            this.集合处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.无人机影像粗校正ToolStripMenuItem,
            this.配准ToolStripMenuItem});
            this.集合处理ToolStripMenuItem.Name = "集合处理ToolStripMenuItem";
            this.集合处理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.集合处理ToolStripMenuItem.Text = "几何处理";
            // 
            // 无人机影像粗校正ToolStripMenuItem
            // 
            this.无人机影像粗校正ToolStripMenuItem.Name = "无人机影像粗校正ToolStripMenuItem";
            this.无人机影像粗校正ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.无人机影像粗校正ToolStripMenuItem.Text = "无人机影像粗校正";
            this.无人机影像粗校正ToolStripMenuItem.Click += new System.EventHandler(this.无人机影像粗校正ToolStripMenuItem_Click);
            // 
            // 配准ToolStripMenuItem
            // 
            this.配准ToolStripMenuItem.Name = "配准ToolStripMenuItem";
            this.配准ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.配准ToolStripMenuItem.Text = "配准";
            this.配准ToolStripMenuItem.Click += new System.EventHandler(this.配准ToolStripMenuItem_Click);
            // 
            // 影像融合ToolStripMenuItem
            // 
            this.影像融合ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iHS变换ToolStripMenuItem,
            this.brovey变换ToolStripMenuItem});
            this.影像融合ToolStripMenuItem.Name = "影像融合ToolStripMenuItem";
            this.影像融合ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.影像融合ToolStripMenuItem.Text = "影像融合";
            // 
            // iHS变换ToolStripMenuItem
            // 
            this.iHS变换ToolStripMenuItem.Name = "iHS变换ToolStripMenuItem";
            this.iHS变换ToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.iHS变换ToolStripMenuItem.Text = "IHS变换 (未成功)";
            this.iHS变换ToolStripMenuItem.Click += new System.EventHandler(this.iHS变换ToolStripMenuItem_Click);
            // 
            // brovey变换ToolStripMenuItem
            // 
            this.brovey变换ToolStripMenuItem.Name = "brovey变换ToolStripMenuItem";
            this.brovey变换ToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.brovey变换ToolStripMenuItem.Text = "Brovey变换";
            this.brovey变换ToolStripMenuItem.Click += new System.EventHandler(this.brovey变换ToolStripMenuItem_Click);
            // 
            // 阈值分割ToolStripMenuItem
            // 
            this.阈值分割ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.阈值分割ToolStripMenuItem1,
            this.oSTUToolStripMenuItem});
            this.阈值分割ToolStripMenuItem.Name = "阈值分割ToolStripMenuItem";
            this.阈值分割ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.阈值分割ToolStripMenuItem.Text = "影像分割";
            // 
            // 阈值分割ToolStripMenuItem1
            // 
            this.阈值分割ToolStripMenuItem1.Name = "阈值分割ToolStripMenuItem1";
            this.阈值分割ToolStripMenuItem1.Size = new System.Drawing.Size(320, 34);
            this.阈值分割ToolStripMenuItem1.Text = "迭代阈值分割";
            this.阈值分割ToolStripMenuItem1.Click += new System.EventHandler(this.阈值分割ToolStripMenuItem1_Click);
            // 
            // oSTUToolStripMenuItem
            // 
            this.oSTUToolStripMenuItem.Name = "oSTUToolStripMenuItem";
            this.oSTUToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.oSTUToolStripMenuItem.Text = "OSTU（最大类间方差）法";
            this.oSTUToolStripMenuItem.Click += new System.EventHandler(this.oSTUToolStripMenuItem_Click);
            // 
            // 信息提取ToolStripMenuItem
            // 
            this.信息提取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kmeans算法ToolStripMenuItem,
            this.监督分类ToolStripMenuItem1,
            this.监督分类ToolStripMenuItem});
            this.信息提取ToolStripMenuItem.Name = "信息提取ToolStripMenuItem";
            this.信息提取ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.信息提取ToolStripMenuItem.Text = "影像分类";
            // 
            // kmeans算法ToolStripMenuItem
            // 
            this.kmeans算法ToolStripMenuItem.Name = "kmeans算法ToolStripMenuItem";
            this.kmeans算法ToolStripMenuItem.Size = new System.Drawing.Size(310, 34);
            this.kmeans算法ToolStripMenuItem.Text = "非监督分类k-means算法";
            this.kmeans算法ToolStripMenuItem.Click += new System.EventHandler(this.kmeans算法ToolStripMenuItem_Click);
            // 
            // 监督分类ToolStripMenuItem1
            // 
            this.监督分类ToolStripMenuItem1.Name = "监督分类ToolStripMenuItem1";
            this.监督分类ToolStripMenuItem1.Size = new System.Drawing.Size(310, 34);
            this.监督分类ToolStripMenuItem1.Text = "监督分类(未完成)";
            this.监督分类ToolStripMenuItem1.Click += new System.EventHandler(this.监督分类ToolStripMenuItem1_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ＥＮＶＩToolStripMenuItem});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // 打开ＥＮＶＩToolStripMenuItem
            // 
            this.打开ＥＮＶＩToolStripMenuItem.Name = "打开ＥＮＶＩToolStripMenuItem";
            this.打开ＥＮＶＩToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.打开ＥＮＶＩToolStripMenuItem.Text = "打开ＥＮＶＩ";
            this.打开ＥＮＶＩToolStripMenuItem.Click += new System.EventHandler(this.打开ＥＮＶＩToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.listView,
            this.ZoomOut,
            this.ZoomIn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1328, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openFile
            // 
            this.openFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(34, 28);
            this.openFile.Text = "打开";
            this.openFile.Click += new System.EventHandler(this.Open_Click);
            // 
            // listView
            // 
            this.listView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.listView.Image = ((System.Drawing.Image)(resources.GetObject("listView.Image")));
            this.listView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(34, 28);
            this.listView.Text = "文件列表";
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(34, 28);
            this.ZoomOut.Text = "放大";
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(34, 28);
            this.ZoomIn.Text = "缩小";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.timeNow,
            this.coordanite});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1328, 35);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(302, 28);
            this.toolStripStatusLabel1.Text = "2018114685-罗奥杨-遥感图像处理";
            // 
            // timeNow
            // 
            this.timeNow.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.timeNow.Name = "timeNow";
            this.timeNow.Size = new System.Drawing.Size(104, 28);
            this.timeNow.Text = "当前时间：";
            // 
            // coordanite
            // 
            this.coordanite.Name = "coordanite";
            this.coordanite.Size = new System.Drawing.Size(64, 28);
            this.coordanite.Text = "坐标：";
            this.coordanite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 590);
            this.panel1.TabIndex = 3;
            // 
            // fileTree
            // 
            this.fileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTree.Location = new System.Drawing.Point(0, 0);
            this.fileTree.Name = "fileTree";
            treeNode1.Name = "节点0";
            treeNode1.Text = "文件列表";
            this.fileTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.fileTree.Size = new System.Drawing.Size(260, 590);
            this.fileTree.TabIndex = 0;
            this.fileTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileTree_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imgMessge);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1068, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 590);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // imgMessge
            // 
            this.imgMessge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgMessge.Location = new System.Drawing.Point(0, 0);
            this.imgMessge.Name = "imgMessge";
            this.imgMessge.Size = new System.Drawing.Size(260, 590);
            this.imgMessge.TabIndex = 0;
            this.imgMessge.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBox1.Location = new System.Drawing.Point(338, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(577, 506);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直方图均衡化ToolStripMenuItem,
            this.线性拉伸ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.显示光谱特征ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(189, 124);
            // 
            // 直方图均衡化ToolStripMenuItem
            // 
            this.直方图均衡化ToolStripMenuItem.Name = "直方图均衡化ToolStripMenuItem";
            this.直方图均衡化ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.直方图均衡化ToolStripMenuItem.Text = "直方图均衡化";
            this.直方图均衡化ToolStripMenuItem.Click += new System.EventHandler(this.直方图均衡化ToolStripMenuItem_Click_1);
            // 
            // 线性拉伸ToolStripMenuItem
            // 
            this.线性拉伸ToolStripMenuItem.Name = "线性拉伸ToolStripMenuItem";
            this.线性拉伸ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.线性拉伸ToolStripMenuItem.Text = "线性拉伸";
            this.线性拉伸ToolStripMenuItem.Click += new System.EventHandler(this.线性拉伸ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 显示光谱特征ToolStripMenuItem
            // 
            this.显示光谱特征ToolStripMenuItem.Name = "显示光谱特征ToolStripMenuItem";
            this.显示光谱特征ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.显示光谱特征ToolStripMenuItem.Text = "显示光谱特征";
            this.显示光谱特征ToolStripMenuItem.Click += new System.EventHandler(this.显示光谱特征ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowImage,
            this.ShowHistigram,
            this.ShowImageMessage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 94);
            // 
            // ShowImage
            // 
            this.ShowImage.Name = "ShowImage";
            this.ShowImage.Size = new System.Drawing.Size(188, 30);
            this.ShowImage.Text = "显示图片";
            this.ShowImage.Click += new System.EventHandler(this.ShowImage_Click);
            // 
            // ShowHistigram
            // 
            this.ShowHistigram.Name = "ShowHistigram";
            this.ShowHistigram.Size = new System.Drawing.Size(188, 30);
            this.ShowHistigram.Text = "显示直方图";
            this.ShowHistigram.Click += new System.EventHandler(this.ShowHistigram_Click);
            // 
            // ShowImageMessage
            // 
            this.ShowImageMessage.Name = "ShowImageMessage";
            this.ShowImageMessage.Size = new System.Drawing.Size(188, 30);
            this.ShowImageMessage.Text = "显示图片信息";
            this.ShowImageMessage.Click += new System.EventHandler(this.ShowImageMessage_Click);
            // 
            // 监督分类ToolStripMenuItem
            // 
            this.监督分类ToolStripMenuItem.Name = "监督分类ToolStripMenuItem";
            this.监督分类ToolStripMenuItem.Size = new System.Drawing.Size(310, 34);
            this.监督分类ToolStripMenuItem.Text = "监督分类";
            this.监督分类ToolStripMenuItem.Click += new System.EventHandler(this.监督分类ToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 690);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "遥感图像处理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel timeNow;
        private System.Windows.Forms.ToolStripStatusLabel coordanite;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton openFile;
        private System.Windows.Forms.ToolStripButton listView;
        private System.Windows.Forms.ToolStripButton ZoomOut;
        private System.Windows.Forms.ToolStripButton ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox imgMessge;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowImage;
        private System.Windows.Forms.ToolStripMenuItem ShowHistigram;
        private System.Windows.Forms.ToolStripMenuItem ShowImageMessage;
        private System.Windows.Forms.ToolStripMenuItem 集合处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无人机影像粗校正ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配准ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影像融合ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阈值分割ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息提取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmeans算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监督分类ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 直方图均衡化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线性拉伸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iHS变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brovey变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示光谱特征ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阈值分割ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oSTUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ＥＮＶＩToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监督分类ToolStripMenuItem;
    }
}

