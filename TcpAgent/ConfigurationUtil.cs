using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TcpAgent
{
    class ConfigurationUtil
    {

        public static bool SetConfigValue(string key, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //获得配置文件的全路径  
                //string strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
               
                string strFileName = AppDomain.CurrentDomain.BaseDirectory + "\\TcpAgent.exe.config";
                Console.WriteLine(strFileName + "" + key + ""+ value);
                doc.Load(strFileName);
                //找出名称为“add”的所有元素  
                XmlNodeList nodes = doc.GetElementsByTagName("add");
                for (int i = 0; i < nodes.Count; i++)
                {
                    //获得将当前元素的key属性  
                    XmlAttribute att = nodes[i].Attributes["key"];
                    //根据元素的第一个属性来判断当前的元素是不是目标元素  
                    if (att.Value.Equals(key))
                    {
                        //对目标元素中的第二个属性赋值  
                        att = nodes[i].Attributes["value"];
                        att.Value = value;
                        break;
                    }
                }
                //保存上面的修改  
                doc.Save(strFileName);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch {

                return false;
            }

        }

        public static string GetConfigValue(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                return config.AppSettings.Settings[key].Value;
            }
            else
            {

                return string.Empty;
            }
        }



}
}
