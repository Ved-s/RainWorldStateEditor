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
    public partial class CommunitiesEdit : Form
    {
        internal static CommunitiesEdit Instance;
        static CommunitiesEdit() { Instance = new CommunitiesEdit(); }

        internal float ScavShy;
        internal Dictionary<string, float[]> Values = new Dictionary<string, float[]>();
        internal TreeNode currentNode;

        public CommunitiesEdit()
        {
            InitializeComponent();
            Visible = false;
        }

        public static void Show(TreeNode node) 
        {
            StateTag Tag = node.Tag as StateTag;
            if (Tag.Sub is null || Tag.Sub.Count == 0) return;

            Instance.Values.Clear();
            Instance.currentNode = node;

            foreach (Control c in Instance.Comms.Controls) (c as CommunityPanel).Deconstruct();
            Instance.Comms.Controls.Clear();

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." };
            bool regions = false;

            foreach (StateTag sub in Tag.Sub) 
            {
                if (!sub.IsValueTag()) continue;

                if (sub.Value == "SCAVSHY") 
                {
                    Instance.ScavShy = float.Parse(sub[0].Value, nfi);
                    Instance.ScavshyLabel.Text = $"Scavenger shyness: {Instance.ScavShy:n}";
                    Instance.ScavshyValue.Value = (int)(Instance.ScavShy * 10);
                    continue;
                }

                List<float> floats = new List<float>();

                foreach (string f in sub[0].Value.Split(',')) 
                {
                    floats.Add(float.Parse(f, nfi));
                }
                Instance.Values.Add(sub.Value, floats.ToArray());

                if (!regions) 
                {
                    regions = true;
                    Instance.RegionSelect.Items.Clear();
                    for (int i = 0; i < floats.Count; i++) 
                    {
                        if (i < VanillaRegionNames.Length) 
                        {
                            Instance.RegionSelect.Items.Add(VanillaRegionNames[i]);
                        }
                        else Instance.RegionSelect.Items.Add($"Region {i}");
                        
                    }
                    Instance.RegionSelect.SelectedIndex = 0;
                }

                Instance.Comms.Controls.Add(new CommunityPanel(sub.Value));
                
            }
            GC.Collect();
            Instance.ShowDialog(Main.Instance.TagTree);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

        static string[] VanillaRegionNames = new string[]
        {
            "All",
            "Chimney Canopy",
            "Drainage System",
            "Industrial Complex",
            "Garbage Wastes",
            "Sky Islands",
            "Outskirts",
            "Shaded Citadel",
            "Shoreline",
            "Farm Arrays",
            "The Exterior",
            "Subterranean",
            "Five Pebbles"
        };

        private void ScavshyValue_Scroll(object sender, ScrollEventArgs e)
        {
            Instance.ScavShy = Instance.ScavshyValue.Value / 10f;
            Instance.ScavshyLabel.Text = $"Scavenger shyness: {Instance.ScavShy:n}";
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." };
            StateTag Tag = currentNode.Tag as StateTag;
            string s;
            foreach (StateTag sub in Tag.Sub)
            {
                if (!sub.IsValueTag()) continue;

                if (sub.Value == "SCAVSHY")
                {
                    sub[0].Value = ScavShy.ToString(nfi);
                    continue;
                }
                s = "";
                foreach (float f in Values[sub.Value]) 
                {
                    if (s != "") s += ",";
                    s += f.ToString(nfi);
                }
                sub[0].Value = s;
            }

            foreach (TreeNode subnode in currentNode.Nodes) 
            {
                subnode.Text = TagPreview.TagString(subnode.Tag as StateTag);
            }
        }
    }
}
