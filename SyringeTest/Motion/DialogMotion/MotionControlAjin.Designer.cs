namespace GalvoScanner.Motion.DialogMotion
{
    partial class MotionControlAjin
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_gantry_info = new System.Windows.Forms.Label();
            this.button_regoin_position_setting = new System.Windows.Forms.Button();
            this.button_pos_clear = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox_pos = new System.Windows.Forms.TextBox();
            this.label_position = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.edtMoveDec = new System.Windows.Forms.NumericUpDown();
            this.edtMoveAcc = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_abs_pos = new System.Windows.Forms.TextBox();
            this.button_move_abs = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_step_pos = new System.Windows.Forms.TextBox();
            this.btnStepMoveN = new System.Windows.Forms.Button();
            this.btnStepMoveP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnJogMoveN = new System.Windows.Forms.Button();
            this.btnJogMoveP = new System.Windows.Forms.Button();
            this.labelHomeSearch = new System.Windows.Forms.Label();
            this.button_home = new System.Windows.Forms.Button();
            this.checkBox_servo_on = new System.Windows.Forms.CheckBox();
            this.comboBox_Axis = new System.Windows.Forms.ComboBox();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.tmHomeInfo = new System.Windows.Forms.Timer(this.components);
            this.button_all_stop = new System.Windows.Forms.Button();
            this.button_all_home = new System.Windows.Forms.Button();
            this.button_move_camera_pos = new System.Windows.Forms.Button();
            this.button_move_galvo_pos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_motion_list_add = new System.Windows.Forms.Button();
            this.listView_motion_data = new System.Windows.Forms.ListView();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_motion_list_modify = new System.Windows.Forms.Button();
            this.button_list_clear = new System.Windows.Forms.Button();
            this.button_motion_list_move = new System.Windows.Forms.Button();
            this.button_motion_list_remove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_gantry_info);
            this.groupBox1.Controls.Add(this.button_regoin_position_setting);
            this.groupBox1.Controls.Add(this.button_pos_clear);
            this.groupBox1.Controls.Add(this.label59);
            this.groupBox1.Controls.Add(this.textBox_pos);
            this.groupBox1.Controls.Add(this.label_position);
            this.groupBox1.Controls.Add(this.button_stop);
            this.groupBox1.Controls.Add(this.edtMoveDec);
            this.groupBox1.Controls.Add(this.edtMoveAcc);
            this.groupBox1.Controls.Add(this.edtMoveVel);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelHomeSearch);
            this.groupBox1.Controls.Add(this.button_home);
            this.groupBox1.Controls.Add(this.checkBox_servo_on);
            this.groupBox1.Controls.Add(this.comboBox_Axis);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 383);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis Control";
            // 
            // label_gantry_info
            // 
            this.label_gantry_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_gantry_info.Location = new System.Drawing.Point(210, 47);
            this.label_gantry_info.Name = "label_gantry_info";
            this.label_gantry_info.Size = new System.Drawing.Size(62, 22);
            this.label_gantry_info.TabIndex = 65;
            this.label_gantry_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_regoin_position_setting
            // 
            this.button_regoin_position_setting.Location = new System.Drawing.Point(6, 354);
            this.button_regoin_position_setting.Name = "button_regoin_position_setting";
            this.button_regoin_position_setting.Size = new System.Drawing.Size(138, 23);
            this.button_regoin_position_setting.TabIndex = 64;
            this.button_regoin_position_setting.Text = "Setting region position";
            this.button_regoin_position_setting.UseVisualStyleBackColor = true;
            this.button_regoin_position_setting.Visible = false;
            this.button_regoin_position_setting.Click += new System.EventHandler(this.button_regoin_position_setting_Click);
            // 
            // button_pos_clear
            // 
            this.button_pos_clear.Location = new System.Drawing.Point(210, 308);
            this.button_pos_clear.Name = "button_pos_clear";
            this.button_pos_clear.Size = new System.Drawing.Size(61, 26);
            this.button_pos_clear.TabIndex = 63;
            this.button_pos_clear.Text = "Set zero";
            this.button_pos_clear.UseVisualStyleBackColor = true;
            this.button_pos_clear.Click += new System.EventHandler(this.button_pos_clear_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(178, 315);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(27, 12);
            this.label59.TabIndex = 62;
            this.label59.Text = "mm";
            // 
            // textBox_pos
            // 
            this.textBox_pos.Location = new System.Drawing.Point(75, 312);
            this.textBox_pos.Name = "textBox_pos";
            this.textBox_pos.ReadOnly = true;
            this.textBox_pos.Size = new System.Drawing.Size(100, 21);
            this.textBox_pos.TabIndex = 61;
            this.textBox_pos.Text = "0";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Location = new System.Drawing.Point(6, 315);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(62, 12);
            this.label_position.TabIndex = 60;
            this.label_position.Text = "Position  :";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(196, 105);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 75);
            this.button_stop.TabIndex = 59;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // edtMoveDec
            // 
            this.edtMoveDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveDec.DecimalPlaces = 3;
            this.edtMoveDec.Location = new System.Drawing.Point(110, 159);
            this.edtMoveDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveDec.Name = "edtMoveDec";
            this.edtMoveDec.Size = new System.Drawing.Size(80, 21);
            this.edtMoveDec.TabIndex = 58;
            this.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtMoveDec.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.edtMoveDec.ValueChanged += new System.EventHandler(this.edtMoveDec_ValueChanged);
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAcc.DecimalPlaces = 3;
            this.edtMoveAcc.Location = new System.Drawing.Point(110, 132);
            this.edtMoveAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(80, 21);
            this.edtMoveAcc.TabIndex = 57;
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtMoveAcc.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.edtMoveAcc.ValueChanged += new System.EventHandler(this.edtMoveAcc_ValueChanged);
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(110, 105);
            this.edtMoveVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(80, 21);
            this.edtMoveVel.TabIndex = 56;
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtMoveVel.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.edtMoveVel.ValueChanged += new System.EventHandler(this.edtMoveVel_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 163);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 12);
            this.label21.TabIndex = 55;
            this.label21.Text = "Deceleration  :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 12);
            this.label19.TabIndex = 54;
            this.label19.Text = "Acceleration  :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 12);
            this.label17.TabIndex = 53;
            this.label17.Text = "Velocity        :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_abs_pos);
            this.groupBox4.Controls.Add(this.button_move_abs);
            this.groupBox4.Location = new System.Drawing.Point(6, 254);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 49);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Absolute (mm)";
            // 
            // textBox_abs_pos
            // 
            this.textBox_abs_pos.Location = new System.Drawing.Point(6, 20);
            this.textBox_abs_pos.Name = "textBox_abs_pos";
            this.textBox_abs_pos.Size = new System.Drawing.Size(91, 21);
            this.textBox_abs_pos.TabIndex = 35;
            this.textBox_abs_pos.Text = "0";
            // 
            // button_move_abs
            // 
            this.button_move_abs.Location = new System.Drawing.Point(105, 16);
            this.button_move_abs.Name = "button_move_abs";
            this.button_move_abs.Size = new System.Drawing.Size(61, 26);
            this.button_move_abs.TabIndex = 33;
            this.button_move_abs.Text = "Move";
            this.button_move_abs.UseVisualStyleBackColor = true;
            this.button_move_abs.Click += new System.EventHandler(this.button_move_abs_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_step_pos);
            this.groupBox3.Controls.Add(this.btnStepMoveN);
            this.groupBox3.Controls.Add(this.btnStepMoveP);
            this.groupBox3.Location = new System.Drawing.Point(105, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 49);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step (mm)";
            // 
            // textBox_step_pos
            // 
            this.textBox_step_pos.Location = new System.Drawing.Point(45, 20);
            this.textBox_step_pos.Name = "textBox_step_pos";
            this.textBox_step_pos.Size = new System.Drawing.Size(73, 21);
            this.textBox_step_pos.TabIndex = 35;
            this.textBox_step_pos.Text = "5";
            // 
            // btnStepMoveN
            // 
            this.btnStepMoveN.Location = new System.Drawing.Point(6, 17);
            this.btnStepMoveN.Name = "btnStepMoveN";
            this.btnStepMoveN.Size = new System.Drawing.Size(33, 26);
            this.btnStepMoveN.TabIndex = 34;
            this.btnStepMoveN.Text = "(-)";
            this.btnStepMoveN.UseVisualStyleBackColor = true;
            this.btnStepMoveN.Click += new System.EventHandler(this.btnStepMoveN_Click);
            // 
            // btnStepMoveP
            // 
            this.btnStepMoveP.Location = new System.Drawing.Point(124, 17);
            this.btnStepMoveP.Name = "btnStepMoveP";
            this.btnStepMoveP.Size = new System.Drawing.Size(33, 26);
            this.btnStepMoveP.TabIndex = 33;
            this.btnStepMoveP.Text = "(+)";
            this.btnStepMoveP.UseVisualStyleBackColor = true;
            this.btnStepMoveP.Click += new System.EventHandler(this.btnStepMoveP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnJogMoveN);
            this.groupBox2.Controls.Add(this.btnJogMoveP);
            this.groupBox2.Location = new System.Drawing.Point(7, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 49);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jog";
            // 
            // btnJogMoveN
            // 
            this.btnJogMoveN.Location = new System.Drawing.Point(6, 17);
            this.btnJogMoveN.Name = "btnJogMoveN";
            this.btnJogMoveN.Size = new System.Drawing.Size(33, 26);
            this.btnJogMoveN.TabIndex = 34;
            this.btnJogMoveN.Text = "(-)";
            this.btnJogMoveN.UseVisualStyleBackColor = true;
            this.btnJogMoveN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseDown);
            this.btnJogMoveN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseUp);
            // 
            // btnJogMoveP
            // 
            this.btnJogMoveP.Location = new System.Drawing.Point(52, 17);
            this.btnJogMoveP.Name = "btnJogMoveP";
            this.btnJogMoveP.Size = new System.Drawing.Size(33, 26);
            this.btnJogMoveP.TabIndex = 33;
            this.btnJogMoveP.Text = "(+)";
            this.btnJogMoveP.UseVisualStyleBackColor = true;
            this.btnJogMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseDown);
            this.btnJogMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseUp);
            // 
            // labelHomeSearch
            // 
            this.labelHomeSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeSearch.Location = new System.Drawing.Point(75, 72);
            this.labelHomeSearch.Name = "labelHomeSearch";
            this.labelHomeSearch.Size = new System.Drawing.Size(197, 21);
            this.labelHomeSearch.TabIndex = 49;
            this.labelHomeSearch.Text = " [FFH] HOME_ERR_UNKNOWN";
            this.labelHomeSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_home
            // 
            this.button_home.Location = new System.Drawing.Point(7, 71);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(62, 23);
            this.button_home.TabIndex = 2;
            this.button_home.Text = "Home";
            this.button_home.UseVisualStyleBackColor = true;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // checkBox_servo_on
            // 
            this.checkBox_servo_on.AutoSize = true;
            this.checkBox_servo_on.Location = new System.Drawing.Point(7, 48);
            this.checkBox_servo_on.Name = "checkBox_servo_on";
            this.checkBox_servo_on.Size = new System.Drawing.Size(74, 16);
            this.checkBox_servo_on.TabIndex = 1;
            this.checkBox_servo_on.Text = "Servo on";
            this.checkBox_servo_on.UseVisualStyleBackColor = true;
            this.checkBox_servo_on.CheckedChanged += new System.EventHandler(this.checkBox_servo_on_CheckedChanged);
            // 
            // comboBox_Axis
            // 
            this.comboBox_Axis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Axis.FormattingEnabled = true;
            this.comboBox_Axis.Location = new System.Drawing.Point(7, 21);
            this.comboBox_Axis.Name = "comboBox_Axis";
            this.comboBox_Axis.Size = new System.Drawing.Size(280, 20);
            this.comboBox_Axis.TabIndex = 0;
            this.comboBox_Axis.SelectedIndexChanged += new System.EventHandler(this.comboBox_Axis_SelectedIndexChanged);
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // tmHomeInfo
            // 
            this.tmHomeInfo.Enabled = true;
            this.tmHomeInfo.Tick += new System.EventHandler(this.tmHomeInfo_Tick);
            // 
            // button_all_stop
            // 
            this.button_all_stop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_all_stop.Location = new System.Drawing.Point(3, 392);
            this.button_all_stop.Name = "button_all_stop";
            this.button_all_stop.Size = new System.Drawing.Size(293, 41);
            this.button_all_stop.TabIndex = 1;
            this.button_all_stop.Text = "All Stop";
            this.button_all_stop.UseVisualStyleBackColor = true;
            this.button_all_stop.Click += new System.EventHandler(this.button_all_stop_Click);
            // 
            // button_all_home
            // 
            this.button_all_home.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_all_home.Location = new System.Drawing.Point(3, 439);
            this.button_all_home.Name = "button_all_home";
            this.button_all_home.Size = new System.Drawing.Size(293, 33);
            this.button_all_home.TabIndex = 2;
            this.button_all_home.Text = "All Home";
            this.button_all_home.UseVisualStyleBackColor = true;
            this.button_all_home.Click += new System.EventHandler(this.button_all_home_Click);
            // 
            // button_move_camera_pos
            // 
            this.button_move_camera_pos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_move_camera_pos.Location = new System.Drawing.Point(149, 3);
            this.button_move_camera_pos.Name = "button_move_camera_pos";
            this.button_move_camera_pos.Size = new System.Drawing.Size(141, 37);
            this.button_move_camera_pos.TabIndex = 3;
            this.button_move_camera_pos.Text = "Move camera position";
            this.button_move_camera_pos.UseVisualStyleBackColor = true;
            this.button_move_camera_pos.Click += new System.EventHandler(this.button_move_camera_pos_Click);
            // 
            // button_move_galvo_pos
            // 
            this.button_move_galvo_pos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_move_galvo_pos.Location = new System.Drawing.Point(3, 3);
            this.button_move_galvo_pos.Name = "button_move_galvo_pos";
            this.button_move_galvo_pos.Size = new System.Drawing.Size(140, 37);
            this.button_move_galvo_pos.TabIndex = 4;
            this.button_move_galvo_pos.Text = "Move galvano scanner position";
            this.button_move_galvo_pos.UseVisualStyleBackColor = true;
            this.button_move_galvo_pos.Click += new System.EventHandler(this.button_move_galvo_pos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_move_camera_pos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_move_galvo_pos, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 478);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 43);
            this.tableLayoutPanel1.TabIndex = 16;
            this.tableLayoutPanel1.Visible = false;
            // 
            // button_motion_list_add
            // 
            this.button_motion_list_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_motion_list_add.Location = new System.Drawing.Point(3, 3);
            this.button_motion_list_add.Name = "button_motion_list_add";
            this.button_motion_list_add.Size = new System.Drawing.Size(52, 24);
            this.button_motion_list_add.TabIndex = 18;
            this.button_motion_list_add.Text = "Add";
            this.button_motion_list_add.UseVisualStyleBackColor = true;
            this.button_motion_list_add.Click += new System.EventHandler(this.button_motion_list_add_Click);
            // 
            // listView_motion_data
            // 
            this.listView_motion_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_motion_data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name});
            this.listView_motion_data.FullRowSelect = true;
            this.listView_motion_data.Location = new System.Drawing.Point(3, 539);
            this.listView_motion_data.MultiSelect = false;
            this.listView_motion_data.Name = "listView_motion_data";
            this.listView_motion_data.Size = new System.Drawing.Size(293, 138);
            this.listView_motion_data.TabIndex = 19;
            this.listView_motion_data.UseCompatibleStateImageBehavior = false;
            this.listView_motion_data.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.button_motion_list_modify, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_motion_list_add, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_list_clear, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_motion_list_move, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_motion_list_remove, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 683);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 30);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // button_motion_list_modify
            // 
            this.button_motion_list_modify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_motion_list_modify.Location = new System.Drawing.Point(61, 3);
            this.button_motion_list_modify.Name = "button_motion_list_modify";
            this.button_motion_list_modify.Size = new System.Drawing.Size(52, 24);
            this.button_motion_list_modify.TabIndex = 22;
            this.button_motion_list_modify.Text = "Modify";
            this.button_motion_list_modify.UseVisualStyleBackColor = true;
            this.button_motion_list_modify.Click += new System.EventHandler(this.button_motion_list_modify_Click);
            // 
            // button_list_clear
            // 
            this.button_list_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_list_clear.Location = new System.Drawing.Point(235, 3);
            this.button_list_clear.Name = "button_list_clear";
            this.button_list_clear.Size = new System.Drawing.Size(55, 24);
            this.button_list_clear.TabIndex = 21;
            this.button_list_clear.Text = "Clear";
            this.button_list_clear.UseVisualStyleBackColor = true;
            this.button_list_clear.Click += new System.EventHandler(this.button_list_clear_Click);
            // 
            // button_motion_list_move
            // 
            this.button_motion_list_move.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_motion_list_move.Location = new System.Drawing.Point(119, 3);
            this.button_motion_list_move.Name = "button_motion_list_move";
            this.button_motion_list_move.Size = new System.Drawing.Size(52, 24);
            this.button_motion_list_move.TabIndex = 19;
            this.button_motion_list_move.Text = "Move";
            this.button_motion_list_move.UseVisualStyleBackColor = true;
            this.button_motion_list_move.Click += new System.EventHandler(this.button_motion_list_move_Click);
            // 
            // button_motion_list_remove
            // 
            this.button_motion_list_remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_motion_list_remove.Location = new System.Drawing.Point(177, 3);
            this.button_motion_list_remove.Name = "button_motion_list_remove";
            this.button_motion_list_remove.Size = new System.Drawing.Size(52, 24);
            this.button_motion_list_remove.TabIndex = 20;
            this.button_motion_list_remove.Text = "Remove";
            this.button_motion_list_remove.UseVisualStyleBackColor = true;
            this.button_motion_list_remove.Click += new System.EventHandler(this.button_motion_list_remove_Click);
            // 
            // MotionControlAjin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.listView_motion_data);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_all_home);
            this.Controls.Add(this.button_all_stop);
            this.Controls.Add(this.groupBox1);
            this.Name = "MotionControlAjin";
            this.Size = new System.Drawing.Size(299, 716);
            this.Load += new System.EventHandler(this.MotionControlAjin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Axis;
        private System.Windows.Forms.CheckBox checkBox_servo_on;
        private System.Windows.Forms.NumericUpDown edtMoveDec;
        private System.Windows.Forms.NumericUpDown edtMoveAcc;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_abs_pos;
        private System.Windows.Forms.Button button_move_abs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_step_pos;
        private System.Windows.Forms.Button btnStepMoveN;
        private System.Windows.Forms.Button btnStepMoveP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnJogMoveN;
        private System.Windows.Forms.Button btnJogMoveP;
        private System.Windows.Forms.Label labelHomeSearch;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.Timer tmHomeInfo;
        private System.Windows.Forms.Button button_pos_clear;
        private System.Windows.Forms.Button button_all_stop;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox_pos;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.Button button_all_home;
        private System.Windows.Forms.Button button_regoin_position_setting;
        private System.Windows.Forms.Button button_move_camera_pos;
        private System.Windows.Forms.Button button_move_galvo_pos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_motion_list_add;
        private System.Windows.Forms.ListView listView_motion_data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_motion_list_move;
        private System.Windows.Forms.Button button_motion_list_remove;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.Button button_list_clear;
        private System.Windows.Forms.Button button_motion_list_modify;
        private System.Windows.Forms.Label label_gantry_info;

    }
}
