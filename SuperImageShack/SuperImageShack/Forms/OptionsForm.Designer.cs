namespace SuperImageShack
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.m_languages = new System.Windows.Forms.ComboBox();
            this.m_ok = new System.Windows.Forms.Button();
            this.m_startwithwindows = new System.Windows.Forms.CheckBox();
            this.m_minimized = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_uploadCombo = new System.Windows.Forms.ComboBox();
            this.m_activeWindowCombo = new System.Windows.Forms.ComboBox();
            this.m_fullDesktopCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_supertake = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // m_languages
            // 
            this.m_languages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_languages.FormattingEnabled = true;
            resources.ApplyResources(this.m_languages, "m_languages");
            this.m_languages.Name = "m_languages";
            // 
            // m_ok
            // 
            resources.ApplyResources(this.m_ok, "m_ok");
            this.m_ok.Name = "m_ok";
            this.m_ok.UseVisualStyleBackColor = true;
            this.m_ok.Click += new System.EventHandler(this.m_ok_Click);
            // 
            // m_startwithwindows
            // 
            resources.ApplyResources(this.m_startwithwindows, "m_startwithwindows");
            this.m_startwithwindows.Name = "m_startwithwindows";
            this.m_startwithwindows.UseVisualStyleBackColor = true;
            this.m_startwithwindows.CheckedChanged += new System.EventHandler(this.m_startwithwindows_CheckedChanged);
            // 
            // m_minimized
            // 
            resources.ApplyResources(this.m_minimized, "m_minimized");
            this.m_minimized.Name = "m_minimized";
            this.m_minimized.UseVisualStyleBackColor = true;
            this.m_minimized.CheckedChanged += new System.EventHandler(this.m_minimized_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.m_supertake);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_uploadCombo);
            this.groupBox1.Controls.Add(this.m_activeWindowCombo);
            this.groupBox1.Controls.Add(this.m_fullDesktopCombo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_uploadCombo
            // 
            resources.ApplyResources(this.m_uploadCombo, "m_uploadCombo");
            this.m_uploadCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_uploadCombo.FormattingEnabled = true;
            this.m_uploadCombo.Name = "m_uploadCombo";
            // 
            // m_activeWindowCombo
            // 
            resources.ApplyResources(this.m_activeWindowCombo, "m_activeWindowCombo");
            this.m_activeWindowCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_activeWindowCombo.FormattingEnabled = true;
            this.m_activeWindowCombo.Name = "m_activeWindowCombo";
            // 
            // m_fullDesktopCombo
            // 
            resources.ApplyResources(this.m_fullDesktopCombo, "m_fullDesktopCombo");
            this.m_fullDesktopCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_fullDesktopCombo.FormattingEnabled = true;
            this.m_fullDesktopCombo.Name = "m_fullDesktopCombo";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // m_supertake
            // 
            resources.ApplyResources(this.m_supertake, "m_supertake");
            this.m_supertake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_supertake.FormattingEnabled = true;
            this.m_supertake.Name = "m_supertake";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_minimized);
            this.Controls.Add(this.m_startwithwindows);
            this.Controls.Add(this.m_ok);
            this.Controls.Add(this.m_languages);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_languages;
        private System.Windows.Forms.Button m_ok;
        private System.Windows.Forms.CheckBox m_startwithwindows;
        private System.Windows.Forms.CheckBox m_minimized;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_fullDesktopCombo;
        private System.Windows.Forms.ComboBox m_uploadCombo;
        private System.Windows.Forms.ComboBox m_activeWindowCombo;
        private System.Windows.Forms.ComboBox m_supertake;
        private System.Windows.Forms.Label label5;
    }
}