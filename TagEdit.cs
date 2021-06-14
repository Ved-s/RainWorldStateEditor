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
                    Edit.Text = tag[0].Value;
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
                    if (tag.IsFlagTag())
                    {
                        tag.Value = Edit.Text;
                        node.Text = tag.Value;
                        break;
                    }
                    tag[0].Value = Edit.Text;
                    node.Text = $"{tag.Value}: {tag.Sub[0].Value}";
                    break;

                case TagAction.Rename:
                    tag.Value = Edit.Text;
                    if (!tag.IsValueTag())
                    {
                        node.Text = tag.Value;
                        break;
                    }
                    node.Text = $"{tag.Value}: {tag.Sub[0].Value}";
                    break;

            }
            Close();
        }
    }
    public enum TagAction { Rename, Edit }
}
