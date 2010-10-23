using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SuperImageShack
{
    public partial class DataControl : UserControl
    {
        private XmlElement item;

        

        public DataControl(XmlElement item)
        {
                InitializeComponent();
            this.item = item;
            try
            {
                m_content.Text = item.InnerText;
                m_title.Text = item.Name;
            }
            catch { }
        }

        private void m_content_Enter(object sender, EventArgs e)
        {
            m_content.SelectAll();
        }

        private void m_content_MouseClick(object sender, MouseEventArgs e)
        {
            m_content.SelectAll();
        }
    }
}
