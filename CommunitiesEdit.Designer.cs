
namespace RainWorldStateEdit
{
    partial class CommunitiesEdit
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
            System.Windows.Forms.Label label2;
            this.ScavshyLabel = new System.Windows.Forms.Label();
            this.ScavshyValue = new System.Windows.Forms.HScrollBar();
            this.RegionSelect = new System.Windows.Forms.ComboBox();
            this.Comms = new System.Windows.Forms.Panel();
            this.Ok = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(15, 41);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 18);
            label2.TabIndex = 4;
            label2.Text = "Region:";
            // 
            // ScavshyLabel
            // 
            this.ScavshyLabel.Location = new System.Drawing.Point(12, 8);
            this.ScavshyLabel.Name = "ScavshyLabel";
            this.ScavshyLabel.Size = new System.Drawing.Size(143, 18);
            this.ScavshyLabel.TabIndex = 0;
            this.ScavshyLabel.Text = "Scavenger shyness: 0";
            // 
            // ScavshyValue
            // 
            this.ScavshyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScavshyValue.LargeChange = 1;
            this.ScavshyValue.Location = new System.Drawing.Point(158, 6);
            this.ScavshyValue.Maximum = 1000;
            this.ScavshyValue.Name = "ScavshyValue";
            this.ScavshyValue.Size = new System.Drawing.Size(147, 17);
            this.ScavshyValue.TabIndex = 2;
            this.ScavshyValue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScavshyValue_Scroll);
            // 
            // RegionSelect
            // 
            this.RegionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionSelect.FormattingEnabled = true;
            this.RegionSelect.Location = new System.Drawing.Point(73, 38);
            this.RegionSelect.Name = "RegionSelect";
            this.RegionSelect.Size = new System.Drawing.Size(232, 21);
            this.RegionSelect.TabIndex = 3;
            // 
            // Comms
            // 
            this.Comms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comms.Location = new System.Drawing.Point(2, 65);
            this.Comms.Name = "Comms";
            this.Comms.Size = new System.Drawing.Size(310, 242);
            this.Comms.TabIndex = 5;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(2, 313);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(310, 23);
            this.Ok.TabIndex = 6;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // CommunitiesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 337);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Comms);
            this.Controls.Add(label2);
            this.Controls.Add(this.RegionSelect);
            this.Controls.Add(this.ScavshyValue);
            this.Controls.Add(this.ScavshyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CommunitiesEdit";
            this.Text = "Communities";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ScavshyLabel;
        private System.Windows.Forms.HScrollBar ScavshyValue;
        private System.Windows.Forms.Panel Comms;
        internal System.Windows.Forms.ComboBox RegionSelect;
        private System.Windows.Forms.Button Ok;
    }
}