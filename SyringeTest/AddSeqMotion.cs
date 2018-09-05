using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalvoScanner.Motion;

namespace SyringeTest
{
    public partial class AddSeqMotion : UserControl
    {
        IMotion m_motion = null;

        SequenceManager.SEQ_MOTION m_seqMotion = new SequenceManager.SEQ_MOTION();
        public SequenceManager.SEQ_MOTION SEQEUNCE_Motion
        {
            get 
            {
                try
                {
                    m_seqMotion.nAxisNum = comboBox_index.SelectedIndex;
                    m_seqMotion.dPos = Convert.ToDouble(textBox_motion_pos.Text);                    
                }
                catch (Exception E)
                {
                    m_seqMotion.nAxisNum = -1;
                    m_seqMotion.dPos = 0;

                    MessageBox.Show(E.Message);
                }

                return m_seqMotion; 
            }
        }

        public AddSeqMotion()
        {
            InitializeComponent();

            m_motion = MotionBase.GetInstanceInterface();
            if (m_motion != null)
            {
                int nAxisCnt = m_motion.GetAxisCount();
                for (int i = 0; i < nAxisCnt; i++)
                {
                    comboBox_index.Items.Add(m_motion.GetAxisDevName(i));
                }

                if (nAxisCnt > 0)
                {
                    comboBox_index.SelectedIndex = 0;
                }
            }
        }
    }
}
