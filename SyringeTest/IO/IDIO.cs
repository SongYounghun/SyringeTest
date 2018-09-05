using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvoScanner.IO
{
    public interface IDIO
    {
        void InitDIO();
        int GetInputCount();
        int GetOutputCount();
        bool WriteOutBit(int index, uint value);
        bool ReadOutBit(int index, ref uint value);
        bool ReadInBit(int index, ref uint value);
        void SaveIOMap(string path);
        void LoadIOMap(string path);
    }
}
