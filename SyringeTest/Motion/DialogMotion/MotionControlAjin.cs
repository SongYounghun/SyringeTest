using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GalvoScanner.Common;

namespace GalvoScanner.Motion.DialogMotion
{
    public partial class MotionControlAjin : UserControl
    {
        MotionAjin m_motion = null;

        //RegionPositionSetting m_regionPosSetting = null;

        public MotionControlAjin()
        {
            m_motion = MotionAjin.GetInstance();
                
            InitializeComponent();
        }

        public DialogResult ShowMotionSettingAjin()
        {
            MotionSetting motSetting = new MotionSetting();
            DialogResult res = motSetting.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (m_motion != null)
                {                    
                    m_motion.SaveMotionINI(DefPath.MotionSetting);
                }
            }

            return res;
        }

        private void MotionControlAjin_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    for (int i = 0; i< m_motion.GetAxisCount(); i++)
                    {
                        comboBox_Axis.Items.Add(String.Format("{0} - {1}", i, m_motion.ListAxis[i].DevName));
                        listView_motion_data.Columns.Add(String.Format("Axis {0}", i));
                    }

                    if (comboBox_Axis.Items.Count > 0)
                    {
                        comboBox_Axis.SelectedIndex = 0;
                    }
                }

                LoadData(Application.StartupPath.ToString() + "\\motionAbsPosData");

                //m_regionPosSetting = new RegionPositionSetting(MotionAjin.GetKindOfMotion());
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void comboBox_Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateAxisInfo();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void UpdateAxisInfo()
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;

                    if (index >= -1)
                    {
                        checkBox_servo_on.Checked = m_motion.AxisGetServoOnState(index);
                        double vel = m_motion.ListAxis[index].Velocity;
                        double acc = m_motion.ListAxis[index].Acceleration;
                        double dec = m_motion.ListAxis[index].Deceleration;

                        edtMoveVel.Value = Convert.ToDecimal(vel);
                        edtMoveAcc.Value = Convert.ToDecimal(acc);
                        edtMoveDec.Value = Convert.ToDecimal(dec);
 
                        if (index == m_motion.GantryMasterAxis)
                        {
                            if (m_motion.GantryGetStatus())
                            {
                                label_gantry_info.Text = "Gantry on";
                            }
                            else
                            {
                                label_gantry_info.Text = "Gantry off";
                            }
                        }
                        else
                        {
                            label_gantry_info.Text = "";
                        }
                    }

                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        public String TranslateHomeResult(uint duHomeResult)
        {
            string strResult = "";
            switch (duHomeResult)
            {
                case (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS: strResult = ("[01H] HOME_SUCCESS"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING: strResult = ("([02H] HOME_SEARCHING"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_GNT_RANGE: strResult = ("[10H] HOME_ERR_GNT_RANGE"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_USER_BREAK: strResult = ("[11H] HOME_ERR_USER_BREAK"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_VELOCITY: strResult = ("[12H] HOME_ERR_VELOCITY"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_AMP_FAULT: strResult = ("[13H] HOME_ERR_AMP_FAULT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_NEG_LIMIT: strResult = ("[14H] HOME_ERR_NEG_LIMIT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_POS_LIMIT: strResult = ("[15H] HOME_ERR_POS_LIMIT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_NOT_DETECT: strResult = ("[16H] HOME_ERR_NOT_DETECT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_UNKNOWN: strResult = ("[FFH] HOME_ERR_UNKNOWN"); break;
            }
            return strResult;
        }

        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        double actPos = m_motion.AxisGetActualPosition(index);
                        textBox_pos.Text = String.Format("{0}", actPos);
                    }                    
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
            }
        }

        private void tmHomeInfo_Tick(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        uint homeState = m_motion.AxisHomeState(index);
                        string strHomeState = TranslateHomeResult(homeState);
                        labelHomeSearch.Text = strHomeState;
                    }
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
            }
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisHome(index);

                        UpdateAxisInfo(); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_pos_clear_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisPositionClear(index); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisStop(index); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnJogMoveN_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisMoveJog(index, false); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnJogMoveN_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisStop(index); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnJogMoveP_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisMoveJog(index, true); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnJogMoveP_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisStop(index); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnStepMoveN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        double step = Convert.ToDouble(textBox_step_pos.Text);
                        m_motion.AxisMove(index, -step, true); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void btnStepMoveP_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        double step = Convert.ToDouble(textBox_step_pos.Text);
                        m_motion.AxisMove(index, step, true); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_move_abs_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        double step = Convert.ToDouble(textBox_abs_pos.Text);
                        m_motion.AxisMove(index, step, false); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void checkBox_servo_on_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.AxisSetServoOn(index, checkBox_servo_on.Checked); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_all_stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    m_motion.AllStop();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void edtMoveVel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.ListAxis[index].Velocity = Convert.ToDouble(edtMoveVel.Value);
                        m_motion.SaveMotionINI(DefPath.MotionSetting);
                    }                    
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void edtMoveAcc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.ListAxis[index].Acceleration = Convert.ToDouble(edtMoveAcc.Value);
                        m_motion.SaveMotionINI(DefPath.MotionSetting); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void edtMoveDec_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index >= -1)
                    {
                        m_motion.ListAxis[index].Deceleration = Convert.ToDouble(edtMoveDec.Value);
                        m_motion.SaveMotionINI(DefPath.MotionSetting); 
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_all_home_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    m_motion.AllHome();

                    UpdateAxisInfo();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_regoin_position_setting_Click(object sender, EventArgs e)
        {
            //if (m_regionPosSetting != null)
            //{
            //    m_regionPosSetting.SetAxisNum(comboBox_Axis.SelectedIndex);
            //    m_regionPosSetting.Show();
            //    m_regionPosSetting.Focus();
            //}
        }

        private void button_move_camera_pos_Click(object sender, EventArgs e)
        {
            try
            {
                //if (m_motion != null)
                //{
                //    LVision laserVision = LVision.GetInstance();
                //    if (laserVision != null && laserVision.UseVision && laserVision.VisionMode != LVision.visionModeType.BuiltInVision )
                //    {
                //        m_motion.MoveCameraRegionPosition();
                //    }                    
                //}
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_move_galvo_pos_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    m_motion.MoveGalvoRegionPostion();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_motion_list_add_Click(object sender, EventArgs e)
        {
            try
            {
                AddMotionData motionDataAdd = new AddMotionData(AddMotionData.MotionDataMode.Add);
                if (motionDataAdd.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = new ListViewItem(motionDataAdd.ItemName);
                    for (int i = 0; i < motionDataAdd.ListAxisPosValue.Count; i++)
                    {
                        item.SubItems.Add(String.Format("{0}", motionDataAdd.ListAxisPosValue[i]));
                    }
                    listView_motion_data.Items.Add(item);

                    SaveData(Application.StartupPath.ToString() + "\\motionAbsPosData");
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_list_clear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("삭제 하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listView_motion_data.Items.Clear();
                    SaveData(Application.StartupPath.ToString() + "\\motionAbsPosData");
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_motion_list_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("삭제 하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ListView.SelectedListViewItemCollection items = listView_motion_data.SelectedItems;
                    if (items.Count > 0)
                    {
                        ListViewItem lvItem = items[0];
                        listView_motion_data.Items.Remove(lvItem);
                        SaveData(Application.StartupPath.ToString() + "\\motionAbsPosData");
                    }                    
                }                
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_motion_list_move_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection items = listView_motion_data.SelectedItems;
                if (items.Count > 0)
                {
                    ListViewItem lvItem = items[0];

                    for (int i = 1; i < items[0].SubItems.Count; i++)
                    {
                        string posVal = lvItem.SubItems[i].Text;
                        if (posVal != null && posVal != "")
                        {
                            if (m_motion != null)
                            {
                                int index = i - 1;
                                double step = Convert.ToDouble(posVal);
                                if (m_motion.IsAxisCompletedHome(index))
                                {
                                    m_motion.AxisMove(index, step, false);
                                }                                
                            }
                        }
                    }

                    SaveData(Application.StartupPath.ToString() + "\\motionAbsPosData");
                }                
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_motion_list_modify_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection items = listView_motion_data.SelectedItems;
                if (items.Count > 0)
                {
                    ListViewItem lvItem = items[0];
                    
                    AddMotionData motionDataAdd = new AddMotionData(AddMotionData.MotionDataMode.Modify);
                    motionDataAdd.ItemName = lvItem.Text;

                    for (int i = 1; i < items[0].SubItems.Count; i++)
                    {
                        string posVal = lvItem.SubItems[i].Text;
                        if (posVal == null)
                        {
                            motionDataAdd.ListAxisPosValue.Add("");
                        }
                        else
                        {
                            motionDataAdd.ListAxisPosValue.Add(posVal); 
                        }
                    }

                    if (motionDataAdd.ShowDialog() == DialogResult.OK)
                    {
                        lvItem.Text = motionDataAdd.ItemName;
                        for (int i = 0; i < motionDataAdd.ListAxisPosValue.Count; i++)
                        {
                            lvItem.SubItems[i+1].Text = String.Format("{0}", motionDataAdd.ListAxisPosValue[i]);
                        }
                    }

                    SaveData(Application.StartupPath.ToString() + "\\motionAbsPosData");
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// text 파일을 읽어옵니다.
        /// </summary>
        /// <param name="fileName">읽어올 파일명</param>
        private void LoadData(string fileName)
        {
            FileInfo _finfo = new FileInfo(fileName);
            if (_finfo.Exists)
            {
                // StreamReader를 이용하여 문자판독기를 생성합니다.
                using (TextReader tReader = new StreamReader(fileName))
                {
                    // 파일의 내용을 모두 읽어와 줄바꿈을 기준으로 배열형태로 쪼갭니다.
                    string[] stringLines
                        = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    // 한줄씩 가져와서..
                    foreach (string stringLine in stringLines)
                    {
                        // 빈 문자열이 아니면..
                        if (stringLine != string.Empty)
                        {
                            // 구분자를 이용해서 배열형태로 쪼갭니다.
                            string[] stringArray = stringLine.Split(';');

                            // 아이템을 구성합니다.
                            ListViewItem item = new ListViewItem(stringArray[0]);
                            for (int i = 1; i < stringArray.Length; i++)
                            {                                
                                item.SubItems.Add(stringArray[i]);
                            }                            

                            // ListView에 아이템을 추가합니다.
                            listView_motion_data.Items.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// text 파일로 저장합니다.
        /// </summary>
        /// <param name="fileName">저장할 파일명</param>
        private void SaveData(string fileName)
        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {                
                // ListView의 Item을 하나씩 가져와서..
                foreach (ListViewItem item in listView_motion_data.Items)
                {
                    // 원하는 형태의 문자열로 한줄씩 기록합니다.
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item.Text);

                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        sb.Append(";");
                        sb.Append(item.SubItems[i].Text);
                    }

                    tWriter.WriteLine(sb.ToString());
                }
            }
        }
    }
}
