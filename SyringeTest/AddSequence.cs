using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyringeTest
{
    public partial class AddSequence : Form
    {
        AddSeqDelay m_addSeqDelay = null;
        AddSeqMotion m_addSeqMotion = null;
        AddSeqIO m_addSeqIO = null;

        SequenceManager.SEQ_LIST m_seqList = new SequenceManager.SEQ_LIST();
        public SequenceManager.SEQ_LIST SEQEUNCE_List
        {
            get { return m_seqList; }
        }

        public AddSequence()
        {
            InitializeComponent();
        }

        private void AddSeqeunce_Load(object sender, EventArgs e)
        {
            m_addSeqDelay = new AddSeqDelay();
            m_addSeqMotion = new AddSeqMotion();
            m_addSeqIO = new AddSeqIO();

            m_addSeqDelay.Dock = DockStyle.Fill;
            m_addSeqMotion.Dock = DockStyle.Fill;
            m_addSeqIO.Dock = DockStyle.Fill;

            panel_add_seq.Controls.Add(m_addSeqDelay);
            panel_add_seq.Controls.Add(m_addSeqMotion);
            panel_add_seq.Controls.Add(m_addSeqIO);

            m_addSeqDelay.Show();
            m_addSeqMotion.Hide();
            m_addSeqIO.Hide();

            comboBox_seq.DataSource = Enum.GetValues(typeof(SequenceManager.SEQUENCE));
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (comboBox_seq.SelectedIndex != -1)
            {
                m_seqList.seq = (SequenceManager.SEQUENCE)comboBox_seq.SelectedIndex;                

                switch (comboBox_seq.SelectedIndex)
                {
                    case (int)SequenceManager.SEQUENCE.Delay:
                        m_seqList.data = m_addSeqDelay.DelayTime;
                        break;

                    case (int)SequenceManager.SEQUENCE.Motion:
                        {
                            m_seqList.data = m_addSeqMotion.SEQEUNCE_Motion;
                        }
                        break;

                    case (int)SequenceManager.SEQUENCE.IO:
                        {
                            m_seqList.data = m_addSeqIO.SEQEUNCE_IO;
                        }
                        break;
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void comboBox_seq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_seq.SelectedIndex != -1)
            {
                switch (comboBox_seq.SelectedIndex)
                {
                    case (int)SequenceManager.SEQUENCE.Delay:
                        {
                            m_addSeqDelay.Show();
                            m_addSeqMotion.Hide();
                            m_addSeqIO.Hide();
                        }
                        break;

                    case (int)SequenceManager.SEQUENCE.Motion:
                        {
                            m_addSeqDelay.Hide();
                            m_addSeqMotion.Show();
                            m_addSeqIO.Hide();
                        }
                        break;

                    case (int)SequenceManager.SEQUENCE.IO:
                        {
                            m_addSeqDelay.Hide();
                            m_addSeqMotion.Hide();
                            m_addSeqIO.Show();
                        }
                        break;
                }                    
            }
        }
    }
}
