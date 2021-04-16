using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CustomExecService.util.check
{
    class Deamon
    {
        private static object mLock = new object();
        private bool mWaitingExitSignal = false;
        private static Deamon mInstance = null;
        private Thread mDeamonThread = null;
        private Dictionary<int, int> mProcessReStartMap = null;
        public static Deamon Instance()
        {
            if (mInstance == null)
            {
                lock (Deamon.mLock)
                {
                    if (mInstance == null)
                    {
                        mInstance = new Deamon();
                    }
                }
            }
            return mInstance;
        }
        private Deamon()
        {
            mProcessReStartMap = new Dictionary<int, int>(4);
            mDeamonThread = new Thread(() => { DoDeamon(); });
            mDeamonThread.Name = "Deamon Thread";
        }
        public void Launch()
        {
            if (mWaitingExitSignal)
            {
                return;
            }
            mDeamonThread.Start();
        }
        public void Shutdown()
        {
            if (mWaitingExitSignal)
            {
                return;
            }
            mWaitingExitSignal = true;
            while(true)
            {
                try { Thread.Sleep(1000); } catch (Exception ignore) { }
                if (!mDeamonThread.IsAlive)
                {
                    break;
                }
            }
            ClearDeamon();
            mWaitingExitSignal = false;
        }
        public bool Register(int processID)
        {
            if (processID == -1)
            {
                return false;
            }
            //todo: 记录要守护的线程ID
            if (!mProcessReStartMap.ContainsKey(processID))
            {
                mProcessReStartMap.Add(processID, 0);
            }
            return true;
        }

        private void DoDeamon()
        {
            //todo: 隔一段时间查看线程是否存活
            //todo: 不存活则尝试启动程序
            //todo: 多次启动失败则写入日志并退出守护，通知主程序退出
            while(mWaitingExitSignal)
            {
                if (mProcessReStartMap.Count > 0)
                {
                    List<int> needDel = new List<int>();
                    foreach (KeyValuePair<int, int> pair in mProcessReStartMap)
                    {
                        if (pair.Value > 5)
                        {
                            needDel.Add(pair.Key);
                        }
                        else
                        {
                            if (!RestartProcess(pair.Key))
                            {
                                mProcessReStartMap[pair.Key] += 1;
                            }
                        }
                    }
                    foreach (int id in needDel)
                    {
                        mProcessReStartMap.Remove(id);
                    }
                }
                try
                {
                    Thread.Sleep(30000);
                }
                catch (Exception ignore) { }
            }
        }
        private void ClearDeamon()
        {
            foreach(var pair in mProcessReStartMap)
            {
                KillProcess(pair.Key);
            }
            mProcessReStartMap.Clear();
        }
        private bool RestartProcess(int processID)
        {
            Process tgt = Process.GetProcessById(processID);
            if (tgt.HasExited)
            {
                //tgt.ExitTime;
                //tgt.ExitCode;
                return tgt.Start();
            }
            return true;
        }
        private void KillProcess(int processID)
        {
            try
            {
                Process tgt = Process.GetProcessById(processID);
                if (!tgt.HasExited)
                {
                    tgt.Kill();
                }
                tgt.Dispose();
            }
            catch (Exception ignore)
            {

            }
        }
    }
}
