﻿namespace SyringeTest
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView_seq = new System.Windows.Forms.ListView();
            this.columnHeader_seq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_detail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_add_seq = new System.Windows.Forms.Button();
            this.button_remove_seq = new System.Windows.Forms.Button();
            this.button_clear_seq = new System.Windows.Forms.Button();
            this.textBox_seq_repeat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start_seq = new System.Windows.Forms.Button();
            this.button_start_seq_continuous = new System.Windows.Forms.Button();
            this.button_stop_seq = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_seq_del = new System.Windows.Forms.Button();
            this.button_seq_save = new System.Windows.Forms.Button();
            this.listView_seq_recipe = new System.Windows.Forms.ListView();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_seq_name = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iOToolStripMenuItem,
            this.motionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iOToolStripMenuItem
            // 
            this.iOToolStripMenuItem.Name = "iOToolStripMenuItem";
            this.iOToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.iOToolStripMenuItem.Text = "IO";
            this.iOToolStripMenuItem.Click += new System.EventHandler(this.iOToolStripMenuItem_Click);
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.motionToolStripMenuItem.Text = "Motion";
            this.motionToolStripMenuItem.Click += new System.EventHandler(this.motionToolStripMenuItem_Click);
            // 
            // listView_seq
            // 
            this.listView_seq.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_seq,
            this.columnHeader_detail});
            this.listView_seq.FullRowSelect = true;
            this.listView_seq.Location = new System.Drawing.Point(12, 39);
            this.listView_seq.Name = "listView_seq";
            this.listView_seq.Size = new System.Drawing.Size(328, 288);
            this.listView_seq.TabIndex = 1;
            this.listView_seq.UseCompatibleStateImageBehavior = false;
            this.listView_seq.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_seq
            // 
            this.columnHeader_seq.Text = "Seqeunce";
            this.columnHeader_seq.Width = 111;
            // 
            // columnHeader_detail
            // 
            this.columnHeader_detail.Text = "Detail";
            this.columnHeader_detail.Width = 213;
            // 
            // button_add_seq
            // 
            this.button_add_seq.Location = new System.Drawing.Point(346, 39);
            this.button_add_seq.Name = "button_add_seq";
            this.button_add_seq.Size = new System.Drawing.Size(142, 31);
            this.button_add_seq.TabIndex = 2;
            this.button_add_seq.Text = "Add seqeunce";
            this.button_add_seq.UseVisualStyleBackColor = true;
            this.button_add_seq.Click += new System.EventHandler(this.button_add_seq_Click);
            // 
            // button_remove_seq
            // 
            this.button_remove_seq.Location = new System.Drawing.Point(346, 76);
            this.button_remove_seq.Name = "button_remove_seq";
            this.button_remove_seq.Size = new System.Drawing.Size(142, 31);
            this.button_remove_seq.TabIndex = 3;
            this.button_remove_seq.Text = "Remove seqeunce";
            this.button_remove_seq.UseVisualStyleBackColor = true;
            this.button_remove_seq.Click += new System.EventHandler(this.button_remove_seq_Click);
            // 
            // button_clear_seq
            // 
            this.button_clear_seq.Location = new System.Drawing.Point(346, 113);
            this.button_clear_seq.Name = "button_clear_seq";
            this.button_clear_seq.Size = new System.Drawing.Size(142, 31);
            this.button_clear_seq.TabIndex = 4;
            this.button_clear_seq.Text = "Clear seqeunce";
            this.button_clear_seq.UseVisualStyleBackColor = true;
            this.button_clear_seq.Click += new System.EventHandler(this.button_clear_seq_Click);
            // 
            // textBox_seq_repeat
            // 
            this.textBox_seq_repeat.Location = new System.Drawing.Point(408, 166);
            this.textBox_seq_repeat.Name = "textBox_seq_repeat";
            this.textBox_seq_repeat.Size = new System.Drawing.Size(80, 21);
            this.textBox_seq_repeat.TabIndex = 5;
            this.textBox_seq_repeat.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Repeat : ";
            // 
            // button_start_seq
            // 
            this.button_start_seq.Location = new System.Drawing.Point(348, 193);
            this.button_start_seq.Name = "button_start_seq";
            this.button_start_seq.Size = new System.Drawing.Size(140, 42);
            this.button_start_seq.TabIndex = 7;
            this.button_start_seq.Text = "Start sequence";
            this.button_start_seq.UseVisualStyleBackColor = true;
            this.button_start_seq.Click += new System.EventHandler(this.button_start_seq_Click);
            // 
            // button_start_seq_continuous
            // 
            this.button_start_seq_continuous.Location = new System.Drawing.Point(348, 241);
            this.button_start_seq_continuous.Name = "button_start_seq_continuous";
            this.button_start_seq_continuous.Size = new System.Drawing.Size(140, 42);
            this.button_start_seq_continuous.TabIndex = 8;
            this.button_start_seq_continuous.Text = "Start continuous sequence";
            this.button_start_seq_continuous.UseVisualStyleBackColor = true;
            this.button_start_seq_continuous.Click += new System.EventHandler(this.button_start_seq_continuous_Click);
            // 
            // button_stop_seq
            // 
            this.button_stop_seq.BackColor = System.Drawing.Color.Red;
            this.button_stop_seq.Location = new System.Drawing.Point(348, 289);
            this.button_stop_seq.Name = "button_stop_seq";
            this.button_stop_seq.Size = new System.Drawing.Size(140, 42);
            this.button_stop_seq.TabIndex = 9;
            this.button_stop_seq.Text = "Stop sequence";
            this.button_stop_seq.UseVisualStyleBackColor = false;
            this.button_stop_seq.Click += new System.EventHandler(this.button_stop_seq_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_seq_del);
            this.groupBox1.Controls.Add(this.button_seq_save);
            this.groupBox1.Controls.Add(this.listView_seq_recipe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_seq_name);
            this.groupBox1.Location = new System.Drawing.Point(12, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 158);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sequence";
            // 
            // button_seq_del
            // 
            this.button_seq_del.Location = new System.Drawing.Point(413, 23);
            this.button_seq_del.Name = "button_seq_del";
            this.button_seq_del.Size = new System.Drawing.Size(57, 23);
            this.button_seq_del.TabIndex = 11;
            this.button_seq_del.Text = "Del";
            this.button_seq_del.UseVisualStyleBackColor = true;
            this.button_seq_del.Click += new System.EventHandler(this.button_seq_del_Click);
            // 
            // button_seq_save
            // 
            this.button_seq_save.Location = new System.Drawing.Point(350, 23);
            this.button_seq_save.Name = "button_seq_save";
            this.button_seq_save.Size = new System.Drawing.Size(57, 23);
            this.button_seq_save.TabIndex = 10;
            this.button_seq_save.Text = "Save";
            this.button_seq_save.UseVisualStyleBackColor = true;
            this.button_seq_save.Click += new System.EventHandler(this.button_seq_save_Click);
            // 
            // listView_seq_recipe
            // 
            this.listView_seq_recipe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name});
            this.listView_seq_recipe.FullRowSelect = true;
            this.listView_seq_recipe.GridLines = true;
            this.listView_seq_recipe.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_seq_recipe.Location = new System.Drawing.Point(8, 54);
            this.listView_seq_recipe.Name = "listView_seq_recipe";
            this.listView_seq_recipe.Size = new System.Drawing.Size(462, 98);
            this.listView_seq_recipe.TabIndex = 9;
            this.listView_seq_recipe.UseCompatibleStateImageBehavior = false;
            this.listView_seq_recipe.View = System.Windows.Forms.View.Details;
            this.listView_seq_recipe.SelectedIndexChanged += new System.EventHandler(this.listView_seq_recipe_SelectedIndexChanged);
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Name";
            this.columnHeader_name.Width = 308;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name : ";
            // 
            // textBox_seq_name
            // 
            this.textBox_seq_name.Location = new System.Drawing.Point(68, 25);
            this.textBox_seq_name.Name = "textBox_seq_name";
            this.textBox_seq_name.Size = new System.Drawing.Size(241, 21);
            this.textBox_seq_name.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(500, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_stop_seq);
            this.Controls.Add(this.button_start_seq_continuous);
            this.Controls.Add(this.button_start_seq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_seq_repeat);
            this.Controls.Add(this.button_clear_seq);
            this.Controls.Add(this.button_remove_seq);
            this.Controls.Add(this.button_add_seq);
            this.Controls.Add(this.listView_seq);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOToolStripMenuItem;
        private System.Windows.Forms.ListView listView_seq;
        private System.Windows.Forms.ColumnHeader columnHeader_seq;
        private System.Windows.Forms.ColumnHeader columnHeader_detail;
        private System.Windows.Forms.Button button_add_seq;
        private System.Windows.Forms.Button button_remove_seq;
        private System.Windows.Forms.Button button_clear_seq;
        private System.Windows.Forms.TextBox textBox_seq_repeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_start_seq;
        private System.Windows.Forms.Button button_start_seq_continuous;
        private System.Windows.Forms.Button button_stop_seq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_seq_del;
        private System.Windows.Forms.Button button_seq_save;
        private System.Windows.Forms.ListView listView_seq_recipe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_seq_name;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
    }
}

