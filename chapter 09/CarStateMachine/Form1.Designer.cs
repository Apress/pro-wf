namespace CarStateMachine
{
    partial class Form1
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
            this.btnStartEngine = new System.Windows.Forms.Button();
            this.btnStopEngine = new System.Windows.Forms.Button();
            this.btnLeaveCar = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnBeepHorn = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnNewCar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartEngine
            // 
            this.btnStartEngine.Location = new System.Drawing.Point(113, 40);
            this.btnStartEngine.Name = "btnStartEngine";
            this.btnStartEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStartEngine.TabIndex = 0;
            this.btnStartEngine.Text = "Start Engine";
            this.btnStartEngine.UseVisualStyleBackColor = true;
            this.btnStartEngine.Click += new System.EventHandler(this.btnStartEngine_Click);
            // 
            // btnStopEngine
            // 
            this.btnStopEngine.Location = new System.Drawing.Point(194, 40);
            this.btnStopEngine.Name = "btnStopEngine";
            this.btnStopEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStopEngine.TabIndex = 1;
            this.btnStopEngine.Text = "Stop Engine";
            this.btnStopEngine.UseVisualStyleBackColor = true;
            this.btnStopEngine.Click += new System.EventHandler(this.btnStopEngine_Click);
            // 
            // btnLeaveCar
            // 
            this.btnLeaveCar.Location = new System.Drawing.Point(113, 98);
            this.btnLeaveCar.Name = "btnLeaveCar";
            this.btnLeaveCar.Size = new System.Drawing.Size(75, 23);
            this.btnLeaveCar.TabIndex = 2;
            this.btnLeaveCar.Text = "Leave Car";
            this.btnLeaveCar.UseVisualStyleBackColor = true;
            this.btnLeaveCar.Click += new System.EventHandler(this.btnLeaveCar_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(32, 69);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 3;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(113, 69);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop Moving";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(194, 69);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 5;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnBeepHorn
            // 
            this.btnBeepHorn.Location = new System.Drawing.Point(32, 98);
            this.btnBeepHorn.Name = "btnBeepHorn";
            this.btnBeepHorn.Size = new System.Drawing.Size(75, 23);
            this.btnBeepHorn.TabIndex = 6;
            this.btnBeepHorn.Text = "Beep Horn";
            this.btnBeepHorn.UseVisualStyleBackColor = true;
            this.btnBeepHorn.Click += new System.EventHandler(this.btnBeepHorn_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(300, 23);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewCar
            // 
            this.btnNewCar.Location = new System.Drawing.Point(32, 40);
            this.btnNewCar.Name = "btnNewCar";
            this.btnNewCar.Size = new System.Drawing.Size(75, 23);
            this.btnNewCar.TabIndex = 8;
            this.btnNewCar.Text = "New Car";
            this.btnNewCar.UseVisualStyleBackColor = true;
            this.btnNewCar.Click += new System.EventHandler(this.btnNewCar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 163);
            this.Controls.Add(this.btnNewCar);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnBeepHorn);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnLeaveCar);
            this.Controls.Add(this.btnStopEngine);
            this.Controls.Add(this.btnStartEngine);
            this.Name = "Form1";
            this.Text = "Car Workflow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartEngine;
        private System.Windows.Forms.Button btnStopEngine;
        private System.Windows.Forms.Button btnLeaveCar;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnBeepHorn;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnNewCar;
    }
}

