using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvoScanner.Motion
{
    public interface IMotion
    {
        void InitMotion();
        void AxisSetServoOn(int axisNum, bool isOn);
        bool AxisGetServoOnState(int axisNum);
        void AxisSetMoveParameter(int axisNum, double vel, double acc, double dec);
        void AxisMove(int axisNum, double pos, bool isRel);
        void AxisMoveJog(int axisNum, bool isDirectionPostive);
        void AxisHome(int axisNum);
        uint AxisHomeState(int axisNum);
        void AllHome();
        void AxisStop(int axisNum);
        void AllStop();
        void AxisPositionClear(int axisNum);
        void SaveMotionINI(string path);
        void LoadMotionINI(string path);
        double AxisGetActualPosition(int axisNum);
        void MoveGalvoRegionPostion();
        bool MoveGalvoRegionPositionComplete();
        void MoveCameraRegionPosition();
        bool MoveCameraRegionPositionComplete();
        void SetUseGalvoPosition(int axisNum, bool use);
        void SetUseCameraPosition(int axisNum, bool use);
        bool GetUseGalvoPosition(int axisNum);
        bool GetUseCameraPosition(int axisNum);
        bool IsSetGalvoPosition();
        bool IsSetCameraPosition();
        bool AxisIsBusy(int axisNum);
        bool IsInitMotion();
        bool IsMotionBusy();
        int GetAxisCount();
        string GetAxisDevName(int axisNum);
        bool AxisIsUse(int axisNum);
        double GetPosDst(int axisNum);        
        void AxisMoveV(int axisNum , double fPos, double fV);
        void AxisMoveV(int axisNum , double fPos, double fPosV, double fV);
        void SetTrigger(int axisNum, double dStartPos, double dEndPos, double dPeriodPos, bool bCmd, double dTrigTime = 2, uint triggerLevel = 1);
        void StopTrigger(int axisNum);
        void OverrideVel(int axisNum , double fV);
        bool IsAxisCompletedHome(int axisNum);
        bool IsAllCompletedHome();
        bool GantrySetEnable();
        bool GantrySetDisable();
        bool IsUseGantry();
        bool GantryGetStatus();
    }
}
