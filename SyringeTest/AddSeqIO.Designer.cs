namespace SyringeTest
{
    partial class AddSeqIO
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
            this.comboBox_index = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_on = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBox_index
            // 
            this.comboBox_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_index.FormattingEnabled = true;
            this.comboBox_index.Location = new System.Drawing.Point(116, 65);
            this.comboBox_index.Name = "comboBox_index";
            this.comboBox_index.Size = new System.Drawing.Size(109, 20);
            this.comboBox_index.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output index : ";
            // 
            // checkBox_on
            // 
            this.checkBox_on.AutoSize = true;
            this.checkBox_on.Location = new System.Drawing.Point(242, 67);
            this.checkBox_on.Name = "checkBox_on";
            this.checkBox_on.Size = new System.Drawing.Size(40, 16);
            this.checkBox_on.TabIndex = 2;
            this.checkBox_on.Text = "On";
            this.checkBox_on.UseVisualStyleBackColor = true;
            // 
            // AddSeqIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_on);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_index);
            this.Name = "AddSeqIO";
            this.Size = new System.Drawing.Size(375, 288);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_index;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_on;
    }
}
