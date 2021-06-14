using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainWorldStateEdit
{
    public partial class TagEdit : Form
    {
        public static TagEdit Instance;
        static TreeNode node;
        static TagAction action;

        static TagEdit()
        {
            Instance = new TagEdit();
        }

        public TagEdit()
        {
            InitializeComponent();
            Visible = false;
        }

        public void Show(TreeNode node, TagAction action)
        {
            TagEdit.node = node;
            TagEdit.action = action;

            StateTag tag = node.Tag as StateTag;

            switch (action)
            {
                case TagAction.Rename:
                    Text = $"Rename: {tag.Value}";
                    Edit.Text = tag.Value;
                    break;
                case TagAction.Edit:
                    Text = $"Edit value: {tag.Value}";
                    if (TagPreview.PreviewFirstTag.Contains(tag.Value)) 
                    {
                        Edit.Text = tag[0].IsValueTag() ? tag[0][0].Value : tag[0].Value;
                    }
                    else Edit.Text = tag[0].Value;
                    break;
                    
            };
            ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
        private void Ok_Click(object sender, EventArgs e)
        {

            StateTag tag = node.Tag as StateTag;

            switch (action)
            {
                case TagAction.Edit:

                    if (TagPreview.PreviewFirstTag.Contains(tag.Value))
                    {
                        if (tag[0].IsValueTag())
                            tag[0][0].Value = Edit.Text;
                        else tag[0].Value = Edit.Text;
                    }
                    else if (tag.IsFlagTag()) tag.Value = Edit.Text;
                    else tag[0].Value = Edit.Text;
                    node.Text = TagPreview.TagString(tag);
                    break;

                case TagAction.Rename:
                    tag.Value = Edit.Text;
                    node.Text = TagPreview.TagString(tag);
                    break;

            }
            Close();
        }
        private void Edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Ok_Click(sender, null);
        }
    }
    public enum TagAction { Rename, Edit }
}
