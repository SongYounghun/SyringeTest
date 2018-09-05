namespace SyringeTest
{
    partial class AddSequence
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
            this.panel_add_seq = new System.Windows.Forms.Panel();
            this.comboBox_seq = new System.Windows.Forms.ComboBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_add_seq
            // 
            this.panel_add_seq.Location = new System.Drawing.Point(12, 35);
            this.panel_add_seq.Name = "panel_add_seq";
            this.panel_add_seq.Size = new System.Drawing.Size(375, 288);
            this.panel_add_seq.TabIndex = 0;
            // 
            // comboBox_seq
            // 
            this.comboBox_seq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_seq.FormattingEnabled = true;
            this.comboBox_seq.Location = new System.Drawing.Point(12, 9);
            this.comboBox_seq.Name = "comboBox_seq";
            this.comboBox_seq.Size = new System.Drawing.Size(136, 20);
            this.comboBox_seq.TabIndex = 1;
            this.comboBox_seq.SelectedIndexChanged += new System.EventHandler(this.comboBox_seq_SelectedIndexChanged);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(312, 337);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // AddSeqeunce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 372);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.comboBox_seq);
            this.Controls.Add(this.panel_add_seq);
            this.Name = "AddSeqeunce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddSeqeunce";
            this.Load += new System.EventHandler(this.AddSeqeunce_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_add_seq;
        private System.Windows.Forms.ComboBox comboBox_seq;
        private System.Windows.Forms.Button button_ok;
    }
}