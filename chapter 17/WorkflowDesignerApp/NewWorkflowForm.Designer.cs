namespace WorkflowDesignerApp
{
    partial class NewWorkflowForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.listWorkflowTypes = new System.Windows.Forms.ListBox();
            this.txtNewWorkflowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(126, 145);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(113, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create Workflow";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // listWorkflowTypes
            // 
            this.listWorkflowTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.listWorkflowTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listWorkflowTypes.FormattingEnabled = true;
            this.listWorkflowTypes.ItemHeight = 15;
            this.listWorkflowTypes.Location = new System.Drawing.Point(0, 0);
            this.listWorkflowTypes.Name = "listWorkflowTypes";
            this.listWorkflowTypes.Size = new System.Drawing.Size(446, 109);
            this.listWorkflowTypes.TabIndex = 4;
            this.listWorkflowTypes.SelectedIndexChanged += new System.EventHandler(this.listWorkflowTypes_SelectedIndexChanged);
            // 
            // txtNewWorkflowName
            // 
            this.txtNewWorkflowName.Location = new System.Drawing.Point(171, 116);
            this.txtNewWorkflowName.Name = "txtNewWorkflowName";
            this.txtNewWorkflowName.Size = new System.Drawing.Size(218, 20);
            this.txtNewWorkflowName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Workflow Name";
            // 
            // NewWorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewWorkflowName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.listWorkflowTypes);
            this.Name = "NewWorkflowForm";
            this.Text = "Select New Workflow Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox listWorkflowTypes;
        private System.Windows.Forms.TextBox txtNewWorkflowName;
        private System.Windows.Forms.Label label1;
    }
}