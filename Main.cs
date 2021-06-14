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
        Dictionary<TreeNode, (string, string, bool, bool)> Files = new Dictionary<TreeNode, (string, string, bool, bool)>();
        TreeNode selectedRootNode = null;

        public Main()
        {
            InitializeComponent();
            
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                string file = File.ReadAllText(ofd.FileName);
                string hash = null;
                string possibleHash = file.Substring(0, 32);
                bool hashCorrect = false;
                if (Regex.IsMatch(possibleHash, "^[0-9a-f]{32}$")) 
                {
                    hash = possibleHash;
                    file = file.Substring(32, file.Length - 32);
                    hashCorrect = hash == RWCustom.Md5Sum(file);
                }

                TreeNode tn = new StateParser(file, Path.GetFileName(ofd.FileName)).TagTree.CreateTreeNode();
                Files.Add(tn, (ofd.FileName, hash, hashCorrect, true));
                TagTree.Nodes.Add(tn);
            }
        }
        private void TagTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            selectedRootNode = e.Node;
            while (selectedRootNode.Parent != null)
            {
                selectedRootNode = selectedRootNode.Parent;
            }

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
                CheckSumFix.Enabled = true;
                CheckSumFix.Checked = file.Item4;
                CheckSum.Text = file.Item3 ? "Checksum correct" : "Checksum is wrong";
                CheckSum.ForeColor = file.Item3 ? Color.Green : Color.Red;
            }

            if (e.Button == MouseButtons.Right) TagMenu.Show(e.Node, e.Location);
        }
        private void CheckSumFix_CheckedChanged(object sender, EventArgs e)
        {
            (string, string, bool, bool) file = Files[selectedRootNode];
            Files[selectedRootNode] = (file.Item1, file.Item2, file.Item3, CheckSumFix.Checked);
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            (string, string, bool, bool) file = Files[selectedRootNode];

            sfd.FileName = file.Item1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string text = (selectedRootNode.Tag as StateTag).ToString();
                string hash = (file.Item4 && file.Item2 != null) ? RWCustom.Md5Sum(text) : file.Item2;

                bool hashCorrect = (hash is null)? false : hash == RWCustom.Md5Sum(text);
                Files[selectedRootNode] = (sfd.FileName, hash, hashCorrect, CheckSumFix.Checked);

                if (hash != null) text = hash + text;
                File.WriteAllText(sfd.FileName, text);

                
            }

        }
    }
}
