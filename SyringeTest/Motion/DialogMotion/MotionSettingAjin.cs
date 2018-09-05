using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalvoScanner.Common;

namespace GalvoScanner.Motion.DialogMotion
{
    public partial class MotionSettingAjin : UserControl
    {
        MotionAjin m_motion = null;

        public MotionSettingAjin(MotionBase motion)
        {
            m_motion = MotionAjin.GetInstance();

            InitializeComponent();
        }

        private void button_load_mot_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "AXM files (*.mot)|*.mot|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (m_motion.LoadMOTFile(openFileDialog1.FileName) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    MessageBox.Show("File load failed");
                }
                else
                {
                    string motionSettingPath = DefPath.MotionSetting;
                    m_motion.SaveMotionINI(motionSettingPath);
                    textBox_MOT_filepath.Text = openFileDialog1.FileName;
                }
            }
        }

        private void MotionSettingAjin_Load(object sender, EventArgs e)
        {
            if (m_motion != null)
            {
                if (m_motion.MOTFilePath != "")
                {
                    textBox_MOT_filepath.Text = m_motion.MOTFilePath;

                }

                for (int i = 0; i < m_motion.GetAxisCount(); i++)
                {
                    comboBox_Axis.Items.Add(String.Format("{0} - {1}", i, m_motion.ListAxis[i].DevName));
                    comboBox_gan_master_axis.Items.Add(String.Format("{0} - {1}", i, m_motion.ListAxis[i].DevName));
                    comboBox_gan_slave_axis.Items.Add(String.Format("{0} - {1}", i, m_motion.ListAxis[i].DevName));
                }

                if (comboBox_Axis.Items.Count > 0)
                {
                    comboBox_Axis.SelectedIndex = 0;
                }

                GetGantrySetInfo();
                CheckGantryStatus();
            }
        }

        private void GetMotionSettingUpdate()
        {
            try
            {
                textBox_MOT_filepath.Text = m_motion.MOTFilePath;

                int index = comboBox_Axis.SelectedIndex;
                if (index > -1)
                {
                    checkBox_use_axis.Checked = m_motion.ListAxis[index].IsUseAxis;
                    textBox_unit_per_mm.Text = String.Format("{0}", m_motion.ListAxis[index].UnitPerMM);
                    textBox_unit_per_mm_encoder.Text = String.Format("{0}", m_motion.ListAxis[index].UnitPerMMEncoder);
                    checkBox_total_unit.Checked = m_motion.ListAxis[index].UnitPerMM == m_motion.ListAxis[index].UnitPerMMEncoder ? true : false;

                    bool enable = true;
                    if (index == m_motion.GantrySlaveAxis && m_motion.GantryGetStatus())
                    {
                        enable = false;
                    }

                    textBox_unit_per_mm.Enabled = enable;
                    textBox_unit_per_mm_encoder.Enabled = enable;
                    checkBox_use_axis.Enabled = enable;
                    checkBox_total_unit.Enabled = enable;
                }
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
                if (m_motion != null)
                {
                    GetMotionSettingUpdate();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index > -1)
                    {
                        m_motion.ListAxis[index].SetUnitperMM(Convert.ToDouble(textBox_unit_per_mm.Text));
                        m_motion.ListAxis[index].SetUnitperMMforEncoder(Convert.ToDouble(textBox_unit_per_mm_encoder.Text));
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

        private void checkBox_use_axis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index < 0)
                    {
                        checkBox_use_axis.Checked = false;
                        return;
                    }

                    m_motion.ListAxis[index].IsUseAxis = checkBox_use_axis.Checked;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void checkBox_total_unit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_total_unit.Checked)
                {
                    textBox_unit_per_mm_encoder.Enabled = false;
                    textBox_unit_per_mm_encoder.Text = textBox_unit_per_mm.Text;
                }
                else
                {
                    textBox_unit_per_mm_encoder.Enabled = true;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void textBox_unit_per_mm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_total_unit.Checked)
                {
                    textBox_unit_per_mm_encoder.Text = textBox_unit_per_mm.Text;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_set_gantry_enable_Click(object sender, EventArgs e)
        {
            try
            {
                m_motion.GantryMasterAxis = comboBox_gan_master_axis.SelectedIndex;
                m_motion.GantrySlaveAxis = comboBox_gan_slave_axis.SelectedIndex;
                if (checkBox_slave_use_home.Checked)
                    m_motion.GantrySlaveHomeUse = 1U;
                else
                    m_motion.GantrySlaveHomeUse = 0U;
                m_motion.GantrySlaveOffset = Convert.ToDouble(textBox_slave_offset.Text);
                m_motion.GantrySlaveOffsetRange = Convert.ToDouble(textBox_slave_offset_range.Text);
                m_motion.UseGantry = true;

                m_motion.GantrySetEnable();

                m_motion.SaveMotionINI(null);

                CheckGantryStatus();
                GetGantrySetInfo();
                GetMotionSettingUpdate();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_set_gantry_disable_Click(object sender, EventArgs e)
        {
            try
            {
                m_motion.UseGantry = false;

                m_motion.GantrySetDisable();

                m_motion.SaveMotionINI(null);

                CheckGantryStatus();
                GetGantrySetInfo();
                GetMotionSettingUpdate();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void CheckGantryStatus()
        {
            if (m_motion.GantryGetStatus())
            {
                textBox_gantry_status.Text = "Gantry on";
            }
            else
            {
                textBox_gantry_status.Text = "Gantry off";
            }
        }

        private void GetGantrySetInfo()
        {
            try
            {
                comboBox_gan_master_axis.SelectedIndex = m_motion.GantryMasterAxis;
                comboBox_gan_slave_axis.SelectedIndex = m_motion.GantrySlaveAxis;
                checkBox_slave_use_home.Checked = m_motion.GantrySlaveHomeUse == 1U ? true : false;
                textBox_slave_offset.Text = m_motion.GantrySlaveOffset.ToString("0.#########");
                textBox_slave_offset_range.Text = m_motion.GantrySlaveOffsetRange.ToString("0.#########");
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }
    }
}
