using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public partial class FormFace : Form
    {
        public FormFace()
        {
            InitializeComponent();
        }

        private void createBoxes()
        {
            int count = 134;
            int column = 11;
            for (int i = 0; i < count; i++)
            {
                FaceBox box = new FaceBox(i);
                box.Location = new Point(i % column * 30, i / column * 30);
                this.Controls.Add(box);

                box.Selected += delegate(int faceID)
                {
                    if (this.AddFace != null)
                        this.AddFace("Face_" + faceID);

                    this.Hide();
                };
            }
            this.Width = 30 * column + 6;//6为两边框宽
            this.Height = (count / column + (count % column == 0 ? 0 : 1)) * 30 + 3;
        }

        public delegate void AddFaceHnadler(string faceID);
        public event AddFaceHnadler AddFace;

        private void FormFace_Load(object sender, EventArgs e)
        {
            createBoxes();
        }

        private void FormFace_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
