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
                box.MouseHover += box_MouseHover;
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

        private void box_MouseHover(object sender, EventArgs e)
        {
            FaceBox box = sender as FaceBox;
            picView.Visible = true;
            picView.Location = box.Location;
            picView.Image = (Image)Properties.Resources.ResourceManager.GetObject("Face_" + box.faceID);
            picView.Tag = box.faceID;
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

        private void picView_Click(object sender, EventArgs e)
        {
            if (this.AddFace != null)
                this.AddFace("Face_" + picView.Tag.ToString());
            this.Hide();
        }

        private void picView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, picView.Width-1, picView.Height-1);
        }
    }
}
