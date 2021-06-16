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
    public partial class CommunityPanel : UserControl, IDisposable
    {
        string name;

        public CommunityPanel() : this(null) { }
        public CommunityPanel(string name)
        {
            this.name = name;
            InitializeComponent();
            Dock = DockStyle.Top;
            UpdateValue();
            CommunitiesEdit.Instance.RegionSelect.SelectedIndexChanged += RegionSelect_SelectedIndexChanged;
        }

        private void RegionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void ValueBar_Scroll(object sender, ScrollEventArgs e)
        {
            float value = ValueBar.Value / 1000f;
            int index = CommunitiesEdit.Instance.RegionSelect.SelectedIndex;
            CommunitiesEdit.Instance.Values[name][index] = value;
            NameLabel.Text = $"{name}: {value:n3}";
        }

        private void UpdateValue() 
        {
            int index = CommunitiesEdit.Instance.RegionSelect.SelectedIndex;
            if (index == -1) return;
            float value = CommunitiesEdit.Instance.Values[name][index];
            ValueBar.Value = (int)(value * 1000);
            NameLabel.Text = $"{name}: {value:n3}";
        }

        internal void Deconstruct() 
        {
            CommunitiesEdit.Instance.RegionSelect.SelectedIndexChanged -= RegionSelect_SelectedIndexChanged;
        }
        
    }
}
