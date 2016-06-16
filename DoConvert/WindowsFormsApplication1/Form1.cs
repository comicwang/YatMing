using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DOC文件|*.doc|PPT文件|*.ppt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(@"C:\Users\Administrator\Desktop\DoConvert\DoConvert\bin\Debug\DoConvert.exe", dialog.FileName);
            }
        }
    }
}
