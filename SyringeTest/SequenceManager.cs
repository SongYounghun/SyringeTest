using GalvoScanner;
using GalvoScanner.IO;
using GalvoScanner.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyringeTest
{
    public class SequenceManager
    {
        static private SequenceManager m_seqMng = null;
        static public SequenceManager GetInstance()
        {
            if (m_seqMng == null)
            {
                m_seqMng = new SequenceManager();
            }

            return m_seqMng;
        }

        IMotion m_mot = null;
        IDIO m_io = null;

        public enum SEQUENCE { Delay = 0, Motion, IO, }

        public struct SEQ_MOTION
        {
            public int nAxisNum;
            public double dPos;
        }

        public struct SEQ_IO
        {
            public int nIoNum;
            public bool bOn;
        }

        public struct SEQ_LIST
        {
            public SEQUENCE seq;
            public object data;
        }

        List<SEQ_LIST> m_listSeq = new List<SEQ_LIST>();
        public List<SEQ_LIST> ListSequence
        {
            get { return m_listSeq; }
        }

        int m_nSeqRepeat = 1;
        public int SequenceRepeat
        {
            get { return m_nSeqRepeat; }
            set { m_nSeqRepeat = value; }
        }

        bool m_bSeqContinuous = false;
        public bool SequenceContinuous
        {
            get { return m_bSeqContinuous; }
            set { m_bSeqContinuous = value; }
        }

        public SequenceManager()
        {
            m_mot = MotionBase.GetInstanceInterface();
            m_io = DIOBase.GetInstanceInterface();
        }

        public void AddSeqMotion(int axisNum, double pos)
        {
            SEQ_MOTION seqMot = new SEQ_MOTION();
            seqMot.nAxisNum = axisNum;
            seqMot.dPos = pos;

            SEQ_LIST seqList = new SEQ_LIST();
            seqList.seq = SEQUENCE.Motion;
            seqList.data = seqMot;

            m_listSeq.Add(seqList);
        }

        public void AddSeqIO(int IoNum, bool On)
        {
            SEQ_IO seqIo = new SEQ_IO();
            seqIo.nIoNum = IoNum;
            seqIo.bOn = On;

            SEQ_LIST seqList = new SEQ_LIST();
            seqList.seq = SEQUENCE.IO;
            seqList.data = seqIo;

            m_listSeq.Add(seqList);
        }

        public void AddSeqDelay(int delay)
        {
            SEQ_LIST seqList = new SEQ_LIST();
            seqList.seq = SEQUENCE.Delay;
            seqList.data = delay;

            m_listSeq.Add(seqList);
        }

        public void ClearSeq()
        {
            m_listSeq.Clear();
        }

        public void RemoveSeq(int index)
        {
            if (m_listSeq.Count > 0 && index < m_listSeq.Count)
            {
                m_listSeq.RemoveAt(index);
            }
        }


        Thread m_thSequence = null;
        bool m_bSequenceLive = false;

        private void ProcSequence()
        {
            if (m_mot != null && m_io != null)
            {
                int listSize = m_listSeq.Count;
                int i = 0, repeat = m_nSeqRepeat;

                while (m_bSequenceLive)
                {
                    SEQ_LIST curr = m_listSeq[i++];
                    try
                    {
                        switch (curr.seq)
                        {
                            case SEQUENCE.Delay:
                                int delay = (int)curr.data;
                                Thread.Sleep(delay);
                                break;

                            case SEQUENCE.IO:
                                SEQ_IO dataIO = (SEQ_IO)curr.data;
                                m_io.WriteOutBit(dataIO.nIoNum, Convert.ToUInt32(dataIO.bOn));
                                break;

                            case SEQUENCE.Motion:
                                SEQ_MOTION dataMot = (SEQ_MOTION)curr.data;
                                m_mot.AxisMove(dataMot.nAxisNum, dataMot.dPos, false);
                                while (m_mot.AxisIsBusy(dataMot.nAxisNum)) { Thread.Sleep(1); }
                                break;
                        }
                    }
                    catch (Exception E)
                    {
                        LogFile.LogExceptionErr(E.ToString());
                    }

                    if (i >= listSize)
                    {
                        if (m_bSeqContinuous)
                        {
                            i = 0;
                        }
                        else
                        {
                            if (repeat > 1)
                            {
                                repeat--;
                                i = 0;
                            }
                            else
                            {
                                break;
                            }
                        }                        
                    }
                }
            }

            m_bSeqContinuous = false;
            m_bSequenceLive = false;
            m_thSequence = null;

            return;
        }

        public void StartSequence()
        {
            if (m_thSequence == null)
            {
                if (m_io == null) { MessageBox.Show("IO가 존재하지 않습니다."); return; }
                if (m_mot == null) { MessageBox.Show("Motion이 존재하지 않습니다."); return; }

                m_bSequenceLive = true;
                m_thSequence = new Thread(new ThreadStart(ProcSequence));
                m_thSequence.Start();
            }
        }

        public void StopSequence()
        {
            m_bSeqContinuous = false;
            m_bSequenceLive = false;
            if (m_mot != null)
            {
                m_mot.AllStop();
            }

            if (m_io != null)
            {
                int outSize = m_io.GetOutputCount();
                for (int i = 0; i < outSize; i++)
                {
                    m_io.WriteOutBit(i, 0U);
                }
            }
        }
    }
}
