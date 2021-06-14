
namespace RainWorldStateEdit
{
    partial class RawView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Raw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Raw
            // 
            this.Raw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Raw.Location = new System.Drawing.Point(0, 0);
            this.Raw.Multiline = true;
            this.Raw.Name = "Raw";
            this.Raw.ReadOnly = true;
            this.Raw.Size = new System.Drawing.Size(356, 218);
            this.Raw.TabIndex = 0;
            // 
            // RawView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 218);
            this.Controls.Add(this.Raw);
            this.Name = "RawView";
            this.Text = "Исходные данные";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RawView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Raw;
    }
}