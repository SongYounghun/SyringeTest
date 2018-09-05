using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GalvoScanner.Motion
{
    public class MotionAjin : MotionBase, IMotion
    {
        private static MotionAjin m_motionAjin = null;
        public static MotionAjin GetInstance(bool isUseMotion, KIND_MOTION kindOfMotion)
        {
            m_bIsUseMotion = isUseMotion;
            m_kindOfMotion = kindOfMotion;
            if (m_bIsUseMotion)
            {
                if (m_motionAjin == null)
                {
                    m_motionAjin = new MotionAjin();
                }
                return m_motionAjin;
            }            

            return null;
        }
        public static MotionAjin GetInstance()
        {
            if (m_bIsUseMotion)
            {
                if (m_motionAjin == null)
                {
                    m_motionAjin = new MotionAjin();
                }

                return m_motionAjin;
            }

            return null;
        }

        public static string INIKEY_MOTFILEPATH = "MOTFILEPATH";
        public static string INIKEY_GANTRY_SLAVE_HOMEUSE = "GANTRY_SLAVE_HOMEUSE";
        public static string INIKEY_GANTRY_SLAVE_OFFSET = "GANTRY_SLAVE_OFFSET";
        public static string INIKEY_GANTRY_SLAVE_OFFSETRANGE = "GANTRY_SLAVE_OFFSETRANGE";

        protected uint m_nGantrySlaveHomeUse = 0U;
        public uint GantrySlaveHomeUse
        {
            get { return m_nGantrySlaveHomeUse; }
            set { m_nGantrySlaveHomeUse = value; }
        }

        protected double m_dGantrySlaveOffset = 0.0;
        public double GantrySlaveOffset
        {
            get { return m_dGantrySlaveOffset; }
            set { m_dGantrySlaveOffset = value; }
        }

        protected double m_dGantrySlaveOffsetRange = 0.0;
        public double GantrySlaveOffsetRange
        {
            get { return m_dGantrySlaveOffsetRange; }
            set { m_dGantrySlaveOffsetRange = value; }
        }

        private List<AxisAjin> m_listAxis = null;
        public List<AxisAjin> ListAxis
        {
            get { return m_listAxis; }
        }

        private string m_strMOTFilePath = "";
        public string MOTFilePath
        {
            get { return m_strMOTFilePath; }
            set { m_strMOTFilePath = value; }
        }

        public void SetAllAxisUnitperMM(double unitPerMM)
        {
            if (m_listAxis != null && m_listAxis.Count > 0)
            {
                for (int i = 0; i < m_listAxis.Count; i++)
                {
                    m_listAxis[i].SetUnitperMM(unitPerMM);
                }
            }
        }

        public void InitMotion()
        {
            try
            {
                uint result = CAXL.AxlOpen(7);
                if (result != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS && result != (uint)AXT_FUNC_RESULT.AXT_RT_OPEN_ALREADY)
                    return;

                CAXM.AxmInfoGetAxisCount(ref m_nAxisCount);

                if (m_nAxisCount > 0)
                {
                    m_listAxis = new List<AxisAjin>(m_nAxisCount);

                    for (int i = 0; i < m_nAxisCount; i++)
                    {
                        AxisAjin axis = new AxisAjin();
                        m_listAxis.Add(axis);
                    }

                    for (int i = 0; i < m_nAxisCount; i++)
                    {
                        int boardNum = 0, modulePos = 0;
                        uint moduleID = 0;
                        CAXM.AxmInfoGetAxis(i, ref boardNum, ref modulePos, ref moduleID);
                        m_listAxis[i].AxisNumber = i;
                        m_listAxis[i].SetBoardNum(boardNum);
                        m_listAxis[i].SetModuleId(moduleID);

                        switch (moduleID)
                        {
                            case (uint)AXT_MODULE.AXT_SMC_4V04: m_listAxis[i].DevName = String.Format("{0:00}-[PCIB-QI4A]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_2V04: m_listAxis[i].DevName = String.Format("{0:00}-[PCIB-QI2A]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04: m_listAxis[i].DevName = String.Format("{0:00}-(RTEX-PM)", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04A4: m_listAxis[i].DevName = String.Format("{0:00}-[RTEX-A4N]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04A5: m_listAxis[i].DevName = String.Format("{0:00}-[RTEX-A5N]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV: m_listAxis[i].DevName = String.Format("{0:00}-[MLII-SGDV]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM: m_listAxis[i].DevName = String.Format("{0:00}-(MLII-PM)", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL: m_listAxis[i].DevName = String.Format("{0:00}-[MLII-CSDL]", i); break;
                            case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR: m_listAxis[i].DevName = String.Format("{0:00}-[MLII-CSDH]", i); break;
                            default: m_listAxis[i].SetModuleName(String.Format("{0:00}-[Unknown]", i)); break;
                        }
                    }

                    m_bIsInitMotion = true;
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
            
        }

        public uint LoadMOTFile(string path)
        {
            try
            {
                uint ret = CAXM.AxmMotLoadParaAll(path);
                if (ret == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    MOTFilePath = path;
                }
                return ret;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void AxisSetMoveParameter(int axisNum, double vel, double acc, double dec)
        {
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0)
                {
                    m_listAxis[axisNum].Velocity = vel;
                    m_listAxis[axisNum].Acceleration = acc;
                    m_listAxis[axisNum].Deceleration = dec;
                }
            }
        }

        public void AxisMove(int axisNum, double pos, bool isRel)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        m_listAxis[axisNum].Move(pos, isRel);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
            
        }
        public void AxisMoveV(int axisNum , double fPos, double fV)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].MoveV(fPos, fV);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }

        }
        public void AxisMoveV(int axisNum, double fPos, double fPosV, double fV)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].MoveV(fPos, fPosV ,fV);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }

        }

        public double GetPosDst(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                        return m_listAxis[axisNum].GetPosDst();
                    else
                        return 0.00;
                }
                else
                    return 0.00;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }
        
        public void SetTrigger(int axisNum, double dStartPos, double dEndPos, double dPeriodPos, bool bCmd, double dTrigTime = 2, uint triggerLevel = 1)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                        m_listAxis[axisNum].SetTrigger(dStartPos, dEndPos, dPeriodPos, bCmd, dTrigTime, triggerLevel);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void StopTrigger(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if ( axisNum >= 0)
                        m_listAxis[axisNum].StopTrigger();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void OverrideVel(int axisNum, double fV)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (axisNum >= 0)
                        m_listAxis[axisNum].OverrideVel(fV);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }
        public void AxisHome(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].Home();
                    }
                }            
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }            
        }

        public void AllHome()
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        for (int i = 0; i < m_listAxis.Count; i++)
                        {
                            m_listAxis[i].Home();
                        }
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }            
        }

        public void AxisStop(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].Stop();
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void AllStop()
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        for (int i = 0; i < m_listAxis.Count; i++)
                        {
                            m_listAxis[i].Stop();
                        }
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public void AxisSetServoOn(int axisNum, bool isOn)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].SetServoOn(isOn);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool AxisGetServoOnState(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        return m_listAxis[axisNum].GetServoOnState();
                    }
                }

                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void AxisPositionClear(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].PositionClear();
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public void AxisMoveJog(int axisNum, bool isDirectionPostive)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        m_listAxis[axisNum].MoveJog(isDirectionPostive);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void SaveMotionINI(string path)
        {
            try
            {
                if (path == null || path == "")
                {
                    path = m_sIniPath;
                }

                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        IniFile ini = new IniFile();
                        // Base ///////////////////////
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_USE, UseGantry.ToString(), path);
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_MASTER_AXIS, GantryMasterAxis.ToString(), path);
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_AXIS, GantrySlaveAxis.ToString(), path);
                        //////////////////////////////
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_MOTFILEPATH, m_strMOTFilePath, path);
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_HOMEUSE, GantrySlaveHomeUse.ToString(), path);
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_OFFSET, GantrySlaveOffset.ToString(), path);
                        ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_OFFSETRANGE, GantrySlaveOffsetRange.ToString(), path);

                        for (int i = 0; i < m_listAxis.Count; i++)
                        {
                            m_listAxis[i].SaveAxisINI(path);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void LoadMotionINI(string path)
        {
            try
            {
                if (path == null || path == "")
                {
                    path = m_sIniPath;
                }

                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        IniFile ini = new IniFile();
                        string tempVal = "";
                        // Base ///////////////////////
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_USE, path);
                        if (tempVal != null && tempVal != "") { UseGantry = Convert.ToBoolean(tempVal); }
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_MASTER_AXIS, path);
                        if (tempVal != null && tempVal != "") { GantryMasterAxis = Convert.ToInt32(tempVal); }
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_AXIS, path);
                        if (tempVal != null && tempVal != "") { GantrySlaveAxis = Convert.ToInt32(tempVal); }
                        ///////////////////////////////

                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_MOTFILEPATH, path);
                        if (tempVal != null && tempVal != "") { m_strMOTFilePath = tempVal; }
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_HOMEUSE, path);
                        if (tempVal != null && tempVal != "") { GantrySlaveHomeUse = Convert.ToUInt32(tempVal); }
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_OFFSET, path);
                        if (tempVal != null && tempVal != "") { GantrySlaveOffset = Convert.ToDouble(tempVal); }
                        tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_GANTRY_SLAVE_OFFSETRANGE, path);
                        if (tempVal != null && tempVal != "") { GantrySlaveOffsetRange = Convert.ToDouble(tempVal); }

                        for (int i = 0; i < m_listAxis.Count; i++)
                        {
                            m_listAxis[i].LoadAxisINI(path);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public uint AxisHomeState(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        return m_listAxis[axisNum].GetHomeState();
                    }
                    else
                    {
                        return (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_UNKNOWN;
                    }
                }
                else
                {
                    return (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_UNKNOWN;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public double AxisGetActualPosition(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                    {
                        return m_listAxis[axisNum].GetActualPosition();
                    }
                    else
                    {
                        return -9999999;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public void MoveGalvoRegionPostion()
        {
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0)
                {
                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].UseGalvoPosition)
                        {
                            while (m_listAxis[i].IsBusy()) { Thread.Sleep(10); }
                            double pos = m_listAxis[i].GalvoPosition;
                            m_listAxis[i].Move(pos, false);
                        }
                    }
                }
            }
        }

        public void MoveCameraRegionPosition()
        {
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0)
                {
                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].UseCameraPosition)
                        {
                            double pos = m_listAxis[i].CameraPosition;
                            m_listAxis[i].Move(pos, false);
                        }
                    }
                }
            }
        }

        public bool AxisIsBusy(int axisNum)
        {
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0 && axisNum >= 0)
                {
                    return m_listAxis[axisNum].IsBusy();
                }
            }

            return false;
        }

        public bool MoveGalvoRegionPositionComplete()
        {
            bool ret = false;
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0)
                {
                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].UseGalvoPosition)
                        {
                            ret |= m_listAxis[i].IsBusy();
                        }
                    }
                }
            }
            return ret;
        }

        public bool MoveCameraRegionPositionComplete()
        {
            bool ret = false;
            if (m_bIsInitMotion)
            {
                if (m_listAxis != null && m_listAxis.Count > 0)
                {
                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].UseCameraPosition)
                        {
                            ret |= m_listAxis[i].IsBusy();
                        }
                    }
                }
            }
            return ret;
        }

        public bool IsMotionBusy()
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (m_listAxis != null && m_listAxis.Count > 0)
                    {
                        
                        for (int i = 0; i < m_listAxis.Count; i++)
                        {
                            if (m_listAxis[i].IsBusy())
                                return true;
                        }
                    }

                    return false;
                }

                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public string GetAxisDevName(int axisNum)
        {
            if (axisNum >= 0)
                return m_listAxis[axisNum].DevName;
            else
                return "";
        }

        public bool AxisIsUse(int axisNum)
        {
            if (axisNum >= 0)
                return m_listAxis[axisNum].IsUseAxis;
            else
                return false;
        }

        public void SetUseGalvoPosition(int axisNum, bool use)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (axisNum >= 0)
                    {
                        m_listAxis[axisNum].SetUseGalvoPosition(use);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void SetUseCameraPosition(int axisNum, bool use)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (axisNum >= 0)
                    {
                        m_listAxis[axisNum].SetUseCameraPosition(use);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GetUseGalvoPosition(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (axisNum >= 0)
                    {
                        return m_listAxis[axisNum].GetUseGalvoPostion();
                    }
                    return false;
                }
                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GetUseCameraPosition(int axisNum)
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    if (axisNum >= 0)
                    {
                        return m_listAxis[axisNum].GetUseCameraPosition();
                    }
                    return false;
                }
                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsSetGalvoPosition()
        {
            try
            {
                if (m_bIsInitMotion)
                {                    
                    for (int i = 0; i < m_listAxis.Count; i ++)
                    {
                         if (m_listAxis[i].GetUseGalvoPostion())
                         {
                             return true;
                         }
                        
                    }

                    return false;
                }

                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsSetCameraPosition()
        {
            try
            {
                if (m_bIsInitMotion)
                {
                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].GetUseCameraPosition())
                        {
                            return true;
                        }

                    }

                    return false;
                }

                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsAxisCompletedHome(int axisNum)
        {
            try
            {
                return m_listAxis[axisNum].IsCompletedHome();
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GantrySetEnable()
        {
            try
            {
                if (GantryMasterAxis == -1 || GantrySlaveAxis == -1 || GantryMasterAxis == GantrySlaveAxis)
                {
                    return false;
                }

                uint res = CAXM.AxmGantrySetEnable(GantryMasterAxis, GantrySlaveAxis, GantrySlaveHomeUse,
                                                    GantrySlaveOffset * m_listAxis[GantrySlaveAxis].UnitPerMM,
                                                    GantrySlaveOffsetRange * m_listAxis[GantrySlaveAxis].UnitPerMM);
                if (res == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS ||
                    res == (uint)AXT_FUNC_RESULT.AXT_RT_MOTION_ERROR_GANTRY_ENABLE)
                {
                    m_listAxis[GantrySlaveAxis].IsUseAxis = false;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GantrySetDisable()
        {
            try
            {
                if (GantryMasterAxis == -1 || GantrySlaveAxis == -1 || GantryMasterAxis == GantrySlaveAxis)
                {
                    return false;
                }

                uint res = CAXM.AxmGantrySetDisable(GantryMasterAxis, GantrySlaveAxis);
                if (res == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsUseGantry()
        {
            return UseGantry;
        }

        public bool GantryGetStatus()
        {
            try
            {
                uint slaveHomeUse = 0U, isGantryOn = 0U;
                double slaveOffset = 0.0, slaveOffsetRange = 0.0;

                uint res = CAXM.AxmGantryGetEnable(GantryMasterAxis, ref slaveHomeUse, ref slaveOffset, ref slaveOffsetRange, ref isGantryOn);
                if (isGantryOn == 0U)
                    return false;
                else
                    return true;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsAllCompletedHome()
        {
            try
            {
                bool isAllCompletedhome = true;
                if (IsInitMotion())
                {
                    if (m_listAxis.Count <= 0)
                        return false;

                    for (int i = 0; i < m_listAxis.Count; i++)
                    {
                        if (m_listAxis[i].IsUseAxis)
                        {
                            isAllCompletedhome &= IsAxisCompletedHome(i);
                        }                        
                    }
                }
                else
                {
                    return false;
                }

                return isAllCompletedhome;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }
    }
}
