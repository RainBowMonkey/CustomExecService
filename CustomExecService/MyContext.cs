using CustomExecService.util.config;
using System;
using System.IO;

namespace CustomExecService
{
    class MyContext
    {
        private static MyContext mInstance = null;
        private string mAppFriendlyFullName = null;
        private Configuration mConfiguration = null;
        private MyContext() 
        {
            mAppFriendlyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
        }
        
        public static MyContext Instance()
        {
            if (mInstance == null)
            {
                mInstance = new MyContext();
            }
            return mInstance;
        }

        public void SetConfiguration(Configuration configuration)
        {
            mConfiguration = configuration;
        }
        public Configuration GetConfiguration()
        {
            return mConfiguration;
        }
        public string GetAppFullName()
        {
            return mAppFriendlyFullName;
        }
    }
}
