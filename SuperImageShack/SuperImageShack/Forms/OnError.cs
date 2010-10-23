using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperImageShack.Forms
{
    public partial class OnError : Form
    {
        private Exception exception;

        public OnError(Exception exception)
        {
            InitializeComponent();
            this.exception = exception;
        }
        protected override void OnLoad(EventArgs e)
        {
            m_message.Text = exception.Message;
            m_stackTrace.Text = exception.StackTrace;
            base.OnLoad(e);
        }
    }
}
