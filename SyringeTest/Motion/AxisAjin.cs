using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvoScanner.Motion
{
    enum eAxis { eInit, eReady, eHome, eMove }; 

    public class AxisAjin : AxisBase, IAxis
    {
        private int m_nBoardNum = 0;
        private double m_fPosDst = 0;
        eAxis m_eStat = eAxis.eInit;
        public string m_strID = "";
        Stopwatch m_swWait = new Stopwatch(); 
        int m_msMove = 30000;

        public void SetBoardNum(int boardNum)
        {
            m_nBoardNum = boardNum;
        }
        public int BoardNum
        {
            get { return m_nBoardNum; }
        }

        private uint m_nModuleId = 0;
        public void SetModuleId(uint moduleID)
        {
            m_nModuleId = moduleID;
        }
        public uint ModuleID
        {
            get { return m_nModuleId; }
        }

        private string m_strModuleName = "";
        public void SetModuleName(string moduleName)
        {
            m_strModuleName = moduleName;
        }
        public string ModuleName
        {
            get { return m_strModuleName; }
        }

        public void Home()
        {
            if (m_bIsUseAxis)
            {
                SetServoOn(true);

                uint duRetCode = 0;

                duRetCode = CAXM.AxmHomeSetVel(m_nAxisNumber, 30 * m_dUnitperMM, 10 * m_dUnitperMM, 5 * m_dUnitperMM, 2 * m_dUnitperMM, 50 * m_dUnitperMM, 50 * m_dUnitperMM);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    MessageBox.Show(String.Format("AxmHomeSetVel return error[Code:{0:d}]", duRetCode));
                    return;
                }

                duRetCode = CAXM.AxmHomeSetStart(m_nAxisNumber);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    MessageBox.Show(String.Format("AxmHomeSetStart return error[Code:{0:d}]", duRetCode));
                    return;
                }

                m_eStat = eAxis.eHome;
            }
            
        }

        public void Move(double pos, bool isRelative)
        {
            try
            {
                if (m_bIsUseAxis)
                {
                    uint duRetCode = 0;

                    duRetCode = CAXM.AxmMotSetAbsRelMode(m_nAxisNumber, Convert.ToUInt32(isRelative));
                    if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        MessageBox.Show(String.Format("AxmMotSetAbsRelMode return error[Code:{0:d}]", duRetCode));
                        return;
                    }

                    //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
                    duRetCode = CAXM.AxmMoveStartPos(m_nAxisNumber, pos * UnitPerMM, Velocity * UnitPerMM, Acceleration * UnitPerMM, Deceleration * UnitPerMM);
                    m_fPosDst = pos;
                    m_eStat = eAxis.eMove;
                    if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        MessageBox.Show(String.Format("AxmMoveStartPos return error[Code:{0:d}]", duRetCode)); 

                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
            
        }

        public void MoveV(double fPos, double fV)
        {
            double v, a;

            if (!m_bIsUseAxis) 
                return;
            
            //if (WaitReady())
            //{                
            //    return; 
            //}
            while (!IsBusy())
                Thread.Sleep(1);

            a = Acceleration * UnitPerMM;

            if (fV > 0) 
                v = fV; 
            else
                v = Velocity * UnitPerMM;

            m_fPosDst = fPos;

            CAXM.AxmMoveStartPos(m_nAxisNumber, fPos * UnitPerMM, v, a, a); 
            Thread.Sleep(5);
            m_eStat = eAxis.eMove; 
            return;
        }

        public void MoveV(double fPos, double fPosV, double fV)
        {
            if (!m_bIsUseAxis) 
                return;

            //if (WaitReady()) 
            //{ 
            //    return;
            //}

            while (IsBusy())
                Thread.Sleep(1);

            CAXM.AxmMotSetProfileMode(m_nAxisNumber, 3);
            CAXM.AxmOverrideSetMaxVel(m_nAxisNumber, Velocity * UnitPerMM);
            m_fPosDst = fPos;
            CAXM.AxmOverrideVelAtPos(m_nAxisNumber, fPos * UnitPerMM, Velocity * UnitPerMM, Acceleration * UnitPerMM, Deceleration * UnitPerMM, fPosV * UnitPerMM, fV * UnitPerMM, 0);
            m_eStat = eAxis.eMove; 
            return;
        }


        public void Stop()
        {
            try
            {
                uint duRetCode = 0;
                //++ 지정한 축의 구동을 감속정지합니다.
                duRetCode = CAXM.AxmMoveSStop(m_nAxisNumber);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmMoveSStop return error[Code:{0:d}]", duRetCode));

            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public void SetServoOn(bool isOn)
        {
            try
            {
                if (IsUseAxis)
                    CAXM.AxmSignalServoOn(m_nAxisNumber, Convert.ToUInt32(isOn));
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GetServoOnState()
        {
            try
            {
                if (m_bIsUseAxis)
                {
                    uint uOnOff = 0;
                    CAXM.AxmSignalIsServoOn(m_nAxisNumber, ref uOnOff);

                    return Convert.ToBoolean(uOnOff);
                }

                return false;
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void PositionClear()
        {
            try
            {
                if (IsUseAxis)
                    CAXM.AxmStatusSetPosMatch(m_nAxisNumber, 0.0);
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void MoveJog(bool isDirectionPostive)
        {
            try
            {
                if (m_bIsUseAxis)
                {
                    uint duRetCode = 0;
                    if (isDirectionPostive)
                    {
                        duRetCode = CAXM.AxmMoveVel(m_nAxisNumber, Velocity * UnitPerMM, Acceleration * UnitPerMM, Deceleration * UnitPerMM);
                    }
                    else
                    {
                        duRetCode = CAXM.AxmMoveVel(m_nAxisNumber, -Velocity * UnitPerMM, Acceleration * UnitPerMM, Deceleration * UnitPerMM);
                    } 
                }

            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }


        public void SaveAxisINI(string path)
        {
            try
            {
                IniFile ini = new IniFile();
                string buildSectionName = INISECTION_AXIS + "_" + m_nAxisNumber;
                ini.IniWriteValue(buildSectionName, INIKEY_NUMBER, String.Format("{0}", m_nAxisNumber), path);
                ini.IniWriteValue(buildSectionName, INIKEY_UNITPERMM, String.Format("{0}", m_dUnitperMM), path);
                ini.IniWriteValue(buildSectionName, INIKEY_UNITPERMMENCODER, String.Format("{0}", m_dUnitperMMEnc), path);
                ini.IniWriteValue(buildSectionName, INIKEY_VEL, String.Format("{0}", m_dVelocity), path);
                ini.IniWriteValue(buildSectionName, INIKEY_ACC, String.Format("{0}", m_dAcceleration), path);
                ini.IniWriteValue(buildSectionName, INIKEY_DEC, String.Format("{0}", m_dDeceleration), path);
                ini.IniWriteValue(buildSectionName, INIKEY_USE_GALVOPOS, String.Format("{0}", m_bUseGalvoPosition), path);
                ini.IniWriteValue(buildSectionName, INIKEY_GALVO_POSITION, String.Format("{0}", m_dGalvoPosition), path);
                ini.IniWriteValue(buildSectionName, INIKEY_USE_CAMPOS, String.Format("{0}", m_bUseCamPosition), path);
                ini.IniWriteValue(buildSectionName, INIKEY_CAM_POSITION, String.Format("{0}", m_dCamPosition), path);
                ini.IniWriteValue(buildSectionName, INIKEY_USEAXIS, String.Format("{0}", m_bIsUseAxis), path);
                
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void LoadAxisINI(string path)
        {
            try
            {
                IniFile ini = new IniFile();
                string buildSectionName = INISECTION_AXIS + "_" + m_nAxisNumber;
                string tempVal = "";
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_NUMBER, path);
                if (tempVal != "") { m_nAxisNumber = Convert.ToInt32(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_UNITPERMM, path);
                if (tempVal != "") { m_dUnitperMM = Convert.ToInt32(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_UNITPERMMENCODER, path);
                if (tempVal != "") { m_dUnitperMMEnc = Convert.ToInt32(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_VEL, path);
                if (tempVal != "") { m_dVelocity = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_ACC, path);
                if (tempVal != "") { m_dAcceleration = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_DEC, path);
                if (tempVal != "") { m_dDeceleration = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_USE_GALVOPOS, path);
                if (tempVal != "") { m_bUseGalvoPosition = Convert.ToBoolean(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_GALVO_POSITION, path);
                if (tempVal != "") { m_dGalvoPosition = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_USE_CAMPOS, path);
                if (tempVal != "") { m_bUseCamPosition = Convert.ToBoolean(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_CAM_POSITION, path);
                if (tempVal != "") { m_dCamPosition = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_USEAXIS, path);
                if (tempVal != "") { m_bIsUseAxis = Convert.ToBoolean(tempVal); }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public uint GetHomeState()
        {
            try
            {
                uint duRetCode, duState = 0;
                duRetCode = CAXM.AxmHomeGetResult(m_nAxisNumber, ref duState);

                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    return (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_UNKNOWN;
                }
                return duState;
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public double GetActualPosition()
        {
            try
            {
                double dActPos = 0;
                uint duRetCode = CAXM.AxmStatusGetActPos(m_nAxisNumber, ref dActPos);
                if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    return dActPos / UnitPerMMEncoder;
                }
                else
                {
                    return -9999999;
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsBusy()
        {
            try
            {
                if (m_bIsUseAxis)
                {
                    uint duRetCode = 0;
                    CAXM.AxmStatusReadInMotion(m_nAxisNumber, ref duRetCode);
                    if (duRetCode == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    } 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E)
            {                
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsUse()
        {
            return m_bIsUseAxis;
        }

        public void SetTrigger(double dStartPos, double dEndPos, double dPeriodPos, bool bCmd, double dTrigTime = 2, uint triggerLevel = 1)
        {
            CAXM.AxmTriggerSetReset(m_nAxisNumber);
            if (bCmd)
            {                
                CAXM.AxmTriggerSetTimeLevel(m_nAxisNumber, dTrigTime, triggerLevel, 0, 0);
                CAXM.AxmTriggerSetBlock(m_nAxisNumber, dStartPos * m_dUnitperMM, dEndPos * m_dUnitperMM, dPeriodPos);
            }
            else
            {                
                CAXM.AxmTriggerSetTimeLevel(m_nAxisNumber, dTrigTime, triggerLevel, 1, 0);
                CAXM.AxmTriggerSetBlock(m_nAxisNumber, dStartPos * m_dUnitperMMEnc, dEndPos * m_dUnitperMMEnc, dPeriodPos);
            }
        }

        public void StopTrigger()
        {
            CAXM.AxmTriggerSetReset(m_nAxisNumber);
        }

        public double GetPos(bool bCmd)
        {
            double posNow = 0;
            if (bCmd) CAXM.AxmStatusGetCmdPos(m_nAxisNumber, ref posNow);
            else CAXM.AxmStatusGetActPos(m_nAxisNumber, ref posNow);
            return posNow;
        }

        public void SetPos(bool bCmd, double fPos)
        {
            if (bCmd) CAXM.AxmStatusSetCmdPos(m_nAxisNumber, fPos);
            else CAXM.AxmStatusSetActPos(m_nAxisNumber, fPos);
        }

        public void SetCaption(string strID)
        {
            m_strID = m_nAxisNumber.ToString() + "." + strID;
        }

        public void OverrideVel(double fV)
        {
            if (m_bIsUseAxis)
            {
                if (fV < 0) fV = Velocity * UnitPerMM;
                CAXM.AxmOverrideVel(m_nAxisNumber, fV);
            }
            
        }

        public bool WaitReady(double dp = -1)
        {
            if (m_eStat == eAxis.eInit) return true; m_swWait.Start();
            while ((m_eStat != eAxis.eReady) && (m_swWait.ElapsedMilliseconds <= m_msMove)) 
                Thread.Sleep(1);
            if (m_swWait.ElapsedMilliseconds > m_msMove) 
            { 
                return true; 
            }
            if ((dp > 0) && (Math.Abs(GetPos(false) - m_fPosDst) > dp)) 
            {
                return true; 
            }
            return false;
        }
        public double GetPosDst()
        {
            return m_fPosDst;
        }

        public void SetUseGalvoPosition(bool use)
        {
            try
            {
                if (m_bIsUseAxis && IsCompletedHome())
                {
                    UseGalvoPosition = use;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public void SetUseCameraPosition(bool use)
        {
            try
            {
                if (m_bIsUseAxis && IsCompletedHome())
                {
                    UseCameraPosition = use;
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GetUseGalvoPostion()
        {
            try
            {
                if (m_bIsUseAxis && IsCompletedHome())
                {
                    return UseGalvoPosition;
                }
                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool GetUseCameraPosition()
        {
            try
            {
                if (m_bIsUseAxis && IsCompletedHome())
                {
                    return UseCameraPosition;
                }
                return false;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }

        public bool IsCompletedHome()
        {
            try
            {
                return GetHomeState() == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS;
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw E;
            }
        }
    }
}
