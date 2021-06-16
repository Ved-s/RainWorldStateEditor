
namespace RainWorldStateEdit
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TagTree = new System.Windows.Forms.TreeView();
            this.CheckSum = new System.Windows.Forms.Label();
            this.CheckSumFix = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DelValueEditmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CloneEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RawEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SpecialEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TagTree
            // 
            this.TagTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TagTree.Location = new System.Drawing.Point(0, 23);
            this.TagTree.Name = "TagTree";
            this.TagTree.Size = new System.Drawing.Size(800, 427);
            this.TagTree.TabIndex = 0;
            this.TagTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TagTree_NodeMouseClick);
            this.TagTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TagTree_NodeMouseDoubleClick);
            this.TagTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TagTree_KeyDown);
            this.TagTree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TagTree_KeyUp);
            // 
            // CheckSum
            // 
            this.CheckSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckSum.Location = new System.Drawing.Point(610, 4);
            this.CheckSum.Name = "CheckSum";
            this.CheckSum.Size = new System.Drawing.Size(145, 15);
            this.CheckSum.TabIndex = 3;
            this.CheckSum.Text = "No checksum";
            this.CheckSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckSumFix
            // 
            this.CheckSumFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckSumFix.AutoSize = true;
            this.CheckSumFix.Checked = true;
            this.CheckSumFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSumFix.Enabled = false;
            this.CheckSumFix.Location = new System.Drawing.Point(761, 4);
            this.CheckSumFix.Name = "CheckSumFix";
            this.CheckSumFix.Size = new System.Drawing.Size(39, 17);
            this.CheckSumFix.TabIndex = 4;
            this.CheckSumFix.Text = "Fix";
            this.CheckSumFix.UseVisualStyleBackColor = true;
            this.CheckSumFix.CheckedChanged += new System.EventHandler(this.CheckSumFix_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.SaveAs});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(193, 22);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Load_Click);
            // 
            // Save
            // 
            this.Save.Enabled = false;
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(193, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Enabled = false;
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(193, 22);
            this.SaveAs.Text = "Save as...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteEditMenu,
            this.RenameEditMenu,
            this.ValueEditMenu,
            this.DelValueEditmenu,
            this.CloneEditMenu,
            this.RawEditMenu,
            this.SpecialEditMenu});
            this.EditMenu.Enabled = false;
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "Edit";
            // 
            // DeleteEditMenu
            // 
            this.DeleteEditMenu.Name = "DeleteEditMenu";
            this.DeleteEditMenu.Size = new System.Drawing.Size(138, 22);
            this.DeleteEditMenu.Text = "Delete";
            // 
            // RenameEditMenu
            // 
            this.RenameEditMenu.Name = "RenameEditMenu";
            this.RenameEditMenu.Size = new System.Drawing.Size(138, 22);
            this.RenameEditMenu.Text = "Rename";
            // 
            // ValueEditMenu
            // 
            this.ValueEditMenu.Name = "ValueEditMenu";
            this.ValueEditMenu.Size = new System.Drawing.Size(138, 22);
            this.ValueEditMenu.Text = "Edit value";
            // 
            // DelValueEditmenu
            // 
            this.DelValueEditmenu.Name = "DelValueEditmenu";
            this.DelValueEditmenu.Size = new System.Drawing.Size(138, 22);
            this.DelValueEditmenu.Text = "Delete value";
            // 
            // CloneEditMenu
            // 
            this.CloneEditMenu.Name = "CloneEditMenu";
            this.CloneEditMenu.Size = new System.Drawing.Size(138, 22);
            this.CloneEditMenu.Text = "Clone";
            // 
            // RawEditMenu
            // 
            this.RawEditMenu.Name = "RawEditMenu";
            this.RawEditMenu.Size = new System.Drawing.Size(138, 22);
            this.RawEditMenu.Text = "Raw data";
            // 
            // SpecialEditMenu
            // 
            this.SpecialEditMenu.Enabled = false;
            this.SpecialEditMenu.Name = "SpecialEditMenu";
            this.SpecialEditMenu.Size = new System.Drawing.Size(138, 22);
            this.SpecialEditMenu.Text = "Edit special";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckSumFix);
            this.Controls.Add(this.CheckSum);
            this.Controls.Add(this.TagTree);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "RainWorld state files editor";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView TagTree;
        private System.Windows.Forms.Label CheckSum;
        private System.Windows.Forms.CheckBox CheckSumFix;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Save;
        internal System.Windows.Forms.ToolStripMenuItem DeleteEditMenu;
        internal System.Windows.Forms.ToolStripMenuItem RenameEditMenu;
        internal System.Windows.Forms.ToolStripMenuItem ValueEditMenu;
        internal System.Windows.Forms.ToolStripMenuItem DelValueEditmenu;
        internal System.Windows.Forms.ToolStripMenuItem CloneEditMenu;
        internal System.Windows.Forms.ToolStripMenuItem RawEditMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem SpecialEditMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
    }
}

