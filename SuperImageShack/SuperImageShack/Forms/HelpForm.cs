using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;

namespace SuperImageShack.Forms
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }
        string _base = "";
        protected override void OnLoad(EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                string culture = (CultureInfo.CurrentUICulture.Parent.Name != "") ? CultureInfo.CurrentUICulture.Parent.Name : CultureInfo.CurrentUICulture.Name;
                _base = "file://"+ Application.StartupPath + "\\Help\\" + culture + "\\";
                doc.Load(_base + "Content.xml");
                treeView1.ImageList = m_iconsSet;
                
                CreateNodes(doc.DocumentElement.ChildNodes, treeView1.Nodes);
            }
            catch
            {
                
            }
            base.OnLoad(e);
       }

        private void CreateNodes(XmlNodeList xmlNodeList, TreeNodeCollection parent)
        {
            foreach (XmlNode item in xmlNodeList)
            {
                TreeNode tn = new TreeNode();
                
                tn.Text = item.Attributes["Title"].Value;
                tn.Tag = item;

                if (item.Name == "File")
                {
                    tn.ImageIndex = 1;
                    tn.StateImageIndex = 2;
                }
                else if (item.Name == "Node")
                {
                    tn.ImageIndex = 3;
                    tn.StateImageIndex = 3;
                }
                parent.Add(tn);
                CreateNodes(item.ChildNodes, tn.Nodes);
            }
        }


        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            XmlNode item = (XmlNode)e.Node.Tag;

            if (item.Name == "File")
                e.Node.ImageIndex = 2;
      
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            XmlNode item = (XmlNode)e.Node.Tag;

            if (item.Name == "File")
                e.Node.ImageIndex = 1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlNode item = (XmlNode)e.Node.Tag;

            string path = item.Attributes["Path"].Value;
            webBrowser1.Navigate(_base + path);

        }

     
    }
}
