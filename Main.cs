using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainWorldStateEdit
{
    public partial class Main : Form
    {
        static string[] SupportsSpecialEdit = new string[] { "COMMUNITIES" };
        Dictionary<TreeNode, (string, string, bool, bool)> Files = new Dictionary<TreeNode, (string, string, bool, bool)>();

        internal TreeNode selectedRootNode = null;
        internal TreeNode selectedNode = null;
        internal StateTag SelectedTag { get => selectedNode.Tag as StateTag; }

        public static string AutoloadFile = null;

        public static Main Instance;

        public Main()
        {
            InitializeComponent();
            Instance = this;
        }

        private void SelectNode(TreeNode node) 
        {
            selectedNode = node;
            selectedRootNode = node;
            while (selectedRootNode.Parent != null)
            {
                selectedRootNode = selectedRootNode.Parent;
            }

            EditMenu.Enabled = node.Parent != null;

            (string, string, bool, bool) file = Files[selectedRootNode];

            if (file.Item2 == null)
            {
                CheckSum.Text = "No checksum";
                CheckSum.ForeColor = SystemColors.ControlText;
                CheckSumFix.Checked = true;
                CheckSumFix.Enabled = false;
            }
            else
            {
                Save.Enabled = true;
                SaveAs.Enabled = true;
                CheckSumFix.Enabled = true;
                CheckSumFix.Checked = file.Item4;
                CheckSum.Text = file.Item3 ? "Checksum correct" : "Checksum is wrong";
                CheckSum.ForeColor = file.Item3 ? Color.Green : Color.Red;
            }

            StateTag tag = selectedNode.Tag as StateTag;
            ValueEditMenu.Enabled = tag.IsValueTag() || TagPreview.PreviewFirstTag.Contains(tag.Value);
            SpecialEditMenu.Enabled = SupportsSpecialEdit.Contains(tag.Value);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TagMenu.Init();
            if (AutoloadFile != null) LoadFile(AutoloadFile);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFile(ofd.FileName);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            (string, string, bool, bool) file = Files[selectedRootNode];
            string text = (selectedRootNode.Tag as StateTag).ToString();
            string hash = (file.Item4 && file.Item2 != null) ? RWCustom.Md5Sum(text) : file.Item2;

            bool hashCorrect = (hash is null) ? false : hash == RWCustom.Md5Sum(text);
            Files[selectedRootNode] = (file.Item1, hash, hashCorrect, CheckSumFix.Checked);

            if (hash != null) text = hash + text;
            File.WriteAllText(file.Item1, text);
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            (string, string, bool, bool) file = Files[selectedRootNode];

            sfd.FileName = Path.GetFileName(file.Item1);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string text = (selectedRootNode.Tag as StateTag).ToString();
                string hash = (file.Item4 && file.Item2 != null) ? RWCustom.Md5Sum(text) : file.Item2;

                bool hashCorrect = (hash is null) ? false : hash == RWCustom.Md5Sum(text);
                Files[selectedRootNode] = (sfd.FileName, hash, hashCorrect, CheckSumFix.Checked);

                if (hash != null) text = hash + text;
                File.WriteAllText(sfd.FileName, text);
            }
        }

        private void CheckSumFix_CheckedChanged(object sender, EventArgs e)
        {
            (string, string, bool, bool) file = Files[selectedRootNode];
            Files[selectedRootNode] = (file.Item1, file.Item2, file.Item3, CheckSumFix.Checked);
        }

        private void TagTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            SelectNode(e.Node);
            if (e.Button == MouseButtons.Right)
            {
                TagMenu.Show(e.Location);
            }
        }
        private void TagTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Tag as StateTag).IsValueTag()) TagEdit.Instance.Show(e.Node, TagAction.Edit);
        }
        private void TagTree_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                    SelectNode(TagTree.SelectedNode);
                    break;
            }
        }
        private void TagTree_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if ((TagTree.SelectedNode.Tag as StateTag).IsValueTag()) TagEdit.Instance.Show(TagTree.SelectedNode, TagAction.Edit);
                    break;
            }
        }

        private void LoadFile(string filename)
        {
            string file = File.ReadAllText(filename);
            string hash = null;
            string possibleHash = file.Substring(0, 32);
            bool hashCorrect = false;
            if (Regex.IsMatch(possibleHash, "^[0-9a-f]{32}$"))
            {
                hash = possibleHash;
                file = file.Substring(32, file.Length - 32);
                hashCorrect = hash == RWCustom.Md5Sum(file);
            }

            TreeNode tn = new StateParser(file, Path.GetFileName(filename)).TagTree.CreateTreeNode();
            tn.Expand();
            Files.Add(tn, (filename, hash, hashCorrect, true));
            TagTree.Nodes.Add(tn);
        }
    }
}
