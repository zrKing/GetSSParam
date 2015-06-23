using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using GetSSParam.Properties;

namespace GetSSParam
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager(typeof(Resources));
            string strVersion = rm.GetString("strVersion");
            string strAbout = "Get the params of Shadowsocks for wangfl.\r\nIf there any problems,please contact zrKing©2015";
            strAbout += "\r\n\r\nVersion : ";
            strAbout += strVersion;

            this.label1.Text = strAbout;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
