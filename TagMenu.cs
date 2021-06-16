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
        static MenuItem edit, removeValue, special;
        static ContextMenu menu = new ContextMenu(new MenuItem[]
        {
            new MenuItem("Delete", DeleteTag),
            new MenuItem("Rename", RenameTag),
            edit = new MenuItem("Edit value", EditTag),
            removeValue = new MenuItem("Delete value", RemoveSubTag),
            new MenuItem("Clone", CloneTag),
            new MenuItem("Raw data", RawTag),
            special = new MenuItem("Edit special", Special) { Enabled = false }
        });

        private static void Special(object sender, EventArgs e)
        {
            if (Main.Instance.SelectedTag.Value == "COMMUNITIES") CommunitiesEdit.Show(Main.Instance.selectedNode);
        }
        private static void RemoveSubTag(object sender, EventArgs e)
        {
            StateTag tag = Main.Instance.selectedNode.Tag as StateTag;
            tag.Sub = null;
            Main.Instance.selectedNode.Text = tag.Value;
        }
        private static void RawTag(object sender, EventArgs e)
        {
            string tagstr = (Main.Instance.selectedNode.Tag as StateTag).ToString();
            RawView.Instance.Show(tagstr);
        }
        private static void CloneTag(object sender, EventArgs e)
        {
            if (Main.Instance.selectedNode.Index == 0) { MessageBox.Show("Cannot clone first tag - it might break file structure"); return; }

            string tagstr = (Main.Instance.selectedNode.Tag as StateTag).ToString();
            StateTag newTag = new StateParser(tagstr).TagTree.Sub[0];

            StateTag parent = Main.Instance.selectedNode.Parent.Tag as StateTag;
            parent.Sub.Insert(Main.Instance.selectedNode.Index, newTag);

            Main.Instance.selectedNode.Parent.Nodes.Insert(Main.Instance.selectedNode.Index, newTag.CreateTreeNode());
        }
        private static void EditTag(object sender, EventArgs e)
        {
            TagEdit.Instance.Show(Main.Instance.selectedNode, TagAction.Edit);
        }
        private static void RenameTag(object sender, EventArgs e)
        {
            TagEdit.Instance.Show(Main.Instance.selectedNode, TagAction.Rename);
        }
        private static void DeleteTag(object sender, EventArgs e)
        {
            if (Main.Instance.selectedNode.Index == 0) { MessageBox.Show("Cannot delete first tag - it might break file structure"); return; }

            if (Control.ModifierKeys.HasFlag(Keys.Shift) || MessageBox.Show($"Delete {(Main.Instance.selectedNode.Tag as StateTag).Value}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                (Main.Instance.selectedNode.Parent.Tag as StateTag).Sub.Remove(Main.Instance.selectedNode.Tag as StateTag);
                Main.Instance.selectedNode.Remove();
                GC.Collect();
            }
        }
        public static void Show(Point pos) 
        {
            if (Main.Instance.selectedNode.Parent == null) return;
            menu.Show(Main.Instance.TagTree, pos);
        }

        public static void Init() 
        {
            Main.Instance.DeleteEditMenu.Click += DeleteTag;
            Main.Instance.RenameEditMenu.Click += RenameTag;
            Main.Instance.ValueEditMenu.Click += EditTag;
            Main.Instance.DelValueEditmenu.Click += RemoveSubTag;
            Main.Instance.CloneEditMenu.Click += CloneTag;
            Main.Instance.RawEditMenu.Click += RawTag;
            Main.Instance.SpecialEditMenu.Click += Special;

            Main.Instance.ValueEditMenu.EnabledChanged    += (s, e) => edit.Enabled = Main.Instance.ValueEditMenu.Enabled;
            Main.Instance.DelValueEditmenu.EnabledChanged += (s, e) => removeValue.Enabled = Main.Instance.DelValueEditmenu.Enabled;
            Main.Instance.SpecialEditMenu.EnabledChanged  += (s, e) => special.Enabled = Main.Instance.SpecialEditMenu.Enabled;
        }
    }
}
