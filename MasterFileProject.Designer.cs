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
            this.textBoxFilterId = new System.Windows.Forms.TextBox();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewDisplay = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFilter = new System.Windows.Forms.ListView();
            this.filterId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBoxFilterId
            // 
            this.textBoxFilterId.Location = new System.Drawing.Point(272, 38);
            this.textBoxFilterId.Name = "textBoxFilterId";
            this.textBoxFilterId.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilterId.TabIndex = 2;
            this.textBoxFilterId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterId_KeyUp);
            this.textBoxFilterId.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFilterId_MouseDoubleClick);
            // 
            // textBoxFilterName
            // 
            this.textBoxFilterName.Location = new System.Drawing.Point(272, 85);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilterName.TabIndex = 3;
            this.textBoxFilterName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterName_KeyUp);
            this.textBoxFilterName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFilterName_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Staff ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Staff Name:";
            // 
            // listViewDisplay
            // 
            this.listViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name});
            this.listViewDisplay.HideSelection = false;
            this.listViewDisplay.Location = new System.Drawing.Point(29, 28);
            this.listViewDisplay.Name = "listViewDisplay";
            this.listViewDisplay.Size = new System.Drawing.Size(218, 388);
            this.listViewDisplay.TabIndex = 6;
            this.listViewDisplay.UseCompatibleStateImageBehavior = false;
            this.listViewDisplay.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Staff ID";
            this.id.Width = 65;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 130;
            // 
            // listViewFilter
            // 
            this.listViewFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filterId,
            this.filterName});
            this.listViewFilter.HideSelection = false;
            this.listViewFilter.Location = new System.Drawing.Point(272, 113);
            this.listViewFilter.Name = "listViewFilter";
            this.listViewFilter.Size = new System.Drawing.Size(218, 303);
            this.listViewFilter.TabIndex = 7;
            this.listViewFilter.UseCompatibleStateImageBehavior = false;
            this.listViewFilter.View = System.Windows.Forms.View.Details;
            this.listViewFilter.Click += new System.EventHandler(this.listViewFilter_Click);
            // 
            // filterId
            // 
            this.filterId.Text = "Staff ID";
            this.filterId.Width = 65;
            // 
            // filterName
            // 
            this.filterName.Text = "Name";
            this.filterName.Width = 130;
            // 
            // MasterFileProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 450);
            this.Controls.Add(this.listViewFilter);
            this.Controls.Add(this.listViewDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterName);
            this.Controls.Add(this.textBoxFilterId);
            this.Name = "MasterFileProject";
            this.Text = "Master File Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterId;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewDisplay;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ListView listViewFilter;
        private System.Windows.Forms.ColumnHeader filterId;
        private System.Windows.Forms.ColumnHeader filterName;
    }
}

