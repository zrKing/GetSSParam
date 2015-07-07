using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Threading;

namespace GetSSParam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private string strURL = @"http://doc.wandoer.com/fp.txt";
        private string str = "";
        private string strVersion = "V1.0";
        private static About fa = null;


        private void button1_Click(object sender, EventArgs e)
        {            
           
            try
            {
                this.textBox1.TextAlign = HorizontalAlignment.Left;
                this.textBox1.Text = "Please Wait";
                this.button1.Enabled = false;
                Thread t2 = new Thread(new ThreadStart(ShowLabel));
                Thread t1 = new Thread(new ThreadStart(ThreadMethod));
                t1.Start();
                t2.Start();
                t1.Join();
                t2.Abort();
                this.label1.Text = " ";
            }
            catch (System.Exception ex)
            {
                str = ex.ToString();
                str += "\r\n";
                str += "\r\n";
                str += "\r\n";
                str += "请稍后重试或联系@zrKing";
            }
            finally
            {
                this.button1.Enabled = true;
            }

            this.textBox1.Text = str;
        }

        private void ThreadMethod()
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            str = wc.DownloadString(strURL);
            str = str.Replace("\n", "\r\n");
            
            this.textBox1.Text = str;
        }

        private void ShowLabel()
        {
            string strText = ".";
            while (true)
            {
                strText += ".";
                if (strText.Length >= 5)
                    strText = ".";
                this.label1.Text = strText;
                Application.DoEvents();
                Thread.Sleep(500);
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            string strAbout = "Get the params of Shadowsocks for wangfl.\r\nIf there any problems ,please contact zrKing©2015";
            strAbout += "\r\n\r\nVersion:";
            strAbout += strVersion;

            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox1.Text = strAbout;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fa == null)
                fa = new About();

            if (fa.Visible)
            {
                fa.Activate();
                return;
            }

            fa.ShowDialog(this);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button1_Click(sender, e);
        }
    }
}
