namespace SyringeTest
{
    partial class AddSeqMotion
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_index = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_motion_pos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Axis index : ";
            // 
            // comboBox_index
            // 
            this.comboBox_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_index.FormattingEnabled = true;
            this.comboBox_index.Location = new System.Drawing.Point(132, 72);
            this.comboBox_index.Name = "comboBox_index";
            this.comboBox_index.Size = new System.Drawing.Size(100, 20);
            this.comboBox_index.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position : ";
            // 
            // textBox_motion_pos
            // 
            this.textBox_motion_pos.Location = new System.Drawing.Point(132, 107);
            this.textBox_motion_pos.Name = "textBox_motion_pos";
            this.textBox_motion_pos.Size = new System.Drawing.Size(100, 21);
            this.textBox_motion_pos.TabIndex = 5;
            this.textBox_motion_pos.Text = "0";
            this.textBox_motion_pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "mm";
            // 
            // AddSeqMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_motion_pos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_index);
            this.Name = "AddSeqMotion";
            this.Size = new System.Drawing.Size(375, 288);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_index;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_motion_pos;
        private System.Windows.Forms.Label label3;
    }
}
