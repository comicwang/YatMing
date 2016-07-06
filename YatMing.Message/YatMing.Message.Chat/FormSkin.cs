using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YatMing.Message.Chat
{
    public partial class FormSkin : Form
    {
        private static string dataForlder = Path.Combine(Application.StartupPath, "Skin");
        public FormSkin()
        {
            InitializeComponent();
            InitializeLstimage();
        }

        private void InitializeLstimage()
        {
            if (Directory.Exists(dataForlder) == false)
                Directory.CreateDirectory(dataForlder);
            string[] datas = Directory.GetFiles(dataForlder);
            Array.ForEach(datas, t =>
            {
                AddImage(t);
            });
        }

        private void AddImage(string t, bool copy = false)
        {
            if (copy)
            {
                File.Copy(t, Path.Combine(dataForlder, Path.GetFileName(t)), true);
                t = Path.Combine(dataForlder, Path.GetFileName(t));
            }
            Image image = Image.FromFile(t);
            Image tempImage = null;
            if (image.Width > image.Height)
            {
                tempImage = image.GetThumbnailImage(LstImage.ImageSize.Width, image.Height * LstImage.ImageSize.Width / image.Width, null, this.Handle);
            }
            else
            {
                tempImage = image.GetThumbnailImage(image.Width * LstImage.ImageSize.Height / image.Height, LstImage.ImageSize.Height, null, this.Handle);
            }
            image.Dispose();
            string key = Path.GetFileNameWithoutExtension(t);
            LstImage.Images.Add(key, tempImage);
            ListViewItem item = new ListViewItem();
            item.ImageKey = key;
            item.ToolTipText = key;
            item.Tag = t;
            lvImage.Items.Add(item);
        }

        private void RemoveImage(ListViewItem t)
        {
            picView.Image.Dispose();
            picView.Image = null;
            string path = t.Tag.ToString();
            File.Delete(path);
            LstImage.Images.RemoveByKey(Path.GetFileNameWithoutExtension(path));
            lvImage.Items.Remove(t);
        }

        private void lvImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImage.SelectedItems.Count > 0)
            {
                ListViewItem item = lvImage.SelectedItems[0];
                picView.Image = Image.FromFile(item.Tag.ToString());
            }
        }

        public Image SelectedImage
        {
            get
            {
                return picView.Image;
            }
            private set { picView.Image = value; }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件|*.png;*.jpg;*.jpeg";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Array.ForEach(dialog.FileNames, t => { AddImage(t, true); });
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (lvImage.SelectedItems.Count > 0)
            {
                ListViewItem item = lvImage.SelectedItems[0];
                RemoveImage(item);
            }
        }

        private void lvImage_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
