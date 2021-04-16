using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CustomExecService.util.config
{
    class ConfigReader
    {
        public static bool GetConfiguration()
        {
            XmlDocument document = new XmlDocument();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFlag.CONFIGFILENAME);
            if (File.Exists(path))
            {
                document.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFlag.CONFIGFILENAME));
                Configuration config = new Configuration();
                List<XmlNode> nodeList = new List<XmlNode>();
                GetAllNode(document.ChildNodes, nodeList);
                foreach (XmlNode node in nodeList)
                {
                    if (node.Name.ToLower() == ConfigFlag.NAME)
                    {
                        config.ServiceName = node.InnerText;
                    }
                    if (node.Name.ToLower() == ConfigFlag.BINPATH)
                    {
                        config.BinPath = node.InnerText;
                    }
                    if (node.Name.ToLower() == ConfigFlag.PARAM)
                    {
                        config.Param = node.InnerText;
                    }
                    if (node.Name.ToLower() == ConfigFlag.DESCRIPTION)
                    {
                        config.Description = node.InnerText;
                    }
                }
                MyContext.Instance().SetConfiguration(config);
                return config.IsValid();
            }
            throw new Exception("No Config File");
        }
        private static void GetAllNode(XmlNodeList xmlNodeList, List<XmlNode> nodeList)
        {
            foreach (XmlNode node in xmlNodeList)
            {
                if (node.ChildNodes.Count > 0)
                {
                    GetAllNode(node.ChildNodes, nodeList);
                }
                if (node.NodeType == XmlNodeType.Element)
                {
                    nodeList.Add(node);
                }
            }
        }
    }
}
