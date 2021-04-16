using System;
using System.Diagnostics;
using System.IO;

namespace CustomExecService.util.external
{
    class Exec
    {
        public static int Call(string binPath, string param)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = binPath;
                process.StartInfo.Arguments = param;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(binPath);
                process.Start();
                return process.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
