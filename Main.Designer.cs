
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
            this.Load = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.CheckSum = new System.Windows.Forms.Label();
            this.CheckSumFix = new System.Windows.Forms.CheckBox();
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
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(0, 0);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(42, 23);
            this.Load.TabIndex = 1;
            this.Load.Text = "Open";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Save
            // 
            this.Save.Enabled = false;
            this.Save.Location = new System.Drawing.Point(41, 0);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(42, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CheckSum
            // 
            this.CheckSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckSum.Location = new System.Drawing.Point(608, 4);
            this.CheckSum.Name = "CheckSum";
            this.CheckSum.Size = new System.Drawing.Size(147, 15);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckSumFix);
            this.Controls.Add(this.CheckSum);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.TagTree);
            this.Name = "Main";
            this.Text = "RainWorld state files editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView TagTree;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label CheckSum;
        private System.Windows.Forms.CheckBox CheckSumFix;
    }
}

