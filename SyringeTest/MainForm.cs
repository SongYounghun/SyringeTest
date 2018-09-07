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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSeqRecipe();
        }

        private void LoadSeqRecipe()
        {
            string recPath = Application.StartupPath + "\\SeqRecipe";
            if (Directory.Exists(recPath) && Directory.GetFiles(recPath).Length > 0)
            {
                String[] strfilePaths = Directory.GetFileSystemEntries(recPath);
                for (int i = 0; i < strfilePaths.Length; i++)
                {
                    string path = Path.GetFileNameWithoutExtension(strfilePaths[i]);
                    listView_seq_recipe.Items.Add(path);
                    //if (MessageBox.Show("Do you want to load sequence?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    m_seqMng.ClearSeq();
                    //    LoadSeqXml(path);
                    //}
                }
            }
        }

        private void LoadSeqXml(string path, bool isUpdateUI)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                XElement root = doc.Root;

                if (root != null && !root.IsEmpty)
                {
                    IEnumerator<XElement> xSequences = root.Elements().GetEnumerator();
                    while (xSequences.MoveNext())
                    {
                        XElement xSeq = xSequences.Current;

                        switch (xSeq.Name.LocalName)
                        {
                            case "Delay":
                                {
                                    if (xSeq.Element("delay_time") != null)
                                    {
                                        int nDelayTime = Convert.ToInt32(xSeq.Element("delay_time").Value);

                                    }
                                }
                                break;

                            case "IO":
                                {
                                    if (xSeq.Element("delay_time") != null)
                                    {

                                    }
                                }
                                break;

                            case "Motion":
                                {

                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void SaveSeqXml(string path)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement root = new XElement("Sequence");
                for (int i = 0; i < m_seqMng.ListSequence.Count; i++)
                {
                    XElement xSeq = null;
                    SequenceManager.SEQ_LIST listSeq = m_seqMng.ListSequence[i];
                    switch (listSeq.seq)
                    {
                        case SequenceManager.SEQUENCE.Delay:
                            {
                                int delTime = (int)listSeq.data;
                                xSeq = new XElement("Delay");
                                xSeq.Add(new XElement("delay_time", delTime));
                            }
                            break;

                        case SequenceManager.SEQUENCE.IO:
                            {
                                SyringeTest.SequenceManager.SEQ_IO dataIO = (SyringeTest.SequenceManager.SEQ_IO)listSeq.data;
                                xSeq = new XElement("IO");
                                xSeq.Add(new XElement("nIoNum", dataIO.nIoNum));
                                xSeq.Add(new XElement("bOn", dataIO.bOn));
                            }
                            break;

                        case SequenceManager.SEQUENCE.Motion:
                            {
                                SyringeTest.SequenceManager.SEQ_MOTION dataMot = (SyringeTest.SequenceManager.SEQ_MOTION)listSeq.data;
                                xSeq = new XElement("Motion");
                                xSeq.Add(new XElement("nAxisNum", dataMot.nAxisNum));
                                xSeq.Add(new XElement("dPos", dataMot.dPos));
                            }
                            break;
                    }

                    if (xSeq != null)
                    {
                        root.Add(xSeq);
                    }
                }

                doc.Add(root);
                doc.Save(path);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void button_seq_save_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_seq_name.Text))
            {
                if (!Directory.Exists(Application.StartupPath + "\\SeqRecipe"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\SeqRecipe");
                }
                SaveSeqXml(Application.StartupPath + "\\SeqRecipe\\" + textBox_seq_name.Text);
                listView_seq_recipe.Items.Add(textBox_seq_name.Text);
            }
        }

        private void listView_seq_recipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_seq_recipe.Items.Count > 0)
            {
                if (listView_seq_recipe.SelectedItems.Count > 0)
                {
                    string path = listView_seq_recipe.SelectedItems[0].Text;
                    if (Directory.Exists(Application.StartupPath + "\\SeqRecipe"))
                    {
                        if (MessageBox.Show("Do you want to load sequence?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            LoadSeqXml(Application.StartupPath + "\\SeqRecipe\\" + path, true);
                            textBox_seq_name.Text = path;
                        }
                        
                    }
                }
            }
        }
    }
}
