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
    public partial class RawView : Form
    {
        public static RawView Instance;
        static RawView() { Instance = new RawView(); }

        public RawView()
        {
            InitializeComponent();
            Visible = false;
        }

        private void RawView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }

        public void Show(string data) 
        {
            Raw.Text = data;
            ShowDialog();
        }
    }
}
