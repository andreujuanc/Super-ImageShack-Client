using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace SuperImageShack
{
    public partial class OptionsForm : Form
    {
        public MainForm MainForm { get; set; }
        public OptionsForm()
        {
            InitializeComponent();
            m_languages.Items.Add(CultureInfo.GetCultureInfo("en"));
            m_languages.Items.Add(CultureInfo.GetCultureInfo("es"));
            try
            {
                m_languages.SelectedItem = CultureInfo.CurrentUICulture;
            }
            catch
            {
                m_languages.SelectedIndex = 0;
            }
            this.m_languages.SelectedIndexChanged += new System.EventHandler(this.m_languages_SelectedIndexChanged);
            this.m_activeWindowCombo.SelectedIndexChanged += new System.EventHandler(this.m_activeWindowCombo_SelectedIndexChanged);
            this.m_fullDesktopCombo.SelectedIndexChanged += new System.EventHandler(this.m_fullDesktopCombo_SelectedIndexChanged);
            this.m_uploadCombo.SelectedIndexChanged += new System.EventHandler(this.m_uploadCombo_SelectedIndexChanged);
            this.m_supertake.SelectedIndexChanged += new EventHandler(m_supertake_SelectedIndexChanged);

        }

        protected override void OnLoad(EventArgs e)
        {
            m_startwithwindows.Checked = MainForm.StartWithWindows;
            m_minimized.Checked = MainForm.StartMinimized;
            LoadCombos();
            base.OnLoad(e);
        }

        private void LoadCombos()
        {
            m_fullDesktopCombo.Items.AddRange(new object[] { Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12 });
            m_activeWindowCombo.Items.AddRange(new object[] { Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12 });
            m_uploadCombo.Items.AddRange(new object[] { Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12 });
            m_supertake.Items.AddRange(new object[] { Keys.Control, Keys.Shift, Keys.Alt });

            m_fullDesktopCombo.SelectedItem = ApplicationManager.Current.Keys[SuperImageShack.MainForm.Functions.GetFullScreen];
            m_activeWindowCombo.SelectedItem = ApplicationManager.Current.Keys[SuperImageShack.MainForm.Functions.GetActiveWindow];
            m_uploadCombo.SelectedItem = ApplicationManager.Current.Keys[SuperImageShack.MainForm.Functions.Upload];
            m_supertake.SelectedItem = ApplicationManager.Current.Keys[SuperImageShack.MainForm.Functions.SuperTake];

        }
        private void m_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_languages.SelectedItem is CultureInfo)
            {
                CultureInfo selectedCI = (CultureInfo)m_languages.SelectedItem;

                if (selectedCI != null)
                    Thread.CurrentThread.CurrentUICulture = selectedCI;
                ChangeUILanguage();
                MainForm.SaveSettings();
            }
        }

        private void ChangeUILanguage()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            MainForm.ApplyResources(this,resources);
            if (MainForm != null)
                MainForm.Reload();
            
        }

        private void m_startwithwindows_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.StartWithWindows = m_startwithwindows.Checked;
            MainForm.SaveSettings();
        }

        private void m_minimized_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.StartMinimized = m_minimized.Checked;
            MainForm.SaveSettings();
        }

        private void m_fullDesktopCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationManager.Current.RegisterKey(SuperImageShack.MainForm.Functions.GetFullScreen, (Keys)m_fullDesktopCombo.SelectedItem, this.MainForm);
            MainForm.SaveSettings();
        }

        private void m_activeWindowCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationManager.Current.RegisterKey(SuperImageShack.MainForm.Functions.GetActiveWindow, (Keys)m_activeWindowCombo.SelectedItem, this.MainForm);
            MainForm.SaveSettings();
        }

        private void m_uploadCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationManager.Current.RegisterKey(SuperImageShack.MainForm.Functions.Upload, (Keys)m_uploadCombo.SelectedItem, this.MainForm);
            MainForm.SaveSettings();
        }

        private void m_supertake_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
