
namespace RainWorldStateEdit
{
    partial class CommunityPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.ValueBar = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(7, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(135, 31);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ValueBar
            // 
            this.ValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueBar.LargeChange = 1;
            this.ValueBar.Location = new System.Drawing.Point(145, 7);
            this.ValueBar.Maximum = 1000;
            this.ValueBar.Minimum = -1000;
            this.ValueBar.Name = "ValueBar";
            this.ValueBar.Size = new System.Drawing.Size(208, 17);
            this.ValueBar.TabIndex = 1;
            this.ValueBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ValueBar_Scroll);
            // 
            // CommunityPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueBar);
            this.Controls.Add(this.NameLabel);
            this.Name = "CommunityPanel";
            this.Size = new System.Drawing.Size(359, 31);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.HScrollBar ValueBar;
    }
}
