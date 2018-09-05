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
    public partial class AddMotionData : Form
    {
        public enum MotionDataMode { Add = 0, Modify, }
        MotionDataMode m_modeMotData = MotionDataMode.Add;

        List<string> m_listAxisPosValue = new List<string>();
        public List<string> ListAxisPosValue
        {
            get { return m_listAxisPosValue; }
            set { m_listAxisPosValue = value; }
        }

        public string ItemName
        {
            get { return textBox_data_name.Text; }
            set { textBox_data_name.Text = value; }
        }

        public string ItemName_forMod = "";        

        public AddMotionData(MotionDataMode mode)
        {
            InitializeComponent();

            m_modeMotData = mode;
        }

        private void AddMotionData_Load(object sender, EventArgs e)
        {
            IMotion imotion = MotionBase.GetInstanceInterface();
            if (imotion != null)
            {
                if (m_modeMotData == MotionDataMode.Add)
                {
                    Text = "AddMotionData";
                    button_add_ok.Text = "Add";
                }
                else if (m_modeMotData == MotionDataMode.Modify)
                {
                    Text = "ModifyMotionData";
                    button_add_ok.Text = "Modify";
                }

                int axisCnt = imotion.GetAxisCount();

                for (int i = 0; i < axisCnt; i++)
                {
                    comboBox_axis.Items.Add(i);

                    Label label = new Label();
                    label.Name = "label_" + i;
                    label.Text = "Axis " + i + " : ";
                    label.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Name = "textBox_" + i;
                    if (m_modeMotData == MotionDataMode.Modify && m_listAxisPosValue.Count > 0)
                    {
                        textbox.Text = m_listAxisPosValue[i];
                    }
                    else
                    {
                        textbox.Text = "";
                    }                    
                    flowLayoutPanel1.Controls.Add(textbox);
                }

                if (comboBox_axis.Items.Count > 0)
                {
                    comboBox_axis.SelectedIndex = 0;
                }                
            }
        }

        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            try
            {
                IMotion imotion = MotionBase.GetInstanceInterface();
                if (imotion != null)
                {
                    int index = comboBox_axis.SelectedIndex;
                    double actPos = imotion.AxisGetActualPosition(index);
                    textBox_pos.Text = String.Format("{0}", actPos);
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
            }
        }

        private void button_current_set_Click(object sender, EventArgs e)
        {
            try
            {
                IMotion imotion = MotionBase.GetInstanceInterface();
                if (imotion != null)
                {
                    if (comboBox_axis.Items.Count > 0)
                    {
                        int index = comboBox_axis.SelectedIndex;

                        TextBox textbox = (TextBox)flowLayoutPanel1.Controls.Find("textBox_" + index, true)[0];
                        textbox.Text = String.Format("{0}", imotion.AxisGetActualPosition(index));
                    }
                }
                
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_add_ok_Click(object sender, EventArgs e)
        {
            try
            {
                m_listAxisPosValue.Clear();
                IMotion imotion = MotionBase.GetInstanceInterface();
                if (imotion != null)
                {
                    for (int i = 0; i < imotion.GetAxisCount(); i++)
                    {
                        TextBox textbox = (TextBox)flowLayoutPanel1.Controls.Find("textBox_" + i, true)[0];
                        m_listAxisPosValue.Add(textbox.Text);
                    }

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }

                Close();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }
    }
}
