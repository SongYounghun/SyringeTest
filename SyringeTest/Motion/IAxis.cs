using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvoScanner.Motion
{
    interface IAxis
    {
        void Home();
        uint GetHomeState();
        void Move(double pos, bool isRelative);
        void MoveJog(bool isDirectionPostive);
        void Stop();
        void SetServoOn(bool isOn);
        bool GetServoOnState();
        void PositionClear();
        void SaveAxisINI(string path);
        void LoadAxisINI(string path);
        double GetActualPosition();
        bool IsBusy();
        bool IsUse();
        void SetUseGalvoPosition(bool use);
        void SetUseCameraPosition(bool use);
        bool GetUseGalvoPostion();
        bool GetUseCameraPosition();
        bool IsCompletedHome();
    }
}
