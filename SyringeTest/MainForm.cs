using GalvoScanner;
using GalvoScanner.IO;
using GalvoScanner.IO.DialogIO;
using GalvoScanner.Motion;
using GalvoScanner.Motion.DialogMotion;
using SyringeTest.Motion.DialogMotion;
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
    public partial class MainForm : Form
    {
        MotionControlForm m_motionCtrlAjin = null;
        IOControl m_ioCtrlAjin = null;

        SequenceManager m_seqMng = null;

        public MainForm()
        {
            InitializeComponent();

            m_seqMng = SequenceManager.GetInstance();
        }

        private void iOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DIOBase.GetInstanceInterface() == null) 
            {
                MessageBox.Show("IO가 존재하지 않습니다.");
                return;
            }

            if (m_ioCtrlAjin == null)
            {
                m_ioCtrlAjin = new IOControl();
            }

            m_ioCtrlAjin.Show();
            m_ioCtrlAjin.Focus();

            m_ioCtrlAjin.Location = new Point(this.Location.X - m_ioCtrlAjin.Size.Width, this.Location.Y);
        }

        private void motionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MotionBase.GetInstanceInterface() == null)
            {
                MessageBox.Show("Motion이 존재하지 않습니다.");
                return;
            }

            if (m_motionCtrlAjin == null)
            {
                m_motionCtrlAjin = new MotionControlForm();
            }

            m_motionCtrlAjin.Show();
            m_motionCtrlAjin.Focus();

            m_motionCtrlAjin.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
        }

        private void button_add_seq_Click(object sender, EventArgs e)
        {
            if (m_seqMng != null)
            {
                AddSequence addSeq = new AddSequence();
                if (addSeq.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem item = null;

                    switch (addSeq.SEQEUNCE_List.seq)
                    {
                        case SequenceManager.SEQUENCE.Delay:
                            int nDelay = (int)addSeq.SEQEUNCE_List.data;
                            m_seqMng.AddSeqDelay(nDelay);
                            item = new ListViewItem(SequenceManager.SEQUENCE.Delay.ToString());
                            item.SubItems.Add(nDelay.ToString() + " ms");
                            break;

                        case SequenceManager.SEQUENCE.Motion:
                            SequenceManager.SEQ_MOTION seqMot = (SequenceManager.SEQ_MOTION)addSeq.SEQEUNCE_List.data;
                            m_seqMng.AddSeqMotion(seqMot.nAxisNum, seqMot.dPos);
                            item = new ListViewItem(SequenceManager.SEQUENCE.Motion.ToString());
                            item.SubItems.Add(seqMot.nAxisNum.ToString() + ", " + seqMot.dPos.ToString("0.####"));
                            break;

                        case SequenceManager.SEQUENCE.IO:
                            SequenceManager.SEQ_IO seqIo = (SequenceManager.SEQ_IO)addSeq.SEQEUNCE_List.data;
                            m_seqMng.AddSeqIO(seqIo.nIoNum, seqIo.bOn);
                            item = new ListViewItem(SequenceManager.SEQUENCE.IO.ToString());
                            item.SubItems.Add(seqIo.nIoNum.ToString() + ", " + seqIo.bOn.ToString());
                            break;
                    }

                    if (item != null)
                    {
                        listView_seq.Items.Add(item);
                    }                    
                }
            }
        }

        private void button_remove_seq_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_seqMng != null)
                {
                    ListView.SelectedListViewItemCollection items = listView_seq.SelectedItems;
                    if (items.Count > 0)
                    {
                        ListViewItem lvItem = items[0];
                        int listInd = listView_seq.Items.IndexOf(lvItem);
                        listView_seq.Items.Remove(lvItem);                        
                        m_seqMng.RemoveSeq(listInd);
                    }
                }                
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_clear_seq_Click(object sender, EventArgs e)
        {
            try
            {
                listView_seq.Items.Clear();
                m_seqMng.ClearSeq();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_start_seq_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_seqMng != null)
                {
                    m_seqMng.SequenceRepeat = Convert.ToInt32(textBox_seq_repeat.Text);
                    m_seqMng.StartSequence();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void button_start_seq_continuous_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_seqMng != null)
                {
                    m_seqMng.SequenceContinuous = true;
                    m_seqMng.SequenceRepeat = Convert.ToInt32(textBox_seq_repeat.Text);
                    m_seqMng.StartSequence();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void button_stop_seq_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_seqMng != null)
                {
                    m_seqMng.StopSequence();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
