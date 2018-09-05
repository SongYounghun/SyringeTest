using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvoScanner.Common
{
    public class ViewportlayoutSetting
    {
        public const string INI_SECTION_VIEWPORTLAYOUTSETTING = "VIEWPORTLAYOUT_SETTING";
        public const string INI_KEY_CHORDALERR = "CHORDAL_DRROR";

        private static ViewportlayoutSetting m_viewportSetting = null;
        public static ViewportlayoutSetting GetInstance()
        {
            if (m_viewportSetting == null)
            {
                m_viewportSetting = new ViewportlayoutSetting();
            }
            return m_viewportSetting;
        }

        private double m_dChordalError = 0.001;
        public double ChordalErr
        {
            get { return m_dChordalError; }
            set { m_dChordalError = value; }
        }

        public ViewportlayoutSetting()
        {
            LoadIniViewportLayoutSetting();
        }        

        public void SaveIniViewportLayoutSetting()
        {
            try
            {
                string path = DefPath.ViewportSetting;
                IniFile ini = new IniFile();
                ini.IniWriteValue(INI_SECTION_VIEWPORTLAYOUTSETTING, INI_KEY_CHORDALERR, ChordalErr.ToString("0.#########"), path);
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
            }
        }

        public void LoadIniViewportLayoutSetting()
        {
            try
            {
                string path = DefPath.ViewportSetting;
                IniFile ini = new IniFile();
                string iniValue = ini.IniReadValue(INI_SECTION_VIEWPORTLAYOUTSETTING, INI_KEY_CHORDALERR, path);
                if (iniValue != "") { m_dChordalError = Double.Parse(iniValue); }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
            }
        }
    }
}
