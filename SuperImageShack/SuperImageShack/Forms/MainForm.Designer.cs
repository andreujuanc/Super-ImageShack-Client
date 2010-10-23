namespace SuperImageShack
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_previewPictureBox = new System.Windows.Forms.PictureBox();
            this.dataFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.m_upload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeWindowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutSuperImageShackClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_contextMenu_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_previewPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.m_contextMenu_notify.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.AllowDrop = true;
            resources.ApplyResources(this.m_splitContainer, "m_splitContainer");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_previewPictureBox);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.dataFlowLayout);
            this.m_splitContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.m_splitContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            // 
            // m_previewPictureBox
            // 
            this.m_previewPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            resources.ApplyResources(this.m_previewPictureBox, "m_previewPictureBox");
            this.m_previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_previewPictureBox.Name = "m_previewPictureBox";
            this.m_previewPictureBox.TabStop = false;
            this.m_previewPictureBox.Click += new System.EventHandler(this.m_previewPictureBox_Click);
            // 
            // dataFlowLayout
            // 
            resources.ApplyResources(this.dataFlowLayout, "dataFlowLayout");
            this.dataFlowLayout.Name = "dataFlowLayout";
            // 
            // m_upload
            // 
            resources.ApplyResources(this.m_upload, "m_upload");
            this.m_upload.Name = "m_upload";
            this.m_upload.UseVisualStyleBackColor = true;
            this.m_upload.Click += new System.EventHandler(this.m_upload_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.takeToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // takeToolStripMenuItem
            // 
            this.takeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromDesktopToolStripMenuItem,
            this.activeWindowToolStripMenuItem1});
            this.takeToolStripMenuItem.Name = "takeToolStripMenuItem";
            resources.ApplyResources(this.takeToolStripMenuItem, "takeToolStripMenuItem");
            // 
            // fromDesktopToolStripMenuItem
            // 
            this.fromDesktopToolStripMenuItem.Name = "fromDesktopToolStripMenuItem";
            resources.ApplyResources(this.fromDesktopToolStripMenuItem, "fromDesktopToolStripMenuItem");
            this.fromDesktopToolStripMenuItem.Click += new System.EventHandler(this.fromDesktopToolStripMenuItem_Click);
            // 
            // activeWindowToolStripMenuItem1
            // 
            resources.ApplyResources(this.activeWindowToolStripMenuItem1, "activeWindowToolStripMenuItem1");
            this.activeWindowToolStripMenuItem1.Name = "activeWindowToolStripMenuItem1";
            this.activeWindowToolStripMenuItem1.Click += new System.EventHandler(this.activeWindowToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutSuperImageShackClientToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            resources.ApplyResources(this.viewHelpToolStripMenuItem, "viewHelpToolStripMenuItem");
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // aboutSuperImageShackClientToolStripMenuItem
            // 
            this.aboutSuperImageShackClientToolStripMenuItem.Name = "aboutSuperImageShackClientToolStripMenuItem";
            resources.ApplyResources(this.aboutSuperImageShackClientToolStripMenuItem, "aboutSuperImageShackClientToolStripMenuItem");
            this.aboutSuperImageShackClientToolStripMenuItem.Click += new System.EventHandler(this.aboutSuperImageShackClientToolStripMenuItem_Click);
            // 
            // m_uploadProgressBar
            // 
            resources.ApplyResources(this.m_uploadProgressBar, "m_uploadProgressBar");
            this.m_uploadProgressBar.Name = "m_uploadProgressBar";
            this.m_uploadProgressBar.Step = 2;
            // 
            // m_notifyIcon
            // 
            resources.ApplyResources(this.m_notifyIcon, "m_notifyIcon");
            this.m_notifyIcon.ContextMenuStrip = this.m_contextMenu_notify;
            this.m_notifyIcon.DoubleClick += new System.EventHandler(this.m_notifyIcon_DoubleClick);
            // 
            // m_contextMenu_notify
            // 
            this.m_contextMenu_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem1});
            this.m_contextMenu_notify.Name = "m_contextMenu_notify";
            resources.ApplyResources(this.m_contextMenu_notify, "m_contextMenu_notify");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desktopPictureToolStripMenuItem,
            this.activeWindowToolStripMenuItem,
            this.fromFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // desktopPictureToolStripMenuItem
            // 
            this.desktopPictureToolStripMenuItem.Name = "desktopPictureToolStripMenuItem";
            resources.ApplyResources(this.desktopPictureToolStripMenuItem, "desktopPictureToolStripMenuItem");
            this.desktopPictureToolStripMenuItem.Click += new System.EventHandler(this.desktopPictureToolStripMenuItem_Click);
            // 
            // activeWindowToolStripMenuItem
            // 
            this.activeWindowToolStripMenuItem.Name = "activeWindowToolStripMenuItem";
            resources.ApplyResources(this.activeWindowToolStripMenuItem, "activeWindowToolStripMenuItem");
            this.activeWindowToolStripMenuItem.Click += new System.EventHandler(this.activeWindowToolStripMenuItem_Click);
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            resources.ApplyResources(this.fromFileToolStripMenuItem, "fromFileToolStripMenuItem");
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_uploadProgressBar);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.m_upload);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_previewPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.m_contextMenu_notify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_upload;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private System.Windows.Forms.PictureBox m_previewPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutSuperImageShackClientToolStripMenuItem;
        private System.Windows.Forms.ProgressBar m_uploadProgressBar;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu_notify;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem desktopPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel dataFlowLayout;
        private System.Windows.Forms.ToolStripMenuItem takeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fromDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeWindowToolStripMenuItem1;
    }
}

