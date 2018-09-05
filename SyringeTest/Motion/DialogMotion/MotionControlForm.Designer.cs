namespace SyringeTest.Motion.DialogMotion
{
    partial class MotionControlForm
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
            this.button_setting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(314, 12);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 0;
            this.button_setting.Text = "Setting";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 735);
            this.panel1.TabIndex = 1;
            // 
            // MotionControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(401, 788);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_setting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MotionControlForm";
            this.Text = "MotionControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionControlForm_FormClosing);
            this.Load += new System.EventHandler(this.MotionControlForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_setting;
        private System.Windows.Forms.Panel panel1;

    }
}