using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvoScanner.Motion
{
    public class AxisBase
    {
        public static string INISECTION_AXIS = "AxisSetting";

        public static string INIKEY_NUMBER = "NUMBER";
        public static string INIKEY_UNITPERMM = "UNITPERMM";
        public static string INIKEY_UNITPERMMENCODER = "UNITPERMM_ENC";
        public static string INIKEY_VEL = "VEL";
        public static string INIKEY_ACC = "ACC";
        public static string INIKEY_DEC = "DEC";
        public static string INIKEY_USE_GALVOPOS = "USE_GALVOPOS";
        public static string INIKEY_GALVO_POSITION = "GALVO_POSITION";
        public static string INIKEY_USE_CAMPOS = "USE_CAMPOS";
        public static string INIKEY_CAM_POSITION = "CAM_POSITION";
        public static string INIKEY_USEAXIS = "USE";

        protected int m_nAxisNumber = 0;
        public int AxisNumber
        {
            get { return m_nAxisNumber; }
            set { m_nAxisNumber = value; }
        }

        protected string m_strDeviceName = "";
        public string DevName
        {
            get { return m_strDeviceName; }
            set { m_strDeviceName = value; }
        }

        protected double m_dUnitperMM = 1000;
        public void SetUnitperMM(double unitPerMM)
        {
            m_dUnitperMM = unitPerMM;
        }
        public double UnitPerMM
        {
            get { return m_dUnitperMM; }
        }

        protected double m_dUnitperMMEnc = 1000;
        public void SetUnitperMMforEncoder(double unitPerMM)
        {
            m_dUnitperMMEnc = unitPerMM;
        }
        public double UnitPerMMEncoder
        {
            get { return m_dUnitperMMEnc; }
        }

        protected double m_dVelocity = 100;
        public double Velocity
        {
            get { return m_dVelocity; }
            set { m_dVelocity = value; }
        }

        protected double m_dAcceleration = 100;
        public double Acceleration
        {
            get { return m_dAcceleration; }
            set { m_dAcceleration = value; }
        }

        protected double m_dDeceleration = 100;
        public double Deceleration
        {
            get { return m_dDeceleration; }
            set { m_dDeceleration = value; }
        }

        protected bool m_bUseGalvoPosition = false;
        public bool UseGalvoPosition
        {
            get { return m_bUseGalvoPosition; }
            set { m_bUseGalvoPosition = value; }
        }

        protected double m_dGalvoPosition = 0.0;
        public double GalvoPosition
        {
            get { return m_dGalvoPosition; }
            set { m_dGalvoPosition = value; }
        }

        protected bool m_bUseCamPosition = false;
        public bool UseCameraPosition
        {
            get { return m_bUseCamPosition; }
            set { m_bUseCamPosition = value; }
        }

        protected double m_dCamPosition = 0.0;
        public double CameraPosition
        {
            get { return m_dCamPosition; }
            set { m_dCamPosition = value; }
        }

        protected bool m_bIsUseAxis = false;
        public bool IsUseAxis
        {
            get { return m_bIsUseAxis; }
            set { m_bIsUseAxis = value; }
        }
    }
}
