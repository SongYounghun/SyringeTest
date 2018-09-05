namespace GalvoScanner.Motion.DialogMotion
{
    partial class AddMotionData
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_data_name = new System.Windows.Forms.TextBox();
            this.button_add_ok = new System.Windows.Forms.Button();
            this.comboBox_axis = new System.Windows.Forms.ComboBox();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.label59 = new System.Windows.Forms.Label();
            this.textBox_pos = new System.Windows.Forms.TextBox();
            this.label_position = new System.Windows.Forms.Label();
            this.button_current_set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 122);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(297, 199);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name : ";
            // 
            // textBox_data_name
            // 
            this.textBox_data_name.Location = new System.Drawing.Point(72, 95);
            this.textBox_data_name.Name = "textBox_data_name";
            this.textBox_data_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_data_name.TabIndex = 2;
            // 
            // button_add_ok
            // 
            this.button_add_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add_ok.Location = new System.Drawing.Point(12, 327);
            this.button_add_ok.Name = "button_add_ok";
            this.button_add_ok.Size = new System.Drawing.Size(297, 34);
            this.button_add_ok.TabIndex = 3;
            this.button_add_ok.Text = "Add";
            this.button_add_ok.UseVisualStyleBackColor = true;
            this.button_add_ok.Click += new System.EventHandler(this.button_add_ok_Click);
            // 
            // comboBox_axis
            // 
            this.comboBox_axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_axis.FormattingEnabled = true;
            this.comboBox_axis.Location = new System.Drawing.Point(12, 12);
            this.comboBox_axis.Name = "comboBox_axis";
            this.comboBox_axis.Size = new System.Drawing.Size(83, 20);
            this.comboBox_axis.TabIndex = 4;
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(184, 49);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(27, 12);
            this.label59.TabIndex = 65;
            this.label59.Text = "mm";
            // 
            // textBox_pos
            // 
            this.textBox_pos.Location = new System.Drawing.Point(81, 46);
            this.textBox_pos.Name = "textBox_pos";
            this.textBox_pos.ReadOnly = true;
            this.textBox_pos.Size = new System.Drawing.Size(100, 21);
            this.textBox_pos.TabIndex = 64;
            this.textBox_pos.Text = "0";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Location = new System.Drawing.Point(12, 49);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(62, 12);
            this.label_position.TabIndex = 63;
            this.label_position.Text = "Position  :";
            // 
            // button_current_set
            // 
            this.button_current_set.Location = new System.Drawing.Point(217, 39);
            this.button_current_set.Name = "button_current_set";
            this.button_current_set.Size = new System.Drawing.Size(92, 33);
            this.button_current_set.TabIndex = 66;
            this.button_current_set.Text = "Set current";
            this.button_current_set.UseVisualStyleBackColor = true;
            this.button_current_set.Click += new System.EventHandler(this.button_current_set_Click);
            // 
            // AddMotionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 373);
            this.Controls.Add(this.button_current_set);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.textBox_pos);
            this.Controls.Add(this.label_position);
            this.Controls.Add(this.comboBox_axis);
            this.Controls.Add(this.button_add_ok);
            this.Controls.Add(this.textBox_data_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMotionData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMotionData";
            this.Load += new System.EventHandler(this.AddMotionData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_data_name;
        private System.Windows.Forms.Button button_add_ok;
        private System.Windows.Forms.ComboBox comboBox_axis;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox_pos;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.Button button_current_set;
    }
}