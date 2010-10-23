using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Configuration;
using SuperImageShack.Forms;

namespace SuperImageShack
{
    public partial class MainForm : Form
    {
        public enum Functions
        {
            GetFullScreen,
            GetActiveWindow,
            Upload,
            SuperTake, 
            SuperTakeActive
        }

        public bool StartWithWindows { get; set; }
        public bool StartMinimized { get; set; }

        
 
        public MainForm()
        {
            InitializeComponent();
          

            ApplicationManager.Current.UploadingStarting += new EventHandler(Current_UploadingStarting);
            ApplicationManager.Current.UploadingStep += new EventHandler<UploadingStepEventArgs>(Current_UploadingStep);
            ApplicationManager.Current.UploadingComplete += new EventHandler<UploadCompletedEventArgs>(Current_UploadingComplete);
            ApplicationManager.Current.DataReceived += new DataReceivedEventhandler(Current_DataReceived);
            ApplicationManager.Current.ImageChanged += new EventHandler(Current_ImageChanged);
        }

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            LoadSettings();
            Reload();
            activeWindowToolStripMenuItem.Enabled = false;
            if (StartMinimized)
                this.WindowState = FormWindowState.Minimized;
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Tools.WM_HOTKEY)
            {
                if ((int)m.WParam == ApplicationManager.Current.Keys[Functions.GetFullScreen].ToString().GetHashCode())
                {
                    GetFullScreenshot(false);
                    m_upload.Enabled = true;
                    BringWindowToFront();
                }
                else if ((int)m.WParam == ApplicationManager.Current.Keys[Functions.GetActiveWindow].ToString().GetHashCode())
                {
                    GetActiveWindowsScreenshot(Tools.GetForegroundWindow(), false);
                    m_upload.Enabled = true;
                    BringWindowToFront();

                }
                else if ((int)m.WParam == ApplicationManager.Current.Keys[Functions.Upload].ToString().GetHashCode())
                {
                    if (ApplicationManager.Current.CurrentScreenShot != null && ApplicationManager.Current.State != ThreadState.Running)
                    {
                        ShowBalloon(Resource.notify_uploading);
                        UploadImage(false);
                    }
                }
                else if ((int)m.WParam == ApplicationManager.Current.Keys[Functions.SuperTake].ToString().GetHashCode())
                {
                    if (ApplicationManager.Current.State != ThreadState.Running)
                    {
                        GetFullScreenshot(false);
                        ShowBalloon(Resource.notify_uploading);

                        UploadImage(true);
                    }
                }
                else if ((int)m.WParam == ApplicationManager.Current.Keys[Functions.SuperTakeActive].ToString().GetHashCode())
                {
                    if (ApplicationManager.Current.State != ThreadState.Running)
                    {
                        GetActiveWindowsScreenshot(Tools.GetForegroundWindow(), false);
                        ShowBalloon(Resource.notify_uploading);

                        UploadImage(true);
                    }
                }
            }
        }

        #endregion

        #region ImageRelated_Eventhandlers
        void Current_ImageChanged(object sender, EventArgs e)
        {
            if (ApplicationManager.Current.CurrentScreenShot != null || (m_previewPictureBox.Image != null && ApplicationManager.Current.CurrentScreenShot != m_previewPictureBox.Image))
            {
                if (m_previewPictureBox.BackgroundImage != null)
                    m_previewPictureBox.BackgroundImage.Dispose();
                GC.Collect();
                m_previewPictureBox.BackgroundImage = ApplicationManager.Current.CurrentScreenShot;
                m_upload.Enabled = true;
            }
            else if (m_previewPictureBox.Image == null)
                m_upload.Enabled = false;
        }

        

        int Current_DataReceived(object sender, DataReceivedEventArgs e)
        {
            return (m_uploadProgressBar.Maximum - m_uploadProgressBar.Value) / e.ControlsToCreate;
        }

        void Current_UploadingComplete(object sender, UploadCompletedEventArgs e)
        {
            this.Invoke(new ThreadStart(() =>
            {
                m_upload.Enabled = true;
                m_uploadProgressBar.Value = m_uploadProgressBar.Maximum;
                if (e.Data is bool)
                {
                    if((bool)e.Data)
                    if (!string.IsNullOrEmpty(e.ImageUrl))
                    {
                        Clipboard.SetText(e.ImageUrl);
                        ShowBalloon(Resource.notify_uploaded);
                    }
                }
            }
            ));
        }

        void Current_UploadingStep(object sender, UploadingStepEventArgs e)
        {
            InvokePerformStep();
            if (e.DataControl != null)
            {
                e.DataControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                e.DataControl.Width = m_splitContainer.Panel2.Width - 20;
                this.Invoke(new ThreadStart(() =>
                    dataFlowLayout.Controls.Add(e.DataControl)
                ));
            }
        }

        void Current_UploadingStarting(object sender, EventArgs e)
        {
            this.Invoke(new ThreadStart(() =>
            {
                m_upload.Enabled =false;
                m_uploadProgressBar.Value = 0;
                dataFlowLayout.Controls.Clear();
            }
            ));
        }

        #endregion


        private void ShowBalloon(string text)
        {
            m_notifyIcon.BalloonTipTitle = "Super ImageShack Client v1.0";
            m_notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            m_notifyIcon.BalloonTipText = text;
            m_notifyIcon.ShowBalloonTip(600);
        }

        #region Main

        private void UploadImage(bool showBalloon)
        {
            if (ApplicationManager.Current.State == ThreadState.Stopped)
            {
                m_upload.Enabled = false;
                m_uploadProgressBar.Value = 0;
                ApplicationManager.Current.UploadImageAsync(showBalloon);
            }
        }

        private void GetActiveWindowsScreenshot(IntPtr hwnd, bool show)
        {
            WINDOWINFO info = new WINDOWINFO();
            if (Tools.GetWindowInfo(hwnd, out info))
            {
                if (info.rcClient.Size.Width < 1)
                    return;

                 ApplicationManager.Current.TakeScreenShot(  
                                                            info.rcClient.Size.Width,
                                                            info.rcClient.Size.Height,
                                                            info.rcClient.Left,
                                                            info.rcClient.Top,
                                                            PixelFormat.Format32bppArgb);
            }
        }

        private void GetFullScreenshot(bool show)
        {
            ApplicationManager.Current.TakeScreenShot(
                                                        Screen.PrimaryScreen.Bounds.Width,
                                                        Screen.PrimaryScreen.Bounds.Height,
                                                        Screen.PrimaryScreen.Bounds.X,
                                                        Screen.PrimaryScreen.Bounds.Y,
                                                        PixelFormat.Format32bppArgb);
        }

        #endregion

        private void m_upload_Click(object sender, EventArgs e)
        {
            UploadImage(false);         
        }
        
        #region multilanguageCode

        internal void Reload()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ApplyResources(this, resources);
        }

        //This is a Hack, there should be a better way to do this,like getting the form's private fields.
        public void ApplyResources(Control form, System.ComponentModel.ComponentResourceManager resources)
        {
            foreach (Control item in form.Controls)
            {
                if (item is MenuStrip) 
                {
                    resources.ApplyResources(item, item.Name);
                    ApplyResourcesToMenu(resources, ((MenuStrip)item).Items);
                }
                else
                {
                    if(item is TextBox || item is Label)
                        resources.ApplyResources(item, item.Name);
                }
            }
         
        }

        private static void ApplyResourcesToMenu(System.ComponentModel.ComponentResourceManager resources, IEnumerable item)
        {
           
            foreach (object menuItem in item)
            {
                if (menuItem is ToolStripMenuItem)
                {
                    resources.ApplyResources(menuItem, ((ToolStripMenuItem)menuItem).Name);
                    ApplyResourcesToMenu(resources, ((ToolStripMenuItem)menuItem).DropDownItems);
                }

            }
        }
        #endregion

        #region Misc

        private void SetProgressBarValue(int value)
        {
            this.Invoke(new ThreadStart(() =>
            {
                m_uploadProgressBar.Value = value;
            }));
        }
        private void AddProgressBarValue(int value)
        {
            this.Invoke(new ThreadStart(() =>
            {
                m_uploadProgressBar.Value += value;
            }));
        }

        private void InvokePerformStep()
        {
            this.Invoke(new ThreadStart(() => { m_uploadProgressBar.PerformStep(); }));
        }
        

        int layoutIndex = 0;
        private void m_previewPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                layoutIndex = (int)m_previewPictureBox.BackgroundImageLayout;
                layoutIndex++;
                m_previewPictureBox.BackgroundImageLayout = (ImageLayout)layoutIndex;
            }
            catch
            {
                m_previewPictureBox.BackgroundImageLayout = (ImageLayout)1;
            }
        }

        #endregion

        #region Settings
        internal void SaveSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Culture"].Value = Thread.CurrentThread.CurrentUICulture.Name;
            config.AppSettings.Settings["StartWithWindows"].Value = StartWithWindows.ToString();
            config.AppSettings.Settings["StartMinimized"].Value = StartMinimized.ToString();
            config.AppSettings.Settings["GetFull"].Value = ApplicationManager.Current.Keys[Functions.GetFullScreen].ToString();
            config.AppSettings.Settings["GetActive"].Value = ApplicationManager.Current.Keys[Functions.GetActiveWindow].ToString();
            config.AppSettings.Settings["Upload"].Value = ApplicationManager.Current.Keys[Functions.Upload].ToString();
            config.AppSettings.Settings["SuperTake"].Value = ApplicationManager.Current.Keys[Functions.SuperTake].ToString();
            config.Save();
        }

        private void LoadSettings()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ConfigurationManager.AppSettings["Culture"]);

            SetShortCutKey(TryConvert(ConfigurationManager.AppSettings["GetFull"], Keys.F7), Functions.GetFullScreen);
            SetShortCutKey(TryConvert(ConfigurationManager.AppSettings["GetActive"], Keys.F8), Functions.GetActiveWindow);
            SetShortCutKey(TryConvert(ConfigurationManager.AppSettings["Upload"], Keys.F9), Functions.Upload);

            Keys superTakeKey = ApplicationManager.Current.Keys[Functions.GetFullScreen] | TryConvert(ConfigurationManager.AppSettings["SuperTake"], Keys.Control);
            Keys superTakeKeyActive = ApplicationManager.Current.Keys[Functions.GetActiveWindow] | TryConvert(ConfigurationManager.AppSettings["SuperTake"], Keys.Control);
            SetShortCutKey(superTakeKey, Functions.SuperTake);
            SetShortCutKey(superTakeKeyActive, Functions.SuperTakeActive);

            StartWithWindows = Convert.ToBoolean(ConfigurationManager.AppSettings["StartWithWindows"]);
            StartMinimized = Convert.ToBoolean(ConfigurationManager.AppSettings["StartMinimized"]);
        }

        KeysConverter c = new KeysConverter();
        private Keys TryConvert(string value, Keys keyinerror)
        {
            object result = c.ConvertFromString(value);
            if (result != null)
                return (Keys)result;
            return keyinerror;
        }

        private void SetShortCutKey(Keys keys, Functions functions)
        {
            switch (functions)
            {
                case Functions.GetFullScreen:
                    break;
                case Functions.GetActiveWindow:
                    break;
                case Functions.Upload:
                    break;
            }
            ApplicationManager.Current.RegisterKey(functions, keys, this);
        }

        #endregion


        private void BringWindowToFront()
        {
            this.Show();
            this.Activate();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }  

        private void OpenFromFileDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images Files|*.BMP;*.JPG;*.GIF;*.PNG;";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenFromFile(dialog.FileName);
            }
        }
        private void OpenFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found: " + path);
            FileStream fileOpen = null;
            try
            {
                fileOpen = File.Open(path, FileMode.Open);
                ApplicationManager.Current.CurrentScreenShot = new Bitmap(fileOpen);
            }
            catch { }
            finally 
            {
                if (fileOpen != null)
                    fileOpen.Close();
            }


        }

        #region menuEventHandlers

        private void aboutSuperImageShackClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAboutBox ab = new MyAboutBox();
            ab.ShowDialog();
        }

        HelpForm helpForm = null;
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (helpForm == null)
            {
                helpForm = new HelpForm();
                helpForm.FormClosed += new FormClosedEventHandler(helpForm_FormClosed);
            }

            helpForm.Show();
        }

        void helpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            helpForm = null;
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFromFileDialog();
        }

        private void fromDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFullScreenshot(false);
        }

        private void activeWindowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //GetActiveWindowsScreenshot(f
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BringWindowToFront();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFromFileDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void desktopPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFullScreenshot(true);
        }

        private void activeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IntPtr ptr = GetForegroundWindow();


            //IntPtr prevPtr = GetWindow(ptr, GetWindow_Cmd.GW_HWNDPREV);
            //ShowWindow(prevPtr, ShowWindowCommand.ShowMaximized);

            //GetActiveWindowsScreenshot(prevPtr, true);


        }

        private void m_notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            BringWindowToFront();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm();
            form.MainForm = this;
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region dragnDrop
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                if (data is string[])
                    data = ((string[])data)[0];
                OpenFromFile(data.ToString());
            }
        }

        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                string data = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (File.Exists(data))
                {
                    string ex = new FileInfo(data).Extension.ToUpper();
                    if(ex == ".BMP" || ex ==".JPG" || ex == ".GIF" || ex ==".PNG")
                        e.Effect = DragDropEffects.Link;
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
            }
            catch 
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion
    }
}
