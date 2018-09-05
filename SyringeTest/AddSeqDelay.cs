using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyringeTest
{
    public partial class AddSeqDelay : UserControl
    {
        int m_nDelay = 0;
        public int DelayTime
        {
            get 
            {
                try
                {
                    m_nDelay = Convert.ToInt32(textBox_delay.Text);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                    return -1;
                }
                return m_nDelay; 
            }
        }

        public AddSeqDelay()
        {
            InitializeComponent();
        }
    }
}
