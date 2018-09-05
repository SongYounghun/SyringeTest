using GalvoScanner.Motion.DialogMotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyringeTest.Motion.DialogMotion
{
    public partial class MotionControlForm : Form
    {
        MotionControlAjin m_motionCtrlAjin = null;

        public MotionControlForm()
        {
            InitializeComponent();
        }

        private void MotionControlForm_Load(object sender, EventArgs e)
        {
            if (m_motionCtrlAjin == null)
            {
                m_motionCtrlAjin = new MotionControlAjin();
            }

            m_motionCtrlAjin.Dock = DockStyle.Fill;
            panel1.Controls.Add(m_motionCtrlAjin);
        }

        private void MotionControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void button_setting_Click(object sender, EventArgs e)
        {
            m_motionCtrlAjin.ShowMotionSettingAjin();
        }
    }
}
