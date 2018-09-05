using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalvoScanner.IO;

namespace SyringeTest
{
    public partial class AddSeqIO : UserControl
    {
        IDIO m_io = null;

        SequenceManager.SEQ_IO m_seqIO = new SequenceManager.SEQ_IO();
        public SequenceManager.SEQ_IO SEQEUNCE_IO
        {
            get 
            {
                m_seqIO.nIoNum = comboBox_index.SelectedIndex;
                m_seqIO.bOn = checkBox_on.Checked;
                return m_seqIO; 
            }
        }

        public AddSeqIO()
        {
            InitializeComponent();

            m_io = DIOBase.GetInstanceInterface();
            if (m_io != null)
            {
                int outCount = m_io.GetOutputCount();
                for (int i = 0; i < outCount; i++)
                {
                    comboBox_index.Items.Add(i);
                }
                if (outCount > 0)
                {
                    comboBox_index.SelectedIndex = 0;
                }
            }            
        }        
    }
}
