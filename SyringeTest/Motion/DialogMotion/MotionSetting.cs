using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvoScanner.Motion.DialogMotion
{
    public partial class MotionSetting : Form
    {
        MotionBase m_motion = null;

        MotionSettingAjin m_motSettingAjin = null;

        public MotionSetting()
        {
            switch (MotionBase.GetKindOfMotion())
            {
                case MotionBase.KIND_MOTION.AJIN:
                    {
                        m_motion = MotionAjin.GetInstance();
                    }
                    break;
            }

            InitializeComponent();
        }

        private void MotionSetting_Load(object sender, EventArgs e)
        {
            if (m_motion != null)
            {
                switch (MotionBase.GetKindOfMotion())
                {
                    case MotionBase.KIND_MOTION.AJIN:
                        {
                            m_motSettingAjin = new MotionSettingAjin(m_motion);                            
                            Controls.Add(m_motSettingAjin);
                            Size s = new Size(m_motSettingAjin.Width + 40, m_motSettingAjin.Height + 40);
                            Size = s;
                        }
                        break;
                }
            }
            else
            {
                Close();
            }
        }

        private void MotionSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
