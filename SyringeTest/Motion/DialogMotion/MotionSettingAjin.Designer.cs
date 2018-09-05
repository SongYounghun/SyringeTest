namespace GalvoScanner.Motion.DialogMotion
{
    partial class MotionSettingAjin
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_load_mot = new System.Windows.Forms.Button();
            this.textBox_MOT_filepath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_total_unit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_unit_per_mm_encoder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_use_axis = new System.Windows.Forms.CheckBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox_unit_per_mm = new System.Windows.Forms.TextBox();
            this.label_unitpermm = new System.Windows.Forms.Label();
            this.comboBox_Axis = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_gantry_status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_gan_master_axis = new System.Windows.Forms.ComboBox();
            this.comboBox_gan_slave_axis = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_slave_use_home = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_slave_offset = new System.Windows.Forms.TextBox();
            this.textBox_slave_offset_range = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_set_gantry_enable = new System.Windows.Forms.Button();
            this.button_set_gantry_disable = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_load_mot
            // 
            this.button_load_mot.Location = new System.Drawing.Point(3, 15);
            this.button_load_mot.Name = "button_load_mot";
            this.button_load_mot.Size = new System.Drawing.Size(114, 23);
            this.button_load_mot.TabIndex = 0;
            this.button_load_mot.Text = "Load MOT file";
            this.button_load_mot.UseVisualStyleBackColor = true;
            this.button_load_mot.Click += new System.EventHandler(this.button_load_mot_Click);
            // 
            // textBox_MOT_filepath
            // 
            this.textBox_MOT_filepath.Location = new System.Drawing.Point(124, 17);
            this.textBox_MOT_filepath.Name = "textBox_MOT_filepath";
            this.textBox_MOT_filepath.ReadOnly = true;
            this.textBox_MOT_filepath.Size = new System.Drawing.Size(230, 21);
            this.textBox_MOT_filepath.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_total_unit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_unit_per_mm_encoder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox_use_axis);
            this.groupBox1.Controls.Add(this.button_apply);
            this.groupBox1.Controls.Add(this.label59);
            this.groupBox1.Controls.Add(this.textBox_unit_per_mm);
            this.groupBox1.Controls.Add(this.label_unitpermm);
            this.groupBox1.Controls.Add(this.comboBox_Axis);
            this.groupBox1.Location = new System.Drawing.Point(4, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis setting";
            // 
            // checkBox_total_unit
            // 
            this.checkBox_total_unit.AutoSize = true;
            this.checkBox_total_unit.Checked = true;
            this.checkBox_total_unit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_total_unit.Location = new System.Drawing.Point(136, 58);
            this.checkBox_total_unit.Name = "checkBox_total_unit";
            this.checkBox_total_unit.Size = new System.Drawing.Size(193, 16);
            this.checkBox_total_unit.TabIndex = 71;
            this.checkBox_total_unit.Text = "Total unit (Cmd and Encoder)";
            this.checkBox_total_unit.UseVisualStyleBackColor = true;
            this.checkBox_total_unit.CheckedChanged += new System.EventHandler(this.checkBox_total_unit_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "Unit/mm";
            // 
            // textBox_unit_per_mm_encoder
            // 
            this.textBox_unit_per_mm_encoder.Enabled = false;
            this.textBox_unit_per_mm_encoder.Location = new System.Drawing.Point(172, 107);
            this.textBox_unit_per_mm_encoder.Name = "textBox_unit_per_mm_encoder";
            this.textBox_unit_per_mm_encoder.Size = new System.Drawing.Size(100, 21);
            this.textBox_unit_per_mm_encoder.TabIndex = 69;
            this.textBox_unit_per_mm_encoder.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 12);
            this.label2.TabIndex = 68;
            this.label2.Text = "Unit per mm(for encoder)  :";
            // 
            // checkBox_use_axis
            // 
            this.checkBox_use_axis.AutoSize = true;
            this.checkBox_use_axis.Location = new System.Drawing.Point(7, 146);
            this.checkBox_use_axis.Name = "checkBox_use_axis";
            this.checkBox_use_axis.Size = new System.Drawing.Size(74, 16);
            this.checkBox_use_axis.TabIndex = 67;
            this.checkBox_use_axis.Text = "Use axis";
            this.checkBox_use_axis.UseVisualStyleBackColor = true;
            this.checkBox_use_axis.CheckedChanged += new System.EventHandler(this.checkBox_use_axis_CheckedChanged);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(271, 140);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 66;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(275, 83);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(54, 12);
            this.label59.TabIndex = 65;
            this.label59.Text = "Unit/mm";
            // 
            // textBox_unit_per_mm
            // 
            this.textBox_unit_per_mm.Location = new System.Drawing.Point(172, 80);
            this.textBox_unit_per_mm.Name = "textBox_unit_per_mm";
            this.textBox_unit_per_mm.Size = new System.Drawing.Size(100, 21);
            this.textBox_unit_per_mm.TabIndex = 64;
            this.textBox_unit_per_mm.Text = "0";
            this.textBox_unit_per_mm.TextChanged += new System.EventHandler(this.textBox_unit_per_mm_TextChanged);
            // 
            // label_unitpermm
            // 
            this.label_unitpermm.AutoSize = true;
            this.label_unitpermm.Location = new System.Drawing.Point(80, 83);
            this.label_unitpermm.Name = "label_unitpermm";
            this.label_unitpermm.Size = new System.Drawing.Size(86, 12);
            this.label_unitpermm.TabIndex = 63;
            this.label_unitpermm.Text = "Unit per mm  :";
            // 
            // comboBox_Axis
            // 
            this.comboBox_Axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Axis.FormattingEnabled = true;
            this.comboBox_Axis.Location = new System.Drawing.Point(7, 21);
            this.comboBox_Axis.Name = "comboBox_Axis";
            this.comboBox_Axis.Size = new System.Drawing.Size(339, 20);
            this.comboBox_Axis.TabIndex = 0;
            this.comboBox_Axis.SelectedIndexChanged += new System.EventHandler(this.comboBox_Axis_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button_set_gantry_disable);
            this.groupBox2.Controls.Add(this.button_set_gantry_enable);
            this.groupBox2.Controls.Add(this.textBox_slave_offset_range);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_slave_offset);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.checkBox_slave_use_home);
            this.groupBox2.Controls.Add(this.comboBox_gan_slave_axis);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox_gan_master_axis);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_gantry_status);
            this.groupBox2.Location = new System.Drawing.Point(4, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 200);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gantry setting";
            // 
            // textBox_gantry_status
            // 
            this.textBox_gantry_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_gantry_status.Location = new System.Drawing.Point(8, 20);
            this.textBox_gantry_status.Name = "textBox_gantry_status";
            this.textBox_gantry_status.ReadOnly = true;
            this.textBox_gantry_status.Size = new System.Drawing.Size(139, 21);
            this.textBox_gantry_status.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Master axis :";
            // 
            // comboBox_gan_master_axis
            // 
            this.comboBox_gan_master_axis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_gan_master_axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gan_master_axis.FormattingEnabled = true;
            this.comboBox_gan_master_axis.Location = new System.Drawing.Point(121, 53);
            this.comboBox_gan_master_axis.Name = "comboBox_gan_master_axis";
            this.comboBox_gan_master_axis.Size = new System.Drawing.Size(103, 20);
            this.comboBox_gan_master_axis.TabIndex = 4;
            // 
            // comboBox_gan_slave_axis
            // 
            this.comboBox_gan_slave_axis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_gan_slave_axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gan_slave_axis.FormattingEnabled = true;
            this.comboBox_gan_slave_axis.Location = new System.Drawing.Point(121, 79);
            this.comboBox_gan_slave_axis.Name = "comboBox_gan_slave_axis";
            this.comboBox_gan_slave_axis.Size = new System.Drawing.Size(103, 20);
            this.comboBox_gan_slave_axis.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Slave axis :";
            // 
            // checkBox_slave_use_home
            // 
            this.checkBox_slave_use_home.AutoSize = true;
            this.checkBox_slave_use_home.Location = new System.Drawing.Point(230, 81);
            this.checkBox_slave_use_home.Name = "checkBox_slave_use_home";
            this.checkBox_slave_use_home.Size = new System.Drawing.Size(116, 16);
            this.checkBox_slave_use_home.TabIndex = 7;
            this.checkBox_slave_use_home.Text = "Slave home use";
            this.checkBox_slave_use_home.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Slave offset :";
            // 
            // textBox_slave_offset
            // 
            this.textBox_slave_offset.Enabled = false;
            this.textBox_slave_offset.Location = new System.Drawing.Point(121, 105);
            this.textBox_slave_offset.Name = "textBox_slave_offset";
            this.textBox_slave_offset.Size = new System.Drawing.Size(92, 21);
            this.textBox_slave_offset.TabIndex = 70;
            this.textBox_slave_offset.Text = "0";
            // 
            // textBox_slave_offset_range
            // 
            this.textBox_slave_offset_range.Enabled = false;
            this.textBox_slave_offset_range.Location = new System.Drawing.Point(121, 132);
            this.textBox_slave_offset_range.Name = "textBox_slave_offset_range";
            this.textBox_slave_offset_range.Size = new System.Drawing.Size(92, 21);
            this.textBox_slave_offset_range.TabIndex = 72;
            this.textBox_slave_offset_range.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "Slave offset range:";
            // 
            // button_set_gantry_enable
            // 
            this.button_set_gantry_enable.Location = new System.Drawing.Point(6, 171);
            this.button_set_gantry_enable.Name = "button_set_gantry_enable";
            this.button_set_gantry_enable.Size = new System.Drawing.Size(160, 23);
            this.button_set_gantry_enable.TabIndex = 73;
            this.button_set_gantry_enable.Text = "Enable";
            this.button_set_gantry_enable.UseVisualStyleBackColor = true;
            this.button_set_gantry_enable.Click += new System.EventHandler(this.button_set_gantry_enable_Click);
            // 
            // button_set_gantry_disable
            // 
            this.button_set_gantry_disable.Location = new System.Drawing.Point(186, 171);
            this.button_set_gantry_disable.Name = "button_set_gantry_disable";
            this.button_set_gantry_disable.Size = new System.Drawing.Size(160, 23);
            this.button_set_gantry_disable.TabIndex = 74;
            this.button_set_gantry_disable.Text = "Disable";
            this.button_set_gantry_disable.UseVisualStyleBackColor = true;
            this.button_set_gantry_disable.Click += new System.EventHandler(this.button_set_gantry_disable_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 12);
            this.label7.TabIndex = 75;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 12);
            this.label8.TabIndex = 76;
            this.label8.Text = "mm";
            // 
            // MotionSettingAjin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_MOT_filepath);
            this.Controls.Add(this.button_load_mot);
            this.Name = "MotionSettingAjin";
            this.Size = new System.Drawing.Size(370, 433);
            this.Load += new System.EventHandler(this.MotionSettingAjin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_load_mot;
        private System.Windows.Forms.TextBox textBox_MOT_filepath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Axis;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox_unit_per_mm;
        private System.Windows.Forms.Label label_unitpermm;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.CheckBox checkBox_use_axis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_unit_per_mm_encoder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_total_unit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_gan_slave_axis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_gan_master_axis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_gantry_status;
        private System.Windows.Forms.CheckBox checkBox_slave_use_home;
        private System.Windows.Forms.TextBox textBox_slave_offset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_set_gantry_disable;
        private System.Windows.Forms.Button button_set_gantry_enable;
        private System.Windows.Forms.TextBox textBox_slave_offset_range;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}
