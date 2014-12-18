namespace CTripOSS.Baiji.Editor
{
    partial class PrunerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_OperationsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // m_OperationsCheckedListBox
            // 
            this.m_OperationsCheckedListBox.CheckOnClick = true;
            this.m_OperationsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_OperationsCheckedListBox.FormattingEnabled = true;
            this.m_OperationsCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.m_OperationsCheckedListBox.Name = "m_OperationsCheckedListBox";
            this.m_OperationsCheckedListBox.Size = new System.Drawing.Size(442, 162);
            this.m_OperationsCheckedListBox.TabIndex = 1;
            // 
            // PrunerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_OperationsCheckedListBox);
            this.Name = "PrunerPanel";
            this.Size = new System.Drawing.Size(442, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_OperationsCheckedListBox;
    }
}
