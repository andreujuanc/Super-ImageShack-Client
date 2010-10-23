using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Xml;
using SuperImageShack.App_Code;

namespace SuperImageShack
{
    #region utils
    public class DataReceivedEventArgs : EventArgs 
    {
        public int ControlsToCreate { get; set; }

        public DataReceivedEventArgs(int controlsToCreate)
        {
            this.ControlsToCreate = controlsToCreate;
        }
    }
    public class UploadingStepEventArgs : EventArgs
    {
        public int StepIncrementValue { get; private set; }
        public DataControl DataControl { get; private set; }

        public UploadingStepEventArgs(int value)
        {
            this.StepIncrementValue = value;
        }
        public UploadingStepEventArgs(int value, DataControl control)  : this(value)
        {
            this.DataControl = control;
        }
    }
    public class UploadCompletedEventArgs : EventArgs 
    {
        public object Data { get; set; }
        public string ImageUrl { get; set; }

        public UploadCompletedEventArgs(object data, string imageurl)
        {
            this.Data = data;
            this.ImageUrl = imageurl;
        }
        
    }
    public delegate int DataReceivedEventhandler(object sender, DataReceivedEventArgs e);
    #endregion

    public class ApplicationManager
    {
        #region fields
        public Dictionary<MainForm.Functions, Keys> Keys { get; set; }
        private Thread m_thread = null;
        private Bitmap _currentScreenShot;
        public Bitmap CurrentScreenShot 
        {
            get { return _currentScreenShot; }
            set 
            {
                if (_currentScreenShot != value)
                {
                    _currentScreenShot = value;
                    if (ImageChanged != null)
                        ImageChanged(this, EventArgs.Empty);
                }
            }
        }
        public UploadManager UploadManager { get; set; }
        #endregion

        #region Events
        public event EventHandler UploadingStarting;
        public event EventHandler<UploadingStepEventArgs> UploadingStep;
        public event DataReceivedEventhandler DataReceived;
        public event EventHandler<UploadCompletedEventArgs> UploadingComplete;
        public event EventHandler ImageChanged;
        #endregion

        #region eventInvokes
        public void OnUploadingStarting() 
        {
            if (UploadingStarting != null)
                UploadingStarting(this, EventArgs.Empty);
        }
        public void OnUploadingStep(int value = 0, DataControl control = null) 
        {
            if (UploadingStep != null)
                UploadingStep(this, new UploadingStepEventArgs(value, control));
        }
        public void OnUploadingComplete(object data, string imageurl = "")
        {
            if (UploadingComplete != null)
                UploadingComplete(this, new UploadCompletedEventArgs(data, imageurl));
        }
        public int OnDataReceived(int controlsToCreate)
        {
            if (DataReceived != null)
                return DataReceived(this, new DataReceivedEventArgs(controlsToCreate));
            return 0;
        }
        #endregion

        #region staticInit

        private static ApplicationManager _current;

        public static ApplicationManager Current 
        {
            get 
            {
                if (_current == null)
                    _current = new ApplicationManager();
                return _current;
            }
        }
        #endregion

        #region constructor
        public ApplicationManager()
        {
            UploadManager = new UploadManager();
            Keys = new Dictionary<MainForm.Functions, Keys>();
        }
        #endregion

        #region public methods
     

        public Bitmap TakeScreenShot(int width, int height, int x, int y, PixelFormat format)
        {
            Bitmap Screenshot = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics SSGraphics = Graphics.FromImage(Screenshot);

            SSGraphics.CopyFromScreen(x, y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            CurrentScreenShot = Screenshot;
            return Screenshot;
        }

        public void UploadImageAsync(bool showBallon)
        {
            if (m_thread != null && m_thread.ThreadState != ThreadState.Stopped)
            {
                return;
            }
            m_thread = new Thread(new ParameterizedThreadStart(MainWork));
            OnUploadingStarting();
            m_thread.Start(showBallon);
        }

        #endregion

        #region Properties
        public ThreadState State {
            get 
            {
                return (m_thread == null) ? ThreadState.Stopped : m_thread.ThreadState;
            }
        }
        #endregion

        private void MainWork(object parameter)
        {
            string imageUrl = "";
            try
            {
                string url = "http://www.imageshack.us/upload_api.php?";
                MemoryStream ms = new MemoryStream();
                CurrentScreenShot.Save(ms, ImageFormat.Jpeg);
                ms.Position = 0;
                OnUploadingStep();

                string data = "public&key=2BJMPTXYf1a3a7292a65c957a26c1e8f088ecc18";
                string result = UploadManager.UploadFile(ms, url, "fileupload", "image/jpeg", data);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                OnUploadingStep();

                XmlNodeList resultNodes = doc.GetElementsByTagName("links");
                
                if (resultNodes.Count > 0)
                {
                    XmlNode linkNode = resultNodes[0];
                    int value = OnDataReceived(linkNode.ChildNodes.Count);
                    if (linkNode.ChildNodes.Count > 0)
                        imageUrl = linkNode.ChildNodes[0].InnerText;
                    foreach (XmlElement item in linkNode.ChildNodes)
                    {
                        
                        DataControl dc = new DataControl(item);
                        
                        OnUploadingStep(value, dc);
                    }
                }
            }
            catch (ThreadStateException) { }
            catch (ThreadAbortException) { }

            OnUploadingComplete(parameter, imageUrl);
        }

        public void RegisterKey(MainForm.Functions functions, Keys key, Form form)
        {
            if (Keys.ContainsKey(functions))
            {
                Tools.UnregisterHotKey(form, this.Keys[functions]);
                Keys.Remove(functions);
            }
            Keys.Add(functions, key);
            Tools.RegisterHotKey(form, key);
        }
    }
}
