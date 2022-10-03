namespace Complex_Data_Structures_AT3
{
    partial class MasterFileProject
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
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.listBoxFilter = new System.Windows.Forms.ListBox();
            this.textBoxFilterId = new System.Windows.Forms.TextBox();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(42, 113);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(120, 303);
            this.listBoxDisplay.TabIndex = 0;
            // 
            // listBoxFilter
            // 
            this.listBoxFilter.FormattingEnabled = true;
            this.listBoxFilter.Location = new System.Drawing.Point(245, 113);
            this.listBoxFilter.Name = "listBoxFilter";
            this.listBoxFilter.Size = new System.Drawing.Size(120, 303);
            this.listBoxFilter.TabIndex = 1;
            // 
            // textBoxFilterId
            // 
            this.textBoxFilterId.Location = new System.Drawing.Point(404, 132);
            this.textBoxFilterId.Name = "textBoxFilterId";
            this.textBoxFilterId.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilterId.TabIndex = 2;
            this.textBoxFilterId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilterId_KeyPress);
            this.textBoxFilterId.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFilterId_MouseDoubleClick);
            // 
            // textBoxFilterName
            // 
            this.textBoxFilterName.Location = new System.Drawing.Point(404, 190);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilterName.TabIndex = 3;
            this.textBoxFilterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilterName_KeyPress);
            this.textBoxFilterName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFilterName_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Staff ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Staff Name:";
            // 
            // MasterFileProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterName);
            this.Controls.Add(this.textBoxFilterId);
            this.Controls.Add(this.listBoxFilter);
            this.Controls.Add(this.listBoxDisplay);
            this.Name = "MasterFileProject";
            this.Text = "Master File Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.ListBox listBoxFilter;
        private System.Windows.Forms.TextBox textBoxFilterId;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

