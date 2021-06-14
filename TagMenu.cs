using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainWorldStateEdit
{
    static class TagMenu
    {
        static TreeNode currentNode;
        static MenuItem edit, removeValue;
        static ContextMenu menu = new ContextMenu(new MenuItem[]
        {
            new MenuItem("Delete", DeleteTag),
            new MenuItem("Rename", RenameTag),
            edit = new MenuItem("Edit value", EditTag),
            removeValue = new MenuItem("Delete value", RemoveSubTag),
            new MenuItem("Clone", CloneTag),
            new MenuItem("Raw data", RawTag)
        });

        private static void RemoveSubTag(object sender, EventArgs e)
        {
            StateTag tag = currentNode.Tag as StateTag;
            tag.Sub = null;
            currentNode.Text = tag.Value;
        }

        private static void RawTag(object sender, EventArgs e)
        {
            string tagstr = (currentNode.Tag as StateTag).ToString();
            RawView.Instance.Show(tagstr);
        }
        private static void CloneTag(object sender, EventArgs e)
        {
            if (currentNode.Index == 0) { MessageBox.Show("Cannot clone first tag - it might break file structure"); return; }

            string tagstr = (currentNode.Tag as StateTag).ToString();
            StateTag newTag = new StateParser(tagstr).TagTree.Sub[0];

            StateTag parent = currentNode.Parent.Tag as StateTag;
            parent.Sub.Insert(currentNode.Index, newTag);

            currentNode.Parent.Nodes.Insert(currentNode.Index, newTag.CreateTreeNode());
        }
        private static void EditTag(object sender, EventArgs e)
        {
            TagEdit.Instance.Show(currentNode, TagAction.Edit);
        }
        private static void RenameTag(object sender, EventArgs e)
        {
            TagEdit.Instance.Show(currentNode, TagAction.Rename);
        }
        private static void DeleteTag(object sender, EventArgs e)
        {
            if (currentNode.Index == 0) { MessageBox.Show("Cannot delete first tag - it might break file structure"); return; }

            if (Control.ModifierKeys.HasFlag(Keys.Shift) || MessageBox.Show($"Delete {(currentNode.Tag as StateTag).Value}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                (currentNode.Parent.Tag as StateTag).Sub.Remove(currentNode.Tag as StateTag);
                currentNode.Remove();
                GC.Collect();
            }
        }

        public static void Show(TreeNode tagNode, Point pos) 
        {
            if (tagNode.Parent == null) return;

            StateTag tag = tagNode.Tag as StateTag;
            currentNode = tagNode;
            edit.Enabled = tag.IsValueTag();
            removeValue.Enabled = tag.IsValueTag();
            menu.Show(Program.Form.TagTree, pos);
        }
    }
}
