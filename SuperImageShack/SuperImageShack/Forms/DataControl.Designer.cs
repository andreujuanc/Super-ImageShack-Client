namespace SuperImageShack
{
    partial class DataControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_title = new System.Windows.Forms.Label();
            this.m_content = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_title
            // 
            this.m_title.AutoSize = true;
            this.m_title.Location = new System.Drawing.Point(3, 5);
            this.m_title.Name = "m_title";
            this.m_title.Size = new System.Drawing.Size(35, 13);
            this.m_title.TabIndex = 0;
            this.m_title.Text = "label1";
            // 
            // m_content
            // 
            this.m_content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_content.Location = new System.Drawing.Point(6, 21);
            this.m_content.Name = "m_content";
            this.m_content.Size = new System.Drawing.Size(270, 20);
            this.m_content.TabIndex = 1;
            this.m_content.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_content_MouseClick);
            this.m_content.Enter += new System.EventHandler(this.m_content_Enter);
            // 
            // DataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_content);
            this.Controls.Add(this.m_title);
            this.Name = "DataControl";
            this.Size = new System.Drawing.Size(279, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_title;
        private System.Windows.Forms.TextBox m_content;
    }
}
