﻿using GalvoScanner.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvoScanner.Motion
{
    public class MotionBase
    {
        protected static string m_sIniPath = DefPath.MotionSetting;

        public enum KIND_MOTION { AJIN = 0 };

        public static IMotion GetInstanceInterface()
        {
            if (MotionBase.GetUseMotion())
            {
                switch (MotionBase.GetKindOfMotion())
                {
                    case MotionBase.KIND_MOTION.AJIN:
                        return MotionAjin.GetInstance();
                }
            }
            return null;
        }

        ~MotionBase()
        {
            IMotion motion = GetInstanceInterface();
            if (motion != null)
            {
                for (int i = 0; i < m_nAxisCount; i++)
                {
                    motion.AxisSetServoOn(i, false);
                }
            }            
        }

        protected static bool m_bIsUseMotion = false;
        public static bool GetUseMotion()
        {
            return m_bIsUseMotion;
        }

        protected static KIND_MOTION m_kindOfMotion = KIND_MOTION.AJIN;
        public static KIND_MOTION GetKindOfMotion()
        {
            return m_kindOfMotion;
        }

        public static string INISECTION_MOTION_INITIAL = "InitialMotion";
        public static string INIKEY_INIT_USE_MOTION = "USE_MOTION";
        public static string INIKEY_INIT_KIND_OF_MOTION = "KIND_OF_MOTION";
        
        public static string INISECTION_MOTION_SETTING = "MotionSetting";
        public static string INIKEY_GANTRY_USE = "GANTRY_USE";
        public static string INIKEY_GANTRY_MASTER_AXIS = "GANTRY_MASTER_AXIS";
        public static string INIKEY_GANTRY_SLAVE_AXIS = "GANTRY_SLAVE_AXIS";

        public static void ReadMotionINI(string path)
        {
            if (path == null || path == "")
            {
                path = m_sIniPath;
            }
            bool useMotion = false;
            int kindOfMotion = 0;

            IniFile ini = new IniFile();
            string strIniValue = "";

            strIniValue = ini.IniReadValue(MotionBase.INISECTION_MOTION_INITIAL, MotionBase.INIKEY_INIT_USE_MOTION, path);
            if (strIniValue != "") { useMotion = Convert.ToBoolean(strIniValue); }
            strIniValue = ini.IniReadValue(MotionBase.INISECTION_MOTION_INITIAL, MotionBase.INIKEY_INIT_KIND_OF_MOTION, path);
            if (strIniValue != "") { kindOfMotion = Convert.ToInt32(strIniValue); }

            if (useMotion)
            {
                try
                {
                    switch (kindOfMotion)
                    {
                        case 0: // Ajin
                            {
                                MotionAjin MotAjin = null;
                                MotAjin = MotionAjin.GetInstance(useMotion, MotionBase.KIND_MOTION.AJIN);
                                MotAjin.InitMotion();
                                MotAjin.LoadMotionINI(path);
                                MotAjin.LoadMOTFile(MotAjin.MOTFilePath);
                                if (MotAjin.UseGantry)
                                {
                                    if (!MotAjin.GantrySetEnable())
                                    {
                                        MessageBox.Show("Gantry is not on.");
                                    }
                                }
                            }
                            break;
                    }
                }
                catch (Exception E)
                {
                    LogFile.LogExceptionErr(E.ToString());
                    MessageBox.Show(E.Message);
                }
            }
        }

        protected bool m_bIsInitMotion = false;
        public bool IsInitMotion()
        {
            return m_bIsInitMotion;
        }

        protected int m_nAxisCount = 0;
        public int GetAxisCount()
        {
            return m_nAxisCount;
        }
        public void SetAxisCount(int count)
        {
            m_nAxisCount = count;
        }

        /// Gantry setting ////////////////////////
        protected bool m_bUseGantry = false;
        public bool UseGantry
        {
            get { return m_bUseGantry; }
            set { m_bUseGantry = value; }
        }

        protected int m_nGantryMasterAxis = -1;
        public int GantryMasterAxis
        {
            get { return m_nGantryMasterAxis; }
            set { m_nGantryMasterAxis = value; }
        }

        protected int m_nGantrySlaveAxis = -1;
        public int GantrySlaveAxis
        {
            get { return m_nGantrySlaveAxis; }
            set { m_nGantrySlaveAxis = value; }
        }
        ///////////////////////////////////////////////////////////
    }
}
